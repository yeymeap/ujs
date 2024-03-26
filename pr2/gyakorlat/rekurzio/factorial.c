#include <stdio.h>

int FactorialOfNum(int fact)
{
    if (fact != 1)
    {
        printf("%d * ", fact);
        return fact * FactorialOfNum(fact - 1);
    }
    else
    {
        printf("%d = ", fact);
        return fact;
    }
}

int main()
{
    int n, sum;
    printf("pozitiv termeszetes szam: ");
    scanf("%d", &n);
    sum = FactorialOfNum(n);
    printf("%d", sum);
}