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
using CapaNegocio;

namespace LABOR_4
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guardarXMLProductos(string nombreTabla, string[] datos, DataTable informacion)
        {
            //Raiz del documento
            XmlDocument documento = new XmlDocument();
            XmlElement raiz = documento.CreateElement("CODEXA");
            documento.AppendChild(raiz);
            int localidad = 0;

            for (int i = 0; i < informacion.Rows.Count; i++)
            {

                //Agrega el elemento
                XmlElement elemento = documento.CreateElement(nombreTabla);
                raiz.AppendChild(elemento);

                //Agrega los datos 
                XmlElement idProducto = documento.CreateElement(datos[localidad]);
                idProducto.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(idProducto);
                localidad++;

                XmlElement descripcion = documento.CreateElement(datos[localidad]);
                descripcion.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(descripcion);
                localidad++;

                XmlElement precio = documento.CreateElement(datos[localidad]);
                precio.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(precio);
                localidad = 0;
            }
            documento.Save("C:/Users/franc/source/repos/LAB04-DIEGO/archivo" + nombreTabla + ".xml");
        }

        private void guardarXMLCompras(string nombreTabla, string[] datos, DataTable informacion)
        {
            //Raiz del documento
            XmlDocument documento = new XmlDocument();
            XmlElement raiz = documento.CreateElement("CODEXA");
            documento.AppendChild(raiz);
            int localidad = 0;

            for (int i = 0; i < informacion.Rows.Count; i++)
            {
                
                //Agrega el elemento
                XmlElement elemento = documento.CreateElement(nombreTabla);
                raiz.AppendChild(elemento);

                //Agrega los datos 
                XmlElement idCliente = documento.CreateElement(datos[localidad]);
                idCliente.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(idCliente);
                localidad++;

                XmlElement idProducto = documento.CreateElement(datos[localidad]);
                idProducto.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(idProducto);
                localidad++;

                XmlElement fechaCompra = documento.CreateElement(datos[localidad]);
                fechaCompra.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(fechaCompra);
                localidad=0;
            }
            documento.Save("C:/Users/franc/source/repos/LAB04-DIEGO/archivo" + nombreTabla + ".xml");
        }

        private void guardarXMLClientes(string nombreTabla, string[]datos,DataTable informacion)
        {
            //Raiz del documento
            XmlDocument documento = new XmlDocument();
            XmlElement raiz = documento.CreateElement("CODEXA");
            documento.AppendChild(raiz);
            int localidad = 0;

            for (int i = 0; i < informacion.Rows.Count; i++)
            {
                
                //Agrega el elemento
                XmlElement elemento = documento.CreateElement(nombreTabla);
                raiz.AppendChild(elemento);

                //Agrega los datos 
                XmlElement idCliente = documento.CreateElement(datos[localidad]);
                idCliente.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(idCliente);
                localidad++;

                XmlElement cedula = documento.CreateElement(datos[localidad]);
                cedula.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(cedula);
                localidad++;

                XmlElement nombre = documento.CreateElement(datos[localidad]);
                nombre.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(nombre);
                localidad++;

                XmlElement apellido = documento.CreateElement(datos[localidad]);
                apellido.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(apellido);
                localidad++;

                XmlElement fechaNac = documento.CreateElement(datos[localidad]);
                fechaNac.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(fechaNac);
                localidad++;

                XmlElement sexo = documento.CreateElement(datos[localidad]);
                sexo.AppendChild(documento.CreateTextNode(informacion.Rows[i][datos[localidad]].ToString()));
                elemento.AppendChild(sexo);
                localidad=0;
            }
            documento.Save("C:/Users/franc/source/repos/LAB04-DIEGO/archivo"+nombreTabla+".xml");
        }

        private void cargarDatosBD()
        {
            
            string tabla = cmbTablas.Text.ToString();
            if (tabla.Equals("Clientes"))
            {
                string[] datos = { "idCliente","cedula", "nombre", "apellido", "fechaNacimiento", "sexo" };
                DataTable informacionClientes = new DataTable();
                informacionClientes = consultar.consultaTodosElementos("clientes", datos);
                guardarXMLClientes(tabla,datos,informacionClientes);
            }
            if (tabla.Equals("Compras"))
            {
                string[] datos = { "idCliente", "idProducto", "fechaCompra" };
                DataTable informacionCompras = new DataTable();
                informacionCompras = consultar.consultaTodosElementos("compras", datos);
                guardarXMLCompras(tabla, datos, informacionCompras);
            }
            if (tabla.Equals("Productos"))
            {
                string[] datos = { "idProducto", "descripcion", "precio" };
                DataTable informacionProductos = new DataTable();
                informacionProductos = consultar.consultaTodosElementos("productos", datos);
                guardarXMLProductos(tabla, datos, informacionProductos);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cargarDatosBD();
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVista ventanaVista = new frmVista();
            ventanaVista.Visible = true;
        }
    }
}
