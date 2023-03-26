using Moq;
using Hwdtech;
using Hwdtech.Ioc;
namespace SpaceBattle.Lib.Test;

public class Pushtest
{
    public Pushtest()
    {
        Queue<Icomand> queue1 = new Queue<Icomand>();
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Push", (object[] props) => new PushStrategy(queue1).run(props)).Execute();

    }
    [Fact]
    public void que()
    {
        var cmd = new Mock<Icomand>();
        var act = IoC.Resolve<Icomand>("Push",cmd.Object);
        act.execute();
    }
}
