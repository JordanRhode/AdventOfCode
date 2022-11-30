namespace AdventOfCode.Solutions.Year2021.Day01;

class Solution : SolutionBase
{
    public Solution() : base(01, 2021, "") { }

    protected override string SolvePartOne()
    {
        var lines = Input.ToIntArray(StringUtils.NewLineDelimiter);
        var increased = 0;
        for (var i = 1; i < lines.Length; i++)
        {
            if (lines[i] > lines[i-1])
                increased++;
        }
        return increased.ToString();
    }

    protected override string SolvePartTwo()
    {
        var lines = Input.ToIntArray(StringUtils.NewLineDelimiter);
        var increased = 0;
        for (var i = 3; i < lines.Length; i++)
        {
            var window1 = lines[i - 3] + lines[i - 2] + lines[i - 1];
            var window2 = lines[i - 2] + lines[i - 1] + lines[i];
            if (window1 < window2)
                increased++;
        }
        return increased.ToString();
    }
}
