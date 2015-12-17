using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public interface IUsuario
    {
        int Id
        {
            get;
            set;
        }

        string Nombre
        {
            get;
            set;
        }

        string Direccion
        {
            get;
            set;
        }

        string Telefono
        {
            get;
            set;
        }

        string Usuario
        {
            get;
            set;
        }

        string Contrasena
        {
            get;
            set;
        }

        void Agregar();

        void Editar();

        void Eliminar();
    }
}
