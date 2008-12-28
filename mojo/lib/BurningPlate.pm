package BurningPlate;

use strict;
use warnings;

use base 'Mojo';

sub handler {
    my ($self, $tx) = @_;

    # $tx is a Mojo::Transaction instance
    $tx->res->code(200);
    $tx->res->headers->content_type('text/plain');
    $tx->res->body('Hello Mojo!');

    return $tx;
}

1;
