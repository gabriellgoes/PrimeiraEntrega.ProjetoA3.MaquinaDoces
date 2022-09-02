using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiraEntrega.ProjetoA3.MaquinaDoces
{
    public partial class FrmMaquinaDoces : Form
    {
        public FrmMaquinaDoces()
        {
            InitializeComponent();
        }

        public struct Doce 
        {
            public bool DoceA { get; set; }

            public bool DoceB { get; set; }

            public bool DoceC { get; set; }

            //public Decimal? ValorDoceA { get; set; }

            //public Decimal? ValorDoceB { get; set; }

            //public Decimal? ValorDoceC { get; set; }
        }


        private void btnUmReal_Click(object sender, EventArgs e)
        {
            decimal valor = 1;
            var doce = new Doce();
            CalculaDoces(valor, doce);
        }

        private void btnDoisReais_Click(object sender, EventArgs e)
        {
            decimal valor = 2;

            var doce = new Doce();
            CalculaDoces(valor, doce);
        }

        private void btnCincoReais_Click(object sender, EventArgs e)
        {
            decimal valor = 5;
            var doce = new Doce();
            CalculaDoces(valor, doce);
        }
        
        public void CalculaDoces(decimal valor, Doce doce)
        {
            decimal valorExistente = Convert.ToDecimal(lblRetorno.Text);
            decimal total = 0;
            if (doce.DoceA)
            {
                total = valorExistente - 6;
                comprouDoce = true;
            }

            else if (doce.DoceB)
            {
                total = valorExistente - 7;
                comprouDoce = true;
            }
            else if (doce.DoceC)
            {
                total = valorExistente - 8;
                comprouDoce = true;
            }
            else total = valor + valorExistente;

            lblRetorno.Text = total.ToString();

            AtivaDoce();
        }
        bool comprouDoce = false;
        public void AtivaDoce()
        {
            decimal total = Convert.ToDecimal(lblRetorno.Text);
            
            if(total == 6)
            {
                btnDoceA.BackColor = Color.LightGreen;
                btnDoceA.Enabled = true;

            }
            else if(total == 7)
            {
                btnDoceA.BackColor = Color.LightGreen;
                btnDoceB.BackColor = Color.LightGreen;
                btnDoceA.Enabled = true;
                btnDoceB.Enabled = true;
            }
            else if(total >= 8)
            {
                btnDoceA.BackColor = Color.LightGreen;
                btnDoceB.BackColor = Color.LightGreen;
                btnDoceC.BackColor = Color.LightGreen;
                btnDoceA.Enabled = true;
                btnDoceB.Enabled = true;
                btnDoceC.Enabled = true;
            }
            else
            {
                ResetarCampos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(lblRetorno.Text.Equals("0"))
            {
                MessageBox.Show("Nenhuma operação foi executada.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                MessageBox.Show("O total devolvido será de: R$" + lblRetorno.Text + ",00", 
                    "COMPRA CANCELADA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetarCampos();
            }

            lblRetorno.Text = "0";

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            string valorTotal = lblRetorno.Text;


            if (!comprouDoce)
            {
                MessageBox.Show("Nenhuma operação foi executada.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                MessageBox.Show("Doces comprados! O seu troco será de: R$" + lblRetorno.Text + ",00",
                    "COMPRA CONCLUÍDA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetarCampos();
            }

            lblRetorno.Text = "0";

            ResetarCampos();
        }
        
        private void ResetarCampos()
        {
            btnDoceA.UseVisualStyleBackColor = true;
            btnDoceB.UseVisualStyleBackColor = true;
            btnDoceC.UseVisualStyleBackColor = true;

            btnDoceA.Enabled = false;
            btnDoceB.Enabled = false;
            btnDoceC.Enabled = false;
        }

        private void btnDoceA_Click(object sender, EventArgs e)
        {
            decimal valorRecebido = Convert.ToDecimal(lblRetorno.Text);
            var doce = new Doce();
            doce.DoceA = true;
            CalculaDoces(valorRecebido, doce);
        }

        private void btnDoceB_Click(object sender, EventArgs e)
        {
            decimal valorRecebido = Convert.ToDecimal(lblRetorno.Text);
            var doce = new Doce();
            doce.DoceB = true;
            CalculaDoces(valorRecebido, doce);
        }

        private void btnDoceC_Click(object sender, EventArgs e)
        {
            decimal valorRecebido = Convert.ToDecimal(lblRetorno.Text);
            var doce = new Doce();
            doce.DoceC = true;
            CalculaDoces(valorRecebido, doce);
        }
    }
}
