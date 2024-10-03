#include <stdio.h>

int main(void){
    char fname[30], lname[30], city[30], street[30], country[30];
    int zip;
    printf("Add meg a keresztneved: ");
    scanf("%s", &fname);
    printf("Add meg a vezetekneved: ");
    scanf("%s", &lname);
    printf("Add meg a lakcimed: ");
    scanf("%s", &street);
    printf("Add meg az iranyitoszamot: ");
    scanf("%d", &zip);
    printf("Add meg a telepulest: ");
    scanf("%s", &city);
    printf("Add meg ;az orszagot: ");
    scanf("%s", &country);
    printf("%s %s\n %s\n %s\n %d", lname, fname, city, street, zip);
    return 0;
}