using System;

namespace Odin.Services.LoggingService
{
    public interface ILogginingService
    {
        /// <summary>
        /// log action
        /// </summary>
        /// <param name="message"></param>
        void Log(string message);

        /// <summary>
        /// Log actions with parameters
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Log(string message, params object[] args);

        /// <summary>
        /// log errors
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);

        /// <summary>
        /// log errors
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogError(string message, params object[] args);

        /// <summary>
        /// log errors with parameters
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        void LogError(Exception exception, string message);

        /// <summary>
        /// log errors with parameters
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogError(Exception exception, string message, params object[] args);
    }
}
