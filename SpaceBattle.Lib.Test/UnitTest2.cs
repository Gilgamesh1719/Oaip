using Moq;
using Hwdtech;
using Hwdtech.Ioc;
namespace SpaceBattle.Lib.Test;

public class UniTest2
{
    [Fact]
    public void PosTest_CheckCollision()
    {
        var cmd = new Mock<Icomand>();
        cmd.Setup(_c => _c.execute());

        var NoPropStrat = new Mock<Istrategy>();
        NoPropStrat.Setup(_n => _n.run()).Returns(cmd.Object);

        var PropStrat = new Mock<Istrategy>();
        PropStrat.Setup(_s => _s.run(It.IsAny<object[]>())).Returns(cmd.Object).Verifiable();

        var Dict = new Mock<IDictionary<int, object>>();
        Dict.Setup(_d => _d.Keys).Returns(new List<int>{1});

        var DictStrat = new Mock<Istrategy>();
        DictStrat.Setup(_d => _d.run()).Returns(Dict.Object).Verifiable();

        var ListStart = new Mock<Istrategy>();
        ListStart.Setup(_l => _l.run(It.IsAny<object[]>())).Returns(new List<int>()).Verifiable();

        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Tree", (object[] props) => DictStrat.Object.run()).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "colision", (object[] props) => PropStrat.Object.run()).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "getlist", (object[] props) => ListStart.Object.run(props)).Execute();

        var patient1 = new Mock<Iuobject>();
        var patient2 = new Mock<Iuobject>();

        var checker = new Colision(patient1.Object, patient2.Object);

        checker.execute();

        PropStrat.VerifyAll();
        DictStrat.VerifyAll();
        ListStart.VerifyAll();
    }
}