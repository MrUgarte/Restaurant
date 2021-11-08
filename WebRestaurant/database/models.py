from django.db import models

# Create your models here.

class plato(models.Model):
    nombre=models.CharField(max_length=50)
    precio=models.IntegerField()
    descripcion=models.TextField()
    imagen = models.ImageField(upload_to="media/platos", null=True)

    def __str__(self) :
        return self.nombre


opciones_consultas = [
    [0, "consulta"],
    [1, "reclamo"],
    [2, "sugerencia"],
    [3, "felicitaciones"]
]

class Contacto(models.Model):
    nombre=models.CharField(max_length=50)
    correo = models.EmailField()
    tipo_consulta = models.IntegerField(choices=opciones_consultas)
    mensaje = models.TextField()
    aviso = models.BooleanField()

    def __str__(self):
        return self.nombre