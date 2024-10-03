#include <stdio.h>

int main(void)
{
    int m, n;
    char x[] = "*";
    printf("Teglalap szelessege = ");
    scanf("%d", &m);
    printf("Teglalap magassaga = ");
    scanf("%d", &n);
    for (int j = 1; j <= n; j++)
    {
        printf("\n");
        for (int i = 1; i <= m; i++)
        {
            printf(x);
        }
    }
}