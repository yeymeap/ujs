// 134174
#include <stdio.h>
#include <time.h>
#include <stdlib.h>
typedef struct Konyvek
{
	int id;
	int db;
	double price;
	char writer[50];
} Konyv;

void printBooks(int maximum, Konyv tomb[20])
{
	for (int i = 0; i < maximum; i++)
	{
		if (tomb[i].db <= 0)
		{
			printf("id: %d nincs raktaron: %.2lf eur\n", tomb[i].id, tomb[i].price);
		}
		else if (tomb[i].db > 0)
		{
			printf("id: %d elerheto ar: %.2lf eur\n", tomb[i].id, tomb[i].price);
		}
	}
}

int main()
{
	srand(time(NULL));
	Konyv array1[20];
	int choice, newid, newprice, newdb, max = 3;
	;
	for (int i = 0; i < 3; i++)
	{
		array1[i].id = rand() % (20 - 5 + 1) + 5;
		array1[i].db = rand() % (50 - (-10) + 1) + (-10);
		array1[i].price = ((float)rand() / RAND_MAX) * (20.00 - 10.00) + 10.00;
	}
	int i = 1;
	while (i > 0)
	{
		if (max > 21)
		{
			printf("tomb megtelt");
			exit(0);
		}
		printf("Konyvesbolt\n1. Konyvek listazasa\n2. Uj konyv hozzadasa\n3. Kilepes\n");
		scanf("%d", &choice);
		switch (choice)
		{
		case 1:
			printBooks(max, array1);
			break;
		case 2:
			printf("Uj konyv id:");
			scanf("%d", &array1[max].id);
			printf("Uj konyv darabszam:");
			scanf("%d", &array1[max].db);
			printf("Uj konyv ar:");
			scanf("%lf", &array1[max].price);
			max += 1;
			break;
		case 3:
			exit(0);
		default:
			printf("hiba");
			exit(0);
		}
	}
	printBooks(max, array1);
}