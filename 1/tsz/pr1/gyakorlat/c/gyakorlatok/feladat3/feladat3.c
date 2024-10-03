#include <stdio.h>

int main() {
	int n1, n2;
	printf("Elso szam: ");
	scanf("%d", &n1);
	printf("Masodik szam: ");
	scanf("%d", &n2);

	printf("\n%d:%d=%d, maradek: %d", n1, n2, n1/n2, n1%n2);
}