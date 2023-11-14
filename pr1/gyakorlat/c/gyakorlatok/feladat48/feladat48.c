#include <stdio.h>

int main()
{
    int myArray[100], input, length;
    for (int i = 0; i < 100; i++)
    {
        printf("%d. szam (0 = bevitel vege): ", i + 1);
        scanf("%d", &input);
        if (input == 0)
        {
            length = i;
            break;
        }
        myArray[i] = input;
    }
    for (int i = 0; i < length; i++)
    {
        printf("%d ", myArray[i]);
    }
    printf("\n");
    for (int i = length - 1; i >= 0; i--)
    {
        printf("%d ", myArray[i]);
    }
}