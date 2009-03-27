package BurningPlate;

use strict;
use warnings;
use MojoX::Renderer::TT;

use base 'Mojolicious';

# This method will run for each request
sub dispatch {
    my ( $self, $c ) = @_;

    # Try to find a static file
    my $done = $self->static->dispatch($c);

    # Use routes if we don't have a response code yet
    $self->routes->dispatch($c) unless $done;

    # Nothing found, serve static file "public/404.html"
    unless ( $c->res->code ) {
        $self->static->serve( $c, '/404.html' );
        $c->res->code(404);
    }
}

# This method will run once at server start
sub startup {
    my $self = shift;

    # Use our own context class
    $self->ctx_class('BurningPlate::Context');

    # Use TT
    my $tt = MojoX::Renderer::TT->build(
        mojo             => $self,
        template_options => {
            WRAPPER   => 'wrapper.tt',
            VARIABLES => { name => 'Burning Plate' }
        }
    );
    $self->renderer->add_handler( tt => $tt );
    $self->renderer->default_format('tt');
    $self->renderer->types->type( 'tt' => 'text/html' );

    # Routes
    my $r = $self->routes;

    # Default route
    $r->route('/')->to( controller => 'home', action => 'index' )
      ->name('home');

    $r->route('/restaurants/:id')
      ->to( controller => 'restaurants', action => 'view' )
      ->name('restaurant');

    $r->route('/restaurants')
      ->to( controller => 'restaurants', action => 'index' )
      ->name('restaurants');

    $r->route->to( controller => 'home', action => 'not_found' );
}

sub db {
    return 'dddd';
}

1;
