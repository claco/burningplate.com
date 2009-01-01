<?php
class DATABASE_CONFIG {

	var $development = array(
		'driver' => 'sqlite',
		'persistent' => false,
		'host' => 'localhost',
		'login' => 'root',
		'password' => '',
		'database' => 'db/development.db',
		'encoding' => 'utf8'
	);

    var $production = array();

    var $default = array();

    function __construct() {
        $this->default = $this->development;
    }

    function DATABASE_CONFIG() {
        $this->__construct();
    }
}
?>