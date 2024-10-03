#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    srand(time(NULL));
    int x[20], y;

    for (int i = 0; i < 20; i++)
    {
        x[i] = rand() % 100;
    }
    for (int i = 0; i < 20; i++)
    {
        printf("%d ", x[i]);
    }
    printf("\n");

    // sort
    for (int i = 0; i < 20; i++)
    {
        for (int j = 0; j < 20; j++)
        {
            if (x[j] > x[i])
            {
                y = x[i];
                x[i] = x[j];
                x[j] = y;
            }
        }
    }
    for (int i = 0; i < 20; i++)
    {
        printf("%d ", x[i]);
    }
    return 0;
}