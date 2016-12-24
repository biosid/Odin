using NLog;
using System;

namespace Odin.Services.LoggingService
{
    public class LogginingService : ILogginingService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Log(string message, params object[] args)
        {
            Logger.Info(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            Logger.Error(message, args);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            Logger.Error(exception, message, args);
        }

        public void Log(string message)
        {
            Logger.Info(message);
        }

        public void LogError(string message)
        {
            Logger.Error(message);
        }

        public void LogError(Exception exception, string message)
        {
            Logger.Error(exception, message);
        }
    }
}
