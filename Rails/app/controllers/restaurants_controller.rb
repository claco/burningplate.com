class RestaurantsController < ApplicationController
  
  def index
    @title = 'Restaurants'
    @restaurants = Restaurant.all
  end
  
  def view
    @restaurant = Restaurant.find_by_id(params[:id])
    
    if @restaurant
      @title = @restaurant.name
    else
      @title = 'Restaurant Not Found'
      render :status => 404  
    end
  end
end
