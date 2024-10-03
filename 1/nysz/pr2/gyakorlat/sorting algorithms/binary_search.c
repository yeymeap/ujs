#include <stdio.h>
#include <stdlib.h>
#include <time.h>
int counter = 0;

void bubble(int size, int a[])
{
    int temp;
    for (int i = size - 1; i > 0; i--)
    {
        for (int j = 0; j < i; j++)
        {
            if (a[j] > a[j + 1])
            {
                temp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = temp;
            }
        }
    }
}

void bin(int m, int size, int a[])
{
    int min = 0;
    int max = size - 1;
    int mid = max / 2;

    while (min <= max && a[mid] != m)
    {
        if (a[mid] < m)
        {
            min = mid + 1;
            counter++;
        }
        else
        {
            max = mid - 1;
            counter++;
        }
        mid = (min + max) / 2;
    }

    if (min <= max)
    {
        printf("\nmegtalalhato az %d szam %d indexen", m, mid);
    }
    else
    {
        printf("\n%d nem szerepel a tombben", m);
    }
    printf("\nlepesek szama: %d", counter);
}

int main()
{
    int array1[100], userinput;
    srand(time(NULL));

    for (int i = 0; i < 100; i++)
    {
        array1[i] = rand() % 1000 + 1;
    }

    for (int i = 0; i < 100; i++)
    {
        printf("%d ", array1[i]);
    }
    printf("\n\n");
    bubble(100, array1);

    for (int i = 0; i < 100; i++)
    {
        printf("%d ", array1[i]);
    }

    printf("\nbemeneti ertek:");
    scanf("%d", &userinput);
    bin(userinput, 100, array1);
    printf("\nlepesek szama: %d", counter);
}