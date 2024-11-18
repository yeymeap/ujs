clear all
close all
clc
% lineáris kongrugencia modulo generátor
% a - együttható, c - növekvény, m - modulo, x - véletlen szám
x(1) = 1; % seed - kezdőérték
a = 2685;
c = 6083;
m = 8191;

hold on
for i = 1:2:100-1 
    x(i + 1) = mod(a * x(i) + c, m);
    x(i + 2) = mod(a * x(i + 1) + c, m);    
    plot(x(i + 1), x(i), "r+");
end
hold off