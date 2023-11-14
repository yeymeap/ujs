#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int main()
{
    int myArray[20], index, min = 100;
    srand(time(NULL));
    for (int i = 0; i < 20; i++)
    {
        myArray[i] = rand() % 99 + 1;
        printf("%d, ", myArray[i]);
        if (min > myArray[i])
        {
            min = myArray[i];
            index = i;
        }
    }
    printf("\nLegkisebb elem indexe: %d\nLegkisebb elem: %d", index, min);
}