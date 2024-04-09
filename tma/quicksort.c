#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int swap = 0, compare = 0, min = 0, max = 10;

void generate(int t[], int size)
{
    for (int i = 0; i < size; i++)
    {
        t[i] = rand() % (max - min + 1) + min;
    }
}

void output(int t[], int size)
{
    for (int i = 0; i < size; i++)
    {
        printf("%d  ", t[i]);
    }
    printf("\n");
}

void quicksort(int t[], int start, int end)
{
    int i = start;
    int j = end;
    int pivot = t[rand() % (j - i + 1) + i];
    // int pivot = t[(i+j)/2];
    while (i <= j)
    {
        while (t[i] < pivot)
        {
            i++;
            compare++;
        }
        while (t[j] > pivot)
        {
            j--;
            compare++;
        }
        if (i <= j)
        {
            int tmp = t[i];
            t[i] = t[j];
            t[j] = tmp;
            i++;
            j--;
            swap++;
        }
    }
    if (start < j)
    {
        quicksort(t, start, j);
    }
    if (i < end)
    {
        quicksort(t, i, end);
    }
}

int main()
{
    const int N = 50;
    int a[N];
    srand(time(NULL));
    printf("Gyorsrendezes");
    generate(a, N);
    printf("\nKiindulasi állapot: \n");
    output(a, N);
    quicksort(a, 0, N - 1);
    printf("\nRendezett allapot: \n");
    output(a, N);
    printf("\nCserek szama: %d \nOsszehasonlitasok szama: %d ", swap, compare);
}