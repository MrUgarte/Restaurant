from django.shortcuts import render

# Create your views here.
def home(request):
    return render(request, 'home.html')

def contacto(request):
    return render(request, 'contacto.html')

def galeria(request):
    return render(request, 'galeria.html')

