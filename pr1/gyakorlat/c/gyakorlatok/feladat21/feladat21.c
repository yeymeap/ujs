#include <stdio.h>

int main()
{
    int x, i;
    printf("N = ");
    scanf("%d", &x);
    for (i = x; i >= 0; i--)
    {
        printf("%d ", i);
    }
}
