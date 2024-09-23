clc
clear all
close all

%r - growth, x - population, t - time, k - capacity
global r;
r = 0.2;
x = 1;
t = [1, 30];
[t, x] = ode45(@exp_func, t, x);

plot(t, x, 'r-o');
xlabel('time - t');
ylabel('population - x')