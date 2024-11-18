% Brown mozgás 1D

clear all
close all
clc

x(1) = 0;

for i=1:100
    randnum = rand();
    if(randnum <= 0.5)
        x(i + 1) = x(i) - 1;
    else
        x(i + 1) = x(i) + 1;
    end
end
plot(x(1:100), "r")
grid on

