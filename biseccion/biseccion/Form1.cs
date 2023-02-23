using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biseccion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                this.pictureBox1.Focus();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public static void BloqueaNum(KeyPressEventArgs pE)
        {
            //Para obligar a que sólo se introduzcan números

            if (Char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar)) //permitir teclas de control como retroceso
            {
                pE.Handled = false;
            }
            else if (Char.IsWhiteSpace(pE.KeyChar)) //no permitir teclas de control como espacio
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '-')//permitir tecla -
            {
                pE.Handled = false;
            }
            else if (Char.IsPunctuation(pE.KeyChar))// no permitir teclas de puntuacion
            {
                pE.Handled = true;
            }
            else //el resto de teclas pulsadas se desactivan
            {
                pE.Handled = true;
            }
        }

        private void Limpiar()
        {
            txtXi.Clear();
            txtXu.Clear();
            txtN.Clear();
            txtEA.Clear();
            txtER.Clear();
            txtContador.Clear();
            txtResultados.Clear();
            txtXu.Focus();
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            try
            {

                Double xb, xa, xr, Fxa, Fxr, mult, ea=0, cif;
                int n, contador = 1;

                xa = Convert.ToDouble(txtXi.Text);
                xb = Convert.ToDouble(txtXu.Text);
                n = Convert.ToInt32(txtN.Text);
                cif = 1*  Math.Pow(10, -n);
                //Primera Vuelta
                xr = (xa + xb) / 2;
                Fxa = Math.Pow(xa, 10) - 1;
                Fxr = Math.Pow(xr, 10) - 1;
                mult = Fxa * Fxr;
                double er=((1-xr)/1)*100;

                while (ea <  cif)
                {
                    if (mult > 0) {
                        double xaActual = xa;
                        double xbActual = xr;

                        double xrActual = (xaActual + xbActual) / 2;
                        Fxa = Math.Pow(xaActual, 10) - 1;
                        Fxr = Math.Pow(xbActual, 10) - 1;
                        mult = Fxa * Fxr;
                        er = (((1 - xrActual) / 1) * 100);
                        ea = ((xrActual - xr) / 1 )*100;
                    }

                    else if (mult > 0)
                    {
                        double xaActual2 = xr;
                        double xbActual2 = xb;
                        double xrActual2 = (xaActual2 + xbActual2) / 2;
                        Fxa = Math.Pow(xaActual2, 10) - 1;
                        Fxr = Math.Pow(xbActual2, 10) - 1;
                        mult = Fxa * Fxr;
                        er = ((1 - xrActual2) / -1) * 100;
                        ea = ((xrActual2 - xr) / xrActual2) * 100;

                    }
                    contador++;
                    txtContador.Text = Convert.ToString(contador);
                    txtEA.Text = Convert.ToString(ea);
                    txtER.Text = Convert.ToString(er);

              }
            }
            catch (Exception ex) //bloque catch para captura de error
            {
                string error = ex.Message;
            }

        }

        private void txtContador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtXu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtXu_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloqueaNum(e);
        }

        private void txtXi_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloqueaNum(e);
        }

        private void txtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloqueaNum(e);
        }

        private void txtXu_Leave(object sender, EventArgs e)
        {
            if (txtXu.Text == "")
            {
                txtXu.Text = "1";
                txtXu.ForeColor = Color.White;
            }
        }

        private void txtXi_Leave(object sender, EventArgs e)
        {
            if (txtXi.Text == "")
            {
                txtXi.Text = "1";
                txtXi.ForeColor = Color.White;
            }
        }

        private void txtN_Leave(object sender, EventArgs e)
        {
            if (txtN.Text == "")
            {
                txtN.Text = "1";
                txtN.ForeColor = Color.White;
            }
        }
    }
}
