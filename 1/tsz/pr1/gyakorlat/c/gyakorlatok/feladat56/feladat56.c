#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n;
    double min, max;
    printf("N = ");
    scanf("%d", &n);
    double *point1 = (double *)malloc(n * sizeof(double));
    for (int i = 0; i < n; i++)
    {
        printf("%d. elem: ", i + 1);
        scanf("%lf", &point1[i]);
    }
    min = point1[0];
    max = point1[0];
    for (int i = 0; i < n; i++)
    {
        printf("%.2lf ", point1[i]);
        if (min > point1[i])
        {
            min = point1[i];
        }

        if (max < point1[i])
        {
            max = point1[i];
        }
    }
    printf("\nMin: %2.lf\nMax: %.2lf", min, max);
    free(point1);
    point1 = NULL;
}