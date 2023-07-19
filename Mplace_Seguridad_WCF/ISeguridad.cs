using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Mplace_Seguridad_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISeguridad" in both code and config file together.
    [ServiceContract]
    public interface ISeguridad
    {

        [OperationContract]
        UsuarioDto Registrar(UsuarioDto usuarioDto);

        [OperationContract]
        List<RolDto> ConsultarRoles();

        [OperationContract]
        bool Login(UsuarioDto usuario);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
