using System.ComponentModel;

namespace System.Collections.Generic;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class ToDictionaryValuesExtension
{
    public static Dictionary<TKey, TValue> ToDictionaryValues<TKey, TValue>(this IEnumerable<TKey> keys, Func<TKey, TValue> valueGenerator) where TKey : notnull => keys.ToDictionary(key => key, valueGenerator);
}
