% Rössler egyenletek szkript
% kimeneti simulink értékek
x = out.x;
y = out.y;
z = out.z;
figure;
grid on;
plot3(x, y, z, 'LineWidth', 1.5); % 3d ábra az attraktorra
xlabel('x');
ylabel('y');
zlabel('z');
title('Rössler attraktor');

t = linspace(0, 100, length(x));
figure;
plot(t, x, 'r', t, y, 'g', t, z, 'b'); % x, y, z értékek időbeli változása  
xlabel('t idő');
ylabel('Értékek');
legend('x', 'y', 'z');
title('Rössler attraktor értékeinek időbeli eloszlása');
grid on;
