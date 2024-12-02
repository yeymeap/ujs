s = {'a', 'a', 'a', 'b', 'c', 'c'}
t = {'a', 'b', 'c', 'a', 'a', 'b'}
Page_rank = digraph(s, t);
p = plot(Page_rank, 'Layout', 'layered');
highlight(p, {'a', 'a', 'a'}, {'a', 'b', 'c'}, "EdgeColor", "b");
highlight(p, {'b'},  {'a'}, "EdgeColor", "r");
highlight(p, {'c', 'c'}, {'a', 'b'}, "EdgeColor", "m");