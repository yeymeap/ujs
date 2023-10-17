#include <stdio.h>

int main()
{
    int m, n;
    char x[] = "*";
    printf("Paralelogramma alapjanak hossza = ");
    scanf("%d", &m);
    printf("Paralelogramma magassaga = ");
    scanf("%d", &n);

    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n - 1; j++)
        {
            printf(" ");
        }
    }
    printf("\n");
    for (int k = 1; k <= m; k++)
    {
        printf("%s", x);
    }
}
