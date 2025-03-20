using System.ComponentModel;

namespace Conesoft.Tools;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class FireAndForgetExtensions
{
    public static void FireAndForget(this Task _) { }
    public static void FireAndForget(this ValueTask _) { }
}
