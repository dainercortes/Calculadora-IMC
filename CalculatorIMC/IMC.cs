using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorIMC
{
    class IMC
    {
        public float CalcularIMC(float peso, float altura)
        {
            return peso / (float)Math.Pow(altura, 2);
        }

        public string RangoIMC(string genero, float imc)
        {
            string rango = string.Empty;

            try
            {
                if (genero == "men")
                {
                    rango = (imc < 20) ? "bajo" :
                            (imc <= 24.9) ? "normal" :
                            (imc <= 29.9) ? "sobrepeso" :
                            (imc <= 34.9) ? "obecidad" : "obecidad extrema";
                }
                else if (genero == "women")
                {
                    rango = (imc < 19) ? "bajo" :
                            (imc <= 23.9) ? "normal" :
                            (imc <= 27.9) ? "sobrepeso" : 
                            (imc <= 30) ? "obecidad" : "obedicdad extrema";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rango;
        }

        public string RangoNormal(string genero)
        {
            return (genero == "men") ? "20 - 24.9" : "19 - 23.9";
        }
    }
}
