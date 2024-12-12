s = {'a','a','b','b','b','c','c','c','c','d','d','d','e','e','e','e','e'};
t = {'a','e','a','b','e','a','c','d','e','b','c','e','a','b','c','d','e'};
Page_rank = digraph(s, t);
p = plot(Page_rank, 'Layout', 'layered');
highlight(p, {'a','a'}, {'a','e'}, "EdgeColor", "yellow");
highlight(p, {'b','b','b'}, {'a','b','e'}, "EdgeColor", "green");
highlight(p, {'c','c','c','c'}, {'a','c','d','e'}, "EdgeColor", "red");
highlight(p, {'d','d','d'}, {'b','c','e'}, "EdgeColor", "blue");
highlight(p, {'e', 'e', 'e', 'e', 'e'}, {'a', 'b', 'c', 'd', 'e'}, "EdgeColor", "magenta");
