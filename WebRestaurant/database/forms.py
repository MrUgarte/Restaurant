from django import forms
from django.forms import fields
from .models import Contacto

class ContactoForm(forms.ModelForm):

    class Meta:
        model = Contacto
        #fields  = ["nombre", "correo", "tipo_consulta", "mensaje","avisos"]
        fields = '__all__'