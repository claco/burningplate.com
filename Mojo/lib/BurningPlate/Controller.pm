package BurningPlate::Controller;

use strict;
use warnings;

use base 'Mojolicious::Controller';
use BurningPlate::Schema;

my $db;

sub db {
    if ( !$db ) {
        $db =
          BurningPlate::Schema->connect('dbi:SQLite:db/development.db');
    }

    return $db;
}

sub model {
    my $self = shift;
    my $name = (ref $self) =~ /\:\:(.*)$/ ? $1 : '';

    return $self->db->resultset($name);
}

1;
