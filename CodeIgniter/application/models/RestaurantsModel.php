<?php

class RestaurantsModel extends Model {
    var $table = 'restaurants';

    function RestaurantsModel()
    {
        parent::Model();
    }

    function get_all()
    {
        $query = $this->db->get($this->table);
        return $query->result();
    }
    
    function get_by_id($id) {
        $query = $this->db->get_where('restaurants', array('id' => $id));
        return $query->row();
    }
}