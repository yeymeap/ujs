% Markov-lánc diszkrét esete
% P - állapotátmenet
% Y - kezdeti értékek (A = 200; B = 120; C = 180)
% N = 500 vásárló

clear all
close all
clc

n = 500;

P = [0.8 0.2 0.1
     0.1 0.7 0.3
     0.1 0.1 0.6];

Y = [0.4 
       0.24
       0.36];

hold on
for i=0:1:9
    plot(i,Y(1),"r.", "MarkerSize", 10) % A
    plot(i,Y(2),"g.", "MarkerSize", 10) % B
    plot(i,Y(3),"b.", "MarkerSize", 10) % B
    Y = P * Y;
    %A = n * Y(1)
    %B = n * Y(2)
    %C = n * Y(3)
end
hold off