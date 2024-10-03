#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>

int main()
{
    int start, end, ticketType, ticketReserve, bicycle, wagon, seat, difference, distance, stationDistances[] = {0, 22, 31, 54, 100};
    char *startPoint, *endPoint;
    double price = 0;
    srand(time(NULL));

    printf("Kerem adja meg a kiindulasi allomast:\n1. Komarom\n2. Nemesocsa\n3. Nagymegyer\n4. Dunaszerdahely\n5. Pozsony\n");
    scanf("%d", &start);
    switch (start)
    {
    case 1:
        startPoint = "Komarom";
        break;
    case 2:
        startPoint = "Nemesocsa";
        break;
    case 3:
        startPoint = "Nagymegyer";
        break;
    case 4:
        startPoint = "Dunaszerdahely";
        break;
    case 5:
        startPoint = "Pozsony";
        break;
    }

    printf("Kerem adja meg a celallomast:\n1. Komarom\n2. Nemesocsa\n3. Nagymegyer\n4. Dunaszerdahely\n5. Pozsony\n");
    scanf("%d", &end);
    if (start == end)
    {
        printf("Hibas allomas valasztas!\n");
        return 0;
    }

    switch (end)
    {
    case 1:
        endPoint = "Komarom";

        break;
    case 2:
        endPoint = "Nemesocsa";

        break;
    case 3:
        endPoint = "Nagymegyer";

        break;
    case 4:
        endPoint = "Dunaszerdahely";

        break;
    case 5:
        endPoint = "Pozsony";
        break;
    }

    distance = abs(stationDistances[end - 1] - stationDistances[start - 1]);
    difference = abs(start - end);
    switch (difference)
    {
    case 1:
        price = 1.5;
        break;
    case 2:
        price = 2;
        break;
    case 3:
        price = 2.5;
        break;
    case 4:
        price = 3;
        break;
    }

    printf("Helyjegyet kivan valtani?\n1. Igen\n2. Nem\n");
    scanf("%d", &ticketReserve);
    switch (ticketReserve)
    {
    case 1:
        wagon = rand() % 5 + 1;
        seat = rand() % 100 + 1;
        price += 1;
        break;

    default:
        break;
    }

    printf("Jegy tipusa:\n1. Normal\n2. Diak\n3. Nyugdijas\n");
    scanf("%d", &ticketType);
    switch (ticketType)
    {
    case 1:
        break;
    case 2:
        price *= 0.5;
        break;
    case 3:
        price *= 0.2;
        break;
    }
    printf("Biciklit kivan szallitani?\n1. Igen\n2. Nem\n");
    scanf("%d", &bicycle);
    switch (bicycle)
    {
    case 1:
        price += 0.5;
        break;

    default:
        break;
    }
    printf("Indulasi allomas: %s\n", startPoint);
    printf("Celallomas: %s\n", endPoint);
    if (ticketReserve == 1)
    {
        printf("Vagon: %d\n", wagon);
        printf("Szek: %d\n", seat);
    }
    printf("Tavolsag: %d km\n", distance);
    printf("A jegy ara: %.2lf euro\n", price);
}
