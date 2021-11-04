from django.db import models

# Create your models here.

class plato(models.Model):
    nombre=models.CharField(max_length=50)
    precio=models.IntegerField()
    descripcion=models.TextField()
    imagen = models.ImageField(upload_to="media/platos", null=True)

    def __str__(self) :
        return self.nombre