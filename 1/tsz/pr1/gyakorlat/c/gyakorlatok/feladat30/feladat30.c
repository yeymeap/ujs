#include <stdio.h>

int main()
{
    int n, num = 0, first = 0, second = 1;
    printf("N = ");
    scanf("%d", &n);
    printf("%d, %d, ", first, second);
    for (int i = 0; i < n; i++)
    {
        num = first + second;
        first = second;
        second = num;
        printf("%d, ", num);
    }
}