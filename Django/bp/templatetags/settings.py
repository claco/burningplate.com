from django.conf import settings
from django import template
from django.template import Node

register = template.Library()

class NameNode(Node):
    def render(self, context):
        return settings.NAME

def name(parser, token):
    return NameNode()
name = register.tag(name)