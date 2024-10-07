% versengő
% t - idő, y(1) - 1. populáció, y(2) - 2. populáció
% a, b, c - 1. populációt befolyásoló konstansok 
% d, e, f - 2. populációt befolyásoló konstansok

a = 10;
b = 2.5;
c = 1.5;
d = 10;
e = 3;
f = 1;

t = [0,50];

y_zero = [5, 5]; % [y(1), y(2)] kezdeti populációs értékek

[t, y] = ode45(@comp_func, t, y_zero, [], a, b, c, d, e, f);

plot(t, y(:, 1), 'b', t, y(:, 2), 'r');
legend("1. pop", "2. pop")