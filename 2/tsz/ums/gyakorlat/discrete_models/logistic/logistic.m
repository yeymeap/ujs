% logisztikai növekedés diszkrét esete
% x - populáció, t - idő, r - növekedési ráta, k - kapacitás
clear all
close all
clc

r = 0.1;
tmax = 150;
x(1) = 100;
t = 1;
k = 2000;

hold on
plot(t,x(t),'+b');  % kezdeti pont
for t = 1 : tmax
    x(t+1) = x(t) + r*x(t) * (1-x(t)/k);
    plot(t+1,x(t+1),'+b');
end
hold off