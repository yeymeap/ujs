#include <stdio.h>

int main()
{
    int n;
    printf("N = ");
    scanf("%d", &n);
    for (int i = 1; i <= n; i++)
    {
        printf("%d duplaja %d\n", i, i * 2);
    }
    int m;
    do
    {
        printf("M = ");
        scanf("%d", &m);
    } while (m < -30 || m > 30);

    if (m > 0)
    {
        printf("poz");
    }

    else if (m < 0)
    {
        printf("neg");
    }

    else
    {
        printf("0");
    }

    return 0;
}