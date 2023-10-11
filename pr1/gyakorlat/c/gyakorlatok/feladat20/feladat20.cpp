#include <stdio.h>    
   
int main() {
    int num = 0;
    int x;
    printf("N = ");
    scanf("%d", &x);
    for (int i = 1; i < x+1; i++) {  
        num = num + (i*2-1); 
    }
    printf("Az elso %d paratlan szam osszege: %d", x, num);       
 } 