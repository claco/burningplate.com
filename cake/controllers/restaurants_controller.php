<?php
class RestaurantsController extends AppController {

	var $name = 'Restaurants';
	var $helpers = array('Html', 'Form');
	var $components = array('RequestHandler');

	function index() {
		$this->Restaurant->recursive = 0;
		$this->set('restaurants', $this->paginate());
	}

	function view($id = null) {
		$data = $this->Restaurant->findById($id);

		if ($data) {
    		$this->set('restaurant', $this->Restaurant->read(null, $id));
    		$this->pageTitle = $data['Restaurant']['name'];		    
		} else {
            $this->pageTitle = 'Restaurant Not Found';
            $this->notFound();
		}
	}

#	function add() {
#		if (!empty($this->data)) {
#			$this->Restaurant->create();
#			if ($this->Restaurant->save($this->data)) {
#				$this->flash(__('Restaurant saved.', true), array('action'=>'index'));
#			} else {
#			}
#		}
#	}

#	function edit($id = null) {
#		if (!$id && empty($this->data)) {
#			$this->flash(__('Invalid Restaurant', true), array('action'=>'index'));
#		}
#		if (!empty($this->data)) {
#			if ($this->Restaurant->save($this->data)) {
#				$this->flash(__('The Restaurant has been saved.', true), array('action'=>'index'));
#			} else {
#			}
#		}
#		if (empty($this->data)) {
#			$this->data = $this->Restaurant->read(null, $id);
#		}
#	}

#	function delete($id = null) {
#		if (!$id) {
#			$this->flash(__('Invalid Restaurant', true), array('action'=>'index'));
#		}
#		if ($this->Restaurant->del($id)) {
#			$this->flash(__('Restaurant deleted', true), array('action'=>'index'));
#		}
#	}

}
?>