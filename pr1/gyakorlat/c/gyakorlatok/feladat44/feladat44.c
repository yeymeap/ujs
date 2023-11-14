#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int main()
{
    int myArray[15], sum = 0, min = 30, max = 0;
    srand(time(NULL));
    for (int i = 0; i < 15; i++)
    {
        myArray[i] = rand() % 30 + 1;
        printf("%d, ", myArray[i]);
        sum = sum + myArray[i];
        if (myArray[i] < min)
        {
            min = myArray[i];
        }
        if (myArray[i] > max)
        {
            max = myArray[i];
        }
    }
    printf("\n");
    printf("Tomb elemeinek osszege: %d\n", sum);
    printf("Tomb legkisebb eleme: %d\n", min);
    printf("Tomb legnagyobb eleme: %d\n", max);
}