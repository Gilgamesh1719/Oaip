using Moq;
using Hwdtech;
using Hwdtech.Ioc;
namespace SpaceBattle.Lib.Test;

public class StartMoveCMDTests
{
    public StartMoveCMDTests()
    {
        //mocks here
        var a = new Mock<Icomand>();
        var b = new Mock<Istrategy>();
        b.Setup(_b => _b.run(It.IsAny<object[]>())).Returns(a.Object);

        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Uniobject.set", (object[] props) => b.Object.run(props)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Getmove", (object[] props) => b.Object.run(props)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Push", (object[] props) => b.Object.run(props)).Execute();
    }
    [Fact]
    void PosTest()
    {
        var v = new Mock<Istartable>();
        var g = new Mock<Iuobject>();
        v.Setup(_v => _v.obj2).Returns(g.Object);
        v.Setup(_v =>_v.slov).Returns(new Dictionary<string, object>(){{"speed", new Vector(1, 2)}});
        var cmd = new StartMovecom(v.Object);
        cmd.execute();
    }
    [Fact]
    void NegPosTest()
    {
        var v = new Mock<Istartable>();
        var g = new Mock<Iuobject>();
        v.Setup(_v => _v.obj2).Throws<NullReferenceException>();
        v.Setup(_v =>_v.slov).Returns(new Dictionary<string, object>(){{"speed", new Vector(1, 2)}});
        var cmd = new StartMovecom(v.Object);
        Assert.Throws<NullReferenceException>(()=>cmd.execute());
    }
    [Fact]
    void NegPosTest2()
    {
        var v = new Mock<Istartable>();
        var g = new Mock<Iuobject>();
        v.Setup(_v => _v.obj2).Returns(g.Object);
        v.Setup(_v =>_v.slov).Throws<NullReferenceException>();
        var cmd = new StartMovecom(v.Object);
        Assert.Throws<NullReferenceException>(()=>cmd.execute());
    }
    
}