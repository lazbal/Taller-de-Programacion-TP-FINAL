using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using CapaEntidad;
using System.Net;

namespace CapaVisual
{
    /// <summary>
    /// Ventana para crear/verificar una fuente RSS.
    /// </summary>
    public partial class ComprobarRSSFeed : Form
    {
        //Atributos
        private RSSFeed iRSSFeed;
        private ICollection<RSSItem> iListaItems;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="pRSSFeed">Fuente RSS a ser creada/verificada.</param>
        public ComprobarRSSFeed(RSSFeed pRSSFeed) : base()
        {
            InitializeComponent();
            //Se actualza la barra de estado.
            sbStatusRSS.Items.Add("Preparado!");
            iRSSFeed = pRSSFeed;
            //Sí es una modificación, entonces la URL no es nula, por lo que se carga en el campo de URL.
            if (iRSSFeed.URL != null)
            {
                tbURL.Text = iRSSFeed.URL;
            }
        }

        /// <summary>
        /// Se requirió la lectura de la URL.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Desactivar boton actualizar.
            btnActualizar.Enabled = false;
            //Actualizar barra de estado.
            sbStatusRSS.Items[0].Text = "Comprobando fuente RSS.";
            //Limpiar grilla.
            dgDatos.Rows.Clear();
            //Comprobar si el trabajador de segundo plano está ocupado
            if (!bgWorkerRSS.IsBusy)
            {
                //Realizar la tarea de lectura del RSSFeed en segundo plano.
                this.bgWorkerRSS.RunWorkerAsync(this.tbURL.Text);
            }
            else
            {
                MessageBox.Show("En este momento no es posible realizar la operación. Intente nuevamente.", "Operacion Cancelada");
                btnActualizar.Enabled = true;
            }
        }

        /// <summary>
        /// Realización de la lectura del RSSFeed.
        /// </summary>
        private void bgWorkerRSS_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Se le pide a la fachada que lea la fuente rss para verificar que funcion
                IEnumerable<RSSItem> mListaItems = FachadaCapaVisual.LeerRSS((string)e.Argument);
                //Se devuelve la lista como resultado del trabajo en segundo plano.
                e.Result = mListaItems;
            }
            //En caso de que el formato de la URL no sea correcto.
            catch (UriFormatException uriException)
            {
                sbStatusRSS.Items[0].Text = "Formato de URL incorrecto.";
                MessageBox.Show(uriException.Message,"Formato incorrecto");
                //Marcar el trabajo en segundo plano como cancelado.
                e.Cancel = true;
            }
            //En caso de que no se haya podido establecer conexión o la URL no sea de un RSSFeed.
            catch (WebException internetException)
            {
                sbStatusRSS.Items[0].Text = "No se pudo conectar a la fuente.";
                MessageBox.Show(internetException.Message,"Error de conexión");
                //Marcar el trabajo en segundo plano como cancelado.
                e.Cancel = true;
            }
            //En caso de que la URL esté vacía.
            catch (ArgumentNullException nullException)
            {
                MessageBox.Show(nullException.Message, "Valor nulo");
                //Marcar el trabajo en segundo plano como cancelado.
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                e.Cancel = true;
            }

        }

        /// <summary>
        /// Acciones a realizar cuando el trabajador en segundo plano haya finalizado.
        /// </summary>
        private void bgWorkerRSS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Hubo un error.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            //Se canceló la tarea.
            else if (e.Cancelled)
            {
                sbStatusRSS.Text = "Cancelado";
                btnActualizar.Enabled = true;
            }
            //Todo se realizó correctamente.
            else
            {
                //Se recupera la lista de ítems del trabajador.
                iListaItems = (ICollection<RSSItem>)e.Result;
                //Para cada ítem en la lista se lo agrega a la grilla.
                foreach (RSSItem item in iListaItems)
                {
                    string[] iNewRow = { item.Titulo, item.Cuerpo};
                    dgDatos.Rows.Add(iNewRow);
                }
                //Actualizar barra de estado.
                sbStatusRSS.Items[0].Text = ("Noticias Encontradas: " + dgDatos.Rows.Count.ToString());
                //Informarle al usuario que la fuente es válida y funciona.
                MessageBox.Show("La fuente RSS Funciona correctamente, ahora puede guardarla.", "Éxito!");
                //Ocultar el boton de actualizar y mostrar el boton aceptar para guardar los cambios.
                btnActualizar.Visible = false;
                btnAceptar.Visible = true;
            }
        }

        /// <summary>
        /// Aceptar y guardar los cambios.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Se le carga al RSSFeed la url proporcionada en la ventana.
            iRSSFeed.URL = tbURL.Text;
            iRSSFeed.UltimasNoticias.Clear();
            foreach (RSSItem item in iListaItems)
            {
                iRSSFeed.UltimasNoticias.Add(item);
            }
            this.DialogResult = DialogResult.OK;
            //Cerrar ventana.
            this.Close();
        }

        /// <summary>
        /// Cancelar y deshacer los cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //Cerrar ventana.
            this.Close();

        }

        /// <summary>
        /// Tareas a realizar durante el cierre de la ventana.
        /// </summary>
        private void NuevoRSS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Eliminar el trabajador de segundo plano.
            bgWorkerRSS.Dispose();
        }

        /// <summary>
        /// Acciones a realizar sí cambia la URL en la ventana.
        /// </summary>
        private void tbURL_TextChanged(object sender, EventArgs e)
        {
            //Restablecer botones.
            btnAceptar.Visible = false;
            btnActualizar.Visible = true;
            btnActualizar.Enabled = true;
        }
    }
}
