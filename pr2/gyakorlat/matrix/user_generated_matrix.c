#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void fillMatrix(int row, int col, int mat[row][col], int upperbound, int lowerbound)
{
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            mat[i][j] = rand() % (upperbound - lowerbound + 1) + lowerbound;
        }
    }
}

void printMatrix(int row, int col, int mat[row][col])
{
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            printf("%2d ", mat[i][j]);
        }
        printf("\n");
    }
    printf("\n");
}

int main()
{
    srand(time(NULL));
    int row, col, upperbound, lowerbound;

    printf("Matrix sorainak szama: ");
    scanf("%d", &row);
    printf("Matrix oszlolapinak szama: ");
    scanf("%d", &col);

    int matrix[row][col];
    printf("Veletlen szam felso hatar: ");
    scanf("%d", &upperbound);
    printf("Veletlen szam also hatar: ");
    scanf("%d", &lowerbound);

    fillMatrix(row, col, matrix, upperbound, lowerbound);
    printMatrix(row, col, matrix);
}