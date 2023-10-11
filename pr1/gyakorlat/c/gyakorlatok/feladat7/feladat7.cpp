#include <stdio.h>
#include <math.h>

int main() {
	double a, b, c, k, t, s;
	printf("a = ");
	scanf("%lf", &a);
	printf("b = ");
	scanf("%lf", &b);
    c = sqrt(pow(a,2) + pow(b,2));
    s = (a + b + c)/2;
    t = sqrt(s*(s-a)*(s-b)*(s-c));
    k = a + b + c;
    
    printf("c oldal hossza: %.2lf\nterulet: %.2lf\nkerulet: %.2lf", c, t, k);

}