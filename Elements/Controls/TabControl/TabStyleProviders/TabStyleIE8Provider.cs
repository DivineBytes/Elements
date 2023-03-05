﻿using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Elements.Controls.TabControl.TabStyleProviders
{
    /// <summary>
    /// The <see cref="TabStyleIE8Provider"/> class.
    /// </summary>
    /// <seealso cref="Elements.Controls.TabControl.TabStyleProviders.TabStyleRoundedProvider"/>
    [ToolboxItem(false)]
    public class TabStyleIE8Provider : TabStyleRoundedProvider
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TabStyleIE8Provider"/> class.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        public TabStyleIE8Provider(TabControl tabControl) : base(tabControl)
        {
            _Radius = 3;
            _ShowTabCloser = true;
            _CloserColorActive = Color.Red;

            // Must set after the _Radius as this is used in the calculations of the actual padding
            Padding = new Point(6, 5);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the page background brush.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public override Brush GetPageBackgroundBrush(int index)
        {
            // Capture the colours dependant on selection state of the tab
            Color light = Color.FromArgb(227, 238, 251);

            if (_TabControl.SelectedIndex == index)
            {
                light = SystemColors.Window;
            }
            else if (!_TabControl.TabPages[index].Enabled)
            {
                light = Color.FromArgb(207, 207, 207);
            }
            else if (_HotTrack && index == _TabControl.ActiveIndex)
            {
                // Enable hot tracking
                light = Color.FromArgb(234, 246, 253);
            }

            return new SolidBrush(light);
        }

        /// <summary>
        /// Gets the tab rect.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public override Rectangle GetTabRect(int index)
        {
            if (index < 0)
            {
                return new Rectangle();
            }

            Rectangle tabBounds = base.GetTabRect(index);
            bool firstTabinRow = _TabControl.IsFirstTabInRow(index);

            // Make non-SelectedTabs smaller and selected tab bigger
            if (index != _TabControl.SelectedIndex)
            {
                switch (_TabControl.Alignment)
                {
                    case TabAlignment.Top:
                        tabBounds.Y += 1;
                        tabBounds.Height -= 1;
                        break;

                    case TabAlignment.Bottom:
                        tabBounds.Height -= 1;
                        break;

                    case TabAlignment.Left:
                        tabBounds.X += 1;
                        tabBounds.Width -= 1;
                        break;

                    case TabAlignment.Right:
                        tabBounds.Width -= 1;
                        break;
                }
            }
            else
            {
                switch (_TabControl.Alignment)
                {
                    case TabAlignment.Top:
                        tabBounds.Y -= 1;
                        tabBounds.Height += 1;

                        if (firstTabinRow)
                        {
                            tabBounds.Width += 1;
                        }
                        else
                        {
                            tabBounds.X -= 1;
                            tabBounds.Width += 2;
                        }

                        break;

                    case TabAlignment.Bottom:
                        tabBounds.Height += 1;

                        if (firstTabinRow)
                        {
                            tabBounds.Width += 1;
                        }
                        else
                        {
                            tabBounds.X -= 1;
                            tabBounds.Width += 2;
                        }

                        break;

                    case TabAlignment.Left:
                        tabBounds.X -= 1;
                        tabBounds.Width += 1;

                        if (firstTabinRow)
                        {
                            tabBounds.Height += 1;
                        }
                        else
                        {
                            tabBounds.Y -= 1;
                            tabBounds.Height += 2;
                        }

                        break;

                    case TabAlignment.Right:
                        tabBounds.Width += 1;
                        if (firstTabinRow)
                        {
                            tabBounds.Height += 1;
                        }
                        else
                        {
                            tabBounds.Y -= 1;
                            tabBounds.Height += 2;
                        }

                        break;
                }
            }

            // Adjust first tab in the row to align with tabpage
            EnsureFirstTabIsInView(ref tabBounds, index);
            return tabBounds;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Draws the tab closer.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="graphics">The graphics.</param>
        protected override void DrawTabCloser(int index, Graphics graphics)
        {
            if (_ShowTabCloser)
            {
                Rectangle closerRect = _TabControl.GetTabCloserRect(index);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                if (closerRect.Contains(_TabControl.MousePosition))
                {
                    using (GraphicsPath closerPath = GetCloserButtonPath(closerRect))
                    {
                        graphics.FillPath(Brushes.White, closerPath);
                        using (Pen closerPen = new Pen(BorderColor))
                        {
                            graphics.DrawPath(closerPen, closerPath);
                        }
                    }

                    using (GraphicsPath closerPath = GetCloserPath(closerRect))
                    {
                        using (Pen closerPen = new Pen(_CloserColorActive))
                        {
                            closerPen.Width = 2;
                            graphics.DrawPath(closerPen, closerPath);
                        }
                    }
                }
                else
                {
                    using (GraphicsPath closerPath = GetCloserPath(closerRect))
                    {
                        using (Pen closerPen = new Pen(_CloserColor))
                        {
                            closerPen.Width = 2;
                            graphics.DrawPath(closerPen, closerPath);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the tab background brush.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        protected override Brush GetTabBackgroundBrush(int index)
        {
            LinearGradientBrush fillBrush = null;

            // Capture the colours dependant on selection state of the tab
            Color dark = Color.FromArgb(227, 238, 251);
            Color light = Color.FromArgb(227, 238, 251);

            if (_TabControl.SelectedIndex == index)
            {
                dark = Color.FromArgb(196, 222, 251);
                light = SystemColors.Window;
            }
            else if (!_TabControl.TabPages[index].Enabled)
            {
                light = dark;
            }
            else if (HotTrack && index == _TabControl.ActiveIndex)
            {
                // Enable hot tracking
                light = SystemColors.Window;
                dark = Color.FromArgb(166, 203, 248);
            }

            // Get the correctly aligned gradient
            Rectangle tabBounds = GetTabRect(index);
            tabBounds.Inflate(3, 3);
            tabBounds.X -= 1;
            tabBounds.Y -= 1;
            switch (_TabControl.Alignment)
            {
                case TabAlignment.Top:
                    fillBrush = new LinearGradientBrush(tabBounds, dark, light, LinearGradientMode.Vertical);
                    break;

                case TabAlignment.Bottom:
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Vertical);
                    break;

                case TabAlignment.Left:
                    fillBrush = new LinearGradientBrush(tabBounds, dark, light, LinearGradientMode.Horizontal);
                    break;

                case TabAlignment.Right:
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Horizontal);
                    break;
            }

            // Add the blend
            fillBrush.Blend = GetBackgroundBlend(index);

            return fillBrush;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the closer button path.
        /// </summary>
        /// <param name="closerRect">The closer rect.</param>
        /// <returns></returns>
        private static GraphicsPath GetCloserButtonPath(Rectangle closerRect)
        {
            GraphicsPath closerPath = new GraphicsPath();
            closerPath.AddLine(closerRect.X - 1, closerRect.Y - 2, closerRect.Right + 1, closerRect.Y - 2);
            closerPath.AddLine(closerRect.Right + 2, closerRect.Y - 1, closerRect.Right + 2, closerRect.Bottom + 1);
            closerPath.AddLine(closerRect.Right + 1, closerRect.Bottom + 2, closerRect.X - 1, closerRect.Bottom + 2);
            closerPath.AddLine(closerRect.X - 2, closerRect.Bottom + 1, closerRect.X - 2, closerRect.Y - 1);
            closerPath.CloseFigure();
            return closerPath;
        }

        /// <summary>
        /// Gets the background blend.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private Blend GetBackgroundBlend(int index)
        {
            float[] relativeIntensities = { 0f, 0.7f, 1f };
            float[] relativePositions = { 0f, 0.8f, 1f };

            if (_TabControl.SelectedIndex != index)
            {
                relativeIntensities = new[] { 0f, 0.3f, 1f };
                relativePositions = new[] { 0f, 0.2f, 1f };
            }

            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;

            return blend;
        }

        #endregion Private Methods
    }
}