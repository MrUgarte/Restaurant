from django.shortcuts import render
from .models import plato

# Create your views here.
def home(request):
    platos = plato.objects.all()
    data = {
        'platos': platos
    }
    return render(request, 'home.html',data)

def contacto(request):
    return render(request, 'contacto.html')

def galeria(request):
    return render(request, 'galeria.html')

