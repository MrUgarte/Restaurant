from django import forms
from django.forms import fields
from .models import Contacto, plato

class ContactoForm(forms.ModelForm):


    class Meta:
        model = Contacto
        #fields  = ["nombre", "correo", "tipo_consulta", "mensaje","avisos"]
        fields = '__all__'

class PlatoForm(forms.ModelForm):

    class Meta:
        model = plato
        fields = '__all__'