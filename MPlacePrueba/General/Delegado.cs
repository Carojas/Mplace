using System;

namespace MPlacePrueba.General
{
    public class Delegado
    {
        
        public String DelegadoDevuelveString(int numero) 
        {
            if (numero > 0)
                return "El numero es mayor a cero";
            else if (numero < 0)
                return "El numero es menor a cero";
            else 
                return "El numero es cero"; 
        }
        public String DelegadoDevuelveSigno(int numero)
        {
            if (numero > 0)
                return "es positivo";
            else if (numero < 0)
                return "es negativo";
            else
                return "no es positivo ni negativo";
        }

        public String RealizarOperacionParImpar(int numero) 
        {
            if (numero % 2 == 0)
                return $"{numero} / {numero} = {numero / numero}";
            else
                return $"{numero} * {numero} = {numero * numero}";

        }
    }
}
