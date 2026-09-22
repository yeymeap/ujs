%{
Bemenet: x0 - kezdoertek
         epsilon - pontossag amit el szeretnenk erni 2 egymast 
                    koveto kozelito erteknel
         maxit - a maximalis iteraciok szama
         fiter - fuggveny, definialva az alabbiakban
Kimenet: m - az iteraciok szama
         x - kozelito megoldasa az x=fiter(x) -nek
%}
function y=fiter(x)  % a fuggveny megadasa
y=(2*x+8)/x;
end
%
clear all
close all
%%%%%%%%% kezdoertekek
epsilon=0.000001;
x0=3;
maxit=50;
%%%%%%%
m=0; err=2;  % err - az aktualis elteres egymast koveto kozelito ertekek kozt
%
while (err>epsilon) & (m<maxit)
    m=m+1;
    X(m)=x0; % az X -ben taroljuk a kozelito ertekeket
    x=fiter(x0);
    err=abs(x-x0); x0=x;
    fprintf('m=%3.0f     x=%10.8f\n',m,x)
end