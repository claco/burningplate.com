# Create your views here.
from django.shortcuts import render_to_response

def index(request):
    title = 'Home'
    return render_to_response('index.html', locals())