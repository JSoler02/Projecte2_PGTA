using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        string CarpetaBusqueda;
        Computer usr = new Computer();

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            // Creació del cuadre per seleccionar carptea
            FolderBrowserDialog Carpeta = new FolderBrowserDialog();

            // Codi que s'executa al seleccionar una carpeta
            if (Carpeta.ShowDialog() == DialogResult.OK)
            {
                // Carpeta seleccionada
                CarpetaBusqueda = Carpeta.SelectedPath;

                // Verificació
                //MessageBox.Show(Carpeta.SelectedPath);
            }
            textBox1.Text= CarpetaBusqueda;

            if (CarpetaBusqueda !=null) {
                DirectoryInfo di = new DirectoryInfo(@CarpetaBusqueda);

                // Mostra els arxius de la carpeta selecionada
                foreach (var item in di.GetFiles()) { listBox1.Items.Add(item.Name); }
            }
           

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (CarpetaBusqueda == null){ MessageBox.Show("Falta seleccioanr una carpeta"); }
            else { Motor(CarpetaBusqueda); }
        }
        void Motor(string motor)
        {
            // Archivos
            for (int i = 0; i < Directory.EnumerateFiles(CarpetaBusqueda).Count(); i++)
            {
                FileInfo k = new FileInfo(Directory.GetFiles(CarpetaBusqueda)[i]);
                if (k.Name == textBox2.Text) { listBox1.Items.Add("Arxiu seleccionat: " + k.Name); Read(k.FullName); }
            }
            // Carpetas
            if (Directory.EnumerateDirectories(CarpetaBusqueda).Count() > 0)
            {
                for (int i = 0; i < Directory.EnumerateDirectories(CarpetaBusqueda).Count(); i++) { 
                    Motor(Directory.GetDirectories(CarpetaBusqueda)[i]);
                    if (i >= 5000)
                    {
                        MessageBox.Show("No s'ha trobat el arxiu");
                        break;
                    }
                }
            }
        }
        private void Read(string path)
        {
            try
            {
                MessageBox.Show("A");
                byte[] fileBytes = File.ReadAllBytes(path);

                // Validamos que el archivo tenga suficiente longitud para leer el contador.
                if (fileBytes.Length < 3)
                {
                    MessageBox.Show("El archivo es demasiado pequeño.");
                    return;
                }

                List<byte[]> listabyte = new List<byte[]>();
                int i = 0;
                int contador = fileBytes[2];

                while (i < fileBytes.Length)
                {
                    // Verificamos si hay suficiente espacio para el siguiente bloque
                    if (i + contador > fileBytes.Length)
                    {
                        MessageBox.Show("Acceso fuera de límites en el bloque.");
                        break;
                    }

                    byte[] array = new byte[contador];
                    for (int j = 0; j < array.Length; j++)
                    {
                        array[j] = fileBytes[i];
                        i++;
                    }
                    listabyte.Add(array);

                    // Asegúrate de que hay suficiente espacio para leer el nuevo contador
                    if (i + 2 < fileBytes.Length)
                    {
                        contador = fileBytes[i + 2];
                    }
                    else
                    {
                        break; // Salir si no hay suficiente espacio para leer el contador
                    }
                }

                // Convertimos los bloques a hexadecimal
                List<string> listahex = new List<string>();
                foreach (var buffer in listabyte)
                {
                    string hexString = BitConverter.ToString(buffer).Replace("-", " ");
                    listahex.Add(hexString);
                }

                // Mostrar el contenido hexadecimal en la consola
                Console.WriteLine("Contenido en Hexadecimal:");
                foreach (var hex in listahex) { Console.WriteLine(hex); }

                // Llamar a la función para escribir en el archivo
                string outputFilePath = Path.Combine(Environment.CurrentDirectory, "hexadecimal_output.txt");
                WriteHexToFile(outputFilePath, listahex);
                MessageBox.Show($"Hexadecimales escritos en {outputFilePath}");
                checkCAT(listahex,0);
                MessageBox.Show("B");
            }
            catch (Exception ex) { MessageBox.Show("Ocurrió un error al leer el archivo: " + ex.Message); }
        }

        private void WriteHexToFile(string fileName, List<string> hexList)
        {
            try { using (StreamWriter writer = new StreamWriter(fileName)) { foreach (var hex in hexList) { writer.WriteLine(hex); } } }
            catch (Exception ex) { MessageBox.Show("Ocurrió un error al escribir el archivo: " + ex.Message); }
        }
        int checkCAT(List<string> list, int i)
        {
            MessageBox.Show(list.Count.ToString());
            if (i < 0 || i >= list.Count - 1) { return -1; } 
            else
            {
                List<int> caracteresDecimales = new List<int>();
                foreach (var hex in list)
                {
                    // Asegurarse de que la cadena tenga al menos dos caracteres
                    if (hex.Length >= 2)
                    {
                        // Obtener cada carácter y convertirlo a decimal
                        caracteresDecimales.Add(Convert.ToInt32(hex[i].ToString())); // Primer carácter
                    }
                }
                MessageBox.Show(caracteresDecimales[7].ToString());
                if (caracteresDecimales[0] == 48) { return 1; }
                else if (caracteresDecimales[0] != 48) { return 0; }
                else { return -1; }
            }
           
           
        }
    }
    
}
