namespace SpaceBattle.Lib.Test;

public class EmptyCommandTest
{
    [Fact]
    public void EmptyCMDTest()
    {
        EmptyCommand empty = new();
        empty.execute();
    }
}
