#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int array1[100], userinput, i = 0;
    srand(time(NULL));

    for (int i = 0; i < 100; i++)
    {
        array1[i] = rand() % 1000 + 1;
    }

    for (int i = 0; i < 100; i++)
    {
        printf("%d ", array1[i]);
    }

    printf("\nbemeneti ertek:");
    scanf("%d", &userinput);

    while (userinput != array1[i] && i < 100)
    {
        i++;
    }

    if (userinput == array1[i])
    {
        printf("\nmegtalalhato az %d szam %d indexen", userinput, i);
    }

    else
    {
        printf("\n%d nem szerepel a tombben", userinput);
    }
    printf("\nlepesek szama: %d", i + 1);
}