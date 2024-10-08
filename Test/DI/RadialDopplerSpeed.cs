using System;

namespace DI
{
    // Clase hija que hereda de DataItem
    class RadialDopplerSpeed : DataItem
    {
        // Constructor que inicializa las variables utilizando el constructor de la clase base
        public RadialDopplerSpeed(string category, int code, int length, string info)
            : base(category, code, info, length)
        {

        }

        // Implementación del método abstracto Descodificar
        public override void Descodificar()
        {
            //primero separaremos todos los valores y luego los decodificaremos
            string CAL = base.info.Substring(0, 1);
            if (CAL == '0')
            {
                CAL = "Absence of Subfield #1";
            }
            else
            {
                    string D = base.info.Substring(9, 1);
                    if (D == '0')
                    {
                        D = "Doppler speed is valid";
                    }
                    else
                    {
                        D = "Doppler speed is doubtful";
                    }

                    string Spare = base.info.Substring(10, 5);
                    if (Spare == '0')
                    {
                        Spare = "Doppler speed is valid";
                    }
                    else
                    {
                        Spare = "Doppler speed is doubtful";
                    }

                    int CAL_num = Convert.ToInt32(base.info.Substring(16, 9), 2); // mal esta en complement a 2 --> ho he de fer, present esta
                    CAL = Convert.ToString(CAL_num);
            }
            string RDS = base.info.Substring(1, 1);
            if (RDS == '0')
            {
                RDS = "Absence of Subfield #2";
            }
            else
            {
                string REP = Convert.ToString(Convert.ToInt32(base.info.Substring(9, 8), 2));
                string DOP = Convert.ToString(Convert.ToInt32(base.info.Substring(17, 15), 2));
                string AMB = Convert.ToString(Convert.ToInt32(base.info.Substring(33, 15), 2));
                string FRQ = Convert.ToString(Convert.ToInt32(base.info.Substring(49, 15), 2));
            }
            //string Spare = base.info.Substring(2, 5);
            //if (Spare == '00000')
            //{
            //    Spare = "Absence of Subfield";
            //}
            //else
            //{
            //    Spare = "Presence of Subfield";
            //}
            //string FX = base.info.Substring(7, 1);
            //EscribirEnFichero(CAL + ";" + RDS + ";" + Spare + ";");

}
