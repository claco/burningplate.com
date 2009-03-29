package BurningPlate::Controller;

use strict;
use warnings;

use base 'Mojolicious::Controller';
use FindBin              ();
use Path::Class          ();
use BurningPlate::Schema ();

my $db;

sub db {
    if ( !$db ) {
        my $bin  = $FindBin::Bin;
        my $path = Path::Class::dir($bin)->parent;
        my $file = Path::Class::file( $path, 'db', 'development.db' );

        $db = BurningPlate::Schema->connect("dbi:SQLite:$file");
    }

    return $db;
}

sub model {
    my $self = shift;
    my $name = ( ref $self ) =~ /\:\:(.*)$/ ? $1 : '';

    return $self->db->resultset($name);
}

1;
