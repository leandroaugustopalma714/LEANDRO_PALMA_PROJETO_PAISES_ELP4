 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class frmCadEstados : ProjetoElp4Paises.frmCadastros
    {
        Estados oEstado;
        CtrlEstados aCtrlEstados;
        CtrlPaises aCtrlPaises;
        FrmConsPaises ofrmConsPaises;
        public frmCadEstados()
        {
            InitializeComponent();
        }

        public void setFrmConsPaises(object obj)
        {
            if (obj != null)
            {
                ofrmConsPaises = (FrmConsPaises)obj;
            }
        }
        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null) 
                oEstado = (Estados)obj;
            if (ctrl != null)
               aCtrlEstados = (CtrlEstados)ctrl;
        }
        public override void Salvar()
        {
            //if (MessageDlg("CONFIRMA S/N?") == "S")
            oEstado.Estado = txtEstado.Text;
            oEstado.UF = txtUF.Text;
            oEstado.OPais.Pais = txtPais.Text;
            oEstado.Codigo = Convert.ToInt32(txtCodigo.Text);
            // aCtrl.Salvar(oEstado);    
            MessageBox.Show(aCtrlEstados.Salvar(oEstado));


        }

        public override void CarregaTxt()
        {
            this.txtCodigo.Text = Convert.ToString(oEstado.Codigo);
            this.txtEstado.Text = oEstado.Estado;
            this.txtUF.Text = oEstado.UF;
            this.txtPais.Text = oEstado.OPais.Pais;
        }

        public override void LimpaTxt()
        {
            this.txtCodigo.Text = "0";
            this.txtEstado.Clear();
            this.txtUF.Clear();
           // this.txtPais.Clear();

        }

        public override void BloquearTxt()
        {
            this.txtCodigo.Enabled = false;
            this.txtEstado.Enabled = false;
            this.txtUF.Enabled = false;
            this.txtPais.Enabled = false;
            this.txtCodigoPais.Enabled = false;

        }

        public override void DesbloquearTxt()
        {
            this.txtCodigo.Enabled = true;
            this.txtEstado.Enabled = true;
            this.txtUF.Enabled = true;
            this.txtPais.Enabled = true;
            this.txtCodigoPais.Enabled = true;

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string btnSair = ofrmConsPaises.btnSair.Text;
            ofrmConsPaises.btnSair.Text = "Selecionar";
            ofrmConsPaises.ConhecaObjeto(oEstado.OPais, aCtrlPaises);
            ofrmConsPaises.ShowDialog();
            this.txtCodigoPais.Text = Convert.ToString(oEstado.OPais.Codigo);
            this.txtPais.Text = oEstado.OPais.Pais.ToString();
            ofrmConsPaises.btnSair.Text = btnSair;
        }

        private void txtCodigoPais_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
