using System.Runtime.CompilerServices;

namespace Conesoft.Tools;

static class ErrorLogger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static internal void LogError(string message, params object[] parameters) => logError(message, parameters);

    internal delegate void LogErrorDelegate(string message, params object[] parameters);
    static readonly LogErrorDelegate logError = DontLogError;
    private static void DontLogError(string message, params object[] parameters) { }

    static ErrorLogger()
    {
        if (AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).FirstOrDefault(t => t.FullName == "Serilog.Log") is Type type)
        {
            var loggerInstance = type.GetProperty("Logger")?.GetValue(null) ?? null;
            var errorMethod = loggerInstance?.GetType().GetMethod("Error", [typeof(string), typeof(object[])]);
            logError = (errorMethod?.CreateDelegate(typeof(LogErrorDelegate), loggerInstance) as LogErrorDelegate) ?? logError;
        }
    }
}
