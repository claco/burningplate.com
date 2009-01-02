<?php

class Home extends Controller {

	function Home()
	{
		parent::Controller();	
	}
	
	function index()
	{
	    $data['title'] = 'Home';
	    $this->layout->view('home/index', $data);
	}
}
