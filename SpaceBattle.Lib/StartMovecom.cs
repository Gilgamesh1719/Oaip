namespace SpaceBattle.Lib;
using Hwdtech;
public class StartMovecom: Icomand{
    private Istartable start;
    public StartMovecom(Istartable start1){this.start = start1;}
    public void execute()
    {
        foreach(var a in start.slov.ToList()){
            IoC.Resolve<Icomand>("Uniobject.set", this.start.obj2, a.Key, a.Value).execute();
        }
        var cmd = IoC.Resolve<Icomand>("Getmove", this.start);
        IoC.Resolve<Icomand>("Uniobject.set", this.start.obj2, "LongMove", cmd).execute();
        IoC.Resolve<Icomand>("Push", cmd).execute();
    }
}
