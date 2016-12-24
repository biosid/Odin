using System;

namespace Odin.Services.LoggingService
{
    public interface ILogginingService
    {
        void Log(string message);

        void Log(string message, params object[] args);

        void LogError(string message);

        void LogError(string message, params object[] args);

        void LogError(Exception exception, string message);

        void LogError(Exception exception, string message, params object[] args);
    }
}
