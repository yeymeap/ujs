#include <stdio.h>

int main(void)
{
    int n = 224;
    char tomb[224];
    for (int i = 0; i < n; i++)
    {
        tomb[i] = i + 32;
    }
    int min = 33, max = 59;
    for (int i = min; i < max; i++)
    {
        printf("%c", tomb[i]);
    }
}