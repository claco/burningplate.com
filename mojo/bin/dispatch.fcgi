#!/usr/bin/perl
use strict;
use warnings;
use FindBin;
use Mojo::Script::Fastcgi;

use lib "$FindBin::Bin/lib";
use lib "$FindBin::Bin/../lib";
use lib "$FindBin::Bin/../../lib";

$ENV{MOJO_APP} = 'BurningPlate';

my $fastcgi = Mojo::Script::Fastcgi->new;
$fastcgi->run(@ARGV);