public class Triangle {
    private double a, b, c;

    public Triangle(double a_, double b_, double c_){
        a = a_;
        b = b_;
        c = c_;
    }

    public void Change(double a_, double b_, double c_){
        a = a_;
        b = b_;
        c = c_;
    }
    public boolean isPossible() {
        return a + b > c && a + c > b && b + c > a;
    }

    public String Type(){
        if (isPossible()) {
            if (a == b && a == c && b == c) {
                return "Egyenlo oldalu";
            } else if (a == b || b == c || a == c) {
                return "Egyenlo szaru";
            } else {
                return "Altalanos";
            }
        }
        return "ok";
    }
}
