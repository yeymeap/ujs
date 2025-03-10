public class Easter {
    private int year;

    public Easter(int year_){
        year = year_;
    }

    public int getEaster(){
        int d = (19 * (year % 19) + 24) % 30;
        int e = (2 * (year % 4) + 4 * (year % 7) + 6 * d + 5) % 7;

        if (e == 6 && d == 28 && year % 19 > 10){
            return 49;
        }
        else if(e == 6 && d == 29){
            return 50;
        }
        else{
            return 22 + d + e;
        }
    }
}
