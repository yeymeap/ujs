% Brown mozgás 3D

clear all
close all
clc

x(1) = 0;
y(1) = 0;
z(1) = 0;

for i=1:100
    randnum_x = rand();
    if(randnum_x <= 0.5)
        x(i + 1) = x(i) - 1;
    else
        x(i + 1) = x(i) + 1;
    end

    randnum_y = rand();
    if(randnum_y <= 0.5)
        y(i + 1) = y(i) - 1;
    else
        y(i + 1) = y(i) + 1;
    end

    randnum_z = rand();
    if(randnum_z <= 0.5)
        z(i + 1) = z(i) - 1;
    else
        z(i + 1) = z(i) + 1;
    end
end

plot3(x(1:100), y(1:100), z(1:100), "r")
grid on