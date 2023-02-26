using Elements.Base;
using Elements.Constants;
using Elements.Controls.RadialProgress;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.Rating
{
    /// <summary>
    /// The <see cref="Rating"/> class.
    /// </summary>
    /// <seealso cref="Elements.Controls.Base.ControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("RatingChanged")]
    [DefaultProperty("Value")]
    [Description("The Rating")]
    [Designer(typeof(RatingDesigner))]
    [ToolboxBitmap(typeof(Rating), "Rating.bmp")]
    [ToolboxItem(true)]
    public class Rating : ControlBase
    {
        private readonly BufferedGraphicsContext _bufferedContext;
        private BufferedGraphics _bufferedGraphics;
        private int _maximum;
        private float _mouseOverIndex;
        private StarType _ratingType;
        private bool _settingRating;
        private int _starSpacing;
        private int _starWidth;
        private bool _toggleHalfStar;
        private float _value;
        private float borderWidth;
        private float dullStroke;
        private Color starBorderColor;
        private Color starColor;
        private Color starDull;
        private Color starDullBorderColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rating"/> class.
        /// </summary>
        public Rating()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            _bufferedContext = BufferedGraphicsManager.Current;
            _toggleHalfStar = true;
            _maximum = 5;
            _mouseOverIndex = -1;
            _ratingType = StarType.Thick;
            _starSpacing = 1;
            borderWidth = 3f;
            dullStroke = 3f;
            _starWidth = 25;

            starBorderColor = Color.FromArgb(255, 215, 0);
            starColor = Color.FromArgb(255, 255, 0);
            starDull = Color.FromArgb(192, 192, 192);
            starDullBorderColor = Color.FromArgb(128, 128, 128);

            Size = new Size(200, 100);

            UpdateGraphicsBuffer();
        }

        /// <summary>
        /// Occurs when [rating changed].
        /// </summary>
        [Description("Occurs when the star rating of the strip has changed (Typically by a click operation).")]
        public event EventHandler RatingChanged;

        /// <summary>
        /// Occurs when [stars panned].
        /// </summary>
        [Description("Occurs when a different number of stars are illuminated (does not include mouseleave un-ilum).")]
        public event EventHandler StarsPanned;

        /// <summary>
        /// Gets or sets the width of the dull stroke.
        /// </summary>
        /// <value>The width of the dull stroke.</value>
        [Description("The dull stroke width")]
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(3)]
        public float DullStrokeWidth
        {
            get
            {
                return dullStroke;
            }

            set
            {
                if (dullStroke != value)
                {
                    dullStroke = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [Description("The number of stars to display")]
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(5)]
        public int Maximum
        {
            get
            {
                return _maximum;
            }

            set
            {
                bool changed = _maximum != value;
                _maximum = value;

                if (changed)
                {
                    UpdateSize();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets the index of the mouse over star.
        /// </summary>
        /// <value>The index of the mouse over star.</value>
        [Browsable(false)]
        public float MouseOverStarIndex
        {
            get
            {
                return _mouseOverIndex;
            }
        }

        /// <summary>
        /// Gets or sets the preset appearance of the star
        /// </summary>
        /// <value>The type of the rating.</value>
        [Description("The star style to use")]
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(StarType.Thick)]
        public StarType RatingType
        {
            get
            {
                return _ratingType;
            }

            set
            {
                _ratingType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the star border.
        /// </summary>
        /// <value>The color of the star border.</value>
        [Description("The color to use for the star borders when they are illuminated")]
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(typeof(Color), "Gold")]
        public Color StarBorderColor
        {
            get
            {
                return starBorderColor;
            }

            set
            {
                starBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border around the star (including the dull version)
        /// </summary>
        /// <value>The width of the star border.</value>
        [Description("The width of the star border")]
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(3f)]
        public float StarBorderWidth
        {
            get
            {
                return borderWidth;
            }

            set
            {
                borderWidth = value;
                dullStroke = value;
                UpdateSize();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the star.
        /// </summary>
        /// <value>The color of the star.</value>
        [Description("The color to use for the star when they are illuminated")]
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(typeof(Color), "Yellow")]
        public Color StarColor
        {
            get
            {
                return starColor;
            }

            set
            {
                starColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the star dull border.
        /// </summary>
        /// <value>The color of the star dull border.</value>
        [Description("The color to use for the star borders when they are not illuminated")]
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(typeof(Color), "Gray")]
        public Color StarDullBorderColor
        {
            get
            {
                return starDullBorderColor;
            }

            set
            {
                starDullBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the star dull.
        /// </summary>
        /// <value>The color of the star dull.</value>
        [Description("The color to use for the stars when they are not illuminated")]
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(typeof(Color), "Silver")]
        public Color StarDullColor
        {
            get
            {
                return starDull;
            }

            set
            {
                starDull = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star spacing.
        /// </summary>
        /// <value>The star spacing.</value>
        [Description("The amount of space between each star")]
        [Category(PropertyCategory.Layout)]
        [DefaultValue(1)]
        public int StarSpacing
        {
            get
            {
                return _starSpacing;
            }

            set
            {
                _starSpacing = _starSpacing < 0 ? 0 : value;
                UpdateSize();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the star.
        /// </summary>
        /// <value>The width of the star.</value>
        [Description("The width and height of the star in pixels (not including the border)")]
        [Category(PropertyCategory.Layout)]
        [DefaultValue(25)]
        public int StarWidth
        {
            get
            {
                return _starWidth;
            }

            set
            {
                _starWidth = _starWidth < 1 ? 1 : value;
                UpdateSize();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [toggle half star].
        /// </summary>
        /// <value><c>true</c> if [toggle half star]; otherwise, <c>false</c>.</value>
        [Description("Determines whether the user can rate with a half a star of specificity")]
        [Category(PropertyCategory.Behavior)]
        [DefaultValue(false)]
        public bool ToggleHalfStar
        {
            get
            {
                return _toggleHalfStar;
            }

            set
            {
                bool disabled = !value && _toggleHalfStar;
                _toggleHalfStar = value;

                if (disabled)
                {
                    // Only set rating if half star was enabled and now disabled
                    Value = (int)(Value + 0.5);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Description("The number of stars selected (Note: 0 is considered un-rated")]
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(0f)]
        public float Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (value > _maximum)
                {
                    value = _maximum;
                }
                else if (value < 0)
                {
                    value = 0;
                }
                else
                {
                    if (_toggleHalfStar)
                    {
                        value = RoundToNearestHalf(value);
                    }
                    else
                    {
                        value = (int)(value + 0.5f);
                    }
                }

                bool changed = value != _value;
                _value = value;

                if (changed)
                {
                    if (!_settingRating)
                    {
                        _mouseOverIndex = _value;
                        if (!_toggleHalfStar)
                        {
                            _mouseOverIndex -= 1f;
                        }
                    }

                    OnRatingChanged();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets all of the spacing between the stars.
        /// </summary>
        /// <value>The total spacing.</value>
        private int TotalSpacing
        {
            get
            {
                return (_maximum - 1) * _starSpacing;
            }
        }

        /// <summary>
        /// Gets the sum of all star widths.
        /// </summary>
        /// <value>The total width of the star.</value>
        private int TotalStarWidth
        {
            get
            {
                return _maximum * _starWidth;
            }
        }

        /// <summary>
        /// Gets the sum of the width of the stroke for each star.
        /// </summary>
        /// <value>The total width of the stroke.</value>
        private float TotalStrokeWidth
        {
            get
            {
                return _maximum * borderWidth;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (_value == 0f)
            {
                _settingRating = true;
                Value = _toggleHalfStar ? _mouseOverIndex : _mouseOverIndex + 1f;
                _settingRating = false;
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_value > 0)
            {
                return;
            }

            _mouseOverIndex = -1; // No stars will be highlighted
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:MouseMove"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_value > 0)
            {
                return;
            }

            float index = GetHoveredStarIndex(e.Location);

            if (index != _mouseOverIndex)
            {
                _mouseOverIndex = index;
                OnStarsPanned();
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            _bufferedGraphics.Graphics.Clear(BackColor);
            DrawDullStars();
            DrawIlluminatedStars();
            _bufferedGraphics.Render(e.Graphics);
        }

        /// <summary>
        /// Raises the <see cref="E:SizeChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateSize();
            UpdateGraphicsBuffer();
        }

        /// <summary>
        /// Rounds precise numbers to a number no more precise than .5.
        /// </summary>
        /// <param name="f">The value.</param>
        /// <returns>Star shape.</returns>
        private static float RoundToNearestHalf(float f)
        {
            return (float)Math.Round(f / 5.0, 1) * 5f;
        }

        /// <summary>
        /// Draws the dull stars.
        /// </summary>
        private void DrawDullStars()
        {
            float height = Height - borderWidth;
            float lastX = borderWidth / 2f; // Start off at stroke size and increment
            float width = (Width - TotalSpacing - TotalStrokeWidth) / _maximum;

            Pen starDullStroke = new Pen(starDullBorderColor, dullStroke) { LineJoin = LineJoin.Round, Alignment = PenAlignment.Outset };

            // Draw stars
            for (var i = 0; i < _maximum; i++)
            {
                RectangleF rect = new RectangleF(lastX, borderWidth / 2f, width, height);
                var polygon = GetStarPolygon(rect);
                _bufferedGraphics.Graphics.FillPolygon(new SolidBrush(starDull), polygon);
                _bufferedGraphics.Graphics.DrawPolygon(starDullStroke, polygon);
                lastX += _starWidth + _starSpacing + borderWidth;
                _bufferedGraphics.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                _bufferedGraphics.Graphics.FillPolygon(new SolidBrush(starDull), polygon);
                _bufferedGraphics.Graphics.DrawPolygon(starDullStroke, polygon);
                _bufferedGraphics.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
            }
        }

        /// <summary>
        /// Draws the illuminated stars.
        /// </summary>
        private void DrawIlluminatedStars()
        {
            float height = Height - borderWidth;
            float lastX = borderWidth / 2f; // Start off at stroke size and increment
            float width = (Width - TotalSpacing - TotalStrokeWidth) / _maximum;

            Pen _starStroke = new Pen(starBorderColor, borderWidth) { LineJoin = LineJoin.Round, Alignment = PenAlignment.Outset };

            if (_toggleHalfStar)
            {
                // Draw stars
                for (var i = 0; i < _maximum; i++)
                {
                    RectangleF rect = new RectangleF(lastX, borderWidth / 2f, width, height);

                    if (i < _mouseOverIndex - 0.5f)
                    {
                        var polygon = GetStarPolygon(rect);
                        _bufferedGraphics.Graphics.FillPolygon(new SolidBrush(starColor), polygon);
                        _bufferedGraphics.Graphics.DrawPolygon(_starStroke, polygon);
                    }
                    else if (i == _mouseOverIndex - 0.5f)
                    {
                        var polygon = GetSemiStarPolygon(rect);
                        _bufferedGraphics.Graphics.FillPolygon(new SolidBrush(starColor), polygon);
                        _bufferedGraphics.Graphics.DrawPolygon(_starStroke, polygon);
                    }
                    else
                    {
                        break;
                    }

                    lastX += _starWidth + _starSpacing + borderWidth;
                }
            }
            else
            {
                // Draw stars
                for (var i = 0; i < _maximum; i++)
                {
                    RectangleF rect = new RectangleF(lastX, borderWidth / 2f, width, height);
                    var polygon = GetStarPolygon(rect);

                    if (i <= _mouseOverIndex)
                    {
                        _bufferedGraphics.Graphics.FillPolygon(new SolidBrush(starColor), polygon);
                        _bufferedGraphics.Graphics.DrawPolygon(_starStroke, polygon);
                    }
                    else
                    {
                        break;
                    }

                    lastX += _starWidth + _starSpacing + borderWidth;
                }
            }
        }

        /// <summary>
        /// Gets the index of the hovered star.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns></returns>
        private float GetHoveredStarIndex(Point pos)
        {
            if (_toggleHalfStar)
            {
                float widthSection = Width / (float)_maximum / 2f;

                for (var i = 0f; i < _maximum; i += 0.5f)
                {
                    float starX = i * widthSection * 2f;

                    // If cursor is within the x region of the iterated star
                    if ((pos.X >= starX) && (pos.X <= starX + widthSection))
                    {
                        return i + 0.5f;
                    }
                }

                return -1;
            }
            else
            {
                var widthSection = (int)((Width / (double)_maximum) + 0.5);

                for (var i = 0; i < _maximum; i++)
                {
                    float starX = i * widthSection;

                    // If cursor is within the x region of the iterated star
                    if ((pos.X >= starX) && (pos.X <= starX + widthSection))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Gets the semi star polygon.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns></returns>
        private PointF[] GetSemiStarPolygon(RectangleF rect)
        {
            switch (_ratingType)
            {
                case StarType.Default:
                    {
                        return StarGenerator.GenerateNormalSemiStar(rect);
                    }

                case StarType.Thick:
                    {
                        return StarGenerator.GenerateFatSemiStar(rect);
                    }

                case StarType.Detailed:
                    {
                        return StarGenerator.GenerateDetailedSemiStar(rect);
                    }

                default:
                    {
                        return null;
                    }
            }
        }

        /// <summary>
        /// Gets the star polygon.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns></returns>
        private PointF[] GetStarPolygon(RectangleF rect)
        {
            switch (_ratingType)
            {
                case StarType.Default:
                    {
                        return StarGenerator.GenerateNormalStar(rect);
                    }

                case StarType.Thick:
                    {
                        return StarGenerator.GenerateFatStar(rect);
                    }

                case StarType.Detailed:
                    {
                        return StarGenerator.GenerateDetailedStar(rect);
                    }

                default:
                    {
                        return null;
                    }
            }
        }

        /// <summary>
        /// Called when [rating changed].
        /// </summary>
        private void OnRatingChanged()
        {
            RatingChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Called when [stars panned].
        /// </summary>
        private void OnStarsPanned()
        {
            StarsPanned?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Updates the graphics buffer.
        /// </summary>
        private void UpdateGraphicsBuffer()
        {
            if ((Width > 0) && (Height > 0))
            {
                _bufferedContext.MaximumBuffer = new Size(Width + 1, Height + 1);
                _bufferedGraphics = _bufferedContext.Allocate(CreateGraphics(), ClientRectangle);
                _bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        /// <summary>
        /// Updates the size.
        /// </summary>
        private void UpdateSize()
        {
            var height = (int)(_starWidth + borderWidth + 0.5);
            var width = (int)(TotalStarWidth + TotalSpacing + TotalStrokeWidth + 0.5);
            Size = new Size(width, height);
        }
    }
}