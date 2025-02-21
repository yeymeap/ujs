public class Circle {
    private double radius;

    public Circle(double radius_){
        radius = radius_;
    }

    public double getRadius(){
        return radius;
    }

    public double Circumference(){
        double c = 2 * radius * Math.PI;
        return Math.round(c);
    }
    public double Area(){
        double a = Math.PI * Math.pow(radius, 2);
        return Math.round(a);
    }
}
