namespace SpaceBattle.Lib;
public class PushStrategy : Istrategy
{
    private Queue<Icomand> queue;

    public PushStrategy(Queue<Icomand> queue)
    {
        this.queue = queue;
    }

    public object run(params object[] args)
    {
        return new PushComand(queue,(Icomand)args[0]);
    }
}
