using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class FrmConsCidades : ProjetoElp4Paises.frmConsultas
    {  
        frmCadCidades ofrmCadCidades;
        Cidades aCidade;
        CtrlCidades aCtrlCidades;
        public FrmConsCidades()
        {
            InitializeComponent();
           // ofrmCadCidades = new frmCadCidades(); 
        }
        public override void Pesquisar()
        {
        }

        public override void Incluir()
        {
            ofrmCadCidades.LimpaTxt();
            ofrmCadCidades.ConhecaObjeto(aCidade, aCtrlCidades);
            ofrmCadCidades.ShowDialog();
            this.CarregaLV();
        }

        public override void Excluir()
        {
            string aux;
            ofrmCadCidades.ConhecaObjeto(aCidade, aCtrlCidades);
            ofrmCadCidades.LimpaTxt();
            ofrmCadCidades.CarregaTxt();
            ofrmCadCidades.BloquearTxt();
            aux = ofrmCadCidades.btnSalvar.Text;
            ofrmCadCidades.btnSalvar.Text = "Excluir";
            ofrmCadCidades.ShowDialog();
            ofrmCadCidades.DesbloquearTxt();
            ofrmCadCidades.btnSalvar.Text = aux;
        }

        public override void Alterar()
        {
            ofrmCadCidades.ConhecaObjeto(aCidade, aCtrlCidades);
            ofrmCadCidades.CarregaTxt();   
            ofrmCadCidades.ShowDialog();
        }
        protected override void CarregaLV()
        {
            ListV.Items.Clear();

            foreach (var aCidade in aCtrlCidades.Listar())
            {

                ListViewItem item = new ListViewItem(Convert.ToString(aCidade.Codigo));
                item.SubItems.Add(aCidade.Cidade);
                item.SubItems.Add(aCidade.DDD);
                item.SubItems.Add(Convert.ToString(aCidade.OEstado.Codigo));
                item.SubItems.Add(aCidade.OEstado.Estado);

                ListV.Items.Add(item);
            }
        }
        public override void setFrmCadastro(object obj)
        {
            if (obj != null)
            {
                ofrmCadCidades = (frmCadCidades)obj;
            }
        }

        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null)
                aCidade = (Cidades)obj;
            if (ctrl != null)
                aCtrlCidades = (CtrlCidades)ctrl;
            this.CarregaLV();
        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
