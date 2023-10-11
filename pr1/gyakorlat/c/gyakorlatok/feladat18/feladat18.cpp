#include <stdio.h>    
   
int main() {
    int num = 1;
    int x;
    printf("N = ");
    scanf("%d", &x);
    for (int i = 1; i < x+1; i++) {  
        num = num * i; 
    }
    printf("Az elso %d szam szorzata: %d", x, num);       
 } 