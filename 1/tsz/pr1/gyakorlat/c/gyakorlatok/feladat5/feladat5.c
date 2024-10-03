#include <stdio.h>

int main() {
	int e20, e10, e5, e2, e1, osszeg, r20, r10, r5, r2;
	printf("Kifizetendo osszeg: ");
	scanf("%d", &osszeg);
    e20 = osszeg/20;
    r20 = osszeg%20;
    e10 = r20/10;
    r10 = r20%10;
    e5 = r10/5;
    r5 = r10%5;
    e2 = r5/2;
    r2 = r5%2;
    e1 = r2;

    
	printf("\n20 euros bankjegyek szama: %d\n10 euros bankjegyek szama: %d\n5 euros bankjegyek szama: %d\n2 euros ermek szama: %d\n1 euros ermek szama: %d\n", e20, e10, e5, e2, e1);
}