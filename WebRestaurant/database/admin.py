from django.contrib import admin
from .models import plato
# Register your models here.

class PlatoAdmin(admin.ModelAdmin):
    list_display = ["nombre","precio","descripcion","imagen"]
    search_fields = ["nombre"]

admin.site.register(plato, PlatoAdmin)