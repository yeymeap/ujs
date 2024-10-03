#include <stdio.h>

int main()
{

    int k, sum = 0, calc;

    printf("k = ");
    scanf("%d", &k);
    for (int i = 0; i <= k; i++)
    {
        calc = i * (i + 1);
        sum = sum + calc;
    }
    printf("1*2 + 2*3 + ... + k*(k+1) = %d", sum);
}