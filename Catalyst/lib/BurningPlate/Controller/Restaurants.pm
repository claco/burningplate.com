package BurningPlate::Controller::Restaurants;

use strict;
use warnings;
use parent 'Catalyst::Controller';

=head1 NAME

BurningPlate::Controller::Restaurants - Catalyst Controller

=head1 DESCRIPTION

Catalyst Controller.

=head1 METHODS

=cut

=head2 index 

=cut

sub index : Chained('/') PathPrefix Args(0) {
    my ( $self, $c ) = @_;
    my @restaurants = $c->model('Restaurants')->search->all;

    $c->stash->{'title'}       = 'Restaurants';
    $c->stash->{'restaurants'} = \@restaurants;
}

=head2 instance

=cut

sub instance : Chained('/') PathPrefix CaptureArgs(1) {
    my ( $self, $c, $id ) = @_;
    my $restaurant = $c->model('Restaurants')->find($id);

    if ($restaurant) {
        $c->stash->{'title'}      = $restaurant->name;
        $c->stash->{'restaurant'} = $restaurant;
    } else {
        $c->response->status(404);
        $c->stash->{'title'} = 'Restaurant Not Found';
    }
}

=head2 view

=cut

sub view : Chained('instance') PathPart('') Args(0) {

}

=head1 AUTHOR

Christopher Laco

=head1 LICENSE

This library is free software, you can redistribute it and/or modify
it under the same terms as Perl itself.

=cut

1;
