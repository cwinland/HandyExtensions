using HandyExtensions.EventArgs;
using Serilog;
using Serilog.Events;
using System;
using ErrorEventArgs = System.IO.ErrorEventArgs;

namespace HandyExtensions
{
    /// <summary>
    /// Contains extension methods for the <see cref="LoggerConfiguration" /> class.
    /// </summary>
    public static class LoggerConfigurationExtensions
    {
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
