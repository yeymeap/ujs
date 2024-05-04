#include <stdio.h>
#include <stdbool.h>

#define N 10

int lab[N][N] = {{9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
                 {9, 0, 0, 9, 0, 9, 0, 9, 0, 5},
                 {9, 0, 9, 9, 0, 9, 0, 9, 0, 9},
                 {9, 0, 0, 0, 0, 9, 0, 0, 0, 9},
                 {9, 9, 0, 9, 9, 9, 9, 9, 0, 9},
                 {9, 0, 0, 0, 0, 0, 0, 9, 0, 9},
                 {9, 0, 9, 9, 9, 0, 9, 0, 0, 9},
                 {9, 0, 0, 0, 9, 0, 0, 0, 9, 9},
                 {9, 0, 9, 0, 9, 0, 9, 0, 0, 9},
                 {9, 0, 9, 9, 9, 9, 9, 9, 9, 9}};

int kesz = 0;

void kiiras()
{
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            printf("%2d", lab[i][j]);
        }
        printf("\n");
    }
    printf("\n");
}

void lepes(int sor, int oszlop)
{
    if (lab[sor][oszlop] == 5)
    {
        kesz = 1;
    }

    lab[sor][oszlop] = 1;

    if (kesz == 0 && sor > 0 && (lab[sor - 1][oszlop] == 0 || lab[sor - 1][oszlop] == 5))
    {
        lepes(sor - 1, oszlop);
    }
    if (kesz == 0 && oszlop < N - 1 && (lab[sor][oszlop + 1] == 0 || lab[sor][oszlop + 1] == 5))
    {
        lepes(sor, oszlop + 1);
    }
    if (kesz == 0 && sor < N - 1 && (lab[sor + 1][oszlop] == 0 || lab[sor + 1][oszlop] == 5))
    {
        lepes(sor + 1, oszlop);
    }
    if (kesz == 0 && oszlop > 0 && (lab[sor][oszlop - 1] == 0 || lab[sor][oszlop - 1] == 5))
    {
        lepes(sor, oszlop - 1);
    }

    if (kesz == 0)
    {
        lab[sor][oszlop] = 2;
    }
}

int main()
{
    kiiras();
    lepes(N - 1, 1);
    kiiras();
}