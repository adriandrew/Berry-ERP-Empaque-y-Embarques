using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioOptativa" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioOptativa
    {
        [OperationContract]
        void Agregar(Alumno a);
        [OperationContract]
        List<Alumno> Listado();
    }
}
