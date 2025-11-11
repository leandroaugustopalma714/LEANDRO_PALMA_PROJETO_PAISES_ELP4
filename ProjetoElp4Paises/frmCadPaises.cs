using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class frmCadPaises : ProjetoElp4Paises.frmCadastros
    {
         Paises oPais;
        CtrlPaises aCtrlPaises;
        public frmCadPaises()
        {
            InitializeComponent();
        }
        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null) 
                oPais = (Paises)obj;
            if (ctrl != null) 
                aCtrlPaises = (CtrlPaises)ctrl;    
        }
        public override void Salvar()
        {
           //if (MessageDlg("CONFIRMA S/N?") == "S")
                oPais.Codigo = Convert.ToInt32(txtCodigo.Text);
                oPais.Pais = txtPais.Text;
                oPais.Sigla = txtsigla.Text;
                oPais.Ddi = txtDDI.Text;
                oPais.Moeda = txtMoeda.Text;
               // MessageBox.Show("salvo");
                MessageBox.Show(aCtrlPaises.Salvar(oPais));

            //aCtrl.Salvar(oPais);    

        }

        public override void CarregaTxt()
        {
            this.txtCodigo.Text = Convert.ToString(oPais.Codigo); 
            this.txtPais.Text = oPais.Pais;
            this.txtsigla.Text = oPais.Sigla;
            this.txtDDI.Text = oPais.Ddi;
            this.txtMoeda.Text = oPais.Moeda;
        }

        public override void LimpaTxt()
        {
            this.txtCodigo.Text = " 0 "; //ALTEREI 08/11 testando //VOLTEO PRA 0 10/11
            this.txtPais.Clear();
            this.txtsigla.Clear();
            this.txtDDI.Clear();
            this.txtMoeda.Clear();

        }

        public override void BloquearTxt()
        {
            this.txtPais.Enabled = false;
            this.txtsigla.Enabled = false;
            this.txtDDI.Enabled = false;
            this.txtMoeda.Enabled = false;

        }

        public override void DesbloquearTxt()
        {
            this.txtPais.Enabled = true;
            this.txtsigla.Enabled = true;
            this.txtDDI.Enabled = true;
            this.txtMoeda.Enabled=true;
        }

        public void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmCadPaises_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblPais_Click(object sender, EventArgs e)
        {

        }

        private void txtMoeda_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
