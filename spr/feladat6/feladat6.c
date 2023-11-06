#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main(void)
{
    int n = 10, szamok[10], i, j, k, l, sum = 0;
    srand(time(NULL));
    for (i = 0; i < n; i++)
    {
        szamok[i] = rand() % 100 + 1;
    }

    while (i < 5)
    {
        printf("%d\n", szamok[i]);
        i++;
    }
    for (j = 0; j < n; j++)
    {
        sum += szamok[j];
    }

    printf("A szamok osszege: %d\n", sum);
    printf("A szamok atlaga: %.2lf\n", (float)sum / n);
}