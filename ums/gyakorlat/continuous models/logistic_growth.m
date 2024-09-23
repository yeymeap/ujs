clc
clear all
close all

%r - growth, x - population, t - time, k - capacity
global r;
global k;
r = 0.1;
x = 1;
k = 10
t = [1, 70];
[t, x] = ode45(@log_func, t, x);

plot(t, x, 'r-o');
xlabel('time - t');
ylabel('population - x')