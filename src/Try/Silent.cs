using System.ComponentModel;

namespace Conesoft.Tools;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822", Justification = "needs to be non-static for api")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0079", Justification = "lol shup up vs")]
public class Silent
{
    public T? Try<T>(Func<T?> action)
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

    public void Try(Action action)
    {
        try
        {
            action();
        }
        catch (Exception)
        {
        }
    }

    public async Task TryAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception)
        {
        }
    }

    public async Task<T?> TryAsync<T>(Func<Task<T>> action)
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

    public T? Try<T, E>(Func<T?> method) where E : Exception
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

    public T? Try<T, E1, E2>(Func<T?> method) where E1 : Exception where E2 : Exception
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

    public void Try<E>(Action action) where E : Exception
    {
        try
        {
            action();
        }
        catch (E)
        {
        }
    }

    public void Try<E1, E2>(Action action) where E1 : Exception where E2 : Exception
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

    public async Task TryAsync<E>(Func<Task> action) where E : Exception
    {
        try
        {
            await action();
        }
        catch (E)
        {
        }
    }

    public async Task<T?> TryAsync<T, E>(Func<Task<T>> action) where E : Exception
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

    public async Task<T?> TryAsync<T, E1, E2>(Func<Task<T>> action) where E1 : Exception where E2 : Exception
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