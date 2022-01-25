using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FormsMapController
{
    public partial class FormsMap : UserControl
    {
        private const float ZoomIncrement = 0.1f;
        private const float ZoomMin = 0.1f;
        private const float ZoomMax = 5;
        private readonly List<MapMarker> mapMarkers = new List<MapMarker>();
        private Point startLocation = Point.Empty;
        private Point pan = Point.Empty;
        private float zoomFactor = 0.1f;
        private bool panning = false;
        private Image mapImage;
        private Point recentClick;
        private MapMarker draggedMarker = null;
        private Point cursorPosition;

        public FormsMap()
        {
            InitializeComponent();

            pictureBoxMap.MouseWheel += OnMouseWheel;
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
                float zoomDelta = zoomFactor - value;
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

        public static Point ConvertRelativePixelToMapUnits(Point relativePixelLocation, Point pan, float zoomFactor)
        {
            return new Point((int)((pan.X + relativePixelLocation.X) / zoomFactor), (int)((pan.Y + relativePixelLocation.Y) / zoomFactor));
        }

        public static Point ConvertMapUnitsToAbsolutePixel(Point mapLocation, float zoomFactor)
        {
            return new Point((int)(mapLocation.X * zoomFactor), (int)(mapLocation.Y * zoomFactor));
        }

        private void pictureBoxMap_Click(object sender, EventArgs e)
        {
            MouseEventArgs eMouse = (MouseEventArgs)e;

            recentClick = eMouse.Location;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            Point invertedPan = new Point(-Pan.X, -Pan.Y);

            if (!(mapImage is null))
            {
                Size zoom = new Size((int)(MapImage.Width * ZoomFactor), (int)(MapImage.Height * ZoomFactor));
                e.Graphics.DrawImage(MapImage, new Rectangle(invertedPan, zoom));
            }

            // Misc
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(recentClick, new Size(10, 10)));

            foreach (var marker in mapMarkers)
            {
                e.Graphics.DrawImage(marker.Icon, marker.MarkerPixelRectangle(zoomFactor));
            }

            // Cursor position
            e.Graphics.DrawString(cursorPosition.ToString(), SystemFonts.DefaultFont, Brushes.Black, new PointF(0, 0));
        }

        private MapMarker GetMapMarker(Point mapLocation)
        {
            Point absoluteLocation = ConvertMapUnitsToAbsolutePixel(mapLocation, ZoomFactor);

            foreach (var marker in mapMarkers)
            {
                if (marker.MarkerPixelRectangle(ZoomFactor).Contains(absoluteLocation))
                {
                    return marker;
                }
            }

            return null;
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta / SystemInformation.MouseWheelScrollDelta;
            float zoomDelta = ZoomIncrement * delta;

            ZoomFactor = Math.Min(Math.Max(zoomDelta + ZoomFactor, ZoomMin), ZoomMax);

            // Recalculate pan
            Point zoomPoint = new Point(e.Location.X + Pan.X, e.Location.Y + Pan.Y);
            Point offset = new Point((int)(zoomPoint.X * zoomDelta), (int)(zoomPoint.Y * zoomDelta));
            Pan = new Point(Pan.X + offset.X, Pan.Y + offset.Y);

            cursorPosition = ConvertRelativePixelToMapUnits(e.Location, Pan, ZoomFactor);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Cursor = Cursors.Cross;
            panning = true;
            startLocation = new Point(e.Location.X + Pan.X, e.Location.Y + Pan.Y);
            recentClick = Pan;

            draggedMarker = GetMapMarker(e.Location);
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            // Point absolutePixelLocation = new Point(e.Location.X + Pan.X, e.Location.Y + Pan.Y);
            Point mapLocation = ConvertRelativePixelToMapUnits(e.Location, Pan, ZoomFactor);

            // place new marker
            if (e.Button == MouseButtons.Left)
            {
                // move dragged marker
                if (!(draggedMarker is null))
                {
                    draggedMarker.MapLocation = mapLocation;
                }

                Cursor = Cursors.Default;
                panning = false;
                pictureBoxMap.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (draggedMarker is null)
                {
                    AddMarker(new MapMarker(mapLocation, Properties.Resources.pinpoint));
                }

                draggedMarker = null;
                pictureBoxMap.Invalidate();
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                Pan = new Point(
                    startLocation.X - e.Location.X,
                    startLocation.Y - e.Location.Y);

                pictureBoxMap.Invalidate();
                return;
            }

            cursorPosition = ConvertRelativePixelToMapUnits(e.Location, Pan, ZoomFactor);

            MapMarker marker = GetMapMarker(e.Location);

            if (marker is null)
            {
                Cursor = Cursors.Default;
            }
            else
            {
                Cursor = Cursors.Hand;

                Point newMarkerLocation = new Point(e.Location.X + Pan.X, e.Location.Y + Pan.Y);

                if (e.Button == MouseButtons.Left && !(draggedMarker is null))
                {
                    draggedMarker.MapLocation = newMarkerLocation;
                }

                pictureBoxMap.Invalidate();
            }
        }

        public class MapMarker
        {
            public Point MapLocation;
            public Image Icon;
            private readonly Size pixelSize = new Size(25, 40);

            public MapMarker(Point mapLocation, Image icon)
            {
                MapLocation = mapLocation;
                Icon = icon;
            }

            public Point IconOffset() => new Point(pixelSize.Width / 2, -pixelSize.Height);

            public Rectangle MarkerPixelRectangle(float zoomFactor)
            {
                Point pixelLocation = ConvertMapUnitsToAbsolutePixel(MapLocation, zoomFactor);

                return new Rectangle(
                    pixelLocation.X - (pixelSize.Width / 2),
                    pixelLocation.Y - pixelSize.Height,
                    pixelSize.Width, pixelSize.Height);
            }
        }
    }
}
