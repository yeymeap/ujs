#include <stdio.h>

int main()
{
    int multiple = 0;
    printf("N = ");
    scanf("%d", &multiple);
    for (int i = 1; i <= multiple; i++)
        if (i % 3 == 0)
        {
            printf("%d, ", i);
        }
}