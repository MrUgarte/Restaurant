from django import forms
from django.forms import fields
from .models import Contacto, plato
from django.contrib.auth.forms import UserCreationForm
from django.contrib.auth.models import User

class ContactoForm(forms.ModelForm):


    class Meta:
        model = Contacto
        #fields  = ["nombre", "correo", "tipo_consulta", "mensaje","avisos"]
        fields = '__all__'

class PlatoForm(forms.ModelForm):

    class Meta:
        model = plato
        fields = '__all__'

class CustomUserCreationForm(UserCreationForm):
    
    class Meta:
        model = User
        fields= ['username', 'first_name', 'last_name', 'email', 'password1', 'password2']