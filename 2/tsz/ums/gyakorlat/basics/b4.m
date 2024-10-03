clc

[X, Y] = meshgrid(-5:0.5:5, -5:0.5:5);
Z = sin(X + Y);

figure;
surf(X, Y, Z);
title('3D Sin')
xlabel('x tengely')
ylabel('y tengely')
zlabel('z tengely')
colorbar