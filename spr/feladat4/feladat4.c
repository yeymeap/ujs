#include <stdio.h>
#include <time.h>
#include <stdlib.h>

main()
{
    int randnum, count, guess, tries, max;

    printf("Guess the number between 0 and n!\n");
    printf("What is the maximum value?\n: ");
    scanf("%d", &max);
    printf("How many tries do you want?\n: ");
    scanf("%d", &tries);
    srand(time(NULL));
    randnum = rand() % max + 1;

    printf("Guess the number: ");
    while (tries != 0)
    {
        scanf("%d", &guess);
        if (tries == 1)
        {
            printf("You ran out of guesses!");
        }
        else if (guess > max + 1)
        {
            printf("The guessed number is out of the interval!\nTry again: ");
        }
        else if (guess > randnum)
        {
            tries = tries--;
            printf("The number is smaller than your guess!");
            if (tries > 0)
            {
                printf("You have %d tries left!\nNew guess: ", tries);
            }
        }
        else if (guess < randnum)
        {
            tries = tries--;
            printf("The number is bigger than your guess!");
            if (tries > 0)
            {
                printf("You have %d tries left!\nNew guess: ", tries);
            }
        }
        else if (guess == randnum)
        {
            printf("You guessed the number!");
        }
    }
}
// not working, fix it!