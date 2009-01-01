<?php 
/* SVN FILE: $Id$ */
/* Cake schema generated on: 2008-12-30 20:12:13 : 1230688033*/
class BurningPlateSchema extends CakeSchema {
	var $name = 'BurningPlate';

	function before($event = array()) {
		return true;
	}

	function after($event = array()) {
	}

    public $restaurants = array(
        'id' => array('type'=>'integer', 'null' => false, 'default' => NULL, 'length' => 8, 'key' => 'primary'),
        'name' => array('type'=>'string', 'null' => true, 'default' => NULL, 'length' => 255),
        'created' => array('type' => 'datetime'),
        'updated' => array('type' => 'datetime'),
        'indexes' => array(
            'PRIMARY' => array('column' => 'id', 'unique' => 1),
            'RESTAURANT_NAME' => array('column' => 'name', 'unique' => 1)
        )
    );
}
?>