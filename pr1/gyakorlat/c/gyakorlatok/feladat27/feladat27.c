#include <stdio.h>

int main()
{
    int m, n;
    printf("Paralelogramma alapjanak hossza = ");
    scanf("%d", &m);
    printf("Paralelogramma magassaga = ");
    scanf("%d", &n);
    for (int i = n; i > 0; i--)
    {
        for (int j = 1; j < i; j++)
        {
            printf(" ");
        }
        for (int k = 0; k < m; k++)
        {
            printf("*");
        }
        printf("\n");
    }
}
