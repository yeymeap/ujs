#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int main()
{
    srand(time(NULL));
    int array1[60], count50 = 0, sumodd = 0, sum = 0;
    double average = 0;
    for (int i = 0; i < 60; i++)
    {
        array1[i] = rand() % 99 + 1;
        sum += array1[i];
        printf("%d ", array1[i]);
        if (array1[i] <= 50)
        {
            count50 += 1;
        }
        if (array1[i] % 2 == 1)
        {
            sumodd += array1[i];
        }
    }
    average = (double)sum / 60;
    printf("\nless than 50: %d\naverage: %.2lf\nodd sum: %d", count50, average, sumodd);
    printf("\nsum: %d", sum);
}