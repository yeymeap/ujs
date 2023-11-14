#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void printArray(int a[], int size)
{
    for (int i = 0; i < size; i++)
    {
        printf("%d ", a[i]);
    }
}
void randomArray(int tomb[], int hossz, int min, int max)
{
    for (int i = 0; i < 20; i++)
    {
        tomb[i] = rand() % (max + 1 - min) + min;
    }
}

int main()
{
    srand(time(NULL));
    int array[20], size1 = 20, min = 65, max = 90;

    printArray(array, size1);

    printArray(array, size1);
}