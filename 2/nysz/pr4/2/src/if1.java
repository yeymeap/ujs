public class if1{
    private int num;

    public if1(int num_){
        num = num_;
    }
    public int getNum(){
        return num;
    }
    public void setNum(int num_){
        num = num_;
    }
    public String getif1(){
        if(num < 0){
            return(" negativ");
        }
        else if (num > 0){
            return(" pozitiv");
        }
        else {
            return(" nulla");
        }
    }
}