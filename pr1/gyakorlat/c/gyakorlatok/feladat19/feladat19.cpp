#include <stdio.h>    
   
int main() {
    int num = 0;
    int x;
    printf("N = ");
    scanf("%d", &x);
    for (int i = 1; i < x+1; i++) {  
        num = num + (i*2); 
    }
    printf("Az elso %d paros szam osszege: %d", x, num);       
 } 