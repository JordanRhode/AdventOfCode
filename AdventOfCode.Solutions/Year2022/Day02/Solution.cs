namespace AdventOfCode.Solutions.Year2022.Day02;

class Solution : SolutionBase
{
    public Solution() : base(02, 2022, "Rock Paper Scissors", false) { }

    protected override string SolvePartOne()
    {
        var inputs = Input.SplitByNewline().Select(i => i.Split(" ").Select(MapInputToShape).ToArray());
        return inputs.Select(i => getResultScore(i[0], i[1]) + MapShapeToScore(i[1])).Sum().ToString();

        static int getResultScore(Shape opponent, Shape me)
        {
            if (opponent == me)
                return MapResultToScore(Result.Tie);

            var result = me switch
            {
                Shape.Rock => opponent == Shape.Scissors ? Result.Win : Result.Loss,
                Shape.Paper => opponent == Shape.Rock ? Result.Win : Result.Loss,
                Shape.Scissors => opponent == Shape.Paper ? Result.Win : Result.Loss,
                _ => throw new NotImplementedException()
            };
            return MapResultToScore(result);
        }
    }

    protected override string SolvePartTwo()
    {
        var inputs = Input.SplitByNewline().Select(i => i.Split(" ").ToArray());
        return inputs.Select(i =>
        {
            var expectedResult = mapInputToResult(i[1]);
            var expectedShape = getExpectedShape(MapInputToShape(i[0]), expectedResult);
            return MapResultToScore(expectedResult) + MapShapeToScore(expectedShape);
        }).Sum().ToString();

        Result mapInputToResult(string input) => input switch
        {
            "X" => Result.Loss,
            "Y" => Result.Tie,
            "Z" => Result.Win,
            _ => throw new NotImplementedException()
        };
        Shape getExpectedShape(Shape opponent, Result expectedResult)
        {
            if (expectedResult == Result.Tie)
                return opponent;
            
            var oppoLoss = expectedResult == Result.Win;
            return opponent switch
            {
                Shape.Rock => oppoLoss ? Shape.Paper : Shape.Scissors,
                Shape.Paper => oppoLoss ? Shape.Scissors : Shape.Rock,
                Shape.Scissors => oppoLoss ? Shape.Rock : Shape.Paper,
                _ => throw new NotImplementedException()
            };
        }
    }

    private Shape MapInputToShape(string input) => input switch
    {
        "A" => Shape.Rock,
        "X" => Shape.Rock,
        "B" => Shape.Paper,
        "Y" => Shape.Paper,
        "C" => Shape.Scissors,
        "Z" => Shape.Scissors,
        _ => throw new NotImplementedException()
    };

    private static int MapShapeToScore(Shape shape) => shape switch
    {
        Shape.Rock => 1,
        Shape.Paper => 2,
        Shape.Scissors => 3,
        _ => throw new NotImplementedException()
    };

    private static int MapResultToScore(Result result) => result switch
    {
        Result.Win => 6,
        Result.Tie => 3,
        Result.Loss => 0,
        _ => throw new NotImplementedException()
    };

    private enum Result {
        Win,
        Loss,
        Tie
    }

    private enum Shape {
        Rock,
        Paper,
        Scissors
    }
}
