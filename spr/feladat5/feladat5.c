#include <stdio.h>

int main()
{
    int pin, guess;
    printf("Enter new PIN:");
    scanf("%d", &pin);
    printf("\nEnter PIN code: ");
    while (guess != pin)
    {
        scanf("%d", &guess);
        if (pin != guess)
        {
            printf("Incorrect PIN\nTry again: ");
        }
        else
        {
            printf("You got in!");
        }
    }
}