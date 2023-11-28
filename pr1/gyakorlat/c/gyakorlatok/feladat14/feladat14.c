#include <stdio.h>

int main()
{
    int nap;
    printf("Hanyadik nap nevere vagy kivancsi: ");
    scanf("%d", &nap);
    switch (nap)
    {
    case 1:
        printf("Hetfo");
        break;
    case 2:
        printf("Kedd");
        break;
    case 3:
        printf("Szerda");
        break;
    case 4:
        printf("Csutortok");
        break;
    case 5:
        printf("Pentek");
        break;
    case 6:
        printf("Szombat");
        break;
    case 7:
        printf("Vasarnap");
        break;
    }
}