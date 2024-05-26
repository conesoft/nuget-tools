namespace Conesoft.Tools;
public static class NullIfTaskIsCancelled
{
    public static async Task<T?> NullIfCancelled<T>(this Task<T> task)
    {
        try
        {
            return await task;
        }
        catch (OperationCanceledException)
        {
            return default;
        }
    }
}
