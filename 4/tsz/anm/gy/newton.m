clear all
close all
% a fuggveny megadasa

f=@(x)  x^2-2*x-8;     %(x+1)^2*exp(x^2-2)-1;% 
df=@(x) 2*x-2;
%%%%%%
%  vagy
%dsim=diff(sym(f),'x');  % az f(x) szimbolikus derivaltja az  x  szerint
%dfs=matlabFunction(dsim);
%
%%%%%%%%% kezdoertekek
epsilon=0.001;
x0=2;
maxit=50;
%%%%%%%
m=0; err=2;  % err - az aktualis elteres egymast koveto kozelito ertekek kozt
%
while (err>epsilon) & (m<maxit)
    fprintf('m=%3.0f     x=%20.18f\n',m,x0)
    m=m+1;
    x=x0-f(x0)/df(x0);         
    %err=abs(x-x0);
    err=abs(f(x));
    x0=x;
end
%
%
% format long;
% options=[];
% options = optimset('PlotFcns',{@optimplotx,@optimplotfval}); % Examine the solution process by setting options that include plot functions
% options = optimset('Display','iter'); % show iterations
% megoldas=fzero(f,[0,1],options)