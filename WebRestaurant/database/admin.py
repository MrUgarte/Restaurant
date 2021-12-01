from django.contrib import admin
from .models import plato, Contacto
from .forms import PlatoForm
# Register your models here.

class PlatoAdmin(admin.ModelAdmin):
    list_display = ["nombre","precio","descripcion","imagen"]
    search_fields = ["nombre"]
    form = PlatoForm

admin.site.register(plato, PlatoAdmin)
admin.site.register(Contacto)