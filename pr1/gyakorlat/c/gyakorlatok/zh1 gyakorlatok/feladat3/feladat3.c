#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int x, y, pont, hiba = 0, sum, input;
    srand(time(NULL));

    while (hiba != 1)
    {
        x = rand() % 10 + 1;
        y = rand() % 10 + 1;
        sum = x + y;
        printf("%d + %d = ", x, y);
        scanf("%d", &input);
        if (input == sum)
        {
            printf("Helyes!\n");
        }
        else
        {
            printf("Helytelen!\n");
            hiba = 1;
        }
    }
}
