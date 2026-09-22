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
%
%kirajzolas
m=8;
x_min=2; x_max=6;
y_min=2; y_max=6;
x_s(1)=X(1); x_s(2)=X(1);
y_s(1)=0; y_s(2)=X(2);
for n=1:m
    iodd=2*n-1; ieven=2*n;
    x_s(iodd)=X(n); x_s(ieven)=X(n);
    y_s(iodd)=X(n); y_s(ieven)=X(n+1);
end
%
axis([x_min x_max y_min y_max]);
hold on
line(x_s,y_s);
xx=[x_min x_max];
line(xx,xx);
%fplot('(2.*x+8)./x',[x_min x_max]);
fplot(@(x)(2.*x+8)./x,[x_min x_max]) ;
hold off