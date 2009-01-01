use strict;
use warnings;
use Test::More tests => 3;

BEGIN { use_ok 'Catalyst::Test', 'BurningPlate' }
BEGIN { use_ok 'BurningPlate::Controller::Restaurants' }

ok( request('/restaurants')->is_success, 'Request should succeed' );


