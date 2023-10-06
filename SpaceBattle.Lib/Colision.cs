namespace SpaceBattle.Lib;
using Hwdtech;
public class Colision : Icomand
{
    private Iuobject obj1;
    private Iuobject obj2;
    public Colision(Iuobject obje1, Iuobject obje2){this.obj1 = obje1; this.obj2 = obje2;}
    public void execute()
    {
        var tree = IoC.Resolve<IDictionary<int, object>>("Tree");
        var vek = gettree(this.obj1, this.obj2);
        var tree1 = tree;
        foreach (var item in vek){
            tree1 = (IDictionary<int, object>)tree1[item];
        }
        if(tree1.Keys.First() == 1){
            IoC.Resolve<Icomand>("colision", this.obj1, this.obj2).execute();
        } // Метод First не вернет исключение, по причине того, что мы работаем с деревом, которое не может быть пустым. Косательно IoC'а
          // исключение может возникнуть в самой стратегии, но оно должно быть отловлено там. 
    }
    private List<int> gettree(Iuobject o1, Iuobject o2){
        var a = IoC.Resolve<List<int>>("getlist", o1);
        var b = IoC.Resolve<List<int>>("getlist", o2);
        var c = new List<int>();
        foreach (var item in a){   
        c.Add(item -b[a.IndexOf(item)]);
    }
        return c;
    }
    

}
