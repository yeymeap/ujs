// Botló Bence Balázs 134174
/* Generál 50 db random számot egy tömbbe, majd kiírja a tömb elemeit.
A felhasználó beír egy számot, a program kiírja az adott szám hányszor fordul elő a tömbben. */
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int myArray[50], input, count = 0;
    srand(time(NULL));
    for (int i = 0; i < 50; i++)
    {
        myArray[i] = rand() % 10;
        printf("%d ", myArray[i]);
    }
    printf("\nKeresett szam: ");
    scanf("%d", &input);
    for (int i = 0; i < 50; i++)
    {
        if (myArray[i] == input)
        {
            count += 1;
        }
    }
    printf("Keresett szam %d fordul elo", count);
}