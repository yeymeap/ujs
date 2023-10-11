#include <stdio.h>

int main()
{
    int fasz, mod, oszt;
    printf("Adj meg egy szamot te geci: ");
    scanf("%d", &fasz);
    mod = fasz % 10;
    oszt = fasz / 10;
    if (mod == 0 && fasz > 0 && fasz <= 100 )
    {
        switch (fasz)
        {
        case 10:
            printf("tiz");
            break;
        
        case 20:
            printf("husz");
            break;
        case 30:
            printf("harminc");
            break;
        case 40:
            printf("negyven");
            break;
        case 50:
            printf("otven");
            break;
        case 60:
            printf("hatvan");
            break;
        case 70:
            printf("hetven");
            break;
        case 80:
            printf("nyolcvan");
            break;
        case 90:
            printf("kilencven");
            break;
        case 100:
            printf("szaz");
            break;

        }
    }

    else if (mod != 0 && fasz > 0 && fasz <= 100)
    {
        switch (oszt)
        {
        case 1:
            printf("tizen");
            break;
        
        case 2:
            printf("huszon");
            break;
        case 3:
            printf("harminc");
            break;
        case 4:
            printf("negyven");
            break;
        case 5:
            printf("otven");
            break;
        case 6:
            printf("hatvan");
            break;
        case 7:
            printf("hetven");
            break;
        case 8:
            printf("nyolcvan");
            break;
        case 9:
            printf("kilencven");
            break;
        }
        switch (mod)
        {
        case 1:
            printf("egy");
            break;
        
        case 2:
            printf("ketto");
            break;
        case 3:
            printf("harom");
            break;
        case 4:
            printf("negy");
            break;
        case 5:
            printf("ot");
            break;
        case 6:
            printf("hat");
            break;
        case 7:
            printf("het");
            break;
        case 8:
            printf("nyol");
            break;
        case 9:
            printf("kilenc");
            break;
        }
    }
    else
    {
        printf("valamit elbasztal");
    }

}