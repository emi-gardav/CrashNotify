namespace AppEmergencias
{
    partial class Maps
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maps));
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.dataGridEmrgncys = new System.Windows.Forms.DataGridView();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.txtPol = new System.Windows.Forms.TextBox();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmrgncys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(-4, -6);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(761, 606);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClick);
            // 
            // dataGridEmrgncys
            // 
            this.dataGridEmrgncys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEmrgncys.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridEmrgncys.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridEmrgncys.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridEmrgncys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmrgncys.Location = new System.Drawing.Point(828, 161);
            this.dataGridEmrgncys.Name = "dataGridEmrgncys";
            this.dataGridEmrgncys.ReadOnly = true;
            this.dataGridEmrgncys.RowHeadersWidth = 51;
            this.dataGridEmrgncys.RowTemplate.Height = 24;
            this.dataGridEmrgncys.Size = new System.Drawing.Size(592, 413);
            this.dataGridEmrgncys.TabIndex = 1;
            this.dataGridEmrgncys.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SeleccionarRegistro);
            // 
            // txtLat
            // 
            this.txtLat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLat.Location = new System.Drawing.Point(526, 28);
            this.txtLat.Name = "txtLat";
            this.txtLat.ReadOnly = true;
            this.txtLat.ShortcutsEnabled = false;
            this.txtLat.Size = new System.Drawing.Size(100, 22);
            this.txtLat.TabIndex = 4;
            this.txtLat.TabStop = false;
            this.txtLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLng
            // 
            this.txtLng.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLng.Location = new System.Drawing.Point(642, 28);
            this.txtLng.Name = "txtLng";
            this.txtLng.ReadOnly = true;
            this.txtLng.ShortcutsEnabled = false;
            this.txtLng.Size = new System.Drawing.Size(100, 22);
            this.txtLng.TabIndex = 6;
            this.txtLng.TabStop = false;
            this.txtLng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPol
            // 
            this.txtPol.Location = new System.Drawing.Point(772, 28);
            this.txtPol.Name = "txtPol";
            this.txtPol.Size = new System.Drawing.Size(100, 22);
            this.txtPol.TabIndex = 8;
            this.txtPol.Visible = false;
            // 
            // pictureLogo
            // 
            this.pictureLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureLogo.ErrorImage = null;
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.ImageLocation = "";
            this.pictureLogo.InitialImage = null;
            this.pictureLogo.Location = new System.Drawing.Point(854, 28);
            this.pictureLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(610, 110);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLogo.TabIndex = 9;
            this.pictureLogo.TabStop = false;
            // 
            // Maps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1621, 597);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.txtPol);
            this.Controls.Add(this.txtLng);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.dataGridEmrgncys);
            this.Controls.Add(this.gMapControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(88891, 80010);
            this.Name = "Maps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maps Notifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmrgncys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.DataGridView dataGridEmrgncys;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.TextBox txtPol;
        private System.Windows.Forms.PictureBox pictureLogo;
    }
}