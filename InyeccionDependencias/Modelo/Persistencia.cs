using InyeccionDependencias.Modelo.Interface;

namespace InyeccionDependencias.Modelo
{
    public class Persistencia
    {
        private readonly IRFabrica _fabrica;
        private DataContexto _contexto;
        public Persistencia(IRFabrica fabrica)
        {
                _fabrica = fabrica;
        }
        public DataContexto Contexto 
        {
            get => _contexto ?? (_contexto = _fabrica.CrearContexto());
            set => _contexto = value;
        }
    }
}
