package BurningPlate::Model::DB;

use strict;
use base 'Catalyst::Model::DBIC::Schema';

__PACKAGE__->config(
    schema_class => 'BurningPlate::Schema',
);

=head1 NAME

BurningPlate::Model::DB - Catalyst DBIC Schema Model
=head1 SYNOPSIS

See L<BurningPlate>

=head1 DESCRIPTION

L<Catalyst::Model::DBIC::Schema> Model using schema L<BurningPlate::Schema>

=head1 AUTHOR

Christopher Laco

=head1 LICENSE

This library is free software, you can redistribute it and/or modify
it under the same terms as Perl itself.

=cut

1;
