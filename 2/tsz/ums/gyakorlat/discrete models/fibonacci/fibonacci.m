% fibonacci modell
% x_i - fibonacci érték, t_0 - 1. fibonacci szám, t_1 - 2.:
clear all
close all
clc

xt_0 = 0;
xt_1 = 1;
x_t = 0;

message = 'Add meg, mennyi fibonacci számra van szükség:';
max = input(message);

hold on
% első két fibonacci érték
plot(0, xt_0, '.r'); % 0 konstans kezdőérték
plot(1, xt_1, '.r'); % 1 konstans kezdőérték

for t=2:max
    x_t = xt_0 + xt_1 % aktuális fibonacci szám
    xt_0 = xt_1;
    xt_1 = x_t;
    plot(t, x_t, '.r');
end
hold off
