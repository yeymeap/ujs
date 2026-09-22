% a fuggveny megadasa
function y=f(x)
y=(x+1)^2*exp(x^2-2)-1;
end
%
clear all
close all
%%%%%%%%% kezdoertekek
epsilon=0.000001;
a=0;   % az intervallum vegpontjai, ahol a fuggveny elojelet valt
b=2;
%%%%%%%
m=0; maxerr=b-a;  % 
%
if f(a)*f(b)>=0 
    disp('a bemeneti adatokra az intervallum felezeses algoritmus nem hasznalhato');
    return
end
%
%
while (maxerr>epsilon)
    m=m+1;
    s=(a+b)/2;
    %
    if f(s)==0 
        fprintf('\n az egyenlet  megoldasa:     %10.8f \n ',s); 
        return 
    end
    %
    if sign(f(a))==sign(f(s))
        a=s;
    end;
    if sign(f(b))==sign(f(s))
        b=s;
    end;  
    maxerr=b-a;
    fprintf('a=%10.8f    b=%10.8f     b-a=%10.8f\n ',a,b,maxerr)
end
fprintf('\n az egyenlet kozelito megoldasa:     %10.8f \n ',s)
%
