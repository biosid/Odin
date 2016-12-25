using Odin.DataContract;
using System.Collections.Generic;

namespace Odin.Services.FileService
{
    public interface IFileService
    {
        /// <summary>
        /// Получение списка файлов
        /// </summary>
        /// <param name="path">Путь к директории, если значение не указано, берется значение пути поумочанию</param>
        /// <returns></returns>
        List<FileDto> GetList(string path);

        /// <summary>
        /// Получение содержимого файла, введено ограничение на размер файла, хранится в конфиге приложения
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        FileContentDto GetContent(string filePath);

    }
}
