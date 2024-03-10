#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int compare = 0, swap = 0;

void PrintArray(int size, int a[])
{
    for (int i = 0; i < size; i++)
    {
        printf("%d, ", a[i]);
    }
    printf("\n");
}
void RandomArray(int size, int a[])
{
    for (int i = 0; i < size; i++)
    {
        a[i] = rand() % 50 + 1;
    }
}
void SimpleSort(int size, int a[])
{
    int temp = 0;
    for (int i = 0; i < size; i++)
    {
        for (int j = i + 1; j < size; j++)
        {
            compare++;
            if (a[i] > a[j])
            {

                int temp;
                temp = a[i];
                a[i] = a[j];
                a[j] = temp;
                swap++;
            }
        }
    }
}

int main()
{
    int n = 10, array1[10];
    srand(time(NULL));
    RandomArray(n, array1);
    PrintArray(n, array1);
    SimpleSort(n, array1);
    PrintArray(n, array1);
    printf("comparisons: %d\nswaps: %d", compare, swap);
}