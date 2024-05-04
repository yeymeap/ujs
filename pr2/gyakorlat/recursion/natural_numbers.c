#include <stdio.h>

int NaturalNumSum(int nat)
{
    if (nat != 0)
    {
        printf("%d + ", nat);
        return nat + NaturalNumSum(nat - 1);
    }
    else
    {
        printf("%d = ", nat);
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