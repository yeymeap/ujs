#include <stdio.h>

int main()
{
	int size, meat, cheese, shroom, ordertype, coupon = 12345, couponchoice, couponinput, menu, fries, drink, daily, choice, number;
	double price;
	printf("Hamburger rendeles:\n1. Napi menu\n2. Sajat\n");
	scanf("%d", &choice);
	switch (choice)
	{

	case 1:
	{
		printf("Napi menu tartalma: Nagy hamburger(6,00) hussal(1,00) sajttal(0,50), nagy hasabburgonya(2,50), Fanta(1,00)\n");
		price = 3 + 1 + 0.5 + 2.5 + 1;
		break;
	}
	case 2:
	{
		printf("Mekkora hamburgert kersz?\n1. Kicsi(2,50)\n2. Kozepes(3,50)\n3. Nagy(6,00)\n");
		scanf("%d", &size);
		break;
	}
	}
	switch (size)
	{
	case 1:
	{
		price += 2.50;
		break;
	}
	case 2:
	{
		price += 3.50;
		break;
	}
	case 3:
	{
		price += 6.00;
		break;
	}
	}

	printf("Hust? (Eddig %.2lf eur)\n", price);
	printf("1. Igen(1,00)\n2. Nem(0,00)\n");
	scanf("%d", &meat);
	switch (meat)
	{
	case 1:
	{
		price += 1.00;
		break;
	}
	case 2:
	{
		price = price + 0;
		break;
	}
	}

	printf("Sajtot? (Eddig %.2lf eur)\n", price);
	printf("1. Igen(0,50)\n2. Nem(0,00)\n");
	scanf("%d", &cheese);
	switch (cheese)
	{
	case 1:
	{
		price += 0.50;
		break;
	}
	case 2:
	{
		price = price + 0;
		break;
	}
	}

	printf("Gombat? (Eddig %.2lf eur)\n", price);
	printf("1. Igen(0,60)\n2. Nem(0,00)\n");
	scanf("%d", &shroom);
	switch (shroom)
	{
	case 1:
	{
		price += 0.60;
		break;
	}
	case 2:
	{
		price = price + 0;
		break;
	}
	}
	printf("Menuben kered?(Hasabburgonya es udito hozza)\n1. Igen\n2. Nem\n");
	scanf("%d", &menu);
	if (menu == 1)
	{
		printf("Hasab merete:\n1. Kicsi(1,00)\n2. Nagy(2,50)\n");
		scanf("%d", &fries);
		if (fries == 1)
		{
			price += 1.00;
		}
		else if (fries == 2)
		{
			price += 2.50;
		}
		printf("Udito:\n1. Coca-cola(1,50)\n2. Fanta(1,00)\n");
		scanf("%d", &drink);
		if (drink == 1)
		{
			price += 1.50;
		}
		else if (drink == 2)
		{
			price += 1.00;
		}
	}

	printf("Milyen kiszallitas? (Reszosszeg %.2lf eur)\n", price);
	printf("1. Szemelyes atvetel(ingyenes)\n2. Varoson belul(25 felett ingyenes, 25,00-ig 3,00)\n3. Varoson kivul(6,00)\n");
	scanf("%d", &ordertype);
	switch (ordertype)
	{
	case 1:
	{
		price = price;
		break;
	}
	case 2:
	{
		if (price < 25)
		{
			price += 3;
		}
		break;
	}
	case 3:
	{
		price += 6;
		break;
	}
	}
	printf("Fizetendo osszeg: %.2lf euro\n", price);
	printf("Kivan kupont aktivalni?\n1. Igen\n2. Nem\n");
	scanf("%d", &couponchoice);
	switch (couponchoice)
	{
	case 1:
	{
		printf("Adja meg a kuponkodot:\n");
		scanf("%d", &couponinput);
		if (couponinput == coupon)
		{
			price = price * 0.90;
			printf("Kupon ervenyesitve 10%% kedvezmeny!\n");
		}
		else
		{
			printf("Hibas kupon!\n");
		}
		break;
	}
	case 2:
	{
		break;
	}
	}
	printf("Vegosszeg: %.2lf", price);
}
