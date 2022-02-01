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
        private const int PaddingSizeTopBottom = 50;
        private const int PaddingSizeSides = 100;
        private const float ZoomIncrement = 0.1f;
        private const float ZoomMin = 0.1f;
        private const float ZoomMax = 5;
        private readonly List<MapMarker> mapMarkers = new List<MapMarker>();
        private Point startLocation = Point.Empty;
        private Point pan = Point.Empty;
        private float zoomFactor = 0.1f;
        private bool panning = false;
        private Image mapImage;
        private MapMarker draggedMarker = null;
        private Size currentMapSize;

        public FormsMap()
        {
            InitializeComponent();

            pictureBoxMap.MouseWheel += OnMouseWheel;
        }

        [Browsable(true)]
        public event EventHandler MarkerAdded;

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

        public void AddMarker(MapMarker marker)
        {
            mapMarkers.Add(marker);
        }

        public void CenterMarker(MapMarker marker)
        {
            Pan = new Point(marker.Location.AbsolutePixel.X - (pictureBoxMap.Width / 2), marker.Location.AbsolutePixel.Y - (pictureBoxMap.Height / 2));
            Refresh();
        }

        public MapMarker AddDefaultMarker(GraphicsPoint point, bool draggable)
        {
            MapMarker newMarker = new MapMarker(point, Properties.Resources.pinpoint, draggable);
            AddMarker(newMarker);

            return newMarker;
        }

        public void RemoveMarkers()
        {
            mapMarkers.Clear();
        }

        public class MarkerAddedEventArgs : EventArgs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MarkerAddedEventArgs"/> class.
            /// </summary>
            /// <param name="newMarker"></param>
            public MarkerAddedEventArgs(MapMarker newMarker)
            {
                NewMarker = newMarker;
            }

            public MapMarker NewMarker { get; set; }
        }

        public void RemoveMarker(MapMarker mapMarker) => mapMarkers.Remove(mapMarker);

        public List<MapMarker> GetMarkers() => mapMarkers;

        public new void Refresh() => pictureBoxMap.Invalidate();

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            Point invertedPan = new Point(-Pan.X, -Pan.Y);

            if (!(mapImage is null))
            {
                Size zoom = new Size((int)(MapImage.Width * ZoomFactor), (int)(MapImage.Height * ZoomFactor));
                currentMapSize = zoom;
                e.Graphics.DrawImage(MapImage, new Rectangle(invertedPan, zoom));
            }

            // Misc
            foreach (var marker in mapMarkers)
            {
                Debug.WriteLine(marker.MarkerPixelRectangle.X);
                e.Graphics.DrawImage(marker.Icon, marker.MarkerPixelRectangle);
            }
        }

        private MapMarker GetMapMarker(GraphicsPoint location)
        {
            foreach (var marker in mapMarkers)
            {
                if (marker.MarkerPixelRectangle.Contains(location.RelativePixel))
                {
                    return marker;
                }
            }

            return null;
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            GraphicsPoint location = new GraphicsPoint(e.Location, GraphicsPoint.PointRelation.RelativePixel, this);

            int delta = e.Delta / SystemInformation.MouseWheelScrollDelta;
            float zoomDelta = ZoomIncrement * delta;

            ZoomFactor = Math.Min(Math.Max(zoomDelta + ZoomFactor, ZoomMin), ZoomMax);

            // Recalculate pan
            Point zoomPoint = new Point(e.Location.X + Pan.X, e.Location.Y + Pan.Y);
            Point offset = new Point((int)(zoomPoint.X * zoomDelta), (int)(zoomPoint.Y * zoomDelta));
            Pan = new Point(Pan.X + offset.X, Pan.Y + offset.Y);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GraphicsPoint location = new GraphicsPoint(e.Location, GraphicsPoint.PointRelation.RelativePixel, this);

                draggedMarker = GetMapMarker(location);

                if (!(draggedMarker is null) && !draggedMarker.Draggable)
                {
                    draggedMarker = null;
                }

                // Pan only if no marker is being dragged.
                if (draggedMarker is null)
                {
                    Cursor = Cursors.Cross;
                    panning = true;
                    startLocation = location.AbsolutePixel;
                }
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            // Point absolutePixelLocation = new Point(e.Location.X + Pan.X, e.Location.Y + Pan.Y);
            GraphicsPoint location = new GraphicsPoint(e.Location, GraphicsPoint.PointRelation.RelativePixel, this);

            // place new marker
            if (e.Button == MouseButtons.Left)
            {
                // move dragged marker
                if (!(draggedMarker is null))
                {
                    draggedMarker.Location = location;
                }

                draggedMarker = null;

                panning = false;
                pictureBoxMap.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (draggedMarker is null)
                {
                    MapMarker newMapMarker = new MapMarker(location, Properties.Resources.pinpoint, true);
                    AddMarker(newMapMarker);

                    MarkerAdded?.Invoke(this, new MarkerAddedEventArgs(newMapMarker));
                }

                draggedMarker = null;
                pictureBoxMap.Invalidate();
            }

            Cursor = Cursors.Default;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                Pan = new Point(
                    Math.Max(Math.Min(startLocation.X - e.Location.X, currentMapSize.Width), -PaddingSizeSides),
                    Math.Max(Math.Min(startLocation.Y - e.Location.Y, currentMapSize.Height), -PaddingSizeTopBottom));

                pictureBoxMap.Invalidate();
                return;
            }

            GraphicsPoint location = new GraphicsPoint(e.Location, GraphicsPoint.PointRelation.RelativePixel, this);

            MapMarker hoveredMarker = GetMapMarker(location);

            if (draggedMarker is null)
            {
                if (hoveredMarker is null)
                {
                    Cursor = Cursors.Default;
                }
                else
                {
                    Cursor = Cursors.Hand;
                }
            }
            else
            {
                Cursor = Cursors.Hand;

                if (e.Button == MouseButtons.Left)
                {
                    draggedMarker.Location = location;
                }

                pictureBoxMap.Invalidate();
            }
        }

        public struct GraphicsPoint
        {
            public enum PointRelation
            {
                RelativePixel,
                AbsolutePixel,
                AbsoluteMap,
            }

            public Point AbsoluteMap { get; }

            public Point AbsolutePixel
            {
                get
                {
                    return ConvertMapUnitsToAbsolutePixel(AbsoluteMap, formsMap.ZoomFactor);
                }
            }

            public Point RelativePixel
            {
                get
                {
                    Point absolutePixel = AbsolutePixel;
                    return new Point(absolutePixel.X - formsMap.Pan.X, absolutePixel.Y - formsMap.Pan.Y);
                }
            }

            private readonly FormsMap formsMap;

            /// <summary>
            /// Initializes a new instance of the <see cref="GraphicsPoint"/> struct.
            /// </summary>
            /// <param name="point"></param>
            /// <param name="relation"></param>
            /// <param name="formsMap"></param>
            public GraphicsPoint(Point point, PointRelation relation, FormsMap formsMap)
            {
                this.formsMap = formsMap;
                AbsoluteMap = Point.Empty;

                switch (relation)
                {
                    case PointRelation.RelativePixel:
                        AbsoluteMap = ConvertRelativePixelToMapUnits(point, formsMap.Pan, formsMap.ZoomFactor);
                        break;
                    case PointRelation.AbsolutePixel:
                        AbsoluteMap = ConvertAbsolutePixelToMapUnits(point, formsMap.ZoomFactor);
                        break;
                    case PointRelation.AbsoluteMap:
                        AbsoluteMap = point;
                        break;
                    default:
                        break;
                }
            }

            public override string ToString()
            {
                return $"({AbsoluteMap.X};  {AbsoluteMap.Y})";
            }

            public static Point ConvertRelativePixelToMapUnits(Point relativePixel, Point pan, float zoomFactor)
            {
                return new Point((int)((pan.X + relativePixel.X) / zoomFactor), (int)((pan.Y + relativePixel.Y) / zoomFactor));
            }

            public static Point ConvertAbsolutePixelToMapUnits(Point absolutePixel, float zoomFactor)
            {
                return new Point((int)(absolutePixel.X / zoomFactor), (int)(absolutePixel.Y / zoomFactor));
            }

            public static Point ConvertMapUnitsToAbsolutePixel(Point mapLocation, float zoomFactor)
            {
                return new Point((int)(mapLocation.X * zoomFactor), (int)(mapLocation.Y * zoomFactor));
            }
        }

        /// <summary>
        /// A marker for the <c>FormsMap</c>-control.
        /// </summary>
        public class MapMarker
        {
            private readonly Size pixelSize = new Size(25, 40);

            /// <summary>
            /// Initializes a new instance of the <see cref="MapMarker"/> class.
            /// </summary>
            /// <param name="location"></param>
            /// <param name="icon"></param>
            public MapMarker(GraphicsPoint location, Image icon, bool draggable)
            {
                Location = location;
                Icon = icon;
                Draggable = draggable;
            }

            /// <summary>
            /// Gets or sets a value indicating whether a marker is dragable.
            /// </summary>
            public bool Draggable { get; set; }

            /// <summary>
            /// Gets or sets the position of the marker.
            /// </summary>
            public GraphicsPoint Location { get; set; }

            /// <summary>
            /// Gets or sets the image icon displayed as the marker.
            /// </summary>
            public Image Icon { get; set; }

            public Point IconOffset => new Point(pixelSize.Width / 2, -pixelSize.Height);

            /// <summary>
            /// Gets the relative hitbox of the marker.
            /// </summary>
            public Rectangle MarkerPixelRectangle =>
                new Rectangle(
                    Location.RelativePixel.X - (pixelSize.Width / 2),
                    Location.RelativePixel.Y - pixelSize.Height,
                    pixelSize.Width, pixelSize.Height);
        }
    }
}
