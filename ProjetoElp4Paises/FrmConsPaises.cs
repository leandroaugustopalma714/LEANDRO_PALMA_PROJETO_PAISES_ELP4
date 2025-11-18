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
            // 1. Verifica se 'oPais' foi preenchido pelo clique
            if (oPais == null || oPais.Codigo == 0)
            {
                MessageBox.Show("Por favor, selecione um país na lista para excluir.", "Nenhum item selecionado");
                return;
            }

            // 2. Pede confirmação
            if (MessageBox.Show($"Tem certeza que deseja excluir o país: {oPais.Pais}?",
                                "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // 3. Manda o controlador excluir
                    aCtrlPaises.Excluir(oPais);

                    MessageBox.Show("País excluído com sucesso!");

                    // 4. Atualiza o ListView (lendo da coleção em memória)
                    this.CarregaLV();
                    oPais = new Paises(); // Limpa o objeto
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (ListV.SelectedItems.Count > 0)
            {
                try
                {
                    string idSelecionado = ListV.SelectedItems[0].SubItems[0].Text;
                    int id = Convert.ToInt32(idSelecionado);

                    // Agora o 'aCtrlPaises.Carregar(id)' vai funcionar!
                    oPais = aCtrlPaises.Carregar(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao selecionar o item: " + ex.Message);
                    oPais = new Paises();
                }
            }
        }
    } 
}
