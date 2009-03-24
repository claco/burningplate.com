from django.conf.urls.defaults import *
from views import Home, Restaurants

urlpatterns = patterns('',
    url(r'^$', Home.index, name='home'),
    url(r'restaurants/$', Restaurants.index, name='restaurants'),
    url(r'restaurants/(.*)$', Restaurants.view, name='restaurant'),
    url(r'.*', Home.default, name='404')
)
