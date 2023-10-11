#include <stdio.h>

int main() {
	double avg;
	printf("atlag: ");
	scanf("%lf", &avg);

    if (avg < 1  || avg > 5){
        printf("Helytelen ertek");
    }
    else if (avg < 1.5){
        printf("Kituno");
    }
    else if (avg < 2.5){
        printf("Dicseretes");
    }
        else if (avg < 3.5){
        printf("Jo");
    }
        else if (avg < 4.5){
        printf("Elegseges");
    }
        else{
        printf("Elegtelen");
    }
}