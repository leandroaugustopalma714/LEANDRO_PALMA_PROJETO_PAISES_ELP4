using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class frmConsEstados : ProjetoElp4Paises.frmConsultas
    { 
        frmCadEstados  ofrmCadEstados;
        Estados oEstado;
        CtrlEstados aCtrlEstados;
        public frmConsEstados()
        {
            InitializeComponent();
            
        }
        public override void Pesquisar()
        {
        }

        public override void Incluir()
        {
            ofrmCadEstados.LimpaTxt();
           // ofrmCadEstados = new frmCadEstados();
            ofrmCadEstados.ConhecaObjeto(oEstado, aCtrlEstados);
            ofrmCadEstados.ShowDialog();
            this.CarregaLV();
        }

        public override void Excluir()
        {
            
            string aux;
            ofrmCadEstados.ConhecaObjeto(oEstado, aCtrlEstados);
            ofrmCadEstados.LimpaTxt();
            ofrmCadEstados.CarregaTxt();
            ofrmCadEstados.BloquearTxt();
            aux = ofrmCadEstados.btnSalvar.Text;
            ofrmCadEstados.btnSalvar.Text = "Excluir";
            ofrmCadEstados.ShowDialog();
            ofrmCadEstados.DesbloquearTxt();
            ofrmCadEstados.btnSalvar.Text = aux;
        }

        public override void Alterar()
        {
            ofrmCadEstados.ConhecaObjeto(oEstado, aCtrlEstados);
            ofrmCadEstados.CarregaTxt();
            ofrmCadEstados.ShowDialog();
        }
        protected override void CarregaLV()
        {

            foreach (var oEstado in aCtrlEstados.Listar())
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oEstado.Codigo));
                item.SubItems.Add(oEstado.Estado);
                item.SubItems.Add(oEstado.UF);
                item.SubItems.Add(Convert.ToString(oEstado.OPais.Codigo));
                item.SubItems.Add(oEstado.OPais.Pais);

                ListV.Items.Add(item);
            }
        }
        public override void setFrmCadastro(object obj)
        {
            if (obj != null)
            {
                ofrmCadEstados = (frmCadEstados)obj;
            }
        }

        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null)
                oEstado = (Estados)obj;
            if (ctrl != null)

                aCtrlEstados = (CtrlEstados)ctrl;
            this.CarregaLV();
        }

    }

}

