#include <stdio.h>

int main()
{
    int x = 1;
    double input, min, max;
    printf("Kerem a(z) %d. szamot: ", x);
    scanf("%lf", &input);
    max = min = input;
    while (input != 0)
    {
        if (input <= min)
        {
            min = input;
        }
        if (input >= max)
        {
            max = input;
        }
        x++;
        printf("Kerem az %d. szamot: ", x);
        scanf("%lf", &input);
    }

    printf("Legkisebb szam: %.2lf", min);
    printf("Legnagyobb szam: %.2lf", max);
}