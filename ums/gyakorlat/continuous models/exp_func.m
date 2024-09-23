% function return value = function_name(inputs)
function dxdt = exp_func(t, x)
    % function
    global r;
    dxdt = r * x;
end