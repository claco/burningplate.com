package BurningPlate::Home;

use strict;
use warnings;

use base 'BurningPlate::Controller';

# This action will render a template
sub index {
    my $self = shift;

    $self->render;
}

1;
