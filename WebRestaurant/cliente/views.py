from typing import ContextManager
from django.shortcuts import render
from django.views.generic import View
from django.shortcuts import render

# Create your views here.
class ClienteListViews(View):
    def get(self, request, *args, **kwargs):
        context={

        }   
        return render(request, 'registro.html', context)