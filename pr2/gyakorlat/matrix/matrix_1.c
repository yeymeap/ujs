#include <stdio.h>
#include <time.h>
#include <stdlib.h>
int sum = 0;

void output(int row, int col, int array[row][col])
{
    printf("          ");
    for (int x = 0; x < col; x++)
    {
        printf("%2d. ", x + 1);
    }

    printf("\n");
    printf("          ");
    for (int x = 0; x < col + 3; x++)
    {
        printf("---");
    }

    for (int i = 0; i < row; i++)
    {
        printf("\n");
        printf("%3d. sor| ", i + 1);
        for (int j = 0; j < col; j++)
        {
            printf("%3d ", array[i][j]);
        }
    }
    printf("\n");
}

void zero(int row, int col, int array[row][col])
{
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            array[i][j] = 0;
        }
    }
    printf("\n");
}

void generate(int row, int col, int array[row][col])
{
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            array[i][j] = rand() % 100 + 1;
            sum = sum + array[i][j];
        }
    }
    printf("\n");
}

int main()
{
    srand(time(NULL));
    int sor = 5;
    int oszlop = 10;
    int tomb[sor][oszlop];
    output(sor, oszlop, tomb);
    generate(sor, oszlop, tomb);
    output(sor, oszlop, tomb);
    double avg = sum / (sor * oszlop);
    printf("\ntomb osszege: %d", sum);
    printf("\ntomb atlaga: %.2lf", avg);
}