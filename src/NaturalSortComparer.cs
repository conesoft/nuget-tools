using System.Text.RegularExpressions;

namespace Conesoft.Tools;

public partial class NaturalSortComparer(bool inAscendingOrder = true) : IComparer<string>
{
    public static readonly NaturalSortComparer Ascending = new(true);
    public static readonly NaturalSortComparer Descending = new(false);

    public int Compare(string? x, string? y) => CompareAscenting(x, y) * (inAscendingOrder ? 1 : -1);

    private static int CompareAscenting(string? atext, string? btext)
    {
        if (atext == btext)
        {
            return 0;
        }

        if(atext == null)
        {
            return 1;
        }
        if(btext == null)
        {
            return -1;
        }

        var segments = (
            a: SplitStringByNumbers().Split(atext.Replace(" ", "")),
            b: SplitStringByNumbers().Split(btext.Replace(" ", ""))
        );

        var index = Enumerable.Range(0, Math.Min(segments.a.Length, segments.b.Length)).FirstOrDefault(i => segments.a[i] != segments.b[i], -1);

        if(index >= 0)
        {
            var s = (
                a: segments.a[index],
                b: segments.b[index]
            );
            return int.TryParse(s.a, out var ai) && int.TryParse(s.b, out var bi) ? ai.CompareTo(bi) : s.a.CompareTo(s.b);
        }

        return -segments.a.Length.CompareTo(segments.b.Length);
    }

    [GeneratedRegex("([0-9]+)")]
    private static partial Regex SplitStringByNumbers();
}