using HandyExtensions.EventArgs;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;
using ErrorEventArgs = System.IO.ErrorEventArgs;

namespace HandyExtensions
{
    /// <summary>
    /// Contains extension methods for the <see cref="LoggerConfiguration" /> class.
    /// </summary>
    internal static class LoggerConfigurationExtensions
    {
        /// <summary>
        /// Enables EventLog logging.
        /// </summary>
        /// <param name="config">The <see cref="LoggerConfiguration" /> being extended.</param>
        /// <returns>The <see cref="LoggerConfiguration" /> for chaining.</returns>
        /// <exception cref="ArgumentNullException">Path</exception>
        internal static LoggerConfiguration AddEventLogLogging(this LoggerConfiguration config) =>

            //try
            //{
            //    config.WriteTo?.EventLog(EVENT_LOG_SOURCE, manageEventSource: true, logName: EVENT_LOG_SOURCE);
            //}
            //catch (SecurityException)
            //{
            //    const string LOG_NAME = "LPELog.txt";
            //    var fileSystem = new FileSystem();
            //    if (fileSystem.Path == null)
            //    {
            //        throw new ArgumentNullException(nameof(fileSystem.Path));
            //    }
            //    var dirInfo = Environment.CurrentDirectory;
            //    var fileName = fileSystem.Path.Combine(dirInfo ?? string.Empty, LOG_NAME) ?? LOG_NAME;
            //    config.WriteTo?.File(fileName, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true);
            //}
            config;

        /// <summary>
        /// Sets up the internal Serilog logger that is used to perform logging
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The <see cref="ILogger" /> that is setup.</returns>
        /// <exception cref="ArgumentNullException">config</exception>
        /// <exception cref="ArgumentNullException">configuration</exception>
        internal static LoggerConfiguration ReadFromConfiguration(this LoggerConfiguration config,
            IConfiguration configuration)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            config
                .Enrich?.FromLogContext()

                //?.Enrich.WithUtcTimestamp()
                ?.AddEventLogLogging();

            return config;
        }

        /// <summary>
        /// Writes the error.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="message">The message.</param>
        public static void WriteError<T>(this EventHandler<T>? eventHandler, string message)
            where T : EventArgsBase, new() =>
            eventHandler.Write(new T() {MessageLevel = LogEventLevel.Error, Message = message});

        /// <summary>
        /// Writes the error.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="ex">The exception.</param>
        public static void WriteError<T>(this EventHandler<T>? eventHandler, Exception ex)
            where T : EventArgsBase, new() =>
            eventHandler.Write(new T() {MessageLevel = LogEventLevel.Error, Message = ex.Message});

        /// <summary>
        /// Writes the debug.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="message">The message.</param>
        public static void WriteDebug<T>(this EventHandler<T>? eventHandler, string message)
            where T : EventArgsBase, new() =>
            eventHandler.Write(new T() {MessageLevel = LogEventLevel.Debug, Message = message});

        /// <summary>
        /// Writes the information.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="message">The message.</param>
        public static void WriteInformation<T>(this EventHandler<T>? eventHandler, string message)
            where T : EventArgsBase, new() =>
            eventHandler.Write(new T() {MessageLevel = LogEventLevel.Information, Message = message});

        /// <summary>
        /// Writes the warning.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="message">The message.</param>
        public static void WriteWarning<T>(this EventHandler<T>? eventHandler, string message)
            where T : EventArgsBase, new() =>
            eventHandler.Write(new T() {MessageLevel = LogEventLevel.Warning, Message = message});

        /// <summary>
        /// Writes the error.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="progress">The progress.</param>
        /// <param name="ex">The ex.</param>
        public static void WriteError<T>(this IProgress<T> progress, Exception ex) where T : EventArgsBase, new() =>
            progress.Write(new T() {MessageLevel = LogEventLevel.Error, Message = ex.Message});

        /// <summary>
        /// Writes the error.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="progress">The progress.</param>
        /// <param name="message">The message.</param>
        public static void WriteError<T>(this IProgress<T> progress, string message) where T : EventArgsBase, new() =>
            progress.Write(new T() {MessageLevel = LogEventLevel.Error, Message = message});

        /// <summary>
        /// Writes the information.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="progress">The progress.</param>
        /// <param name="message">The message.</param>
        public static void WriteInformation<T>(this IProgress<T> progress, string message)
            where T : EventArgsBase, new() =>
            progress.Write(new T() {MessageLevel = LogEventLevel.Information, Message = message});

        /// <summary>
        /// Writes the warning.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="progress">The progress.</param>
        /// <param name="message">The message.</param>
        public static void WriteWarning<T>(this IProgress<T> progress, string message) where T : EventArgsBase, new() =>
            progress.Write(new T() {MessageLevel = LogEventLevel.Warning, Message = message});

        /// <summary>
        /// Writes the debug.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="progress">The progress.</param>
        /// <param name="message">The message.</param>
        public static void WriteDebug<T>(this IProgress<T> progress, string message) where T : EventArgsBase, new() =>
            progress.Write(new T() {MessageLevel = LogEventLevel.Debug, Message = message});

        /// <summary>
        /// Writes the specified e.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="e">The e.</param>
        public static void Write<T>(this EventHandler<T>? eventHandler, T e) where T : EventArgsBase =>
            eventHandler?.Invoke(null, e);

        /// <summary>
        /// Writes the specified e.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="e">The <see cref="MessageEventArgs"/> instance containing the event data.</param>
        public static void Write(this EventHandler<MessageEventArgs>? eventHandler, MessageEventArgs e) =>
            eventHandler?.Invoke(null, e);

        /// <summary>
        /// Writes the specified e.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="e">The <see cref="ErrorEventArgs"/> instance containing the event data.</param>
        public static void Write(this EventHandler<ErrorEventArgs>? eventHandler, ErrorEventArgs e) =>
            eventHandler?.Invoke(null, e);

        /// <summary>
        /// Writes the specified e.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="progress">The progress.</param>
        /// <param name="e">The e.</param>
        public static void Write<T>(this IProgress<T> progress, T e) where T : EventArgsBase =>
            progress.Report(e);

        /// <summary>
        /// Writes the specified e.
        /// </summary>
        /// <param name="progress">The progress.</param>
        /// <param name="e">The <see cref="ErrorEventArgs"/> instance containing the event data.</param>
        public static void Write(this IProgress<ErrorEventArgs> progress, ErrorEventArgs e) =>
            progress.Report(e);
    }
}
