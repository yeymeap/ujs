#include <stdio.h>
#include <stdlib.h>
#include <time.h>

char filename[] = "user.txt";

void input_matrix(int size, int a[size])
{
    printf("eletkor: ");
    scanf("%d", &a[0]);
    printf("magassag: ");
    scanf("%d", &a[1]);
    printf("tomeg: ");
    scanf("%d", &a[2]);
    printf("vagyon: ");
    scanf("%d", &a[3]);
}

void output_matrix(int size, int a[size])
{
    for (int i = 0; i < size; i++)
    {
        printf("%2d ", a[i]);
    }
}

void save_matrix(int size, int a[size])
{
    FILE *file;
    file = fopen(filename, "w");

    for (int i = 0; i < size; i++)
    {
        fprintf(file, "%d ", a[i]);
    }
    fclose(file);
}

int main()
{
    const int N = 4;
    int status = 0;
    srand(time(NULL));
    int matrix[N];
    input_matrix(N, matrix);
    output_matrix(N, matrix);
    save_matrix(N, matrix);
    printf("\nFájl mentve %s néven.", filename);
    printf("\nszeretned valtoztatni?\n1. igen\n0. nem");
    scanf("%d", &status);
    if (status == 1)
    {
        input_matrix(N, matrix);
        output_matrix(N, matrix);
        save_matrix(N, matrix);
    }
    else
    {
        exit(0);
    }
}