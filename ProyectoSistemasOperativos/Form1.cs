using EjemploHilos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoSistemasOperativos
{
    public partial class Form1 : Form
    {
        private OsoYAbejas osoYAbejas;
        public int cap = 0;
        private bool tarroLleno = false;
        private bool osoComiendo = false;
        public Form1()
        {
            InitializeComponent();
            btnFinalizar.Click += btnFinalizar_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void determinaCapacidadTarro(int c)
        {
            cap = c;
        }

        public void actualizarCapacidadTarro(string capacidad)
        {
            if (cantidadTarro.InvokeRequired)
            {
                cantidadTarro.Invoke((MethodInvoker)delegate
                {
                    cantidadTarro.Text = capacidad;
                });
            }
            else
            {
                cantidadTarro.Text = capacidad;
            }


            if (cap <= 25)
            {
                tarroLleno = true;
                osoYAbejas.Formulario.CambiarImagenAbejas("C:\\Users\\Gera\\Desktop\\ProyectoOS\\ProyectoSistemasOperativos\\ProyectoSistemasOperativos\\img\\abejaVolando.gif");
                osoYAbejas.Formulario.CambiarImagenTarro("C:\\Users\\Gera\\Desktop\\ProyectoOS\\ProyectoSistemasOperativos\\ProyectoSistemasOperativos\\img\\miel-unscreen.gif");
            }
            else if (osoComiendo)
            {
                osoYAbejas.Formulario.CambiarImagenAbejas(""); // Vacía el nombre de la imagen para ocultar la abeja
                osoYAbejas.Formulario.CambiarImagenTarro(""); // Vacía el nombre de la imagen para ocultar el tarro
            }
        }

        public void actualizarEstadoOso(string edo)
        {
            if (cantidadTarro.InvokeRequired)
            {
                cantidadTarro.Invoke((MethodInvoker)delegate
                {
                    cantidadTarro.Text = edo;
                });
            }
            else
            {
                cantidadTarro.Text = edo;
            }

            if (edo == "Oso se despierta")
            {
                osoComiendo = true;
                osoYAbejas.Formulario.CambiarImagenOso("C:\\Users\\Gera\\Desktop\\ProyectoOS\\ProyectoSistemasOperativos\\ProyectoSistemasOperativos\\img\\osoComiendo.gif");
                if (!tarroLleno)
                {
                    //osoYAbejas.Formulario.CambiarImagenFondo("C:\\Users\\Gera\\Desktop\\ProyectoOS\\ProyectoSistemasOperativos\\ProyectoSistemasOperativos\\img\\fondo.png");
                    osoYAbejas.Formulario.CambiarImagenAbejas("C:\\Users\\Gera\\Desktop\\ProyectoOS\\ProyectoSistemasOperativos\\ProyectoSistemasOperativos\\img\\abejaVolando.gif");
                    osoYAbejas.Formulario.CambiarImagenTarro("C:\\Users\\Gera\\Desktop\\ProyectoOS\\ProyectoSistemasOperativos\\ProyectoSistemasOperativos\\img\\miel-unscreen.gif");
                }
            }
            else
            {
                osoComiendo = false;
                osoYAbejas.Formulario.CambiarImagenOso(""); // Vacía el nombre de la imagen para ocultar el oso
                osoYAbejas.Formulario.CambiarImagenAbejas(""); // Vacía el nombre de la imagen para ocultar la abeja
                osoYAbejas.Formulario.CambiarImagenTarro(""); // Vacía el nombre de la imagen para ocultar el tarro
            }
        }

        public void actualizarEstadoAbejas(string estado)
        {
            if (cantidadTarro.InvokeRequired)
            {
                cantidadTarro.Invoke((MethodInvoker)delegate
                {
                    cantidadTarro.Text = estado;
                });
            }
            else
            {
                cantidadTarro.Text = estado;
            }

            if (estado == "Abejas continúan con su trabajo")
            {
                osoYAbejas.Formulario.CambiarImagenAbejas("C:\\Users\\Gera\\Desktop\\ProyectoOS\\ProyectoSistemasOperativos\\ProyectoSistemasOperativos\\img\\abejaVolando.gif");
                osoYAbejas.Formulario.CambiarImagenTarro("C:\\Users\\Gera\\Desktop\\ProyectoOS\\ProyectoSistemasOperativos\\ProyectoSistemasOperativos\\img\\miel-unscreen.gif");
            }
        }

        public void imprimeTamTarro(string tam)
        {
            if (cantidadTarro.InvokeRequired)
            {
                cantidadTarro.Invoke((MethodInvoker)delegate
                {
                    tamTarro.Text = tam;
                });
            }
            else
            {
                tamTarro.Text = tam;
            }
        }

        public void imprimeCantidadDeAbejas(string cant)
        {
            if (cantidadTarro.InvokeRequired)
            {
                cantidadTarro.Invoke((MethodInvoker)delegate
                {
                    numAbejas.Text = cant;
                });
            }
            else
            {
                numAbejas.Text = cant;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Crea una instancia de la clase OsoYAbejas
            osoYAbejas = new OsoYAbejas();
            osoYAbejas.Formulario = this;
        }
        public void CambiarImagenAbejas(string nombreImagen)
        {
            if (string.IsNullOrEmpty(nombreImagen))
            {
                if (pictureBoxAbejas.InvokeRequired)
                {
                    pictureBoxAbejas.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxAbejas.Image = null;
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                        pictureBox3.Image = null;
                        pictureBox4.Image = null;
                        pictureBox5.Image = null;
                        pictureBox6.Image = null;
                        pictureBox7.Image = null;
                        pictureBox8.Image = null;
                    });
                }
                else
                {
                    pictureBoxAbejas.Image = null;
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    pictureBox4.Image = null;
                    pictureBox5.Image = null;
                    pictureBox6.Image = null;
                    pictureBox7.Image = null;
                    pictureBox8.Image = null;
                }
            }
            else
            {
                if (pictureBoxAbejas.InvokeRequired)
                {
                    pictureBoxAbejas.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxAbejas.Image = Image.FromFile(nombreImagen);
                        pictureBox1.Image = Image.FromFile(nombreImagen);
                        pictureBox2.Image = Image.FromFile(nombreImagen);
                        pictureBox3.Image = Image.FromFile(nombreImagen);
                        pictureBox4.Image = Image.FromFile(nombreImagen);
                        pictureBox5.Image = Image.FromFile(nombreImagen);
                        pictureBox6.Image = Image.FromFile(nombreImagen);
                        pictureBox7.Image = Image.FromFile(nombreImagen);
                        pictureBox8.Image = Image.FromFile(nombreImagen);
                    });
                }
                else
                {
                    pictureBoxAbejas.Image = Image.FromFile(nombreImagen);
                    pictureBox1.Image = Image.FromFile(nombreImagen);
                    pictureBox2.Image = Image.FromFile(nombreImagen);
                    pictureBox3.Image = Image.FromFile(nombreImagen);
                    pictureBox4.Image = Image.FromFile(nombreImagen);
                    pictureBox5.Image = Image.FromFile(nombreImagen);
                    pictureBox6.Image = Image.FromFile(nombreImagen);
                    pictureBox7.Image = Image.FromFile(nombreImagen);
                    pictureBox8.Image = Image.FromFile(nombreImagen);
                }
            }
        }

        public void CambiarImagenTarro(string nombreImagen)
        {
            if (string.IsNullOrEmpty(nombreImagen))
            {
                if (pictureBoxTarro.InvokeRequired)
                {
                    pictureBoxTarro.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxTarro.Image = null;
                    });
                }
                else
                {
                    pictureBoxTarro.Image = null;
                }
            }
            else
            {
                if (pictureBoxTarro.InvokeRequired)
                {
                    pictureBoxTarro.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxTarro.Image = Image.FromFile(nombreImagen);
                    });
                }
                else
                {
                    pictureBoxTarro.Image = Image.FromFile(nombreImagen);
                }
            }
        }

        public void CambiarImagenOso(string nombreImagen)
        {
            if (string.IsNullOrEmpty(nombreImagen)) // Verifica si la cadena está vacía o nula
            {
                // Si la cadena está vacía, establece la imagen del PictureBox como nula para ocultarla
                if (pictureBoxOso.InvokeRequired)
                {
                    pictureBoxOso.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxOso.Image = null;
                    });
                }
                else
                {
                    pictureBoxOso.Image = null;
                }
            }
            else
            {
                // Si se proporciona una ruta de acceso válida, carga la imagen normalmente
                if (pictureBoxOso.InvokeRequired)
                {
                    pictureBoxOso.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxOso.Image = Image.FromFile(nombreImagen);
                    });
                }
                else
                {
                    pictureBoxOso.Image = Image.FromFile(nombreImagen);
                }
            }
        }

        private void edoOso_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cantidadTarro_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
