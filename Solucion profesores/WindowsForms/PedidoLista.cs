using DTOs;
using API.Clients;
using System;

namespace WindowsForms
{
    public partial class PedidoLista : Form
    {
        public PedidoLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            this.pedidosDataGridView.AutoGenerateColumns = false;
            
            this.pedidosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 80
            });
            
            this.pedidosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ClienteNombre",
                HeaderText = "Cliente",
                DataPropertyName = "ClienteNombre",
                Width = 200
            });
            
            this.pedidosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaPedido",
                HeaderText = "Fecha Pedido",
                DataPropertyName = "FechaPedido",
                Width = 225,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            this.pedidosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CantidadItems",
                HeaderText = "Productos",
                DataPropertyName = "CantidadItems",
                Width = 150,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            this.pedidosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Total",
                DataPropertyName = "Total",
                Width = 120,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private async void Pedidos_Load(object sender, EventArgs e)
        {
            await ConfigureButtonPermissions();
            await this.LoadPedidos();
        }

        private async Task ConfigureButtonPermissions()
        {
            var authService = AuthServiceProvider.Instance;
            
            // Verificar permisos para cada botón
            bool canAdd = await authService.HasPermissionAsync("pedidos.agregar");
            bool canUpdate = await authService.HasPermissionAsync("pedidos.actualizar");
            bool canDelete = await authService.HasPermissionAsync("pedidos.eliminar");
            
            // Configurar visibilidad de botones según permisos
            agregarButton.Visible = canAdd;
            actualizarButton.Visible = canUpdate;
            eliminarButton.Visible = canDelete;
            
            // Guardar permisos en Tag para uso posterior
            agregarButton.Tag = canAdd;
            actualizarButton.Tag = canUpdate;
            eliminarButton.Tag = canDelete;
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            PedidoDTO pedidoNuevo = new PedidoDTO();
            PedidoDetalle pedidoDetalle = new PedidoDetalle(FormMode.Add, pedidoNuevo);

            pedidoDetalle.ShowDialog();

            await this.LoadPedidos();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarControles();

                int id = this.SelectedItem().Id;
                PedidoDTO pedido = await PedidoApiClient.GetAsync(id);

                PedidoDetalle pedidoDetalle = new PedidoDetalle(FormMode.Update, pedido);
                pedidoDetalle.ShowDialog();

                await this.LoadPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            PedidoDTO pedido = this.SelectedItem();

            var result = MessageBox.Show($"¿Está seguro que desea eliminar el pedido #{pedido.Id} del cliente {pedido.ClienteNombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeshabilitarControles();
                    await PedidoApiClient.DeleteAsync(pedido.Id);
                    await this.LoadPedidos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HabilitarControles();
                }
            }
        }

        private async Task LoadPedidos()
        {
            try
            {
                DeshabilitarControles();
                this.pedidosDataGridView.DataSource = null;

                IEnumerable<PedidoDTO> pedidos = await PedidoApiClient.GetAllAsync();

                this.pedidosDataGridView.DataSource = pedidos;

                // Solo manejar Enabled/Disabled si los botones son visibles (tienen permisos)
                bool canUpdate = actualizarButton.Tag is bool updatePermission && updatePermission;
                bool canDelete = eliminarButton.Tag is bool deletePermission && deletePermission;

                if (this.pedidosDataGridView.Rows.Count > 0)
                {
                    this.pedidosDataGridView.Rows[0].Selected = true;

                    // Solo habilitar si tiene permisos Y hay elementos
                    if (canDelete) this.eliminarButton.Enabled = true;
                    if (canUpdate) this.actualizarButton.Enabled = true;
                }
                else
                {
                    // Solo deshabilitar si son visibles
                    if (canDelete) this.eliminarButton.Enabled = false;
                    if (canUpdate) this.actualizarButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private PedidoDTO SelectedItem()
        {
            PedidoDTO pedido;

            pedido = (PedidoDTO)pedidosDataGridView.SelectedRows[0].DataBoundItem;

            return pedido;
        }

        private void DeshabilitarControles()
        {
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            eliminarButton.Enabled = false;
            pedidosDataGridView.Enabled = false;
        }

        private void HabilitarControles()
        {
            agregarButton.Enabled = true;
            pedidosDataGridView.Enabled = true;
            // actualizar y eliminar se habilitan según permisos y datos en LoadPedidos
        }
    }
}