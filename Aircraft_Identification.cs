using System;

namespace DI
{
    // Clase hija que hereda de DataItem
    class AircraftIdentification : DataItem
    {
        // Constructor que inicializa las variables utilizando el constructor de la clase base
        public AircraftId(string category, int code, int length, string info)
            : base(category, code, info, length)
        {
            
        }


        // Implementación del método abstracto Descodificar
        public override void Descodificar()
        {
            int length = 6; //Cada caracter tiene 6 bits

            for(int position = 0; position<= 48; position=position+length) {
                string aux = base.info.Substring(position, length);
                int auxInt = Convert.ToInt32(aux,2);
                EscribirEnFichero(Convert.ToString(auxInt) + ";");
            }
        }
    }
}