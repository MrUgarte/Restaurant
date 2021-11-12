from django.shortcuts import render
from .models import plato
from .forms import ContactoForm, PlatoForm

# Create your views here.
def home(request):
    platos = plato.objects.all()
    data = {
        'platos': platos
    }
    return render(request, 'home.html',data)

def contacto(request):
    
    data = {
        'form': ContactoForm()
    }

    if request.method == 'POST':
        formulario = ContactoForm(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            data["mensaje"] = "contacto guardado"
        else:
            data["form"] = formulario
            
    return render(request, 'contacto.html', data)

def galeria(request):
    return render(request, 'galeria.html')

def agregar_producto(request):

    data = {
        'form': PlatoForm()
    }

    if request.method == 'POST':
        formulario = PlatoForm(data=request.POST, files=request.FILES)
        if formulario.is_valid():
            formulario.save()
            data["mensaje"] = "guardado correctamente"
        else:
            data["form"] = formulario

    return render(request,'administrador/productos/agregar.html', data)


def listar_productos(request):
    productos = plato.objects.all()

    data = {
        'productos': productos
    }

    return render(request,'administrador/productos/listar.html', data)