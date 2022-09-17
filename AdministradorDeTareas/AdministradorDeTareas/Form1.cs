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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
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
                dgvAdministrador.Rows[n].Cells[2].Value = DarFormato((p.WorkingSet64 / 1024).ToString());
                dgvAdministrador.Rows[n].Cells[3].Value = DarFormato((p.VirtualMemorySize64 / 1024).ToString());
                dgvAdministrador.Rows[n].Cells[4].Value = p.SessionId;
            }
            txtContador.Text = "Procesos Actuales: " + dgvAdministrador.Rows.Count.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
