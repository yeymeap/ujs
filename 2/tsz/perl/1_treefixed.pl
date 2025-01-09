#!/usr/bin/perl

print("Karacsonyfa magassaga n:\n"); # bemenet
$height = <STDIN>; # bemenet
chomp($height);     # newline eltávolítása
$height = int($height);  # integerré alakítás
$width = 180; # terminál szélessége
$trunk_width = 5;  # tartó szélessége
$trunk_length = 3 # tartó magassága

for ($i = 1; $i <= $height; $i++) {
    $stars = 2 * $i - 1; # csillagok száma a sorban
    $spaces = int(($width - $stars) / 2); # spacek száma a középre igazítás miatt
    print ' ' x $spaces . '*' x $stars . "\n"; # kiírás
    }

$trunk_spaces = int(($width - $trunk_width) / 2); # spacek száma középre igazítás miatt
for ($j = 1; $j <= $trunk_length; $j++) { 
    print ' ' x $trunk_spaces . '#' x $trunk_width . "\n"; # kiírás
    }