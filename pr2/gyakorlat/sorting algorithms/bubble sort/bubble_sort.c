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
void BubbleSort(int size, int a[])
{
    int temp = 0;
    for (int i = size - 1; i > 0; i--)
    {
        for (int j = 0; j < i; j++)
        {
            compare++;
            if (a[j] > a[j + 1])
            {
                temp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = temp;
                swap++;
            }
        }
    }
}

int main()
{
    int n = 20, array1[20];
    srand(time(NULL));
    RandomArray(n, array1);
    PrintArray(n, array1);
    BubbleSort(n, array1);
    PrintArray(n, array1);
    printf("comparisons: %d\nswaps: %d", compare, swap);
}