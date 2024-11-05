#!/usr/bin/perl
use strict;
use warnings;
my $version = 0.01;

sub print_help {
    print <<EOT;
Available commands:
  help - Show this help message
  exit - Exit the shell
  ls   - List files in the current directory
  man  - Display information about specific commands (e.g., "man cp")
EOT
}

sub print_prompt {
    print "ss> ";
}

MAIN: {
    print "Welcome to ss (Simple Shell) version $version\n",
          "Type: help for help\n";
    print_prompt();

    while (<>) {
        chomp;
        my $cmd = $_;

        if ($cmd =~ /^\s*help\s*$/) {
            print_help();
        }
        elsif ($cmd =~ /^\s*exit\s*$/) {
            exit;
        }
        elsif ($cmd =~ /^\s*ls\s*$/) {
            system("ls");
        }
        elsif ($cmd =~ /^\s*man\s+cp\s*$/) {
            print "file vagy mappa másolására szolgál\n";
        }
        elsif ($cmd =~ /^\s*man\s+\w+\s*$/) {
            print "ez meg nincs kész, dolgozunk rajta\n";
        }
        else {
            print "Command not recognized\n";
        }

        print_prompt();
    }
}
