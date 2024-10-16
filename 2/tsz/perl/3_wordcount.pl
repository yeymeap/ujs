$filename = 'text.txt'; # fájlnév

print "Megszámolásra szánt szó: ";
chomp($user_word = <STDIN>); # bemenet
$user_word = lc($user_word); # kisbetűvé alakítás

$count = 0; # számláló inkrementálása

open(FH, '<', $filename) or die "Nem sikerült megnyitni a fájlt: $!"; # fájl megnyitása

while ($line = <FH>) { # fájl olvasása
    foreach $word (split(/\W+/, $line)) { # sorok vágása szavakra
        $word = lc($word); # kisbetűvé alakítás
        $count++ if $word eq $user_word; # számláló inkrementálása, keresett szó találat esetén
    }
}

close(FH); # fájl bezárása

print "A(z) '$user_word' szó megjelenéseinek száma a szövegben: $count\n"; # kiírás