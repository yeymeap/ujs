s = {'a', 'a', 'a', 'b', 'b', 'c', 'c', 'd', 'd', 'd', 'd'}
t = {'a', 'b', 'd', 'b', 'd', 'a', 'd', 'a', 'b', 'c', 'd'}
Page_rank = digraph(s, t);
p = plot(Page_rank, 'Layout', 'layered');
highlight(p, {'a', 'a', 'a'}, {'a', 'b', 'd'}, "EdgeColor", "k");
highlight(p, {'b', 'b'},  {'b', 'd'}, "EdgeColor", "r");
highlight(p, {'c', 'c'}, {'a', 'd'}, "EdgeColor", "m");
highlight(p, {'d', 'd', 'd', 'd'}, {'a', 'b', 'c', 'd'}, "EdgeColor", "b");