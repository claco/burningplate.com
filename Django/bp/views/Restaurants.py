# Create your views here.
from django.http import Http404
from django.shortcuts import render_to_response
from bp.models import Restaurants

def index(request):
    title = 'Restaurants'
    restaurants = Restaurants.objects.all()
    return render_to_response('restaurants/index.html', locals())
    
def view(request, id):
    notFound = True
    title = 'Restaurant Not Found'

    if id.isdigit():
        try:
            restaurant = Restaurants.objects.get(id=id)
            title = restaurant.name
            notFound = False
        except Restaurants.DoesNotExist:
            notFound = True

    response = render_to_response('restaurants/view.html', locals())
    if notFound:
        response.status_code = 404
    return response
