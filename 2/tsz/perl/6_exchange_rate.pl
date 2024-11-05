#!/usr/bin/perl
use strict;
use warnings;
use LWP::Simple;
# sajnos nem találtam olyan oldalt, ahol lelehet kérdezni ingyenesen végtelenszer, de ez a kód megfelelő lenne arra
my $api_url = 'https://open.er-api.com/v6/latest/USD'; # json formátumú pénznemek közötti átváltás

while (1) { # végtelen ciklus
    my $content = get($api_url); # tartalom megszerzése

    if (defined $content) { # ellenőrzés
        if ($content =~ /"HUF":([\d.]+)/) { # regex Forint keresés
            my $usd_value = $1; # Forint kiválasztás

            printf("1 USD = %.4f HUF\n", $usd_value);  # Forint kiírása
        } else {
            print "Nem található\n"; # ha nem találja a Forintot
        }
    } else {
        print "Lekérdezési hiba.\n"; # hiba a lekérdezésnél
    }
    sleep(10); # 10 mp a várakozás következő lekérés előtt
}
