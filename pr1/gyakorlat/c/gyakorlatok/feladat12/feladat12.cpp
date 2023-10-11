#include <stdio.h>

int main() {
	int ev, a, b, c, d, e, h, husvet;
	printf("Evszam: ");
	scanf("%d", &ev);
    if (ev >= 1800 && ev <= 2099)
    {
        a = ev % 19;
        b = ev % 4;
        c = ev % 7;
        d = (19 * a + 24) % 30;
        e = (2 * b + 4 * c + 6 * d + 5) % 7;

        if (e == 6 && d == 29)
        {
            h = 50;
        }
        else if (e == 6 && d == 28 && a > 10)
        {
            h = 49;
        }
        else{
            h = 22 + d + e;
        }
        if (h <= 31)
        {
            husvet = h;
            printf("Husvet vasarnap datuma: %d. marcius %d.", ev, husvet);
        }
        else
        {
            husvet = h - 31;
            printf("Husvet vasarnap datuma %d. aprilis %d.", ev, husvet);
        }
    }
    else{
        printf("Ev csak 1800 es 2099 kozott");
    }
}