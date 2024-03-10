#include <stdio.h>
#include <stdlib.h>
#include <time.h>
const int N = 20;
int compare = 0, swap = 0;

void PrintArray(int size, int a1[])
{
    for (int i = 0; i < size; i++)
    {
        printf("%d ", a1[i]);
    }
}

void RandomArray(int size, int a1[])
{
    for (int i = 0; i < size; i++)
    {
        a1[i] = rand() % 100 + 1;
    }
}

void SimpleSort(int size, int a1[])
{
    for (int i = 0; i < size; i++)
    {
        for (int j = i + 1; j < N; j++)
        {
            compare++;
            ;
            if (a1[i] > a1[j])
            {
                int temp = a1[i];
                a1[i] = a1[j];
                a1[j] = temp;
                swap++;
            }
        }
    }
}

void BubbleSort(int size, int a1[])
{
    for (int i = size; i > 0; i--)
    {
        for (int j = 0; j < i - 1; j++)
        {
            compare++;
            ;
            if (a1[j] > a1[j + 1])
            {
                int temp = a1[j];
                a1[j] = a1[j + 1];
                a1[j + 1] = temp;
                swap++;
            }
        }
    }
}

void InsertionSort(int size, int a1[])
{
    for (int i = 1; i < size; i++)
    {
        int j = i - 1;
        while (j >= 0 && a1[j] > a1[j + 1])
        {
            int temp = a1[j];
            a1[j] = a1[j + 1];
            a1[j + 1] = temp;
            j--;
            swap++;
            compare++;
        }
    }
}

void ChooseSort(int type, int a1[])
{
    switch (type)
    {
    case 1:
        SimpleSort(N, a1);
        break;
    case 2:
        BubbleSort(N, a1);
        break;
    case 3:
        InsertionSort(N, a1);
        break;
    default:
        printf("\nError during sort type choice!");
        exit(0);
    }
}

int main()
{
    int array1[N], sortType = 0;
    srand(time(NULL));
    RandomArray(N, array1);
    PrintArray(N, array1);
    printf("\n\nWhat sort do you want?\n\n1. Simple Sort\n2. Bubble Sort\n3. Insertion Sort\n\n");
    scanf("%d", &sortType);
    ChooseSort(sortType, array1);
    printf("\n");
    PrintArray(N, array1);
    printf("\ncomparisons: %d\nswaps: %d", compare, swap);
}
