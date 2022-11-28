namespace SpaceBattle.Lib.Test;
using Moq;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var b = new Mock<Imovable>();
        b.Setup(_b=>_b.velocity).Returns(new Vector(-7, 3));
        b.Setup(_b=>_b.Coords).Returns(new Vector(12, 5));
        var Comand = new moveCMD(b.Object);
        Comand.execute();
        b.VerifySet(_b => _b.Coords = new Vector(5, 8));
    }
    [Fact]
    public void Test2(){
        var b = new Mock<Imovable>();
        b.Setup(_b=>_b.velocity).Returns(new Vector(-7, 3));
        b.Setup(_b=>_b.Coords).Throws<Exception>();
        var Comand = new moveCMD(b.Object);
        Assert.Throws<Exception>(()=>Comand.execute());
    }
    [Fact]
    public void Test3(){
        var b = new Mock<Imovable>();
        b.Setup(_b=>_b.velocity).Throws<Exception>();
        b.Setup(_b=>_b.Coords).Returns(new Vector(12, 5));
        var Comand = new moveCMD(b.Object);
        Assert.Throws<Exception>(()=>Comand.execute());
    }
    
}