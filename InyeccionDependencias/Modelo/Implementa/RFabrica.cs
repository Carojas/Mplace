using InyeccionDependencias.Modelo.Interface;

namespace InyeccionDependencias.Modelo.Implementa
{
    public class RFabrica : IRFabrica
    {
        public DataContexto CrearContexto() 
        {
            return new DataContexto();
        }
    }
}
