#include <stdio.h>
#include <math.h>
#define PI 3.141592654

int main(void)
{   
    int type;
    double a, b, c, r, k, t, s;
    printf("Perimeter and area calculator\n1 - triangle\n2 - square\n3 - rectangle\n4 - circle\nNumber: ");
    scanf("%d", &type);

    switch (type)
    {
    case 1:
        printf("a = ");
        scanf("%lf", &a);
        printf("b = ");
        scanf("%lf", &b);
        printf("c = ");
        scanf("%lf", &c);
        k = a+b+c;
        s = k/2;
        t = sqrt(s*(s-a)*(s-b)*(s-c));
        printf("Perimeter: %.2lf", k);
        printf("Area: %.2lf", t);
        break;
    case 2:
        printf("a = ");
        scanf("%lf", &a);
        k = 4*a;
        t = pow(a, 2);
        printf("Perimeter: %.2lf\n", k);
        printf("Area: %.2lf", t);
        break;
    case 3:
        printf("a = ");
        scanf("%lf", &a);
        printf("b = ");
        scanf("%lf", &b);
        k = 2*(a+b);
        t = a*b;
        printf("Perimeter: %.2lf\n", k);
        printf("Area: %.2lf", t);
        break;
    case 4:
        printf("r = ");
        scanf("%lf", &r);
        k = 2*PI*r;
        t = PI*pow(r,2);
        printf("Perimeter: %.2lf\n", k);
        printf("Area: %.2lf", t);
        break;
    default:
    printf("Incorrect type given");
    }
    return 0;
}