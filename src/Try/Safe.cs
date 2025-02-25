using System;

namespace Conesoft.Tools;

public static class Safe
{
    public static T? Try<T>(Func<T?> action)
    {
        try
        {
            return action();
        }
        catch (Exception exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
            return default;
        }
    }

    public static void Try(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
        }
    }

    public static async Task TryAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
        }
    }

    public static async Task<T?> TryAsync<T>(Func<Task<T>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
            return await Task.FromResult(default(T));
        }
    }

    public static T? Try<T, E>(Func<T?> method) where E : Exception
    {
        try
        {
            return method();
        }
        catch (E exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
            return default;
        }
    }

    public static T? Try<T, E1, E2>(Func<T?> method) where E1 : Exception where E2 : Exception
    {
        try
        {
            return method();
        }
        catch (E1 exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
            return default;
        }
        catch (E2 exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
            return default;
        }
    }

    public static void Try<E>(Action action) where E : Exception
    {
        try
        {
            action();
        }
        catch (E exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
        }
    }

    public static void Try<E1, E2>(Action action) where E1 : Exception where E2 : Exception
    {
        try
        {
            action();
        }
        catch (E1 exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
        }
        catch (E2 exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
        }
    }

    public static async Task TryAsync<E>(Func<Task> action) where E : Exception
    {
        try
        {
            await action();
        }
        catch (E exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
        }
    }

    public static async Task<T?> TryAsync<T, E>(Func<Task<T>> action) where E : Exception
    {
        try
        {
            return await action();
        }
        catch (E exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
            return await Task.FromResult(default(T));
        }
    }

    public static async Task<T?> TryAsync<T, E1, E2>(Func<Task<T>> action) where E1 : Exception where E2 : Exception
    {
        try
        {
            return await action();
        }
        catch (E1 exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
            return await Task.FromResult(default(T));
        }
        catch (E2 exception)
        {
            ErrorLogger.LogError("Safe.Try Exception: {exception}", exception);
            return await Task.FromResult(default(T));
        }
    }
}