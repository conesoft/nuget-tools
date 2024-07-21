using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class EndOnCancelExtension
{
    public static async IAsyncEnumerable<T> EndOnCancel<T>(this IAsyncEnumerable<T> endless, [EnumeratorCancellation] CancellationToken cancellation, Action? whenDone = null)
    {
        var e = endless.GetAsyncEnumerator(cancellation);
        try
        {
            while (cancellation.IsCancellationRequested == false)
            {
                var next = false;
                try
                {
                    next = await e.MoveNextAsync();
                }
                catch (OperationCanceledException) when (cancellation.IsCancellationRequested)
                {
                    yield break;
                }
                if (next)
                {
                    yield return e.Current;
                }
                else
                {
                    yield break;
                }
            }
        }
        finally
        {
            whenDone?.Invoke();
            if (e != null)
            {
                await e.DisposeAsync();
            }
        }
    }
}
