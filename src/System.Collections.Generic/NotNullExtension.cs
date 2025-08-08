using System.ComponentModel;

namespace System.Collections.Generic;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class NotNullExtension
{
    public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> items) where T : struct => items.OfType<T>();
    public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> items) where T : class => items.OfType<T>();
}