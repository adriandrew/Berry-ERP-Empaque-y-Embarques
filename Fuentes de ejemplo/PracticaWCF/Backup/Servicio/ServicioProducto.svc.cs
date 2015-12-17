using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Negocio;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioProducto" en el código, en svc y en el archivo de configuración a la vez.
    public class ServicioProducto : IServicioProducto
    {
        public void Agregar(Producto p){
            p.Guardar();
        }

        public List<Producto> Listado() {
            return new Producto().Listado();
        }
    }
}
