#include <stdio.h>
#include <time.h>
#include <stdlib.h>
int sum(int n)
{
    if (n != 0)
    {
        return n + sum(n - 1);
    }
    else
    {
        return n;
    }
}

int fact(int n)
{
    if (n == 0)
    {
        return 1;
    }
    else
    {
        return n * fact(n - 1);
    }
}

int fib(int n)
{
    if (n > 2)
    {
        return fib(n - 1) + fib(n - 2);
    }
    else if (n <= 2)
    {
        return 1;
    }
    else
    {
        return 1;
    }
}

int nat(int n, int m)
{
    if (n <= m)
    {
        printf(" %d ", n);
        nat(n + 1, m);
    }
    return 0;
}

void star(int n)
{
    if (n > 0)
    {
        printf("*");
        star(n - 1);
        printf("+");
    }
}

int five(int n)
{
    if (n == 1)
    {
        return 5;
    }
    else
    {
        return (five(n - 1) - 1) * 2;
    }
}

int another(int n)
{
    if (n <= 2)
    {
        return 2;
    }
    else
    {
        return (another(n - 2) * 3) - another(n - 1);
    }
}

int main()
{
    int szumma, szam, faktorialis, fibonacci, natural, sorozat, sorozat2;
    printf("n: ");
    scanf("%d", &szam);
    szumma = sum(szam);
    faktorialis = fact(szam);
    fibonacci = fib(szam);

    printf("\nszumma: %d", szumma);
    printf("\nfaktorialis: %d", faktorialis);
    printf("\nfibonacci: %d ", fibonacci);

    printf("\n");

    nat(1, szam);

    printf("\n");

    star(szam);

    printf("\n");

    sorozat = five(szam);
    printf("%d", sorozat);

    printf("\n");

    sorozat2 = another(szam);
    printf("%d", sorozat2);
}