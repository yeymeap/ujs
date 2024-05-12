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

char *generatePassword(int length, int useLowercase, int useUppercase, int useNumbers, int useSymbols)
{
    //  karakterek
    char lowercase[] = "abcdefghijklmnopqrstuvwxyz";
    char uppercase[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    char digits[] = "0123456789";
    char symbols[] = "!@#$%^&*()_+-=[]{}|;:,.<>/?";

    // hasznalt karakterkeszlet kiszamitasa
    int charsetSize = 0;
    if (useLowercase == 1)
        charsetSize += 26;
    if (useUppercase == 1)
        charsetSize += 26;
    if (useNumbers == 1)
        charsetSize += 10;
    if (useSymbols == 1)
        charsetSize += 27;

    // memoriafoglalas
    // ezt azert csinalom dinamikusan lefoglalt memoriaval, mert talan hatekonyabb es mert nekem atlathatobb mintsem rand()-al szorakozni minden karaktipusnal
    char *charset = (char *)malloc((charsetSize + 1) * sizeof(char)); // + 1 a nullterminator karakter miatt kell
    checkMalloc(charset);
    char *passwordString = (char *)malloc((length + 1) * sizeof(char));
    checkMalloc(passwordString);

    // felhasznalhato karakterek beirasa charset-be
    int index = 0;
    if (useLowercase == 1)
    {
        for (int i = 0; i < 26; i++)
        {
            charset[index++] = lowercase[i];
        }
    }
    if (useUppercase == 1)
    {
        for (int i = 0; i < 26; i++)
        {
            charset[index++] = uppercase[i];
        }
    }
    if (useNumbers == 1)
    {
        for (int i = 0; i < 10; i++)
        {
            charset[index++] = digits[i];
        }
    }
    if (useSymbols == 1)
    {
        for (int i = 0; i < 27; i++)
        {
            charset[index++] = symbols[i];
        }
    }

    charset[index] = '\0'; // nullterminator

    for (int i = 0; i < length; i++)
    {
        int randomIndex = rand() % charsetSize;
        passwordString[i] = charset[randomIndex];
    }
    passwordString[length] = '\0'; // nullterminator

    // keveres elotti jelszo
    // printf("%s", password);

    for (int i = length - 1; i > 0; i--) // vegso megkevergetes
    {
        int j = rand() % (i + 1);
        char temp = passwordString[i];
        passwordString[i] = passwordString[j];
        passwordString[j] = temp;
    }

    // memoriafelszabaditas
    free(charset);
    charset = NULL;

    printf("A jelszo erossege: ");

    int useSum = useLowercase + useUppercase + useNumbers + useSymbols;
    // jelszo komplexitas
    if (length >= 16)
    {
        if (useSum > 2)
        {
            printf("eros");
        }
        else
        {
            printf("kozepes");
        }
    }
    else if (length < 16 && useSum > 3)
    {
        printf("kozepes");
    }
    else
    {
        printf("gyenge");
    }
    return passwordString;
}

int main()
{
    srand(time(NULL));
    int length, useLowercase, useUppercase, useNumbers, useSymbols;

    // felhasznalo bemenet
    printf("Jelszo hossza (max 100 karakter): ");
    if (scanf("%d", &length) != 1 || length <= 0 || length > 100)
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    printf("Valasz legalabb egy karakterfajtat!\n");

    printf("Kisbetuk? (1 - igen, 0 - nem): ");
    if (scanf("%d", &useLowercase) != 1 || (useLowercase != 0 && useLowercase != 1)) // hibas bemenet hibaellenorzes
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    printf("Nagybetuk? (1 - igen, 0 - nem): ");
    if (scanf("%d", &useUppercase) != 1 || (useUppercase != 0 && useUppercase != 1))
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    printf("Szamok? (1 - igen, 0 - nem): ");
    if (scanf("%d", &useNumbers) != 1 || (useNumbers != 0 && useNumbers != 1))
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    printf("Szimbolumok? (1 - igen, 0 - nem): ");
    if (scanf("%d", &useSymbols) != 1 || (useSymbols != 0 && useSymbols != 1))
    {
        printf("Hibas bemenet.\n");
        return 1;
    }

    if (useLowercase == 0 && useUppercase == 0 && useNumbers == 0 && useSymbols == 0) // karaktervalasztas hibaellenorzes
    {
        printf("Hibas karaktervalasztas.\n");
        return 1;
    }

    // jelszogeneralas
    char *password = generatePassword(length, useLowercase, useUppercase, useNumbers, useSymbols);

    // kimenet
    printf("\nGeneralt jelszo: %s\n", password);

    // memoriafelszabaditas
    free(password);
    password = NULL;

    return 0;
}

/*
adodik olyan eset is, mikor kivalasztunk egy karaktertipust es nem kerul bele a jelszoba
errol tudok de mar nem szeretnem tovabb komplikalni
*/