using System;

namespace Odin.Services.LoggingService
{
    public interface ILogginingService
    {
        /// <summary>
        /// Лог действия
        /// </summary>
        /// <param name="message"></param>
        void Log(string message);

        /// <summary>
        /// Лог действия с параметрами
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Log(string message, params object[] args);

        /// <summary>
        /// Лог ошибки
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);

        /// <summary>
        /// Лог ошибки
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogError(string message, params object[] args);

        /// <summary>
        /// Лог ошибки с параметрами
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        void LogError(Exception exception, string message);

        /// <summary>
        /// Лог ошибки с параметрами
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogError(Exception exception, string message, params object[] args);
    }
}
