public class Rectangle {
    private double a, b;

    public Rectangle(double a_, double b_){
        a = a_;
        b = b_;
    }

    public double circumference(){
        return 2 * (a + b);
    }

    public double area(){
        return a * b;
    }
}
