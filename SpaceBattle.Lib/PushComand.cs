namespace SpaceBattle.Lib;
public class PushComand : Icomand
{
    private Queue<Icomand> queue;
    private Icomand cmd;

    public PushComand(Queue<Icomand> queue, Icomand cmd)
    {
        this.queue = queue;
        this.cmd = cmd;
    }

    public void execute()
    {
        queue.Enqueue(cmd);
    }
}
