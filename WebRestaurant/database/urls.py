from django.urls import path
from .views import home,contacto,galeria, agregar_producto, listar_productos, modificar_producto, eliminar_producto, home_administrador, listar_contactos,eliminar_contacto

urlpatterns = [
    path('', home, name="home"),
    path('contacto/', contacto, name="contacto"),
    path('galeria/', galeria, name="galeria"),
    path('agregar-producto/', agregar_producto, name="agregar_producto"),
    path('listar-productos/', listar_productos, name="listar_productos"),
    path('modificar-producto/<id>/', modificar_producto, name="modificar-producto"),
    path('eliminar-producto/<id>/', eliminar_producto, name="eliminar-producto"),
    path('home-admin/', home_administrador, name="home_administrador"),
    path('listar-contactos/', listar_contactos, name="listar_contactos"),
    path('eliminar-contactos/<id>/', eliminar_contacto, name="eliminar-contacto"),
   
    
]
