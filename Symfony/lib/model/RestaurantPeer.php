<?php

class RestaurantPeer extends BaseRestaurantPeer
{
    function getAll() {
        return RestaurantPeer::doSelect(new Criteria());
    }
    
    function getById($id) {
        return RestaurantPeer::retrieveByPk($id);
    }
}
