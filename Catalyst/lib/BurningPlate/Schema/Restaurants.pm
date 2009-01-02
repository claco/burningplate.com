package BurningPlate::Schema::Restaurants;
use strict;
use warnings;
use base 'DBIx::Class';

__PACKAGE__->load_components(qw/InflateColumn::DateTime Core/);
__PACKAGE__->table('restaurants');
__PACKAGE__->add_columns(
    id => { data_type => 'INT', is_nullable => 0, is_auto_increment => 1 },
    name    => { data_type => 'VARCHAR',  is_nullable => 0, size => 255 },
    created => { data_type => 'DATETIME', is_nullable => 0 },
    updated => { data_type => 'DATETIME', is_nullable => 0 }
);
__PACKAGE__->set_primary_key('id');
__PACKAGE__->add_unique_constraint( [qw/name/] );

1;
