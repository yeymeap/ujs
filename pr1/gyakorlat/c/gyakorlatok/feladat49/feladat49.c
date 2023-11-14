#include <stdio.h>

int main()
{
    int myArray[10], input, length;
    for (int i = 0; i < 10; i++)
    {
        printf("%d. szam: ", i + 1);
        scanf("%d", &input);
        myArray[i] = input;
    }
    for (int i = 0; i < 10; i++)
    {
        printf("%d ", myArray[i]);
    }

    printf("\nKeresendo szam: ");
    scanf("%d", &input);

    for (int i = 0; i < 10; i++)
    {
        if (myArray[i] == input)
        {
            printf("Keresendo szam indexe: %d", i);
        }
        else if (myArray[i] != input && i == 10)
        {
            printf("Keresendo szam nem talalhato");
        }
    }
}
