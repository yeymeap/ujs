clc

x = 0:0.1:10;
y1 = sin(x);
y2 = cos(x);

figure;
plot(x, y1, 'r-', x, y2, 'b-')
legend('sin(x)', 'cos(x)')
title('szinusz és koszinus függvények')
grid on