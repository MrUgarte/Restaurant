from django.core import paginator
from django.shortcuts import render, redirect, get_object_or_404
from .models import plato, Contacto
from .forms import ContactoForm, PlatoForm, CustomUserCreationForm
from django.contrib import messages
from django.core.paginator import Paginator
from django.http import Http404
from django.contrib.auth import authenticate, login
from django.contrib.auth.decorators import login_required, permission_required

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
            messages.success(request, "Enviado correctamente")
            return redirect(to="contacto")
        else:
            data["form"] = formulario
            
    return render(request, 'contacto.html', data)

def galeria(request):
    return render(request, 'galeria.html')

@permission_required('database.add_plato')
def agregar_producto(request):

    data = {
        'form': PlatoForm()
    }

    if request.method == 'POST':
        formulario = PlatoForm(data=request.POST, files=request.FILES)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, "Creado correctamente")
            return redirect(to="listar_productos")
        else:
            data["form"] = formulario

    return render(request,'administrador/productos/agregar.html', data)

@permission_required('database.view_plato')
def listar_productos(request):
    productos = plato.objects.all()
    page = request.GET.get('page', 1)

    try:
        paginator = Paginator(productos, 5)
        productos = paginator.page(page)
    except:
        raise Http404

    data = {
        'entity': productos,
        'paginator': paginator
    }

    return render(request,'administrador/productos/listar.html', data)

@permission_required('database.change_plato')
def modificar_producto(request, id):
    
    pla = get_object_or_404(plato, id=id)

    data = {
        'form': PlatoForm(instance=pla)
    }

    if request.method == 'POST':
       formulario = PlatoForm(data=request.POST, instance= pla ,files=request.FILES)
       if formulario.is_valid():
           formulario.save()
           messages.success(request, "Modificado correctamente")
           return redirect(to="listar_productos")
       else:
           data["form"] = formulario

    return render(request, 'administrador/productos/modificar.html',data)

@permission_required('database.delete_plato')
def eliminar_producto(request, id):
    
    producto = get_object_or_404(plato, id=id)
    producto.delete()
    messages.success(request, "Eliminado correctamente")
    return redirect(to="listar_productos")

def home_administrador(request):
    return render(request, 'administrador/home_administrador.html')

def listar_contactos(request):
    contactos = Contacto.objects.all()

    data = {
        'contactos': contactos
    }

    return render(request,'administrador/usuarios/listarContactos.html', data)


def eliminar_contacto(request, id):
    
    contacto = get_object_or_404(Contacto, id=id)
    contacto.delete()
    messages.success(request, "Eliminado correctamente")
    return redirect(to="listar_contactos")

def registro(request):

    data = {
        'form' : CustomUserCreationForm()
    }

    if request.method == 'POST':
        formulario = CustomUserCreationForm(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            user = authenticate(username=formulario.cleaned_data["username"], password=formulario.cleaned_data["password1"])
            login(request, user)
            messages.success(request, "Te has registrado correctamente")
            return redirect(to="home")
        data["form"] = formulario
    return render(request, 'registration/registro.html', data)