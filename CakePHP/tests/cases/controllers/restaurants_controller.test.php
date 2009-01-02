<?php 
/* SVN FILE: $Id$ */
/* RestaurantsController Test cases generated on: 2008-12-30 21:12:20 : 1230690740*/
App::import('Controller', 'Restaurants');

class TestRestaurants extends RestaurantsController {
	var $autoRender = false;
}

class RestaurantsControllerTest extends CakeTestCase {
	var $Restaurants = null;

	function setUp() {
		$this->Restaurants = new TestRestaurants();
		$this->Restaurants->constructClasses();
	}

	function testRestaurantsControllerInstance() {
		$this->assertTrue(is_a($this->Restaurants, 'RestaurantsController'));
	}

	function tearDown() {
		unset($this->Restaurants);
	}
}
?>