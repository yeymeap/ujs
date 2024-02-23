#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    srand(time(NULL));
    int n, maxhead = 0, maxtails = 0, currenthead = 0, currenttails = 0;
    double tails = 0, head = 0;
    printf("Hany dobast akarsz?\n");
    scanf("%d", &n);

    double *point1 = (double *)malloc(n * sizeof(double));
    if (point1 == NULL)
    {
        printf("Hiba a memoriafoglalasnal!");
        exit(0);
    }

    for (int i = 0; i < n; i++)
    {
        point1[i] = rand() % 2 + 1;
        if (point1[i] == 1)
        {
            printf("f");
            head++;
            currenthead++;
            currenttails = 0;
        }
        else if (point1[i] == 2)
        {
            printf("i");
            tails++;
            currenttails++;
            currenthead = 0;
        }

        if (currenttails > maxtails)
        {
            maxtails = currenttails;
        }

        if (currenthead > maxhead)
        {
            maxhead = currenthead;
        }
    }
    printf("\nirasok: %.2lf %%", tails / n * 100);
    printf("\nfejek : %.2lf %%", head / n * 100);
    printf("\nLeghosszabb iras sorozat: %d", maxtails);
    printf("\nLeghosszabb fej sorozat: %d", maxhead);

    free(point1);
    point1 = NULL;
    return 0;
}