using System.Runtime.CompilerServices;

namespace Conesoft.Tools;

static class ErrorLogger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static internal void LogError(string message, params object[] parameters) => logError(message, parameters);

    internal delegate void LogErrorDelegate(string message, params object[] parameters);
    static LogErrorDelegate logError = InitializerLogError;
    private static void DontLogError(string message, params object[] parameters) { }

    private static void InitializerLogError(string message, params object[] parameters)
    {
        if (AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).FirstOrDefault(t => t.FullName == "Serilog.Log") is Type type)
        {
            var method = type.GetMethod("Error", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public, [typeof(string), typeof(object[])]);
            logError = method?.CreateDelegate<LogErrorDelegate>() ?? DontLogError;
        }
    }
}
