public class Equation {
    private double a, b, c;
    public Equation(double a_, double b_, double c_){
        a = a_;
        b = b_;
        c = c_;
    }
    public double GetD(){
        return b * b - 4 * a * c;
    }
    public int GetPossible(){
        double d = GetD();
        return (d < 0) ? 0 : (d == 0 ? 1 : 2);
    }

    public double GetX1(){
        return (-b + Math.sqrt(GetD())) / ( 2 * a);
    }
    public double GetX2(){
        return (-b - Math.sqrt(GetD())) / ( 2 * a);
    }
}
