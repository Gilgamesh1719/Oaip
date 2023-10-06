namespace SpaceBattle.Lib;
public class moveCMD: Icomand{
    private Imovable obj1;
    public moveCMD(Imovable move){
        this.obj1 = move;
    }
    public void execute(){
        this.obj1.Coords+=this.obj1.velocity;
    }
}
