#include <stdio.h>

int rudak[3] = {5, 0, 0};

void atrak(int honnan, int hova)
{
    rudak[honnan - 1]--;
    rudak[hova - 1]++;
    printf("%d-rol %d-re: %d %d %d\n", honnan, hova, rudak[0], rudak[1], rudak[2]);
}

void hanoi(int n, int a, int b, int c)
{
    if (n > 0)
    {
        hanoi(n - 1, a, c, b);
        atrak(a, b);
        hanoi(n - 1, c, b, a);
    }
}

int main()
{
    hanoi(rudak[0], 1, 3, 2);
}