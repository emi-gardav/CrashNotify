using System;

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

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.dataGridEmrgncys = new System.Windows.Forms.DataGridView();
            this.txtPol = new System.Windows.Forms.TextBox();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLng = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmrgncys)).BeginInit();
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
            this.gMapControl1.Location = new System.Drawing.Point(13, 13);
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
            this.gMapControl1.Size = new System.Drawing.Size(746, 554);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl1_OnMarkerClick);
            this.gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClick);
            // 
            // dataGridEmrgncys
            // 
            this.dataGridEmrgncys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEmrgncys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmrgncys.Location = new System.Drawing.Point(765, 117);
            this.dataGridEmrgncys.Name = "dataGridEmrgncys";
            this.dataGridEmrgncys.ReadOnly = true;
            this.dataGridEmrgncys.RowHeadersWidth = 51;
            this.dataGridEmrgncys.RowTemplate.Height = 24;
            this.dataGridEmrgncys.Size = new System.Drawing.Size(383, 148);
            this.dataGridEmrgncys.TabIndex = 1;
            this.dataGridEmrgncys.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SeleccionarRegistro);
            // 
            // txtPol
            // 
            this.txtPol.Location = new System.Drawing.Point(765, 117);
            this.txtPol.Name = "txtPol";
            this.txtPol.Size = new System.Drawing.Size(100, 22);
            this.txtPol.TabIndex = 8;
            this.txtPol.Visible = false;
            // 
            // txtLat
            // 
            this.txtLat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLat.Location = new System.Drawing.Point(553, 12);
            this.txtLat.Name = "txtLat";
            this.txtLat.ReadOnly = true;
            this.txtLat.Size = new System.Drawing.Size(100, 15);
            this.txtLat.TabIndex = 4;
            // 
            // txtLng
            // 
            this.txtLng.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLng.Location = new System.Drawing.Point(659, 12);
            this.txtLng.Name = "txtLng";
            this.txtLng.ReadOnly = true;
            this.txtLng.Size = new System.Drawing.Size(100, 15);
            this.txtLng.TabIndex = 6;
            // 
            // Maps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 579);
            this.Controls.Add(this.txtPol);
            this.Controls.Add(this.txtLng);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.dataGridEmrgncys);
            this.Controls.Add(this.gMapControl1);
            this.Name = "Maps";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmrgncys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.DataGridView dataGridEmrgncys;
        private System.Windows.Forms.TextBox txtPol;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLng;
        private EventHandler txtLat_TextChanged;
        private EventHandler txtLng_TextChanged;
    }
}

