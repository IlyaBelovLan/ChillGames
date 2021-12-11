namespace ChillGames.Data.DbInitializer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using AutoMapper;
    using Models.Common.Extensions;
    using Models.Entities.Games;
    using Models.Entities.Images;
    using Models.Entities.Tags;
    using Models.Entities.Users;
    using Models.Games;
    using StoreContext;

    /// <summary>
    /// Инициализатор базы данных. 
    /// </summary>
    public class StoreDbInitializer : IInitializer
    {
        /// <summary>
        /// <see cref="StoreDbContext"/>.
        /// </summary>
        private readonly StoreDbContext _dbContext;

        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Путь к папке с файлами для инициализации.
        /// </summary>
        private readonly string _dirPath;

        /// <summary>
        /// Инициализирует экземпляр <see cref="StoreDbInitializer"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="dirPath">Путь к папке с файлами.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public StoreDbInitializer(StoreDbContext dbContext, string dirPath, IMapper mapper)
        {
            _dbContext = dbContext;
            _dirPath = dirPath;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает название директории с игровыми изображениями.
        /// </summary>
        public static string DirectoryWithImagesName => "Images";

        /// <summary>
        /// Получает название файла с игровым описанием.
        /// </summary>
        public static string FileWithGameDescriptionName => "GameDescription.txt";

        /// <summary>
        /// Получает расширение файла изображения.
        /// </summary>
        public static string ImageFileExtensionName => ".jpg";

        /// <summary>
        /// Получает название файла изображения-обложки.
        /// </summary>
        public static string PreviewImageName => "preview.jpg";

        /// <inheritdoc />
        public void Initialize()
        {
            if (_dbContext.Games.Any())
                return;
            
            var rootDirInfo = GetDirectoryInfo(_dirPath);

            var subDirs = rootDirInfo.GetDirectories();

            foreach (var subDir in subDirs)
            {
                InitializeFromDirectory(subDir);
            }

            var userIlya = new EntityUser
            {
                Email = "IlyaBelov2000@gmail.com",
                Name = "Ilya",
                RegistrationDate = DateTime.Now
            };
            
            var userNikita = new EntityUser
            {
                Email = "NikitaNesterov1220@gmail.com",
                Name = "Nikita",
                RegistrationDate = DateTime.Now
            };

            _dbContext.GetDbSet<EntityUser>().Add(userIlya);
            _dbContext.GetDbSet<EntityUser>().Add(userNikita);

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Добавляет информацию об игре и ее изображения в контекст.
        /// </summary>
        /// <param name="oneGameDirInfo">Директория с информацией об одной игре.</param>
        private void InitializeFromDirectory(DirectoryInfo oneGameDirInfo)
        {
            var file = GetGameDescriptionFileInfo(oneGameDirInfo);
            var entityGameId = ReadAndAddEntityGameFromFileInfo(file);
            
            var imagesDir = GetImagesDirectoryInfo(oneGameDirInfo);
            var imageFiles = GetImageFileInfos(imagesDir);

            ReadAndAddEntityGameImagesFromFileInfos(imageFiles, entityGameId);
        }

        /// <summary>
        /// Добавляет изображения в контекст.
        /// </summary>
        /// <param name="imagesFileInfos">Информация о файлах изображений.</param>
        /// <param name="entityGameId">Идентификатор игры, для которой добавляются изображения.</param>
        private void ReadAndAddEntityGameImagesFromFileInfos(FileInfo[] imagesFileInfos, long entityGameId)
        {
            foreach (var imageFile in imagesFileInfos)
            {
                var imageBytes = File.ReadAllBytes(imageFile.FullName);
                var imageCode = Convert.ToBase64String(imageBytes);

                var isPreview = imageFile.Name == PreviewImageName;
                var order = isPreview ? -1 : Convert.ToInt32(imageFile.Name.Substring(0, imageFile.Name.IndexOf(".")));
                
                var entityGameImage = new EntityGameImage
                {
                    EntityGameId = entityGameId,
                    ImageCode = imageCode,
                    IsPreview = isPreview,
                    Order = order
                };

                _dbContext.GetDbSet<EntityGameImage>().Add(entityGameImage);
            }
            
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Считывает из файла и добавляет в контекст игру. 
        /// </summary>
        /// <param name="gameDescriptionFileIInfo">Информация о файле с описанием игры.</param>
        /// <returns>Идентификатор игры.</returns>
        private long ReadAndAddEntityGameFromFileInfo(FileInfo gameDescriptionFileIInfo)
        {
            using var fileStream = gameDescriptionFileIInfo.Open(FileMode.Open, FileAccess.Read);
            using var streamReader = new StreamReader(fileStream);
            
            var jsonGame = streamReader.ReadToEnd();
            var game = JsonSerializer.Deserialize<Game>(jsonGame, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            });

            var entityGame = _mapper.Map<EntityGame>(game);
            
            var existingTags = _dbContext.GetDbSet<EntityTag>().ToList();
            entityGame.ReplaceRepeatedTags(existingTags);

            _dbContext.GetDbSet<EntityGame>().Add(entityGame);

            _dbContext.SaveChanges();

            return entityGame.Id;
        }

        /// <summary>
        /// Возвращает список файлов-изображений из директории.
        /// </summary>
        /// <param name="dirInfo">Информация о директории.</param>
        /// <returns>Список файлов-изображений.</returns>
        private static FileInfo[] GetImageFileInfos(DirectoryInfo dirInfo)
        {
            var imageFiles = dirInfo.GetFiles().Where(w => w.Extension != ".db").ToArray();

            if (imageFiles.Any(a => a.Extension != ImageFileExtensionName))
                throw new IOException("Неверный формат файла изображения!");

            return imageFiles;
        }
        
        /// <summary>
        /// Возвращает информацию о файле с описанием игры.
        /// </summary>
        /// <param name="dirInfo">Информация о директории.</param>
        /// <returns>Информацию о файле с изображением.</returns>
        /// <exception cref="IOException"></exception>
        private static FileInfo GetGameDescriptionFileInfo(DirectoryInfo dirInfo)
        {
            var descriptionFile = dirInfo.GetFiles().FirstOrDefault(f => f.Name == FileWithGameDescriptionName);

            if (descriptionFile == null)
                throw new IOException("Не найден файл с описанием игры!");

            return descriptionFile;
        }
        
        /// <summary>
        /// Возвращает директорию с изображениями.
        /// </summary>
        /// <param name="dirInfo">Информация о директории.</param>
        /// <returns>Директорию с изображениями.</returns>
        private static DirectoryInfo GetImagesDirectoryInfo(DirectoryInfo dirInfo)
        {
            var imagesDir = dirInfo.GetDirectories().FirstOrDefault(f => f.Name == DirectoryWithImagesName);

            if (imagesDir == null)
                throw new IOException("Не найдена директория с изображениями!");

            return imagesDir;
        }
        
        /// <summary>
        /// Возвращает информацию о директории.
        /// </summary>
        /// <param name="path">Путь к директории.</param>
        /// <returns>Информация о директории.</returns>
        private static DirectoryInfo GetDirectoryInfo(string path)
        {
            var dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
                throw new IOException($"Директория по адресу {path} не существует!");

            return dirInfo;
        }
    }
}