namespace SpaceBattle.Lib.Test;
using Moq;
public class vectortest{
    [Fact]
    public void Test1(){
        var obj1 = new Vector(11, 5);
        Assert.NotNull(obj1);
    }
    [Fact]
    public void Test2(){
        var obj1= new Vector(11, 5);
        Assert.True(2==obj1.Size);
    }
    [Fact]
    public void Test3(){
        var obj1= new Vector(11, 5);
        Assert.True("Vector(11, 5)"==obj1.ToString());
    }
    [Fact]
    public void Test4(){
        var obj1= new Vector(11, 5);
        var obj2= new Vector(22, 10);
        Assert.Equal(obj1, obj2);
    }
    [Fact]
    public void Test5(){
        var obj1= new Vector(11, 5);
        Assert.IsType<int>(obj1.GetHashCode());
    }
    [Fact]
    public void Test6(){
        var obj1= new Vector(11, 5);
        Assert.True(obj1[0]==11);
    }
    [Fact]
    public void Test7(){
        var obj1= new Vector(11, 5);
        var obj2= new Vector(22, 10);
        Assert.True(obj1+obj2==new Vector(33,15));
    }
    [Fact]
    public void Test7_n(){
        var obj1= new Vector(11, 5);
        var obj2= new Vector(22, 10, 1); 
        Assert.Throws<ArgumentException>(()=>obj1+obj2);
    }
    [Fact]
    public void Test8(){
        var obj1= new Vector(11, 5);
        var obj2= new Vector(22, 10);
        Assert.True(obj1-obj2==new Vector(-11,-5));
    }
    [Fact]
    public void Test8_n(){
        var obj1= new Vector(11, 5);
        var obj2= new Vector(22, 10, 1); 
        Assert.Throws<ArgumentException>(()=>obj1-obj2);
    }
    [Fact]
    public void Test9(){
        var obj1= new Vector(11, 5);
        var obj2= new Vector(11, 5); 
        Assert.True(obj1==obj2);
    }
    [Fact]
    public void Test9_n(){
        var obj1= new Vector(11, 5);
        var obj2= new Vector(11, 6); 
        Assert.False(obj1==obj2);
    }
    [Fact]
    public void Test9_n2(){
        var obj1= new Vector(11, 5);
        var obj2= new Vector(11, 6, 2); 
        Assert.False(obj1==obj2);
    }
    [Fact]
    public void Test10(){
        var obj1= new Vector(11, 5);
        var obj2= new Vector(11, 6); 
        Assert.True(obj1!=obj2);
    }    
    
}
