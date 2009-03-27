package BurningPlate::Home;

use strict;
use warnings;

use base 'BurningPlate::Controller';

# This action will render a template
sub index {
    my $self = shift;
    $self->stash->{'title'} = 'Home';

    $self->render;
}

sub not_found {
    my $self = shift;
    $self->stash->{'title'} = 'Resource Not Found';
    $self->res->code(404);
    $self->render(template => 'errors/404.tt');
}

1;
