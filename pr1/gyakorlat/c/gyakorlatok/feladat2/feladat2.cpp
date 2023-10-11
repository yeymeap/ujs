#include <stdio.h>

int main() {
	int width, length, depth, volume;
	printf("Add meg a medence szelesseget: ");
	scanf("%d", &width);
	printf("Add meg medence hosszat: ");
	scanf("%d", &length);
    printf("Add meg medence melyseget: ");
	scanf("%d", &depth);
	volume = width * length * depth * 1000;
	printf("\nA medence feltoltesehez %d liter vizre van szukseg", volume);
}