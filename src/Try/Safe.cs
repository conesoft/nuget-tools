namespace Conesoft.Tools;

static class Safe
{
    public static T? Try<T>(Func<T?> action)
    {
        try
        {
            return action();
        }
        catch (Exception)
        {
            return default;
        }
    }

    public static void Try(Action action)
    {
        try
        {
            action();
        }
        catch (Exception)
        {
        }
    }

    public static async Task TryAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception)
        {
        }
    }

    public static async Task<T?> TryAsync<T>(Func<Task<T>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception)
        {
            return await Task.FromResult(default(T));
        }
    }

    public static T? Try<T, E>(Func<T?> method) where E : Exception
    {
        try
        {
            return method();
        }
        catch (E)
        {
            return default;
        }
    }

    public static T? Try<T, E1, E2>(Func<T?> method) where E1 : Exception where E2 : Exception
    {
        try
        {
            return method();
        }
        catch (E1)
        {
            return default;
        }
        catch (E2)
        {
            return default;
        }
    }

    public static void Try<E>(Action action) where E : Exception
    {
        try
        {
            action();
        }
        catch (E)
        {
        }
    }

    public static void Try<E1, E2>(Action action) where E1 : Exception where E2 : Exception
    {
        try
        {
            action();
        }
        catch (E1)
        {
        }
        catch (E2)
        {
        }
    }

    public static async void TryAsync<E>(Func<Task> action) where E : Exception
    {
        try
        {
            await action();
        }
        catch (E)
        {
        }
    }

    public static async Task<T?> TryAsync<T, E>(Func<Task<T>> action) where E : Exception
    {
        try
        {
            return await action();
        }
        catch (E)
        {
            return await Task.FromResult(default(T));
        }
    }

    public static async Task<T?> TryAsync<T, E1, E2>(Func<Task<T>> action) where E1 : Exception where E2 : Exception
    {
        try
        {
            return await action();
        }
        catch (E1)
        {
            return await Task.FromResult(default(T));
        }
        catch (E2)
        {
            return await Task.FromResult(default(T));
        }
    }
}