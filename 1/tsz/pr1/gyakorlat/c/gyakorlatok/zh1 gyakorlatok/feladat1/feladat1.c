#include <stdio.h>

int main()
{
    int x, y, kerulet;
    printf("Kert szelessege: ");
    scanf("%d", &x);
    printf("Kert hossza: ");
    scanf("%d", &y);
    kerulet = 2 * (x + y);
    printf("Kerulet: %d m\n", kerulet);
    return 0;
}