# Generated by Django 3.2.9 on 2021-11-04 05:59

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('database', '0002_plato_imagen'),
    ]

    operations = [
        migrations.AlterField(
            model_name='plato',
            name='imagen',
            field=models.ImageField(null=True, upload_to='media/platos'),
        ),
    ]
