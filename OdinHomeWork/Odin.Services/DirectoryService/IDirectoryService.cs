using Odin.DataContract;
using System.Collections.Generic;

namespace Odin.Services.DirectoryService
{
    /// <summary>
    /// Сервис для работы с директориями
    /// </summary>
    public interface IDirectoryService
    {
        /// <summary>
        /// Получает список директорий по текущему пути
        /// </summary>
        /// <param name="path">Путь к файлу, если путь не указан берется значение по-умолчанию</param>
        /// <returns></returns>
        List<DirectoryDto> GetList(string path);
    }
}
