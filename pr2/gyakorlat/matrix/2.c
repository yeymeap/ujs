#include <stdio.h>
#include <stdlib.h>
#include <time.h>
void bubbleSort(int arr[], int col)
{
    for (int i = 0; i < col - 1; i++)
    {
        for (int j = 0; j < col - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}

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

void sortMatrixRow(int row, int col, int mat[row][col])
{
    for (int i = 0; i < row; i++)
    {
        bubbleSort(mat[i], col);
    }
}

int main()
{
    srand(time(NULL));
    int row = 6, col = 6, upperbound = 50, lowerbound = 1, matrix[row][col];
    fillMatrix(row, col, matrix, upperbound, lowerbound);
    printMatrix(row, col, matrix);
    sortMatrixRow(row, col, matrix);
    printMatrix(row, col, matrix);
}
