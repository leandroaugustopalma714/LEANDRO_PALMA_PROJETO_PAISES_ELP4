using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class frmCadastros : ProjetoElp4Paises.Frm
    {
        public frmCadastros()
        {
            InitializeComponent();
        }

        public virtual void Salvar()
        {

        }

        public virtual void CarregaTxt()
        {

        }

        public virtual void LimpaTxt()
        {

        }

        public virtual void BloquearTxt()
        {

        }

        public virtual void DesbloquearTxt()
        {

        }
        public void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
            Sair();
        }

        protected void txtDataCad_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCadastros_Load(object sender, EventArgs e)
        {

        }

        protected void txtUltAlt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }
    }
}
