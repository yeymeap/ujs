#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int number, guess, max_value, max_tries, tries = 0;
    srand(time(0)); // seed the random number generator with the current time
    printf("Enter the maximum value for the random number generator: ");
    scanf("%d", &max_value);
    printf("Enter the maximum number of tries: ");
    scanf("%d", &max_tries);
    number = rand() % max_value + 1; // generate a random number between 1 and max_value
    printf("Guess the number between 1 and %d\n", max_value);
    do
    {
        printf("Enter your guess: ");
        scanf("%d", &guess);
        if (guess < 1 || guess > max_value) // check if guess is outside of range
        {
            printf("Invalid guess. Please enter a number between 1 and %d.\n", max_value);
            continue; // skip counting the guess as a try
        }
        tries++;
        if (guess > number)
        {
            printf("Too high! %d tries left.\n", max_tries - tries);
        }
        else if (guess < number)
        {
            printf("Too low! %d tries left.\n", max_tries - tries);
        }
        else
        {
            printf("Congratulations, you guessed the number in %d tries!\n", tries);
        }
    } while (guess != number && tries < max_tries);
    if (tries == max_tries)
    {
        printf("Sorry, you ran out of tries. The number was %d.\n", number);
    }
    return 0;
}
