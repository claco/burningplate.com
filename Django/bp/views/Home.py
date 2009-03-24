# Create your views here.
from django.shortcuts import render_to_response

def index(request):
    title = 'Home'
    return render_to_response('index.html', locals())

def default(request):
    title = 'Resource Not Found'
    response = render_to_response('errors/404.html', locals())
    response.status_code = 404
    return response