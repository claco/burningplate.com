#!/usr/bin/env python
import sys
#sys.path += ['django_src']
sys.path += ['django_project']
from fcgi import WSGIServer
from django.core.handlers.wsgi import WSGIHandler
import os
os.environ['DJANGO_SETTINGS_MODULE'] = 'settings'
WSGIServer(WSGIHandler()).run()

