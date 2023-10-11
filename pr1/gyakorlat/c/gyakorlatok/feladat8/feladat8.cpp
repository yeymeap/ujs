#include <stdio.h>
#include <math.h>

int main() {
	double x1, x2, y1, y2, a, b, c;
	printf("Elso pont:\n");
    printf("x1 = ");
	scanf("%lf", &x1);
	printf("y1 = ");
	scanf("%lf", &y1);
    printf("Masodik pont:\n");
    printf("x2 = ");
	scanf("%lf", &x2);
	printf("y2 = ");
	scanf("%lf", &y2);
    a = fabs(x1-x2);
    b = fabs(y1-y2);
    c = sqrt(pow(a,2) + pow(b,2));
    
    printf("A ket pont tavolsaga: %.2lf", c );

}