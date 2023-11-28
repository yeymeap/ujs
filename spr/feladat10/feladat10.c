#include <stdio.h>
typedef struct diak
{
    char nev[30];
    int szuletesiEv;
    double atlag;
} Diak;
int main()
{
    Diak d[3];
    for (int i = 0; i < 3; i++)
    {
        printf("Kerem a diak nevet: ");
        scanf("%s", &d[i].nev);
        printf("Kerem a diak szuletesi evet: ");
        scanf("%d", &d[i].szuletesiEv);
        printf("Kerem a diak jegyeinek atlagat: ");
        scanf("%lf", &d[i].atlag);
        printf("\n");
    }
    for (int i = 0; i < 3; i++)
    {
        printf("%s, %d, %.2lf\n", d[i].nev, d[i].szuletesiEv, d[i].atlag);
    }
    printf("\n");
    return 0;
}