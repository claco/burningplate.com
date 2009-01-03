from django.db import models

# Create your models here.
class Restaurants(models.Model):
    name = models.CharField(max_length=255, blank=False, null=False,unique=True)
    created = models.DateTimeField(auto_now_add=True)
    updated = models.DateTimeField(auto_now=True)
