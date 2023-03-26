namespace SpaceBattle.Lib.Test;

public class EmptyCommandStrategy : Istrategy
{
    EmptyCommand empty;
    public EmptyCommandStrategy()
    {
        this.empty = new();
    }
    public object run(params object[] args)
    {
        return this.empty;
    }
}
