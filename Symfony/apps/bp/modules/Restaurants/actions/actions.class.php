<?php

/**
 * Restaurants actions.
 *
 * @package    .
 * @subpackage Restaurants
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 12479 2008-10-31 10:54:40Z fabien $
 */
class RestaurantsActions extends sfActions
{
 /**
  * Executes index action
  *
  * @param sfRequest $request A request object
  */
  public function executeIndex(sfWebRequest $request)
  {
      $this->getResponse()->setSlot('restaurants', RestaurantPeer::getAll());
  }
  
  public function executeView(sfWebRequest $request) {
      $id = $request->getParameter('id');
      $restaurant = RestaurantPeer::getById($id);
      
      if ($restaurant) {
          $this->getResponse()->setSlot('restaurant', $restaurant);
      } else {
          $this->getResponse()->setStatusCode(404);
      }
  }
}
