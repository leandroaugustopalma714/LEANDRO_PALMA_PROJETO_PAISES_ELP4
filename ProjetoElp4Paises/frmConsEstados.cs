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
        frmCadEstados ofrmCadEstados;
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

            // 1. Verifica se 'oEstado' foi preenchido pelo clique
            if (oEstado == null || oEstado.Codigo == 0)
            {
                MessageBox.Show("Por favor, selecione um Estado na lista para excluir.", "Nenhum item selecionado");
                return;
            }

            // 2. Pede confirmação
            if (MessageBox.Show($"Tem certeza que deseja excluir o estado: {oEstado.Estado}?",
                                "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // 3. Manda o controlador excluir
                    aCtrlEstados.Excluir(oEstado);

                    MessageBox.Show("País excluído com sucesso!");

                    // 4. Atualiza o ListView (lendo da coleção em memória)
                    this.CarregaLV();
                    oEstado = new Estados(); // Limpa o objeto
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        public override void Alterar()
        {
            ofrmCadEstados.ConhecaObjeto(oEstado, aCtrlEstados);
            ofrmCadEstados.CarregaTxt();
            ofrmCadEstados.ShowDialog();
        }
        protected override void CarregaLV()
        {
           ListV.Items.Clear();
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

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ListV.SelectedItems.Count > 0)
            {
                try
                {
                    string idSelecionado = ListV.SelectedItems[0].SubItems[0].Text;
                    int id = Convert.ToInt32(idSelecionado);

                    // Agora o 'aCtrlestados.Carregar(id)' vai funcionar!
                    oEstado = aCtrlEstados.Carregar(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao selecionar o item: " + ex.Message);
                    oEstado = new Estados();
                }
            }
        }
    }
}

