﻿using System;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace Yupi.Core.Io.Logger
{
    public class YupiLogManager
    {
        private static ILog _yupiLogManager;

        public static void Init(Type declaringType)
        {
            XmlConfigurator.Configure();

            _yupiLogManager = LogManager.GetLogger(declaringType);
        }

        public static void Stop()
        {
            ILoggerRepository repository = LogManager.GetRepository();

            repository.Shutdown();
        }

        /// <summary>
        ///     Logs the exception.
        /// </summary>
        /// <param name="exceptionText">The log text.</param>
        /// <param name="writerBody"></param>
        /// <param name="writerHeader"></param>
        public static void LogException(string exceptionText, string writerBody = "Registered Game Exception.", string writerHeader = "Yupi.Error")
        {
            _yupiLogManager.Error(exceptionText);

            YupiWriterManager.WriteLine(writerBody, writerHeader, ConsoleColor.DarkRed);
        }

        /// <summary>
        ///     Logs the exception.
        /// </summary>
        /// <param name="exceptionLog"></param>
        /// <param name="writerBody"></param>
        /// <param name="writerHeader"></param>
        public static void LogException(Exception exceptionLog, string writerBody = "Registered Game Exception.", string writerHeader = "Yupi.Error")
        {
            _yupiLogManager.Error(exceptionLog);

            YupiWriterManager.WriteLine(writerBody, writerHeader, ConsoleColor.DarkRed);
        }

        /// <summary>
        ///     Logs the critical exception.
        /// </summary>
        /// <param name="exceptionText">The log text.</param>
        /// <param name="writerBody"></param>
        /// <param name="writerHeader"></param>
        public static void LogCriticalException(string exceptionText, string writerBody = "Registered Game Critical Exception.", string writerHeader = "Yupi.Error")
        {
            _yupiLogManager.Fatal(exceptionText);

            YupiWriterManager.WriteLine(writerBody, writerHeader, ConsoleColor.Red);
        }

        /// <summary>
        ///     Logs the exception.
        /// </summary>
        /// <param name="exceptionLog"></param>
        /// <param name="writerBody"></param>
        /// <param name="writerHeader"></param>
        public static void LogCriticalException(Exception exceptionLog, string writerBody = "Registered Game Critical Exception.", string writerHeader = "Yupi.Error")
        {
            _yupiLogManager.Fatal(exceptionLog);

            YupiWriterManager.WriteLine(writerBody, writerHeader, ConsoleColor.Red);
        }

        /// <summary>
        ///     Logs the message.
        /// </summary>
        /// <param name="logText">The log text.</param>
        /// <param name="writerHeader"></param>
        public static void LogMessage(string logText, string writerHeader = "Yupi.Infos")
        {
            _yupiLogManager.Info(logText);

            YupiWriterManager.WriteLine(logText, writerHeader, ConsoleColor.DarkGreen);
        }

        public static ILog GetLogManager() => _yupiLogManager;
    }
}