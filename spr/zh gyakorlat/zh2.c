// Botló Bence Balázs 134174
#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int main()
{
    int type, x, y, i, input, result, points = 0, div, tries, etype, difficulty, max, factor;
    srand(time(NULL));
    printf("Matek gyakorlas\nVeletlenszeru mod: 1\nVegtelen mod: 2\nOsszeadas: 3\nKivonas: 4\nSzorzas: 5\nOsztas: 6\nMod: ");
    scanf("%d", &etype);

    switch (etype)
    {
    case 1:
        printf("Hany feladatot szeretnel megoldani?\n");
        scanf("%d", &tries);
        printf("Maximalis ertek: ");
        scanf("%d", &max);
        for (i = 0; i != tries; i++)
        {
            x = rand() % max;
            y = rand() % max;
            type = rand() % 4;
            switch (type)
            {
            case 0:
                result = x + y;
                printf("%d + %d = ", x, y);
                scanf("%d", &input);
                if (input == result)
                {
                    printf("Helyes!\n");
                    points++;
                }
                else
                {
                    printf("Helytelen!\nA helyes valasz: %d\n", result);
                }
                break;
            case 1:
                result = x - y;
                printf("%d - %d = ", x, y);
                scanf("%d", &input);
                if (input == result)
                {
                    printf("Helyes!\n");
                    points++;
                }
                else
                {
                    printf("Helytelen!\nA helyes valasz: %d\n", result);
                }
                break;
            case 2:
                result = x * y;
                printf("%d * %d = ", x, y);
                scanf("%d", &input);
                if (input == result)
                {
                    printf("Helyes!\n");
                    points++;
                }
                else
                {
                    printf("Helytelen!\nA helyes valasz: %d\n", result);
                }
                break;
            case 3:
                if (y == 0)
                {
                    y++;
                }
                if (x == 0)
                {
                    x++;
                }
                if (x % y != 0)
                {
                    x = x + (y - (x % y));
                }
                result = x / y;
                printf("%d / %d = ", x, y);
                scanf("%d", &input);
                if (input == result)
                {
                    printf("Helyes!\n");
                    points++;
                }
                else
                {
                    printf("Helytelen!\nA helyes valasz: %d\n", result);
                }
                break;
            default:
                printf("Hibas bemenet!\n");
                continue;
                break;
            }
        }
        break;
    case 2:
        max = 10;
        printf("Hany pontonkent szeretnel nehezitest?\n");
        scanf("%d", &difficulty);
        printf("Mennyivel szeretnel neheziteni?\n");
        scanf("%d", &factor);
        for (;;)
        {

            if (points % difficulty == 0 && points != 0)
            {
                max = max + factor;
            }

            x = rand() % max;
            y = rand() % max;
            type = rand() % 4;
            switch (type)
            {
            case 0:
                result = x + y;
                printf("%d + %d = ", x, y);
                scanf("%d", &input);
                if (input == result)
                {
                    printf("Helyes!\n");
                    points++;
                }
                else
                {
                    printf("Helytelen!\nA helyes valasz: %d\n", result);
                    printf("A jatek vege!\n");
                    goto end;
                }
                break;
            case 1:
                result = x - y;
                printf("%d - %d = ", x, y);
                scanf("%d", &input);
                if (input == result)
                {
                    printf("Helyes!\n");
                    points++;
                }
                else
                {
                    printf("Helytelen!\nA helyes valasz: %d\n", result);
                    printf("A jatek vege!\n");
                    goto end;
                }
                break;
            case 2:
                result = x * y;
                printf("%d * %d = ", x, y);
                scanf("%d", &input);
                if (input == result)
                {
                    printf("Helyes!\n");
                    points++;
                }
                else
                {
                    printf("Helytelen!\nA helyes valasz: %d\n", result);
                    printf("A jatek vege!\n");
                    goto end;
                }
                break;
            case 3:
                if (y == 0)
                {
                    y++;
                }
                if (x == 0)
                {
                    x++;
                }
                if (x % y != 0)
                {
                    x = x + (y - (x % y));
                }
                result = x / y;
                printf("%d / %d = ", x, y);
                scanf("%d", &input);
                if (input == result)
                {
                    printf("Helyes!\n");
                    points++;
                }
                else
                {
                    printf("Helytelen!\nA helyes valasz: %d\n", result);
                    printf("A jatek vege!\n");
                    goto end;
                }
                break;
            }
        }
        break;

    case 3:
        printf("Hany feladatot szeretnel megoldani?\n");
        scanf("%d", &tries);
        printf("Maximalis ertek x: ");
        scanf("%d", &max);
        for (i = 0; i != tries; i++)
        {
            x = rand() % max;
            y = rand() % max;
            result = x + y;
            printf("%d + %d = ", x, y);
            scanf("%d", &input);
            if (input == result)
            {
                printf("Helyes!\n");
                points++;
            }
            else
            {
                printf("Helytelen!\nA helyes valasz: %d\n", result);
            }
        }
        break;
    case 4:
        printf("Hany feladatot szeretnel megoldani?\n");
        scanf("%d", &tries);
        printf("Maximalis ertek x: ");
        scanf("%d", &max);
        for (i = 0; i != tries; i++)
        {
            x = rand() % max;
            y = rand() % max;
            result = x - y;
            printf("%d - %d = ", x, y);
            scanf("%d", &input);
            if (input == result)
            {
                printf("Helyes!\n");
                points++;
            }
            else
            {
                printf("Helytelen!\nA helyes valasz: %d\n", result);
            }
        }
        break;
    case 5:
        printf("Hany feladatot szeretnel megoldani?\n");
        scanf("%d", &tries);
        printf("Maximalis ertek x: ");
        scanf("%d", &max);
        for (i = 0; i != tries; i++)
        {
            x = rand() % max;
            y = rand() % max;
            result = x * y;
            printf("%d * %d = ", x, y);
            scanf("%d", &input);
            if (input == result)
            {
                printf("Helyes!\n");
                points++;
            }
            else
            {
                printf("Helytelen!\nA helyes valasz: %d\n", result);
            }
        }
        break;
    case 6:
        printf("Hany feladatot szeretnel megoldani?\n");
        scanf("%d", &tries);
        printf("Maximalis ertek x: ");
        scanf("%d", &max);
        for (i = 0; i != tries; i++)
        {
            x = rand() % max;
            y = rand() % max;
            type = rand() % 4;
            if (y == 0)
            {
                y++;
            }
            if (x == 0)
            {
                x++;
            }
            if (x % y != 0)
            {
                x = x + (y - (x % y));
            }
            result = x / y;
            printf("%d / %d = ", x, y);
            scanf("%d", &input);
            if (input == result)
            {
                printf("Helyes!\n");
                points++;
            }
            else
            {
                printf("Helytelen!\nA helyes valasz: %d\n", result);
            }
        }
        break;
    }
end:
    printf("Pontszam: %d\n", points);
}
