#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    srand(time(NULL));
    int n;
    printf("Tomb elemeinek szama: ");
    scanf("%d", &n);
    double *point1 = (double *)malloc(n * sizeof(double));
    double *point2 = (double *)malloc(n * sizeof(double));

    if (point1 == NULL)
    {
        printf("Hiba a memoriafoglalasnal!");
        exit(0);
    }
    if (point2 == NULL)
    {
        printf("Hiba a memoriafoglalasnal!");
        exit(0);
    }

    for (int i = 0; i < n; i++)
    {
        point1[i] = ((float)rand() / RAND_MAX) * 9.99;
        printf("%.2lf ", point1[i]);
    }
    printf("\n");
    for (int i = 0; i < n; i++)
    {
        point2[i] = ((float)rand() / RAND_MAX) * 9.99;
        printf("%.2lf ", point2[i]);
    }
    printf("\nSzamok osszege:\n");
    for (int i = 0; i < n; i++)
    {
        printf("%.2lf ", point1[i] + point2[i]);
    }
    printf("\nSzamok kulonbsege:\n");
    for (int i = 0; i < n; i++)
    {
        printf("%.2lf ", point1[i] - point2[i]);
    }
    free(point1);
    free(point2);
    point1 = NULL;
    point2 = NULL;
}