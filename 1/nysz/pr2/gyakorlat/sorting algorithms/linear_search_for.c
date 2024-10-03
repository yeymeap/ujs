#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int array1[100], userinput, counter = 0;
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

    for (int i = 0; i < 100; i++)
    {
        if (userinput == array1[i])
        {
            printf("\nmegtalalhato az %d szam %d indexen", userinput, i);
        }
        else if (i == 99)
        {
            printf("\n%d nem szerepel a tombben", userinput);
        }
        counter++;
    }
    printf("\nlepesek szama: %d", counter);
}