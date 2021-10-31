from typing import ContextManager
from .forms import CustomUserCreationForm
from django.shortcuts import redirect, render
from django.views.generic import View
from django.shortcuts import render
from django.contrib.auth import authenticate, login


# Create your views here.
class ClienteListViews(View):
    def get(self, request, *args, **kwargs):
        context={
            
        }   
        
        # FORMULARIO DE REGISTRO
        data ={  
            'form':CustomUserCreationForm() 
        }   
        
        if request.method == 'POST':
            formulario = CustomUserCreationForm(data=request.POST)
            if formulario.is_valid():
                formulario.save()
                user = authenticate(username=formulario.cleaned_data["username"],password=formulario.cleaned_data["password1"])
                return redirect(to="login")
        
        return render(request, 'registro.html', data)