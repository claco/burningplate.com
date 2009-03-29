package BurningPlate::Controller::Root;

use strict;
use warnings;
use parent 'Catalyst::Controller';

#
# Sets the actions in this controller to be registered with no prefix
# so they function identically to actions created in MyApp.pm
#
__PACKAGE__->config->{namespace} = '';

=head1 NAME

BurningPlate::Controller::Root - Root Controller for BurningPlate

=head1 DESCRIPTION

[enter your description here]

=head1 METHODS

=cut

=head2 index

=cut

sub index : Path : Args(0) {
    my ( $self, $c ) = @_;
    $c->stash->{'title'} = 'Home';
}

sub default : Path {
    my ( $self, $c ) = @_;
    $c->response->status(404);
    $c->stash->{'template'} = 'errors/404.tt';
    $c->stash->{'title'} = 'Resource Not Found';
}

=head2 end

Attempt to render a view, if needed.

=cut 

sub end : ActionClass('RenderView') {
}

=head1 AUTHOR

Christopher Laco

=head1 LICENSE

This library is free software, you can redistribute it and/or modify
it under the same terms as Perl itself.

=cut

1;
