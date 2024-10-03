#include <stdio.h>
#include <math.h>

#define PI 3.141592654  // PI definialasa

int main() {
	double alfa, a, b, c;
	printf("A derekszogu haromszog atfogojanak hossza: ");
	scanf("%lf", &c);
	printf("Alfa szog (fokokban): ");
	scanf("%lf", &alfa);
    a = c * sin( alfa * PI/180 );
    b = c * cos( alfa * PI/180 );
    printf("Egyik befogo hossza: %.2lf\nMasik befogo hossza: %.2lf", a, b);

}