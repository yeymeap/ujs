#include <stdio.h>

int main() {
	double szazalek;
	printf("vizsgan elert eredmeny (szazalekban 0-100): ");
	scanf("%lf", &szazalek);
    if (szazalek > 100)
    {
        printf("Nagyobb ertek mint 100");
    }
    else if (szazalek >= 90)
    {
        printf("Vizsgajegy: A");
    }
    else if (szazalek >= 80)
    {
        printf("Vizsgajegy: B");
    }
        else if (szazalek >= 70)
    {
        printf("Vizsgajegy: C");
    }
        else if (szazalek >= 60)
    {
        printf("Vizsgajegy: D");
    }
        else if (szazalek >= 50)
    {
        printf("Vizsgajegy: E");
    }
    else{
        printf("Vizsgajegy: FX");
    }

}