namespace Winform_Equipo_20A
{
    partial class frmArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblFiltroCodigo = new System.Windows.Forms.Label();
            this.tbFiltroCodigo = new System.Windows.Forms.TextBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.lblCampo = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblFiltroAvanzado = new System.Windows.Forms.Label();
            this.cbxCampo = new System.Windows.Forms.ComboBox();
            this.cbxCriterio = new System.Windows.Forms.ComboBox();
            this.tbFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.btnLimpiarFiltro = new System.Windows.Forms.Button();
            this.btnFiltroAvanzado = new System.Windows.Forms.Button();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(74, 208);
            this.dgvArticulos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.RowHeadersWidth = 62;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(814, 391);
            this.dgvArticulos.TabIndex = 0;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(18, 638);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(168, 35);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar Articulo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(195, 638);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(168, 35);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar Articulo";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(372, 638);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(168, 35);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar Articulo";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblFiltroCodigo
            // 
            this.lblFiltroCodigo.AutoSize = true;
            this.lblFiltroCodigo.Location = new System.Drawing.Point(190, 14);
            this.lblFiltroCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroCodigo.Name = "lblFiltroCodigo";
            this.lblFiltroCodigo.Size = new System.Drawing.Size(74, 20);
            this.lblFiltroCodigo.TabIndex = 4;
            this.lblFiltroCodigo.Text = "CODIGO";
            // 
            // tbFiltroCodigo
            // 
            this.tbFiltroCodigo.Location = new System.Drawing.Point(160, 38);
            this.tbFiltroCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFiltroCodigo.Name = "tbFiltroCodigo";
            this.tbFiltroCodigo.Size = new System.Drawing.Size(148, 26);
            this.tbFiltroCodigo.TabIndex = 5;
            this.tbFiltroCodigo.TextChanged += new System.EventHandler(this.tbFiltroCodigo_TextChanged);
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Location = new System.Drawing.Point(18, 14);
            this.lblFiltrar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(123, 20);
            this.lblFiltrar.TabIndex = 6;
            this.lblFiltrar.Text = "FILTRAR POR: ";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(88, 122);
            this.lblCampo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(66, 20);
            this.lblCampo.TabIndex = 7;
            this.lblCampo.Text = "CAMPO";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(320, 122);
            this.lblCriterio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(86, 20);
            this.lblCriterio.TabIndex = 8;
            this.lblCriterio.Text = "CRITERIO";
            // 
            // lblFiltroAvanzado
            // 
            this.lblFiltroAvanzado.AutoSize = true;
            this.lblFiltroAvanzado.Location = new System.Drawing.Point(574, 122);
            this.lblFiltroAvanzado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroAvanzado.Name = "lblFiltroAvanzado";
            this.lblFiltroAvanzado.Size = new System.Drawing.Size(66, 20);
            this.lblFiltroAvanzado.TabIndex = 9;
            this.lblFiltroAvanzado.Text = "FILTRO";
            // 
            // cbxCampo
            // 
            this.cbxCampo.FormattingEnabled = true;
            this.cbxCampo.Location = new System.Drawing.Point(42, 146);
            this.cbxCampo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxCampo.Name = "cbxCampo";
            this.cbxCampo.Size = new System.Drawing.Size(180, 28);
            this.cbxCampo.TabIndex = 10;
            this.cbxCampo.SelectedIndexChanged += new System.EventHandler(this.cbxCampo_SelectedIndexChanged);
            // 
            // cbxCriterio
            // 
            this.cbxCriterio.FormattingEnabled = true;
            this.cbxCriterio.Location = new System.Drawing.Point(261, 146);
            this.cbxCriterio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxCriterio.Name = "cbxCriterio";
            this.cbxCriterio.Size = new System.Drawing.Size(180, 28);
            this.cbxCriterio.TabIndex = 11;
            // 
            // tbFiltroAvanzado
            // 
            this.tbFiltroAvanzado.Location = new System.Drawing.Point(494, 148);
            this.tbFiltroAvanzado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFiltroAvanzado.Name = "tbFiltroAvanzado";
            this.tbFiltroAvanzado.Size = new System.Drawing.Size(216, 26);
            this.tbFiltroAvanzado.TabIndex = 12;
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.Image = global::Winform_Equipo_20A.Properties.Resources.imagen_Limpiador_filtro;
            this.btnLimpiarFiltro.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(813, 102);
            this.btnLimpiarFiltro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(75, 77);
            this.btnLimpiarFiltro.TabIndex = 14;
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);
            // 
            // btnFiltroAvanzado
            // 
            this.btnFiltroAvanzado.Image = global::Winform_Equipo_20A.Properties.Resources.imagen_buscador;
            this.btnFiltroAvanzado.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnFiltroAvanzado.Location = new System.Drawing.Point(720, 102);
            this.btnFiltroAvanzado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFiltroAvanzado.Name = "btnFiltroAvanzado";
            this.btnFiltroAvanzado.Size = new System.Drawing.Size(75, 77);
            this.btnFiltroAvanzado.TabIndex = 13;
            this.btnFiltroAvanzado.UseVisualStyleBackColor = true;
            this.btnFiltroAvanzado.Click += new System.EventHandler(this.btnFiltroAvanzado_Click);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbxArticulo.Location = new System.Drawing.Point(897, 208);
            this.pbxArticulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(190, 254);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxArticulo.TabIndex = 15;
            this.pbxArticulo.TabStop = false;
            // 
            // frmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.btnLimpiarFiltro);
            this.Controls.Add(this.btnFiltroAvanzado);
            this.Controls.Add(this.tbFiltroAvanzado);
            this.Controls.Add(this.cbxCriterio);
            this.Controls.Add(this.cbxCampo);
            this.Controls.Add(this.lblFiltroAvanzado);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.lblFiltrar);
            this.Controls.Add(this.tbFiltroCodigo);
            this.Controls.Add(this.lblFiltroCodigo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvArticulos);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmArticulos";
            this.Text = "frmArticulos";
            this.Load += new System.EventHandler(this.frmArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblFiltroCodigo;
        private System.Windows.Forms.TextBox tbFiltroCodigo;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblFiltroAvanzado;
        private System.Windows.Forms.ComboBox cbxCampo;
        private System.Windows.Forms.ComboBox cbxCriterio;
        private System.Windows.Forms.TextBox tbFiltroAvanzado;
        private System.Windows.Forms.Button btnFiltroAvanzado;
        private System.Windows.Forms.Button btnLimpiarFiltro;
        private System.Windows.Forms.PictureBox pbxArticulo;
    }
}