function y = comp_func(t, y, a, b, c, d, e, f)
    y = [y(1)* (a - b * y(1) - c * y(2)); y(2) * (d - e * y(1) - f * y(2))]; % [1. populáció, 2. populáció]
end