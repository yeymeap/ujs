#include <stdio.h>

int main()
{
    int n, x, y, count;
    x = 0;
    y = 0;
    count = 1;
    printf("N = ");
    scanf("%d", &n);
    for (int i = 1; i <= n; i++)
    {
        printf("%d. szam: ", count);
        scanf("%d", &y);
        count = count++;
        x = x + y;
    }
    printf("Szamok osszege: %d", x);
}