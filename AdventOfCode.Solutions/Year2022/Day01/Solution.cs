namespace AdventOfCode.Solutions.Year2022.Day01;

class Solution : SolutionBase
{
    public Solution() : base(01, 2022, "Calorie Counting") { }

    protected override string SolvePartOne()
    {
        // Alternative Solution: return Input.Split("\n\n").Select(i => i.SplitByNewline().Sum(int.Parse)).Max().ToString();
        int maxCalories = 0;
        int currentCalories = 0;
        var lines = Input.SplitByNewline(splitOptions: StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i]) || lines.Length -1 == i)
            {
                if (currentCalories > maxCalories)
                    maxCalories = currentCalories;
                currentCalories = 0;
                continue;
            }
            currentCalories += int.Parse(lines[i]);
        }
        return maxCalories.ToString();
    }

    protected override string SolvePartTwo()
    {
        // Alternative Solution: return Input.Split("\n\n").Select(i => i.SplitByNewline().Sum(int.Parse)).OrderByDescending(i => i).Take(3).Sum().ToString();
        int currentCalories = 0;
        var topThreeCalories = new HashSet<int>();
        var lines = Input.SplitByNewline(splitOptions: StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                calorieCheck();
                continue;
            }
            currentCalories += int.Parse(lines[i]);
        }
        calorieCheck();

        return topThreeCalories.Sum().ToString();

        void calorieCheck()
        {
            if (topThreeCalories.Count < 3)
            {
                topThreeCalories.Add(currentCalories);
            }
            else if (topThreeCalories.Min() < currentCalories)
            {
                topThreeCalories.Remove(topThreeCalories.Min());
                topThreeCalories.Add(currentCalories);
            }
            currentCalories = 0;
        }
    }
}
