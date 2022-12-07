namespace AdventOfCode.Solutions.Year2022.Day04;

class Solution : SolutionBase
{
    public Solution() : base(04, 2022, "Camp Cleanup", false) { }

    protected override string SolvePartOne()
    {
        var input = Input.SplitByNewline().Select(i => i.Split(',').Select(i => i.Split('-').Select(int.Parse).ToArray()).ToArray());
        return input.Count(i => {
            var leftMin = i[0][0];
            var rightMin = i[1][0];
            var leftMax = i[0][1];
            var rightMax = i[1][1];
            return (leftMin >= rightMin && leftMax <= rightMax) || (leftMin <= rightMin && leftMax >= rightMax);
        } ).ToString();
    }

    protected override string SolvePartTwo()
    {
        var input = Input.SplitByNewline().Select(i => i.Split(',').Select(i => i.Split('-').Select(int.Parse).ToArray()).ToArray());
        return input.Count(i => {
            var leftMin = i[0][0];
            var rightMin = i[1][0];
            var leftMax = i[0][1];
            var rightMax = i[1][1];
            return (leftMin >= rightMin && leftMin <= rightMax) || (leftMax >= rightMin && leftMax <= rightMax) || (rightMin >= leftMin && rightMin <= leftMax) || (rightMax >= leftMin && rightMax <= leftMax);
        }).ToString();
    }
}
