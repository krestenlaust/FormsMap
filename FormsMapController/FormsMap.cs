using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FormsMapController
{
    public partial class FormsMap : UserControl
    {
        private readonly List<MapMarker> mapMarkers = new List<MapMarker>();
        private Point startLocation = Point.Empty;
        private Point pan = Point.Empty;
        private float zoomFactor = 0.1f;
        private bool panning = false;
        private Image mapImage;
        private Point recentClick;
        private MapMarker draggedMarker = null;

        public FormsMap()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Property Changed"), Description("Notifies whenever user is panning.")]
        public event EventHandler PanChanged;

        [Browsable(true)]
        [Category("Property Changed"), Description("Notifies whenever zoom factor has changed.")]
        public event EventHandler ZoomFactorChanged;

        public float ZoomFactor
        {
            get => zoomFactor;
            set
            {
                bool changed = zoomFactor != value;

                zoomFactor = value;

                if (changed)
                {
                    ZoomFactorChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public Point Pan
        {
            get => pan;
            set
            {
                bool changed = pan != value;

                pan = value;

                if (changed)
                {
                    PanChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public Image MapImage
        {
            get => mapImage;
            set
            {
                mapImage = value;
                pictureBoxMap.Invalidate();
            }
        }

        public void AddMarker(MapMarker mapMarker)
        {
            mapMarkers.Add(mapMarker);
        }

        public new void Refresh() => pictureBoxMap.Invalidate();

        private void pictureBoxMap_Click(object sender, EventArgs e)
        {
            MouseEventArgs eMouse = (MouseEventArgs)e;

            recentClick = eMouse.Location;
        }

        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            if (!(mapImage is null))
            {
                Size zoom = new Size((int)(MapImage.Width * ZoomFactor), (int)(MapImage.Height * ZoomFactor));
                e.Graphics.DrawImage(MapImage, new Rectangle(Pan, zoom));
            }

            DrawMisc(e.Graphics);
        }

        private void DrawMisc(Graphics g)
        {
            g.FillRectangle(Brushes.Red, new Rectangle(recentClick, new Size(10, 10)));

            foreach (var marker in mapMarkers)
            {
                g.DrawImage(marker.Icon, marker.MarkerRectangle(Pan, zoomFactor));
            }
        }

        private MapMarker GetMapMarker(Point location)
        {
            foreach (var marker in mapMarkers)
            {
                if (marker.MarkerRectangle(Point.Empty, 1).Contains(new Point(location.X + Pan.X, location.Y + Pan.Y)))
                {
                    return marker;
                }
            }

            return null;
        }

        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panning = true;
                startLocation = new Point(e.Location.X - Pan.X, e.Location.Y - Pan.Y);
                recentClick = Pan;

                draggedMarker = GetMapMarker(e.Location);
            }
        }

        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            Point newMarkerLocation = new Point(e.Location.X + pan.X, e.Location.Y + pan.Y);

            // place new marker
            if (e.Button == MouseButtons.Left)
            {
                // move dragged marker
                if (!(draggedMarker is null))
                {
                    draggedMarker.Location = newMarkerLocation;
                }

                panning = false;
                pictureBoxMap.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (draggedMarker is null)
                {
                    AddMarker(new MapMarker(newMarkerLocation, Properties.Resources.pinpoint));
                }

                draggedMarker = null;
                pictureBoxMap.Invalidate();
            }
        }

        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                Pan = new Point(
                    e.Location.X - startLocation.X,
                    e.Location.Y - startLocation.Y);

                pictureBoxMap.Invalidate();
            }

            MapMarker marker = GetMapMarker(e.Location);

            if (marker is null)
            {
                Cursor = Cursors.Default;
            }
            else
            {
                Cursor = Cursors.Hand;

                Point newMarkerLocation = new Point(
                    e.Location.X + pan.X,
                    e.Location.Y + pan.Y);

                if (e.Button == MouseButtons.Left && !(draggedMarker is null))
                {
                    draggedMarker.Location = newMarkerLocation;
                }

                pictureBoxMap.Invalidate();
            }
        }

        public class MapMarker
        {
            public Point Location;
            public Image Icon;
            private readonly Size markerSize = new Size(25, 40);

            public MapMarker(Point location, Image icon)
            {
                Location = location;
                Icon = icon;
            }

            public Point IconOffset() => new Point(markerSize.Width / 2, -markerSize.Height);

            public Rectangle MarkerRectangle(Point pan, float zoomFactor)
            {
                return new Rectangle(
                Location.X - (markerSize.Width / 2) + pan.X, Location.Y - markerSize.Height + pan.Y,
                (int)(markerSize.Width * zoomFactor), (int)(markerSize.Height * zoomFactor));
            }
        }
    }
}
