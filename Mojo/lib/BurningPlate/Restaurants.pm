package BurningPlate::Restaurants;

use strict;
use warnings;

use base 'BurningPlate::Controller';

# This action will render a template
sub index {
    my $self = shift;
    warn $self->table->count;
    
    $self->render;
}

sub view {
    my $self = shift;
    my $id = $self->stash->{'id'};
    my $restaurant = $self->table->find($id);

warn $id;
warn $restaurant->name;

    $self->render;
}

1;
