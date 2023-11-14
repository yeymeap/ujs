#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int main()
{

    int myArray[10], myArray2[10];
    srand(time(NULL));
    for (int i = 0; i < 10; i++)
    {
        myArray[i] = rand() % (99 - 10 + 1) + 10;
        printf("%d, ", myArray[i]);
    }
    printf("\n");
    for (int i = 0; i < 10; i++)
    {
        myArray2[i] = myArray[10 - 1 - i];
    }
    for (int i = 0; i < 10; i++)
    {
        printf("%d, ", myArray2[i]);
    }
}