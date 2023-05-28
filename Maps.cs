using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppEmergencias.Models;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MongoDB.Driver.Core.Configuration;

namespace AppEmergencias
{
    public partial class Maps : Form
    {
        Services link = new Services();
        GMarkerGoogle marker;
        GMarkerGoogle GhostMarker = new GMarkerGoogle(new PointLatLng(25.721115799151143, -100.32688464858524), GMarkerGoogleType.green);
        GMapOverlay markerOverlay;

        public Maps()
        {
            if (link.Test())
            {
                InitializeComponent();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string query = "SELECT s.Poliza, s.Latitud, s.Longitud, c.Telefono FROM siniestros s INNER JOIN clientes c ON s.Poliza = c.Poliza WHERE s.Emergencia != 0 OR s.Asistencia != 0";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, link.Link());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridEmrgncys.DataSource = dt;

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new GMap.NET.PointLatLng(25.721115799151143, -100.32688464858524);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            this.RedMarkMaker();
            this.YellowMarkMaker();
        }

        private void RedMarkMaker()
        {
            markerOverlay = new GMapOverlay("Marcador");
            string query = "SELECT Latitud, Longitud FROM siniestros WHERE Emergencia = 1";
            using (SqlConnection cnn = new SqlConnection(link.Link()))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                try
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        marker = new GMarkerGoogle(new PointLatLng(reader.GetDouble(0), reader.GetDouble(1)), GMarkerGoogleType.red);
                        AssignMarkerId(marker);
                        markerOverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        marker.ToolTipText = string.Format("Ubicación: \n Latitud:{0} \n Longitud: {1}", reader.GetDouble(0), reader.GetDouble(1));
                        gMapControl1.Overlays.Add(markerOverlay);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos. " + ex.Message);
                }
            }
        }

        private void YellowMarkMaker()
        {
            markerOverlay = new GMapOverlay("Marcador");
            string query = "SELECT Latitud, Longitud FROM siniestros WHERE Emergencia <> 1 AND Asistencia = 1";

            using (SqlConnection cnn = new SqlConnection(link.Link()))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                try
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        marker = new GMarkerGoogle(new PointLatLng(reader.GetDouble(0), reader.GetDouble(1)), GMarkerGoogleType.yellow);
                        AssignMarkerId(marker);
                        markerOverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        marker.ToolTipText = string.Format("Ubicación: \n Latitud:{0} \n Longitud: {1}", reader.GetDouble(0), reader.GetDouble(1));
                        gMapControl1.Overlays.Add(markerOverlay);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos. " + ex.Message);
                }
            }
        }

        private void SeleccionarRegistro(object sender, DataGridViewCellMouseEventArgs e)
        {
            int filaSeleccionada = e.RowIndex;
            GMarkerGoogle BlipMarker = new GMarkerGoogle(new PointLatLng(25.721115799151143, -100.32688464858524), GMarkerGoogleType.blue_dot);
            txtPol.Text = dataGridEmrgncys.Rows[filaSeleccionada].Cells[0].Value.ToString();
            BlipMarker.Position = new PointLatLng(Convert.ToDouble(dataGridEmrgncys.Rows[filaSeleccionada].Cells[1].Value.ToString()), Convert.ToDouble(dataGridEmrgncys.Rows[filaSeleccionada].Cells[2].Value.ToString()));
            markerOverlay.Markers.Remove(GhostMarker);
            markerOverlay.Markers.Add(BlipMarker);
            gMapControl1.Overlays.Add(markerOverlay);
            gMapControl1.Position = GhostMarker.Position;
            Thread.Sleep(2000);
            markerOverlay.Markers.Remove(BlipMarker);
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            txtLat.Text = lat.ToString();
            txtLng.Text = lng.ToString();
            GhostMarker.Position = new PointLatLng(lat, lng);
            GhostMarker.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", lat, lng);
            markerOverlay.Markers.Add(GhostMarker);
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private Dictionary<GMapMarker, int> markerIds = new Dictionary<GMapMarker, int>();
        private int nextMarkerId = 1;

        private void AssignMarkerId(GMapMarker marker)
        {
            markerIds[marker] = nextMarkerId;
            nextMarkerId++;
        }

        private int GetMarkerId(GMapMarker marker)
        {
            if (markerIds.ContainsKey(marker))
            {
                return markerIds[marker];
            }

            return -1; // Valor de identificador inválido si el marcador no tiene asignado un identificador
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            int rowId = GetMarkerId(item);
            /*DataGridViewRow row = dataGridEmrgncys.Rows[rowId];

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = Color.Yellow; // Cambiar a cualquier color que desees
                rowId++;
            }*/

            if (rowId != -1)
            {
                foreach (DataGridViewRow row in dataGridEmrgncys.Rows)
                {
                    if (row.Cells["Poliza"] != null && row.Cells["Poliza"].Value != null && item.Tag != null && row.Cells["Poliza"].Value.ToString() == item.Tag.ToString()) // Reemplaza "MarkerId" con el nombre real de la columna en tu esquema de datos
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.BackColor = Color.Yellow; // Cambia a cualquier color que desees
                        }
                        break; // Salir del bucle si se encuentra el marcador correspondiente
                    }
                    rowId++;
                }
            }
        }
    }
}
