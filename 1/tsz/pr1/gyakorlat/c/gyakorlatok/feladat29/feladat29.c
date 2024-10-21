#include <stdio.h>

int main()
{
    int m, n;

    printf("Teglalat szelessege (m): ");
    scanf("%d", &m);
    printf("Teglalat magassaga (n): ");
    scanf("%d", &n);

    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= m; j++)
        {
            if (i == 1 || i == n || j == 1 || j == m)
            {
                printf("*"); // Csillag az éleken
            }
            else
            {
                printf(" ");
            }
        }
        printf("\n");
    }

    return 0;
}
