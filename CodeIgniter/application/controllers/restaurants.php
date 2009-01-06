<?php

class Restaurants extends Controller {

	function Restaurants()
	{
		parent::Controller();
		$this->load->model('RestaurantsModel', '', TRUE);
	}
	
	function index()
	{
	    $data['title'] = 'Restaurants';
	    $data['restaurants'] = $this->RestaurantsModel->get_all();
	    $this->layout->view('restaurants/index', $data);
	}

    function view($id)
    {
        $restaurant = $this->RestaurantsModel->get_by_id($id);

        if ($restaurant) {
            $data['title'] = $restaurant->name;
            $data['restaurant'] = $restaurant;
        } else {
            header("HTTP/1.1 404 Not Found");
            $data['title'] = 'Restaurant Not Found';
            $data['restaurant'] = null;
        }
	    $this->layout->view('restaurants/view', $data); 
    }
}
