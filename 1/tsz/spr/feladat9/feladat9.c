#include <stdio.h>
#include <stdlib.h>
#include <time.h>
int inputnum()
{
    int num;
    printf("N = ");
    scanf("%d", &num);
    return num;
}
int randomnum()
{
    int randomnumber;

    randomnumber = rand() % 100 + 1;
    return randomnumber;
}

int main()
{
    srand(time(NULL));
    int n = inputnum();
    int *a = (int *)malloc(n * sizeof(int));
    if (a == NULL)
    {
        printf("Memory allocation error!");
        exit(0);
    }
    for (int i = 0; i < n; i++)
    {
        a[i] = randomnum();
        printf("%d, ", a[i]);
    }
    printf("\n");
    free(a);
}