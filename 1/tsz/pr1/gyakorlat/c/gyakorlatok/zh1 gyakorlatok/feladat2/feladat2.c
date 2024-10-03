#include <stdio.h>

int main()
{
    int szam, oszto;
    printf("Kerek egy 1-100 kozotti szamot: ");
    scanf("%d", &szam);
    while (szam < 1 || szam > 100)
    {
        printf("Kerek egy 1-100 kozotti szamot: ");
        scanf("%d", &szam);
    }
    printf("A szam osztoi: ");

    for (int i = 1; i <= szam + 1; i++)
    {
        if (szam % i == 0)
        {
            printf("%d, ", i);
        }
    }
    return 0;
}