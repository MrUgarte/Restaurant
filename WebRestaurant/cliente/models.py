from django.db import models
import uuid #Se requiere para los pruductos unicos

# Creacion de modelos.
class Usuario(models.Model):
    user = models.CharField(max_length=100)
    password=models.CharField(max_length=100)
    Email=models.EmailField(max_length=200)
    
    def __str__(self):
        return self.user


class Productos(models.Model):
    ID_Producto=models.UUIDField(primary_key=True,default=uuid.uuid4,help_text='id unica para producto')
    Nombre_producto=models.CharField(max_length=100)
    Stock=models.IntegerField(blank=True,null=True)

    def __str__(self):
        return self.ID_Producto

