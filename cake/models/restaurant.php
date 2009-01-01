<?php
class Restaurant extends AppModel {

	var $name = 'Restaurant';
	var $useDbConfig = 'development';
	var $validate = array(
		'id' => array('numeric'),
		'name' => array('notEmpty'),
		'created' => array('date time'),
		'updated' => array('date time')
	);

}
?>