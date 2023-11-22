#include <stdio.h>
#include <stdlib.h>
#include <time.h>
int main()
{
    srand(time(NULL));
    int n;
    printf("Tomb elemeinek szama: ");
    scanf("%d", &n);
    int *point1 = (int *)malloc(n * sizeof(int));
    if (point1 == NULL)
    {
        printf("Hiba a memoriafoglalasnal!");
        exit(0);
    }
    for (int i = 0; i <= n; i++)
    {
        point1[i] = rand() % (100 - (-100) + 1) + (-100);
        printf("%d, ", point1[i]);
    }
    free(point1);
    point1 = NULL;
    return 0;
}