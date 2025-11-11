using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class frmCadCidades : ProjetoElp4Paises.frmCadastros
    {
        Cidades aCidade;
        CtrlCidades aCtrlCidades;
        CtrlEstados aCtrlEstados;
        frmConsEstados ofrmConsEstados;
        public frmCadCidades()
        {
            InitializeComponent();
        }
        public void setFrmConsEstados(object obj)
        {
            if (obj != null)
            {
                ofrmConsEstados = (frmConsEstados)obj;
            }
        }
        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null) 
            aCidade = (Cidades)obj;
            if (ctrl != null)
                aCtrlCidades = (CtrlCidades)ctrl;
        }
        public override void Salvar()
        {
            //if (MessageDlg("CONFIRMA S/N?") == "S")
            aCidade.Cidade = txtCidade.Text;
            aCidade.DDD =  txtDDD.Text;
            aCidade.OEstado.Estado = txtEstado.Text;
            aCidade.Codigo = Convert.ToInt32(txtCodigo.Text);

            // aCtrl.Salvar(aCidade);    
            MessageBox.Show(aCtrlCidades.Salvar(aCidade));

        }

        public override void CarregaTxt()
        {
            this.txtCodigo.Text = Convert.ToString(aCidade.Codigo);
            this.txtCidade.Text = Convert.ToString(aCidade.Cidade);
            this.txtDDD.Text = Convert.ToString(aCidade.DDD);
            this.txtEstado.Text = aCidade.OEstado.Estado;
        }

        public override void LimpaTxt()
        {
            
            this.txtCodigo.Text = "0";
            this.txtCidade.Clear();
            this.txtDDD.Clear();
            //this.txtEstado.Clear();

        }

        public override void BloquearTxt()
        {
            this.txtCodigo.Enabled = false;
            this.txtCidade.Enabled = false;
            this.txtDDD.Enabled = false;
            this.txtEstado.Enabled = false;
            this.txtCodigoEstado.Enabled = false;

        }

        public override void DesbloquearTxt()
        {
            this.txtCodigo.Enabled = true; 
            this.txtCidade.Enabled = true;
            this.txtDDD.Enabled = true;
            this.txtEstado.Enabled = true;
            this.txtCodigoEstado.Enabled = true;

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1(object sender, EventArgs e)
        {

        }

        private void txtCodigoPais_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string btnSair = ofrmConsEstados.btnSair.Text;
            ofrmConsEstados.btnSair.Text = "Selecionar";
            ofrmConsEstados.ConhecaObjeto(aCidade.OEstado, aCtrlEstados);
            ofrmConsEstados.ShowDialog();
            this.txtCodigoEstado.Text = Convert.ToString(aCidade.OEstado.Codigo);
            this.txtEstado.Text = aCidade.OEstado.Estado.ToString();
            ofrmConsEstados.btnSair.Text = btnSair;
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
