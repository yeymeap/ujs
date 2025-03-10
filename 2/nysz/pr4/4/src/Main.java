public class Main{
    public static void main(String[] args) {
        Year year = new Year(2000);
        System.out.println(year.GetYear() + " " + (year.LeapYear() ? "" : "not ") + "leap year");
        Easter easter = new Easter(2025);
        int h = easter.getEaster();
        if(h <= 31) {
            System.out.println("March " + h);
        }
        else{
            System.out.println("April " + (h - 31));
        }
        Time t = new Time(3823);
        System.out.println(t.getHour() + "hour(s) " + t.getMinute() + "minute(s) " + t.getSecond() + "second(s) " );
        Equation eq = new Equation(3, 4, 5);
        
        System.out.println("Discriminant = " + eq.GetD() + "Possible solutions = " + eq.GetPossible() + "X1 = " + eq.GetX1() + "X2 = " + eq.GetX2());
    }

}