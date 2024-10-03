#include <stdio.h>
#include <math.h>

int main() {
	double a, b, c;
	printf("a olda hossza: ");
	scanf("%lf", &a);
	printf("b oldal hossza: ");
	scanf("%lf", &b);
    printf("c oldal hossza: ");
	scanf("%lf", &c);

    if (sqrt(pow(a,2)+pow(b,2) == pow(c,2)) || sqrt(pow(a,2)+pow(c,2) == pow(b,2)) || sqrt(pow(b,2)+pow(c,2) == pow(a,2)))
    {
        printf("A haromszog derekszogu");
    }
    else
    {
        printf("A haromszog nem derekszogu");
    }

}