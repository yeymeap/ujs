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

void oneAroundMatrix(int row, int col, int mat[row][col])
{
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            mat[0][j] = 1;
            mat[row - 1][j] = 1;
            mat[i][0] = 1;
            mat[i][col - 1] = 1;
        }
    }
}

int sumMatrix(int row, int col, int mat[row][col])
{
    int sum = 0;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            sum = sum + mat[i][j];
        }
    }
    return sum;
}
double avgMatrix(int row, int col, int mat[row][col])
{
    double sum = 0, avg = 0;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            sum = sum + mat[i][j];
        }
    }
    avg = sum / (row * col);
    return avg;
}

int minMatrix(int row, int col, int mat[row][col])
{
    int min = mat[0][0];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            if (min > mat[i][j])
            {
                min = mat[i][j];
            }
        }
    }
    return min;
}

int maxMatrix(int row, int col, int mat[row][col])
{
    int max = mat[0][0];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            if (max < mat[i][j])
            {
                max = mat[i][j];
            }
        }
    }
    return max;
}

void changeMinMaxMatrix(int row, int col, int mat[row][col])
{
    int min = mat[0][0];
    int max = mat[0][0];
    int min_row, min_col, max_row, max_col;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            if (max < mat[i][j])
            {
                max = mat[i][j];
                max_row = i;
                max_col = j;
            }
            if (min > mat[i][j])
            {
                min = mat[i][j];
                min_row = i;
                min_col = j;
            }
        }
    }
    int temp = mat[min_row][min_col];
    mat[min_row][min_col] = mat[max_row][max_col];
    mat[max_row][max_col] = temp;
}

int main()
{
    srand(time(NULL));
    int row = 5, col = 5, upperbound = 50, lowerbound = 1, sum, onesum, maxnumber, minvalue, maxvalue;
    double avg;
    int matrix[row][col];

    fillMatrix(row, col, matrix, upperbound, lowerbound);
    sum = sumMatrix(row, col, matrix);
    avg = avgMatrix(row, col, matrix);
    minvalue = minMatrix(row, col, matrix);
    maxvalue = maxMatrix(row, col, matrix);
    printMatrix(row, col, matrix);
    printf("Sum of matrix: %d", sum);
    printf("\nAverage of matrix: %.2lf", avg);
    printf("\nMinimum value of matrix: %d", minvalue);
    printf("\nMaximum value of matrix: %d", maxvalue);
    printf("\nMin and Max value swapped:\n\n");

    changeMinMaxMatrix(row, col, matrix);
    printMatrix(row, col, matrix);
    printf("\n\n");

    oneAroundMatrix(row, col, matrix);
    printMatrix(row, col, matrix);
    onesum = sumMatrix(row, col, matrix);
    printf("Sum of one around matrix: %d", onesum);
}