public class Time {

    private int hour;

    public int getHour(){
        return hour;
    }

    private int minute;

    public int getMinute(){
        return minute;
    }

    private int second;

    public int getSecond(){
        return second;
    }

    public Time(int all){
        hour = all/(60 * 60);
        minute = all/60 % 60;
        second = all % 60;
    }
}
