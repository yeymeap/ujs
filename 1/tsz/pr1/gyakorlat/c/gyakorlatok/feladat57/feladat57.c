#include <stdio.h>
#include <stdlib.h>
typedef struct diak
{
    char nev[50];
    double atlag;

} Diak;
int main()
{
    int n;
    char namebest[50], nameworst[50];
    double avgbest, avgworst;

    printf("Diakok szama: ");
    scanf("%d", &n);
    Diak *d = (Diak *)malloc(n * sizeof(Diak));
    for (int i = 0; i < n; i++)
    {
        printf("Kerem a diak nevet: ");
        scanf("%s", &d[i].nev);
        printf("Kerem a diak jegyeinek atlagat: ");
        scanf("%lf", &d[i].atlag);
        printf("\n");
    }
    for (int i = 0; i < n; i++)
    {
        printf("%s, %.2lf\n", d[i].nev, d[i].atlag);
    }
    printf("\n");
    free(d);
}