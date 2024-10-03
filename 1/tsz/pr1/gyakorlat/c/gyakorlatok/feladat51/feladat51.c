#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>

int main()
{
    int myArray[20], random, input, difference, min = -1, max = -1;
    srand(time(NULL));
    for (int i = 0; i < 20; i++)
    {
        random = rand() % 100;
        myArray[i] = random;
        printf("%d ", myArray[i]);
    }

    printf("\nKeresett szam: ");
    scanf("%d", &input);
    printf("Legkozelebbi szamok: ");
    for (int i = 0; i < 20; i++)
    {
        difference = (abs(input - myArray[i]));
        printf("%d ", myArray[i]);
    }
}
