#include <stdio.h>

int main() {
	int e20, e10, e5, e2, e1, osszeg;
	printf("Add meg a 20 eurosok szamat: ");
	scanf("%d", &e20);
	printf("Add meg a 10 eurosok szamat: ");
	scanf("%d", &e10);
    printf("Add meg az 5 eurosok szamat: ");
	scanf("%d", &e5);
    printf("Add meg a 2 eurosok szamat: ");
	scanf("%d", &e2);
    printf("Add meg az 1 eurosok szamat: ");
	scanf("%d", &e1);
    osszeg = (20*e20)+(10*e10)+(5*e5)+(2*e2)+e1;
	printf("\nEz osszesen: %d euro", osszeg);
}