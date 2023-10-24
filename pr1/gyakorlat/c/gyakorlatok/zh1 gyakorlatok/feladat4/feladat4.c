#include <stdio.h>

int main()
{
    int input;
    printf("1-50 kozotti szam: ");
    scanf("%d", &input);
    while (input < 1 || input > 50)
    {
        printf("1-50 kozotti szam: ");
        scanf("%d", &input);
    }
    for (int i = 0; i != input + 1; i++)
    {
        for (int j = 0; j != input + 1; j++)
        {
            if (i * j == input)
            {
                printf("%d = %d * %d\n", input, i, j);
            }
        }
    }
    return 0;
}