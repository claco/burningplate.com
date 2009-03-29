class Restaurants < Application

  def index
    @title = 'Restaurants'
    @restaurants = Restaurant.all

    render
  end
  
  def view(id)
    @restaurant = Restaurant.get(id)

    if @restaurant
      @title = @restaurant.name
      
      render
    else
      @title = 'Restaurant Not Found'

      render :status => 404
    end
  end
end
