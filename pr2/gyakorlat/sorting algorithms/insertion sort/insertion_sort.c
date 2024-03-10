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
void InsertionSort(int size, int a[])
{
    int temp;
    for (int i = 1; i < size; i++)
    {
        int j = i - 1;
        while (j >= 0 && a[j] > a[j + 1])
        {
            temp = a[j];
            a[j] = a[j + 1];
            a[j + 1] = temp;
            j--;
            swap++;
            compare++; // ez nem jo
        }
    }
}

int main()
{
    int n = 10;
    int array1[10];
    srand(time(NULL));
    RandomArray(n, array1);
    PrintArray(n, array1);
    InsertionSort(n, array1);
    PrintArray(n, array1);
    printf("comparisons: %d\nswaps: %d", compare, swap);
}