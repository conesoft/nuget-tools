﻿namespace Conesoft.Tools;
public static class NotNullHelper
{
    public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> items) => items.Where(i => i != null).Cast<T>();
}
