#include <stdio.h>
#include <math.h>

int main() {
	double a, b, c, change;
	printf("a oldal hossza: ");
	scanf("%lf", &a);
	printf("b oldal hossza: ");
	scanf("%lf", &b);
    printf("c oldal hossza: ");
	scanf("%lf", &c);
    change = NULL;

    if (c<a)
    {
        change=c;
        c=a;
        a=change;
    }
    else if (c<b)
    {   
        change=c;
        c=b;
        b=change;  
    }

    if (sqrt(pow(a,2)+pow(b,2) == pow(c,2)))
    {
        printf("a haromszog derekszogu");
    }
    else{
        printf("a haromszog nem derekszogu");
    }
}