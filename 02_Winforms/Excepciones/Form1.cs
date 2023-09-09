using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manejoExcepciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int resultado;
            try
            {
                resultado = calcular();
                lblResultado.Text = "= " + resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado, contactar a tu dev.");
            }
            finally
            {

            }
        }

        private int calcular()
        {
            int a, b, r;
            try
            {
                a = int.Parse(txtUno.Text);
                b = int.Parse(txtDos.Text);
                r = a / b;
                return r;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
