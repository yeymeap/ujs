$filename = 'emails.txt'; # fájlnév

open($fh, '<', $filename) or die "Nem sikerult megnyitni a fajlt: '$filename' $!"; # fájl nyitása

$email_regex = qr/([a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+\.[a-zA-Z]{2,}(?:\.[a-zA-Z]{2})?)/; #email regex

while (my $line = <$fh>) { # sorok olvasása
    chomp $line;  # újsor karakter eltávolítása

    my @emails = ($line =~ /$email_regex/g); # emailek megszerzése

    foreach my $email (@emails) { # emailek ellenőrzése
        print "Valid email: $email\n";
    }
}

close $fh; # fájl bezárása