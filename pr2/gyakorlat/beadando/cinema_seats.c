// Botló Bence Balázs 134174
/*Helyfoglaló rendszer kialakítása


pl.: színház, mozi, étterem, stadion, parkoló, repülő, vonat, stb.

A program képes:

    megjeleníteni az adott állapotot tekintettel a foglat és szabad helyekre
    jelmagyarázattal segíti a felhasználót
    helyek foglalását kezelni

Implementálásra javasolt funkciók:

    drágább és olcsóbb helyek kezelése (téma szerint eltérő)
    foglalás időtartama (pl. parkolók esetén)
    statisztikát számol (pl. foglalt helyek alapján a bevétel, hány % a telítettség, stb..)
    a program véletlenszerű feltöltéssel kezd
    szabályok helyfoglalásra (pl. nem lehet üres helyet kihagyni foglalt mellett)
    a helyfoglalásról jegyet állít elő (egy egyszerű .txt fájlba kimenti struktúráltan az adatokat)
    hely foglaltsági állapotát fájlba menti és onnan be tudja olvasni
    foglalásnál több állapot kezelése (pl.: foglalt, törölt, folyamatban, fizetett) */

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <ctype.h>

int const row = 8, col = 10, unitPrice = 5; // konstansok deklaralasa

void FillMatrix(int mat[row][col]) // matrix feltoltese 0-1 kozotti intervallumban
{
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            mat[i][j] = rand() % 2;
        }
    }
}

void PrintMatrix(int mat[row][col]) // matrix kiirasa
{
    printf("   ");
    for (int j = 0; j < col; j++)
    {
        printf("%3d.", j + 1);
    }

    printf("\n");

    for (int i = 0; i < row; i++)
    {
        printf("%2c ", 'A' + i);
        for (int j = 0; j < col; j++)
        {
            printf("%3d ", mat[i][j]);
        }
        printf("\n");
    }
}

void ExportSeating(int mat[row][col], const char *filename) // ulesrend kiirasa fajlba
{
    FILE *file = fopen(filename, "w");
    if (file == NULL) // hibaellenorzes
    {
        printf("Hiba a fajl megnyitasakor.\n");
        return;
    }

    fprintf(file, "   ");
    for (int j = 0; j < col; j++)
    {
        fprintf(file, "%3d.", j + 1);
    }
    fprintf(file, "\n");

    for (int i = 0; i < row; i++)
    {
        fprintf(file, "%2c ", 'A' + i);
        for (int j = 0; j < col; j++)
        {
            fprintf(file, "%3d ", mat[i][j]);
        }
        fprintf(file, "\n");
    }

    fclose(file);
    printf("Az ulohelyek kiirasa sikeres volt a(z) %s fajlba.\n", filename);
}

int CalculateOccupancy(int mat[row][col]) // telitettseg kiszamolasa
{
    int occupied = 0;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            if (mat[i][j] == 1)
            {
                occupied++;
            }
        }
    }
    return occupied;
}

void PrintOccupancy(int mat[row][col]) // telitettseg, bevetel kiirasa
{
    int totalSeats = row * col;
    int occupiedSeats = CalculateOccupancy(mat);
    double occupancyPercentage = (double)occupiedSeats / totalSeats * 100;
    int profit = occupiedSeats * unitPrice;

    printf("Az ulohelyek %d%%-a foglalt.\n", (int)occupancyPercentage);
    printf("Bevetel: %d EUR\n", profit);
}

void BuyTicket(int mat[row][col]) // vasarlas
{
    int userInput, startCol, index, bookingSuccess = 0;
    char rowLetter;

    while (bookingSuccess == 0) // a do-while loopokban rossz input eseten belep egy vegtelen loopba
    {                           // errol tudok, de ennek kikuszobolese csak tulkomplikalna a kodot
        do                      // nyilvan egy live environmentbe ez elengedhetetlen, de itt most engedjuk el :)
        {
            printf("Maximum 4 jegyet tudsz venni, egymas melle!\nEgy jegy ara %d EUR\nHany jegyet szeretnel venni?\n", unitPrice);
            scanf("%d", &userInput);
            if (userInput < 1 || userInput > 4)
            {
                printf("Hibas bevitel, kerlek probald ujra.\n");
            }
        } while (userInput < 1 || userInput > 4); // ellenorzes

        do
        {
            printf("Hova szeretned a jegyet/jegyeket?\nIrd be a sorszam betujet: ");
            scanf(" %", &rowLetter);
            rowLetter = toupper(rowLetter); // elfogadja kis- es nagybetuket is
            index = rowLetter - 'A';
            if (index < 0 || index >= row)
            {
                printf("Hibas bevitel, kerlek probald ujra.\n");
            }
        } while (index < 0 || index >= row);

        do
        {
            printf("Ird be a kezdoszlop szamat (1-%d): ", col);
            scanf("%d", &startCol);
            startCol--;
            if (startCol < 0 || startCol >= col)
            {
                printf("Hibas bevitel, kerlek probald ujra.\n");
            }
            else if (startCol + userInput > col)
            {
                printf("Tul sok jegyet szeretnel egy sorban, kerlek probald ujra.\n");
            }
        } while (startCol < 0 || startCol >= col || startCol + userInput > col);

        int available = 1;
        for (int j = startCol; j < startCol + userInput; j++) // ellenorzes, hogy van e eleg szabad hely
        {
            if (mat[index][j] != 0)
            {
                available = 0;
                break;
            }
        }

        if (available == 1)
        {
            for (int j = startCol; j < startCol + userInput; j++)
            {
                mat[index][j] = 1;
            }
            printf("Jegyfoglalas sikeres!\n");
            bookingSuccess = 1;
        }
        else
        {
            printf("A valasztott helyek mar foglaltak. Probald ujra.\n");
        }
    }
    PrintMatrix(mat);
    int price = userInput * unitPrice;
    printf("Fizetendo osszeg: %d EUR\n", price); // ar kiirasa
}

int main()
{
    srand(time(NULL));
    int seats[row][col];
    FillMatrix(seats);
    PrintMatrix(seats);
    printf("Jelmagyarazat:\n0 - Ures\n1 - Foglalt\n");
    BuyTicket(seats);
    PrintOccupancy(seats);
    ExportSeating(seats, "seats.txt");
    return 0;
}
