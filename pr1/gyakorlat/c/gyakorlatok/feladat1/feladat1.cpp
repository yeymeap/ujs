#include <stdio.h>

int main() {
	int width, length;
	printf("Add meg a telek szelesseget: ");
	scanf("%d", &width);
	printf("Add meg telek hosszat: ");
	scanf("%d", &length);
	int area = width * length;
	printf("\nTelek terulete: %d", area);
}