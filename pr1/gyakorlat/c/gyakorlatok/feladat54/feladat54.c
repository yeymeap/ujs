#include <stdio.h>
#include <stdlib.h>
#include <time.h>
int main()
{
    srand(time(NULL));
    int n, sum = 0, paros = 0, paratlan = 0;
    double avg = 0;
    printf("Tomb elemeinek szama: ");
    scanf("%d", &n);
    int *point1 = (int *)malloc(n * sizeof(int));
    if (point1 == NULL)
    {
        printf("Hiba a memoriafoglalasnal!");
        exit(0);
    }
    for (int i = 0; i < n; i++)
    {
        point1[i] = rand() % (100 - (-100) + 1) + (-100);
        printf("%d, ", point1[i]);
        if (point1[i] % 2 == 0)
        {
            paros += 1;
        }
        else if (point1[i] % 2 != 0)
        {
            paratlan += 1;
        }
    }
    for (int i = 0; i < n; i++)
    {
        sum = sum + point1[i];
    }
    free(point1);
    point1 = NULL;
    avg = (double)sum / n;
    printf("\nSzamok osszege: %d", sum);
    printf("\nAtlag: %.2lf", avg);
    printf("\nParos szamok: %d", paros);
    printf("\nParatlan szamok: %d", paratlan);

    return 0;
}