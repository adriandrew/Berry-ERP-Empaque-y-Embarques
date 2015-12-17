using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Negocio;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioProducto" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioProducto
    {
        [OperationContract]
        void Agregar(Producto p);

        [OperationContract]
        List<Producto> Listado();



    }
}
