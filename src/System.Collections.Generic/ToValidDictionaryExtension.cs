using System.ComponentModel;

namespace System.Collections.Generic;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class ToValidDictionaryExtension
{
    public static Dictionary<TKey, TValue> ToValidDictionaryValues<TKey, TValue>(this IEnumerable<TKey> keys, Func<TKey, TValue?> valueGenerator) where TKey : notnull where TValue : struct => keys.ToValidDictionary(key => key, valueGenerator);

    public static Dictionary<TKey, TValue> ToValidDictionary<T0, TKey, TValue>(this IEnumerable<T0> enumerable, Func<T0, TKey> keySelector, Func<T0, TValue?> valueSelector) where TKey : notnull where TValue : struct
    {
        Dictionary<TKey, TValue> d = [];
        foreach (var item in enumerable)
        {
            try
            {
                var key = keySelector(item);
                var value = valueSelector(item);
                if (value != null)
                {
                    d.Add(key, value.Value);
                }
            }
            catch (Exception)
            {
            }
        }
        return d;
    }

    public static async Task<Dictionary<TKey, TValue>> ToValidDictionary<T0, TKey, TValue>(this IEnumerable<T0> enumerable, Func<T0, TKey> keySelector, Func<T0, Task<TValue?>> valueSelector) where TKey : notnull
    {
        var tasks = enumerable.Select(async item => new { Key = item, Value = await valueSelector(item) }).ToArray();
        try
        {
            await Task.WhenAll(tasks);
        }
        catch
        {
        }
        return tasks
            .Where(t => t.Status == TaskStatus.RanToCompletion)
            .Select(t => t.Result)
            .Where(item => item.Value != null)
            .ToDictionary(item => keySelector(item.Key), item => item.Value!);
    }
}
