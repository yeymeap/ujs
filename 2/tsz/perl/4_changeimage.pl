#!/usr/bin/perl
print "Eredeti állapot: 1\nEgy képre átírás: 2\n"; # választási lehetőség
chomp($choice = <STDIN>); # levágás

while($choice != 1 && $choice != 2){ # bemenetkezelés
    print "Hibás bemenet\nEredeti állapot: 1\nEgy képre átírás: 2\n"; # választási lehetőség
    chomp($choice = <STDIN>); # levágás
}

$html_file = '4_index.html'; # fájlnév változó

if($choice == 1){ # elágazás
    $i = 1; # inkrementáló

    open($fh, '<', $html_file) or die "Nem sikerült megnyitni a fájlt: '$html_file' $!"; # fájl megnyitása
    @lines = <$fh>; # olvasás
    close($fh); # fájl bezárása
    
    open($out, '>', $html_file) or die "Nem sikerült megnyitni a fájlt: '$html_file' $!"; # fájl megnyitása
    
    foreach $line (@lines) { # minden sorra
        if($line =~ s{<img src="[^"]*"}{<img src="4_img/$i.jpg"}g){ # feltételvizsgálat
            $i++; # i inkrementálása, ha talált a képet
        }
        print $out $line; # írás
        
    }
    close($out); # fájl bezárása
        print "A képek át lettek írva az eredeti képekre.\n"

}

elsif($choice == 2){ # elágazás
    $new_image = '4_img/6.jpg'; # kiválasztott kép, melyre át van írva az összes kép

    open($fh, '<', $html_file) or die "Nem sikerült megnyitni a fájlt: '$html_file' $!"; # fájl megnyitása
    @lines = <$fh>; # olvasás
    close($fh); # fájl bezárása

    open($out, '>', $html_file) or die "Nem sikerült megnyitni a fájlt: '$html_file' $!"; # fájl megnyitása

    foreach $line (@lines) { # minden sorra
        $line =~ s{<img src="[^"]*"}{<img src="$new_image"}g; # átírás a választott képre
        print $out $line; # írás
    }

    close($out); # fájl bezárása
    print "A képek át lettek írva a kiválasztott képre '$new_image'.\n"}