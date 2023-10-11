#include <stdio.h>

int main()
{
    int mod;
    printf("Add meg meddig irja ki az 5-el es 3-al oszthato szamokat: ");
    scanf("%d", &mod);
    for (int i = 1; i < mod; i++)
    {
        if (i % 5 == 0 || i % 3 == 0)
        {
            printf("%d, ", i);
        }
    }
}