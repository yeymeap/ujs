% Lotka - Volterra - zsákmány ragadozó
% t - idő, y(1) - zsákmány, y(2) - ragadozó
% a, b - zsákmányt befolyásoló konstansok
% c, d - ragadozót befolyásoló konstansok
%körforgás:
%a = 1.9;
%b = 3;
%c = 1;
%d = 0.9;

a = 1.9; 
b = 3;
c = 1;
d = 1.5;

t = [0,50];

y_zero = [0.5, 1.5]; % [y(1), y(2)] kezdeti populációs értékek

[t, y] = ode45(@lv_func, t, y_zero, [], a, b, c, d);

plot(t, y(:, 1), 'b', t, y(:, 2), 'r');
legend("zsakmany", "ragadozo")