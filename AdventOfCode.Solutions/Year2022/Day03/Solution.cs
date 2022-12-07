namespace AdventOfCode.Solutions.Year2022.Day03;

class Solution : SolutionBase
{
    public Solution() : base(03, 2022, "Rucksack Reorganization", false) { }

    protected override string SolvePartOne()
    {
        var input = Input.SplitByNewline().Select(i => i.ToCharArray());
        var priorities = input.Select(i => {
            var left = i.Take(i.Length / 2);
            var right = i.Skip(i.Length / 2);
            var itemType = left.Intersect(right).First();
            return Letters.IndexOf(itemType);
        });
        return priorities.Sum().ToString();
    }

    protected override string SolvePartTwo()
    {
        var input = Input.SplitByNewline().Select(i => i.ToCharArray());
        var sum = 0;
        for (var i = 0; i < input.Count(); i += 3)
        {
            var group = input.Skip(i).Take(3).ToArray();
            var itemType = group[0].Intersect(group[1]).Intersect(group[2]).First();
            sum += Letters.IndexOf(itemType);
        }
        return sum.ToString();
    }

    private readonly List<char> Letters = new()
    {
        '_',
        'a',
        'b',
        'c',
        'd',
        'e',
        'f',
        'g',
        'h',
        'i',
        'j',
        'k',
        'l',
        'm',
        'n',
        'o',
        'p',
        'q',
        'r',
        's',
        't',
        'u',
        'v',
        'w',
        'x',
        'y',
        'z',
        'A',
        'B',
        'C',
        'D',
        'E',
        'F',
        'G',
        'H',
        'I',
        'J',
        'K',
        'L',
        'M',
        'N',
        'O',
        'P',
        'Q',
        'R',
        'S',
        'T',
        'U',
        'V',
        'W',
        'X',
        'Y',
        'Z',
    };
}
