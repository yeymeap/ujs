public class Year {
    private int year;

    public int GetYear(){
        return year;
    }

    public Year(int year_){
        year = year_;
    }

    public boolean LeapYear(){
        return year % 4 == 0 && !(year % 100 == 0) || year % 400 == 0;
    }
}
