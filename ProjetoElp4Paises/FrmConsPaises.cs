using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class FrmConsPaises : ProjetoElp4Paises.frmConsultas
    {
        frmCadPaises oFrmCadPaises;
        Paises oPais;
        CtrlPaises aCtrlPaises;
        public FrmConsPaises()
        {
            InitializeComponent();
            oFrmCadPaises = new frmCadPaises();
        }

        public override void Pesquisar()
        {
        }

        public override void Incluir()
        {
            oFrmCadPaises.LimpaTxt();
            oFrmCadPaises.ConhecaObjeto(oPais, aCtrlPaises);
            oFrmCadPaises.ShowDialog();
            this.CarregaLV();
        }

        public override void Excluir()
        {
            string aux;
            oFrmCadPaises.ConhecaObjeto(oPais, aCtrlPaises);
            oFrmCadPaises.LimpaTxt();
            oFrmCadPaises.CarregaTxt();
            oFrmCadPaises.BloquearTxt();
            aux = oFrmCadPaises.btnSalvar.Text;
            oFrmCadPaises.btnSalvar.Text = "Excluir";
            oFrmCadPaises.ShowDialog();
            oFrmCadPaises.DesbloquearTxt();
            oFrmCadPaises.btnSalvar.Text = aux;

        }

        public override void Alterar()
        {
            oFrmCadPaises.ConhecaObjeto(oPais, aCtrlPaises);
            oFrmCadPaises.LimpaTxt();
            oFrmCadPaises.CarregaTxt();
            oFrmCadPaises.ShowDialog();
        }
        protected override void CarregaLV()
        {
            ListV.Items.Clear();
            foreach (var oPais in aCtrlPaises.Listar())
            {

                ListViewItem item = new ListViewItem(Convert.ToString(oPais.Codigo));
                item.SubItems.Add(oPais.Pais);
                item.SubItems.Add(oPais.Sigla);
                item.SubItems.Add(oPais.Ddi);
                item.SubItems.Add(oPais.Moeda);
                ListV.Items.Add(item);
            }
        }

        public override void setFrmCadastro(object obj)
        {
            if (obj != null)
            {
                oFrmCadPaises = (frmCadPaises)obj;
            }
        }

        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null)
                oPais = (Paises)obj;
            if (ctrl != null)
                aCtrlPaises = (CtrlPaises)ctrl;
            this.CarregaLV();
        }

    } 
}
