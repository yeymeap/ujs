// Botló Bence Balázs 134174
/* Program, amely bekéri két különböző méretű kör középpontjainak koordinátáit
(x1, y1, x2, y2) és sugarainak hosszát (r1, r2), majd meghatározza a két kör kölcsönös
helyzetét.*/
#include <stdio.h>
#include <math.h>

int main()
{
    double x1, x2, y1, y2, r1, r2, t, rk, ro;
    printf("Elso kor kozepponjta x1: ");
    scanf("%lf", &x1);
    printf("Elso kor kozepponjta y1: ");
    scanf("%lf", &y1);
    printf("Elso kor sugara r1: ");
    scanf("%lf", &r1);
    printf("Masodik kor kozepponjta x2: ");
    scanf("%lf", &x2);
    printf("Masodik kor kozepponjta y2: ");
    scanf("%lf", &y2);
    printf("Masodik kor sugara r2: ");
    scanf("%lf", &r2);

    t = (sqrt(pow(x2 - x1, 2) + pow(y2 - y1, 2)));
    rk = fabs(r1 - r2);
    ro = r1 + r2;
    if (t > r1 + r2)
    {
        printf("Ket kornek nincs kozos pontja");
    }
    else if (t == ro)
    {
        printf("Ket kor kivulrol erinti egymast");
    }
    else if (rk < t && t < ro)
    {
        printf("Ket kor metszi egymast");
    }
    else if (t == rk && rk != 0)
    {
        printf("Ket kor belulrol erinti egymast");
    }
    else if (t > 0 && t < rk && rk != 0)
    {
        printf("Kis kor a nagy kor belsejeben van");
    }
    else
    {
        printf("hiba");
    }
}