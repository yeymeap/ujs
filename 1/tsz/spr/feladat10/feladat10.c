#include <stdio.h>
#include <time.h>
#include <stdlib.h>
typedef struct diak
{
    char nev[30];
    double atlag;
} Diak;
int main()
{
    srand(time(NULL));
    Diak d[5];
    double average = 0, sum = 0, best = 6.00, worst = 0.00, averagest = 0.00;
    int indexbest = 0, indexworst;
    for (int i = 0; i < 5; i++)
    {
        printf("Neve: ");
        scanf("%s", &d[i].nev);
        d[i].atlag = ((double)rand() / (double)(RAND_MAX)) * (5.00 - 1.00) + 1.00;
    }
    for (int i = 0; i < 5; i++)
    {
        printf("%s, %.2lf\n", d[i].nev, d[i].atlag);
        sum += d[i].atlag;
        if (d[i].atlag < best)
        {
            best = d[i].atlag;
            indexbest = i;
        }
        if (d[i].atlag > worst)
        {
            worst = d[i].atlag;
            indexworst = i;
        }
    }

    average = sum / 5;
    printf("Osztalyatlag: %.2lf\n", average);
    printf("Legjobb diak neve: %s\nAtlaga: %.2lf\n", d[indexbest].nev, d[indexbest].atlag);
    printf("Legrosszabb diak neve: %s\nAtlaga: %.2lf", d[indexworst].nev, d[indexworst].atlag);
    return 0;
}