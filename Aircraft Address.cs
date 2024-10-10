using System;

namespace DI
{
    // Clase hija que hereda de DataItem
    class AircraftAddress : DataItem
    {
        // Constructor que inicializa las variables utilizando el constructor de la clase base
        public AircraftAddress(string category, int code, int length, string info)
            : base(category, code, info, length)
        {
            
        }


        // Implementación del método abstracto Descodificar
        public override void Descodificar()
        {
            int length = 24; //Cada octeto tiene 8 bits

            string address = base.info.Substring(length);
            // Convertir la direccion de binario a decimal
            int addressDecimal = Convert.ToInt32(address, 2);

            
            // Llamada al método EscribirEnFichero de la clase base
            EscribirEnFichero(Convert.ToString(addressDecimal) + ";");
        }
    }
}