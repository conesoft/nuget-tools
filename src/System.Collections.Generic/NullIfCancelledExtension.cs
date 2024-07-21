using System.ComponentModel;

namespace System.Collections.Generic;


[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class NullIfCancelledExtension
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
