// Botló Bence Balázs 134174
#include <stdio.h>
#include <math.h>

int main()
{
    int wallnum, i = 0;
    double unitprice, area, a, b, paintprice, paintvolume, flakonvolume = 0.6, flakonarea = 3.65, workprice, unitnum, sum, areaS = 0, paintvolumeS = 0, unitnumS = 0, workpriceS = 0, paintpriceS = 0, sumS = 0;
    printf("Festek ar kalkulator!\n");
    printf("Festekes kanna merete: %.1lf l\n", flakonvolume);
    printf("A munka ara 5 euro/10 negyzetmeter\n");
    printf("Rahagyas 12 szazalek\n");
    printf("Festek ara euroban: ");
    scanf("%lf", &unitprice);
    printf("Hany falat akarsz kifesteni: ");
    scanf("%d", &wallnum);
    printf("\nFalak hossza es szelessege meterben (ket tizedes jegyig):\n\n");

    while (i != wallnum)
    {
        printf("%d. fal\n", i + 1);
        printf("hossz: ");
        scanf("%lf", &a);
        printf("szelesseg: ");
        scanf("%lf", &b);

        area = a * b;
        paintvolume = area / flakonarea * 1.12;
        unitnum = ceil(paintvolume / flakonvolume);
        workprice = area / 10 * 5;
        paintprice = unitprice * unitnum;
        sum = workprice + paintprice;
        printf("\nA festendo felulet: %.2lf negyzetmeter\n", area);
        printf("Festek szukseges mennyisege: %.2lf l\n", paintvolume);
        printf("Festekes kanna szukseges darabszama: %.0lf\n", unitnum);
        printf("A munka ara: %.2lf euro\n", workprice);
        printf("A festek ara: %.2lf euro\n", paintprice);
        printf("A teljes koltseg: %.2lf euro\n\n", sum);

        areaS = areaS + area;
        paintvolumeS = paintvolumeS + paintvolume;
        unitnumS = unitnumS + unitnum;
        workpriceS = workpriceS + workprice;
        paintpriceS = paintpriceS + paintprice;
        sumS = sumS + sum;
        i++;
    }

    printf("Az osszes festendo felulet: %.2lf negyzetmeter\n", areaS);
    printf("Osszes festek szukseges mennyisege: %.2lf l\n", paintvolumeS);
    printf("Osszes festekes kanna szukseges darabszama: %.0lf\n", unitnumS);
    printf("Osszes munka ara: %.2lf euro\n", workpriceS);
    printf("Osszes festek ara: %.2lf euro\n", paintpriceS);
    printf("Osszkoltseg: %.2lf euro\n", sumS);
    return 0;
}