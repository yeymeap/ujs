#include <stdio.h>

int NaturalNumSum(int nat)
{
    if (nat != 0)
    {
        return nat + NaturalNumSum(nat - 1);
    }
    else
    {
        return nat;
    }
}

int main()
{
    int n, sum;
    printf("pozitiv termeszetes szam: ");
    scanf("%d", &n);
    sum = NaturalNumSum(n);
    printf("%d", sum);
}