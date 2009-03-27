package BurningPlate::Restaurants;

use strict;
use warnings;

use base 'BurningPlate::Controller';

# This action will render a template
sub index {
    my $self        = shift;
    my @restaurants = $self->model->all;

    $self->stash->{'title'}       = 'Restaurants';
    $self->stash->{'restaurants'} = \@restaurants;
    $self->render;
}

sub view {
    my $self       = shift;
    my $id         = $self->stash->{'id'};
    my $restaurant = $self->model->find($id);

    if ($restaurant) {
        $self->stash->{'title'}      = $restaurant->name;
        $self->stash->{'restaurant'} = $restaurant;
    } else {
        $self->stash->{'title'} = 'Restaurant Not Found';
        $self->res->code(404);
    }
    $self->render;
}

1;
