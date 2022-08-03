using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LABOR_4
{
    public partial class frmVista : Form
    {
        public frmVista()
        {
            InitializeComponent();
        }

        private void cargarGridClientes(dynamic lista)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("idCliente", typeof(int));
            tabla.Columns.Add("cedula", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("apellido", typeof(string));
            tabla.Columns.Add("sexo", typeof(string));
            tabla.Columns.Add("fechaNac", typeof(string));

        }

        private void cargarClientes()
        {
            XmlTextReader xmlTextReader = new XmlTextReader("C:/Users/franc/source/repos/LAB04-DIEGO/archivoClientes.xml");
            string ultimaEtiqueta = "";
            string valor = "";
            dynamic listValores = new dynamic[6];
            dynamic listaGeneral=new dynamic[100];
            DataTable tabla = new DataTable();
            int i = 0;
            int pos = 0;
            tabla.Columns.Add("idCliente", typeof(int));
            tabla.Columns.Add("cedula", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("apellido", typeof(string));
            tabla.Columns.Add("sexo", typeof(string));
            tabla.Columns.Add("fechaNac", typeof(string));
            while (xmlTextReader.Read())
            {
                if (xmlTextReader.NodeType == XmlNodeType.Element)
                {
                    ultimaEtiqueta = xmlTextReader.Name;
                    continue;
                }
                if (xmlTextReader.NodeType == XmlNodeType.Text)
                {
                    if (i < 5)
                    {
                        valor = xmlTextReader.ReadContentAsString();
                        listValores[i] = valor;

                        i++;
                    }
                    else
                    {
                        //tabla.Rows.Add(listValores[pos], listValores[pos+1], listValores[pos+2], listValores[pos+3], listValores[pos+4], listValores[pos+5]);
                        
                        //dgvInformacion.Rows[0].Cells[1].Value = tabla.Rows[0]["idCliente"];
                        //listaGeneral[pos] = listValores;
                        pos++;
                        i = 0;

                    }


                }

            }
            xmlTextReader.Close();
            
            //cargarClientes(listaGeneral);
        }

        public void cargarGridEstudiantes(DataTable informacionEstudiantes)
        {
            dgvInformacion.Rows.Clear();
            for (int i = 0; i < informacionEstudiantes.Rows.Count; i++)
            {
                int indice = dgvInformacion.Rows.Add();
                dgvInformacion.Rows[indice].Cells[1].Value = informacionEstudiantes.Rows[i]["identificacion"];
                dgvInformacion.Rows[indice].Cells[2].Value = informacionEstudiantes.Rows[i]["nombre"];
                dgvInformacion.Rows[indice].Cells[3].Value = informacionEstudiantes.Rows[i]["promedio"];
                dgvInformacion.Rows[indice].Cells[3].Value = informacionEstudiantes.Rows[i]["fechaNacimiento"];
            }
        }

        private void frmVista_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }
    }
}
