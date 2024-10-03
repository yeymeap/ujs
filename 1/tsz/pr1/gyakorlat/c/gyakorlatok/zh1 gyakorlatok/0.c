#include <stdio.h>
int main()
{
    int a, b, value;
    do
    {
        printf("a = ");
        scanf("%d", &a);
        if (a % 2 == 0)
        {
            printf("paros\n");
        }
    } while (a >= 10 && a <= 70);

    printf("b = ");
    scanf("%d", &b);
    for (int i = 1; i <= b; i++)
    {
        value = 5 * i;
        printf("5 * %d = %d\n", i, value);
    }
}