using System;

namespace DI
{
    // Clase hija que hereda de DataItem
    class Communications_Capability_Flight_Status : DataItem
    {
        // Constructor que inicializa las variables utilizando el constructor de la clase base
        public Comm_Cap_Fli_Status(string category, int code, int length, string info)
            : base(category, code, info, length)
        {
            
        }


        // Implementación del método abstracto Descodificar
        public override void Descodificar()
        {
            int fields [9] = [3,3,1,1,1,1,1,1,4]; //el tamaño de cada campo
            string aux;
            int position=0;
            for (int i = 0; i < 9; i++){
                aux = base.infoSubstring(position,fields[i])
                if (i==0) { COMM_Lecture(aux); }
                else if (i==1) { STAT_Lecture(aux); }
                else if (i==2) { SI_Lecture(aux); }
                else if (i==4) { MSSC_Lecture (aux); }
                else if (i==5) { ARC_Lecture(aux); }
                else if (i==6) { AIC_Lecture(aux); }
                else if (i==7) {B1A_Lecture(aux); }
                else if (i==8) {B1B_Lecture(aux); }

                position=position+fields[i];
            }
        }
        private void COMM_Lecture(string aux){
            int auxDecimal = Convert.ToInt32(aux,2);
            if (auxDecimal == 0){ aux="No communications capability (surveillance only)"; }
            else if (auxDecimal == 1){ aux="Comm. A and Comm. B capability"; }
            else if (auxDecimal == 2){ aux="Comm. A, Comm. B and Uplink ELM"; }
            else if (auxDecimal == 3){ aux="Comm. A, Comm. B, Uplink ELM and Downlink ELM"; } 
            else if (auxDecimal == 4){ aux="Level 5 Transponder capability"; }
            else if (auxDecimal >= 5 || auxDecimal <= 7){ aux="Not assigned"; }
            else { aux = "ERROR"; }

            EscribirEnFichero(aux + ";");
        } 
        private void STAT_Lecture(string aux){
            int auxDecimal = Convert.ToInt32(aux,2);
            if (auxDecimal == 0){ aux="No alert, no SPI, aircraft airborne"; }
            else if (auxDecimal == 1){ aux="No alert, no SPI, aircraft on ground"; }
            else if (auxDecimal == 2){ aux="Alert, no SPI, aircraft airborne"; }
            else if (auxDecimal == 3){ aux="Alert, no SPI, aircraft on ground"; } 
            else if (auxDecimal == 4){ aux="Alert, SPI, aircraft airborne or on ground"; }
            else if (auxDecimal == 5){ aux="No alert, SPI, aircraft airborne or on ground"; }
            else if (auxDecimal == 6){ aux="Not assignet"; }
            else if (auxDecimal == 7) { aux="Unknown"; }
            else { aux="ERROR"; }

            EscribirEnFichero(aux + ";");
        } 
        private void SI_Lecture(string aux){
            int auxDecimal = Convert.ToInt32(aux,2);
            if (auxDecimal == 0) { aux="SI-Code Capable"; }
            else if (auxDecimal == 1) { aux="II-Code Capable"; }
            else { aux="ERROR"; }

            EscribirEnFichero(aux + ";");
        }
        private void MSSC_Lecture(string aux){
            int auxDecimal = Convert.ToInt32(aux,2);
            if (auxDecimal == 0) { aux="No"; }
            else if (auxDecimal == 1) { aux="Si"; }
            else { aux="ERROR"; }

            EscribirEnFichero(aux + ";");
        }
        private void ARC_Lecture(string aux){
            int auxDecimal = Convert.ToInt32(aux,2);
            if (auxDecimal == 0) { aux="100 ft resolution"; }
            else if (auxDecimal == 1) { aux="25 ft resolution"; }
            else { aux="ERROR"; }

            EscribirEnFichero(aux + ";");
        }
        private void AIC_Lecture(string aux){
            int auxDecimal = Convert.ToInt32(aux,2);
            if (auxDecimal == 0) { aux="No"; }
            else if (auxDecimal == 1) { aux="Si"; }
            else { aux="ERROR"; }

            EscribirEnFichero(aux + ";");
        }
        private void B1A_Lecture(string aux){
            int auxDecimal = Convert.ToInt32(aux,2);
            if (auxDecimal == 0) { aux="Don't read bit 16"; }
            else if (auxDecimal == 1) { aux="Read bit 16"; }
            else { aux="ERROR"; }

            EscribirEnFichero(aux + ";");
        }
        private void B1B_Lecture(string aux){
            int auxDecimal = Convert.ToInt32(aux,2);
            if (auxDecimal == 0) { aux="Don't read bit 37"; }
            else if (auxDecimal == 1) { aux="Read bit 37"; }
            else if (auxDecimal == 2) { aux="Don't read bit 38"; }
            else if (auxDecimal == 3) { aux="Read bit 38"; }
            else if (auxDecimal == 4) { aux="Dont't read bit 39"; }
            else if (auxDecimal == 5) { aux="Read bit 39"; }
            else if (auxDecimal == 6) { aux="Dont't read bit 40"; }
            else if (auxDecimal == 7) { aux="Read bit 40"; }
            else { aux="ERROR"; }

            EscribirEnFichero(aux + ";");
        }
    }
}