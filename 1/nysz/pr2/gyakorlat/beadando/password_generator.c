// Botló Bence Balázs 134174
/*Véletlen jelszó generáló alkalmazás


pl.: https://passwordsgenerator.net/

A program képes:

    véletlen jelszó generálására
    felhasználó által megadott hosszúságú jelszó előállítására

Implementálásra javasolt funkciók:

    tetszőleges kombinációban megadott karakterkészletekből (kis-, nagybetűk, számok, speciális karakterek) generálni a jelszót
    ellenőrizni, hogy a generált jelszó megfelel-e a meghatározott feltételeknek
    jelszót értékelni bonyolultság szerint
    egyéb (elképzelés alapján)*/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

// fuggvenydeklaraciok, jelszogeneralo fuggveny

void checkMalloc(void *pointer)
{
    if (pointer == NULL)
    {
        printf("Hiba a memoriafoglalasnal!");
        exit(0);
    }
}

char *passwordGenerate(int length, int lowercase, int uppercase, int number, int symbol, int sum)
{
    //  karakterek
    char lowerset[] = "abcdefghijklmnopqrstuvwxyz";
    char upperset[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    char numberset[] = "0123456789";
    char symbolset[] = "!@#$%^&*()_+-=[]{}|;:,.<>/?";

    // hasznalt karakterkeszlet kiszamitasa
    int charsetSize = 0;
    if (lowercase == 1)
        charsetSize += 26;
    if (uppercase == 1)
        charsetSize += 26;
    if (number == 1)
        charsetSize += 10;
    if (symbol == 1)
        charsetSize += 27;

    // memoriafoglalas
    // ezt azert csinalom dinamikusan lefoglalt memoriaval, mert talan hatekonyabb es mert nekem atlathatobb mintsem rand()-al szorakozni minden karaktipusnal
    char *charset = (char *)malloc((charsetSize + 1) * sizeof(char)); // + 1 a nullterminator karakter miatt kell
    checkMalloc(charset);
    char *passwordS = (char *)malloc((length + 1) * sizeof(char));
    checkMalloc(passwordS);

    // felhasznalhato karakterek beirasa charset-be
    int index = 0;
    if (lowercase == 1)
    {
        for (int i = 0; i < 26; i++)
        {
            charset[index++] = lowerset[i];
        }
    }
    if (uppercase == 1)
    {
        for (int i = 0; i < 26; i++)
        {
            charset[index++] = upperset[i];
        }
    }
    if (number == 1)
    {
        for (int i = 0; i < 10; i++)
        {
            charset[index++] = numberset[i];
        }
    }
    if (symbol == 1)
    {
        for (int i = 0; i < 27; i++)
        {
            charset[index++] = symbolset[i];
        }
    }

    charset[index] = '\0'; // nullterminator

    for (int i = 0; i < length; i++)
    {
        int randomIndex = rand() % charsetSize;
        passwordS[i] = charset[randomIndex];
    }
    passwordS[length] = '\0'; // nullterminator

    // keveres elotti jelszo
    // printf("%s", password);

    for (int i = length - 1; i > 0; i--) // vegso megkevergetes
    {
        int j = rand() % (i + 1);
        char temp = passwordS[i];
        passwordS[i] = passwordS[j];
        passwordS[j] = temp;
    }

    // memoriafelszabaditas
    free(charset);
    charset = NULL;

    printf("A jelszo erossege: ");

    //  jelszo komplexitas
    if (length >= 16)
    {
        if (sum > 2)
        {
            printf("eros");
        }
        else
        {
            printf("kozepes");
        }
    }
    else if (length < 16 && length > 8 && sum > 3)
    {
        printf("kozepes");
    }
    else
    {
        printf("gyenge");
    }

    return passwordS;
}

int main()
{
    srand(time(NULL));
    int length, useLower, useUpper, useNum, useSymbol, useSum;

    // felhasznalo bemenet
    printf("Jelszo hossza (max 100 karakter): ");
    scanf("%d", &length);
    if (length < 1 || length > 100)
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    printf("Valasz legalabb egy karakterfajtat!\n");

    printf("Kisbetuk (1 - igen, 0 - nem): ");
    scanf("%d", &useLower);
    if (useLower != 0 && useLower != 1) // hibas bemenet hibaellenorzes
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    printf("Nagybetuk (1 - igen, 0 - nem): ");
    scanf("%d", &useUpper);
    if (useUpper != 0 && useUpper != 1)
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    printf("Szamok (1 - igen, 0 - nem): ");
    scanf("%d", &useNum);
    if (useNum != 0 && useNum != 1)
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    printf("Szimbolumok (1 - igen, 0 - nem): ");
    scanf("%d", &useSymbol);
    if (useSymbol != 0 && useSymbol != 1)
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    useSum = useLower + useUpper + useNum + useSymbol;
    if (useSum == 0) // karaktervalasztas hibaellenorzes
    {
        printf("Hibas karaktervalasztas.\n");
        return 1;
    }

    // jelszogeneralas
    char *password = passwordGenerate(length, useLower, useUpper, useNum, useSymbol, useSum);

    // kimenet
    printf("\nGeneralt jelszo: %s\n", password);

    // memoriafelszabaditas
    free(password);
    password = NULL;
    // fel kell szabaditani a passwordS avagy felszabadul?
    return 0;
}

/*
adodik olyan eset is, mikor kivalasztunk egy karaktertipust es nem kerul bele a jelszoba
errol tudok de mar nem szeretnem tovabb komplikalni
*/