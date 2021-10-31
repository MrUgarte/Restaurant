from django.db import models
import uuid #Se requiere para los pruductos unicos

# Creacion de modelos.
class Usuario(models.Model):
    user = models.CharField(max_length=100)
    password=models.CharField(max_length=100)
    Email=models.EmailField(max_length=200)


class Sesion(models.model):
    user = models.CharField(max_length=100)
    password=models.CharField(max_length=100)

    def _str_(self):
        return self.user

class Productos(models.model):
    ID_Producto=models.UUIDField(primary_key=True,default=uuid.uuid4,help_text='id unica para producto')
    Nombre_producto=models.CharField(max_length=100)
    Stock=models.IntegerField(blank=True,Null=True)

