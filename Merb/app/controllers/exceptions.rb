class Exceptions < Merb::Controller
  
  # handle NotFound exceptions (404)
  def not_found
    render :template => 'errors/404'
  end

  # handle NotAcceptable exceptions (406)
  def not_acceptable
    render :format => :html
  end

end