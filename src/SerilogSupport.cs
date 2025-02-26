using System.Runtime.CompilerServices;
using System.Security.AccessControl;

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
        var log = $"D:\\log {Random.Shared.Next()}.txt";
        File.AppendAllLines(log, ["ErrorLogger()"]);
        File.AppendAllLines(log, AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Select(t => t.FullName ?? "<no name>") ?? []);
        if (AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).FirstOrDefault(t => t.FullName == "Serilog.Log") is Type type)
        {
            File.AppendAllLines(log, [$"Type: {type.FullName}"]);
            var method = type.GetMethod("Error", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public, [typeof(string), typeof(object[])]);
            File.AppendAllLines(log, [$"Method: {method?.Name ?? "not found"}"]);
            logError = method?.CreateDelegate<LogErrorDelegate>() ?? DontLogError;
            File.AppendAllLines(log, [$"Delegate: {logError == DontLogError}"]);
        }
    }
}
