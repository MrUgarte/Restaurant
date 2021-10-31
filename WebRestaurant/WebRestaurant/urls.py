from django.contrib import admin
from django.urls import path, include
from django.urls.conf import include
from .views import HomeView,ErrorView

urlpatterns = [
    path('admin/', admin.site.urls),
    path('', HomeView.as_view(), name="login"),
    path('cliente/',include('cliente.urls', namespace='cliente')),
    path('NoDispobile', ErrorView.as_view(), name="ERROR"),
]
