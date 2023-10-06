namespace SpaceBattle.Lib;
public class Vector{
    private List<int> vek = new List<int>();
    public Vector(params int[] arks){
         foreach(int W in arks){
            this.vek.Add(W);
         }
    }
    public int Size => this.vek.Count;
    public override string ToString()
    {
        var msg = "Vector(";
        for (int i = 0; i < vek.Count; i++)
        {
            msg += vek[i].ToString() + ", ";
        }
        msg = msg.Substring(0, msg.Length - 2);
        msg += ")";
        return string.Format(msg);
 
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(vek);
    }

    public int this[int index]{
        get{
            return vek[index];
        }
    }
    public static Vector operator + (Vector a, Vector b){
        if (a.Size != b.Size){
            throw new ArgumentException();
        } 
        List<int> l = new List<int>();
        for (int i = 0; i < a.Size; i++){
            l.Add(a[i]+b[i]);
        }
        return new Vector(l.ToArray());
    }
    public static Vector operator - (Vector a, Vector b){
        if (a.Size != b.Size){
            throw new ArgumentException();
        } 
        List<int> l = new List<int>();
        for (int i = 0; i < a.Size; i++){
            l.Add(a[i]-b[i]);
        }
        return new Vector(l.ToArray());
    }   
    public static bool operator == (Vector a, Vector b){
        if (a.Size != b.Size){
            return false;
        } 
        for (int i = 0; i < b.Size; i++){
            if (a[i]!=b[i]){
                return false;
            }
        }
        return true;
    }
    public static bool operator != (Vector a, Vector b){
        return !(a==b);
    }
    

}
