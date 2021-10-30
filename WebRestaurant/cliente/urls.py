from django.conf.urls import url
from django.urls import path
from django.urls.resolvers import URLPattern
from .views import ClienteListViews


app_name="cliente"

urlpatterns = [ 
    path('registro/',ClienteListViews.as_view(),name="registro")
]