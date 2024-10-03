clc

x = 0:0.1:10;
y1 = sin(x);
y2 = cos(x);

figure;
subplot(2,1,1);
plot(x, y1, 'r-')
title('sin')
grid on

subplot(2,1,2);
plot(x, y2, 'b-')
title('cos')
grid on
