% Markov-lánc diszkrét esete
% P - állapotátmenet
% Y_0 - kezdeti értékek (A = 200; B = 120; C = 180)
% Y_1 - eredmény
% N = 500 vásárló

clear all
close all
clc

P = [0.8 0.2 0.1
     0.1 0.7 0.3
     0.1 0.1 0.6];

Y_0 = [0.4 
       0.24
       0.36];

hold on
plot(0,Y_0, "r*")
Y_1 = P * Y_0;
plot(1,Y_1, "r*")
hold off