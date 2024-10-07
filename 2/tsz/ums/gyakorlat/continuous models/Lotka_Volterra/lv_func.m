function y = lv_func(t, y, a, b, c, d)
    y = [y(1) * (a-b*y(2)); y(2) * (c*y(1) - d)]; % [zsákmány, ragadozó]
end