public class Main {
    public static void main(String[] args){
        Rectangle t = new Rectangle(10, 20);
        System.out.println("Teglalap kerulete: " + t.circumference() + ", terulete: " + t.area());
        Triangle h = new Triangle(9, 9, 1);
        System.out.println("Szerkesztheto: " + h.isPossible());
        System.out.println(h.Type());
        //h.Change(5, 5, 5);
    }
}