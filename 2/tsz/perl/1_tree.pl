#!/usr/bin/perl
print("Karacsonyfa magassaga n:\n"); # bemenet
$height = <STDIN>; # bemenet
chomp($height);     # newline eltávolítása
$height = int($height);  # integerré alakítás


while($height < 3 || $height > 10){ # ha magasság kisebb mint 3 vagy nagyobb mint 10, vagy nem numerikus karakter
    print("Helytele magassag, mivel n < 3 vagy n > 10\n"); 
    print("Karacsonyfa magassaga n:\n");
    $height = <STDIN>;
}

print("\n"); # newline

for ($i = 1; $i <= $height; $i++) { # karácsonyfa kirajzolása
    print ' ' x ($height - $i); # space karaker kiírás, minden iterációval kevesebb space
    print '*' x (2 * $i - 1); #csillag karakter kiírás, minden iterációval dupla annyi csillag - 1 mint az előzőben
    print "\n"; # newline
}

for ($j = 0; $j < 2; $j++) { # tartó kirajzolása
    print ' ' x ($height - 2); # tartó középre igazítás
    print "***"; # tartó
    print "\n" # newline
}