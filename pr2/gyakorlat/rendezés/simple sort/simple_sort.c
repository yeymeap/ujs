#include <stdio.h>
#include <time.h>

int main()
{
    srand(time(NULL));
    int array1[20], compare = 0, swap = 0;
    // fill array with random numbers
    for (int i = 0; i < 20; i++)
    {
        array1[i] = rand() % 50 + 1;
    }
    for (int i = 0; i < 20; i++)
    {
        printf("%d, ", array1[i]);
    }

    // sorting
    for (int i = 0; i < 20; i++)
    {
        for (int j = i + 1; j < 20; j++)
        {
            compare++;
            if (array1[i] > array1[j])
            {

                int temp;
                temp = array1[i];
                array1[i] = array1[j];
                array1[j] = temp;
                swap++;
            }
        }
    }

    printf("\n");
    for (int i = 0; i < 20; i++)
    {
        printf("%d, ", array1[i]);
    }
    printf("\ncomparisons: %d\nswaps: %d", compare, swap);
}