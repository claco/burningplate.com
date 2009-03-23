<?php
class Error extends Controller {
 
	function error_404()
	{
	    header("HTTP/1.1 404 Not Found");
        $data['title'] = 'Resource Not Found';
	    $this->layout->view('errors/404', $data);
	}
}