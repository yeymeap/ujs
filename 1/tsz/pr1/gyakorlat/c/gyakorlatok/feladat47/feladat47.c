#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int main()
{
    int myArray[20], indexmin, indexmax, min = 100, max = 0;
    srand(time(NULL));
    for (int i = 0; i < 20; i++)
    {
        myArray[i] = rand() % 99 + 1;
        printf("%d, ", myArray[i]);
        if (min > myArray[i])
        {
            min = myArray[i];
            indexmin = i;
        }
        if (max < myArray[i])
        {
            max = myArray[i];
            indexmax = i;
        }
    }
    printf("\nLegkisebb elem indexe: %d\nLegkisebb elem: %d\nLegnagyobb elem indexe: %d\nLegnagyobb elem: %d", indexmin, min, indexmax, max);
}