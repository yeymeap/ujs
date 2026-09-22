%%%%%%%%%%%%%% Hur modszer (Regula Falsi Method)
clear all
% a fuggveny megadasa

f=@(x) x^2-2*x-8;

%%%%%%%%% kezdoertekek
epsilon=0.00001;
x0=2.5; x1=5.;%xm0=x0; xm1=x1;
maxit=100;
%%%%%%%
m=0; err=2;  % err - az aktualis elteres egymast koveto kozelito ertekek kozt
%
while (err>epsilon) & (m<maxit)
    m=m+1;
    x=x1-f(x1)*(x1-x0)/(f(x1)-f(x0));   
    %x=x1-f(x1)/(f(x1)-f(x0))/(x1-x0);  ugyanaz vagy megsem?
    fprintf('m=%3.0f     x0=%10.8f    x1=%10.8f    x=%10.8f\n',m,x0,x1,x);
    if sign(f(x))==sign(f(x0))
        x0=x;
    end
    if sign(f(x))==sign(f(x1))
        x1=x;
    end  
    err=abs(f(x));
end