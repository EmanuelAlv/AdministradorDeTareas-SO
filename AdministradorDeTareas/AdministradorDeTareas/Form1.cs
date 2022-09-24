using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministradorDeTareas
{
    public partial class Form1 : MetroFramework.Forms.MetroForm // llamado al form1 con la labreria MetroModernUI
    {
        public Form1()
        {
            InitializeComponent();
            UpdateProcessList();
        }
        private void UpdateProcessList()
        {
            dgvAdministrador.Rows.Clear();
            foreach (Process p in Process.GetProcesses())
            {
                //Aqui se llenan los datos del sistema en el data grid
                int n = dgvAdministrador.Rows.Add();
                dgvAdministrador.Rows[n].Cells[0].Value = p.ProcessName;
                dgvAdministrador.Rows[n].Cells[1].Value = p.Id;
                dgvAdministrador.Rows[n].Cells[2].Value = DarFormato((p.WorkingSet64 / 1024).ToString()); //Envia como argumentos los p. a la funcion DarFormato
                dgvAdministrador.Rows[n].Cells[3].Value = DarFormato((p.VirtualMemorySize64 / 1024).ToString()); //Envia como argumentos los p. a la funcion DarFormato
                dgvAdministrador.Rows[n].Cells[4].Value = p.SessionId;
            }
            txtContador.Text = "Procesos Actuales: " + dgvAdministrador.Rows.Count.ToString(); // Imprime en el label la cantidad de procesos corriendo
        }
        //Funcion para dar formato a los numeros que se muestran en memoria fisica y virtual
        private string DarFormato(string mb)
        {
            string mbFinal = "";
            //Numeros con un digito
            if (mb.Length <= 4)
            {
                int x = 0;
                foreach (char a in mb)
                {
                    if (x == 1)
                    {
                        mbFinal = mbFinal + "." + a;
                    }
                    else
                    {
                        if (x == (mb.Length - 1))
                        {
                            mbFinal = mbFinal + a;
                            mbFinal = mbFinal.Substring(0, mbFinal.Length - 1);
                            Console.WriteLine(mbFinal);
                            return mbFinal + " MB";
                        }
                        else
                        {
                            mbFinal = mbFinal + a;

                        }

                    }
                    x++;
                }
            }
            //Numeros con dos digitos
            if (mb.Length > 4)
            {
                int x = 0;
                foreach (char a in mb)
                {
                    if (x == 2)
                    {
                        mbFinal = mbFinal + "." + a;
                    }
                    else
                    {
                        if (x == (mb.Length - 1))
                        {
                            mbFinal = mbFinal + a;
                            mbFinal = mbFinal.Substring(0, mbFinal.Length - 3);
                            //Console.WriteLine(mbFinal);
                            return mbFinal + " MB";
                        }
                        else
                        {
                            mbFinal = mbFinal + a;
                        }
                    }
                    x++;
                }
            }
            return "00.00 MB";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateProcessList(); //Llama a la funcion que actualiza los procesos
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string  proceso = txtProceso.Text = dgvAdministrador.CurrentRow.Cells[0].Value.ToString();
            foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName == proceso) //Si el proces name es igual al procesos seleccionado. Procede a eliminarlo
                    {
                        p.Kill(); //Eliminamos el proceso
                        UpdateProcessList();
                        MessageBox.Show("Proceso eliminado");
                    }
                    /*else //Si no hay ningun proceso seleccionado. Mostrara un mensaje de error
                    {
                        MessageBox.Show("Error al detener.  Selecciona un proceso.");
                        return;
                    }*/
                }
            UpdateProcessList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el form del programa
        }

        private void dgvAdministrador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProceso.Text = dgvAdministrador.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtProceso_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreProceso_Click(object sender, EventArgs e)
        {

        }
    }
}
