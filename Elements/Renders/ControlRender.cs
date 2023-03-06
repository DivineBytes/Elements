using Elements.Enumerators;
using Elements.Models;
using Elements.Utilities;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Elements.Renders
{
    /// <summary>
    /// The <see cref="ControlRender"/> class.
    /// </summary>
    public static class ControlRender
    {
        #region Public Methods

        /// <summary>
        /// Render bars.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="point">The point.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        /// <param name="bars">The bars.</param>
        /// <param name="spacing">The spacing.</param>
        public static void RenderBars(Graphics graphics, Point point, Size size, Color color, int bars, int spacing)
        {
            // TODO: Auto align in middle (to avoid drawing from top down since size can change depending on # bars.)
            int bump = spacing;

            for (var i = 0; i < bars; i++)
            {
                // Construct bar
                Pen linePen = new Pen(color, 2);

                // X , Y
                Point pt1 = new Point(point.X, point.Y + bump);

                // X , Y
                Point pt2 = new Point(point.X + size.Width, point.Y + bump);

                // Draw line bar
                graphics.DrawLine(linePen, pt1, pt2);

                // Prepare for next bar drawing
                bump += spacing;
            }
        }

        /// <summary>
        /// Draws the text and image content.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The coordinates of the rectangle to draw.</param>
        /// <param name="text">The string to draw.</param>
        /// <param name="font">The font to use in the string.</param>
        /// <param name="foreColor">The color of the string.</param>
        /// <param name="image">The image to draw.</param>
        /// <param name="imageSize">The image Size.</param>
        /// <param name="textImageRelation">The text image relation.</param>
        public static void RenderContent(Graphics graphics, Rectangle rectangle, string text, Font font, Color foreColor, Image image, Size imageSize, TextImageRelation textImageRelation)
        {
            Rectangle _imageRectangle = new Rectangle(new Point(), imageSize);
            Point _imagePoint = RelationUtilities.GetTextImageRelationLocation(graphics, textImageRelation, _imageRectangle, text, font, rectangle, ImageTextRelation.Image);
            Point _textPoint = RelationUtilities.GetTextImageRelationLocation(graphics, textImageRelation, _imageRectangle, text, font, rectangle, ImageTextRelation.Text);

            graphics.DrawImage(image, new Rectangle(_imagePoint, imageSize));
            graphics.DrawString(text, font, new SolidBrush(foreColor), _textPoint);
        }

        /// <summary>
        /// Renders a triangle.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The button rectangle.</param>
        /// <param name="color">The color.</param>
        /// <param name="direction">The direction.</param>
        public static void RenderTriangle(Graphics graphics, Rectangle rectangle, Color color, Vertical direction)
        {
            Point[] points = new Point[3];

            switch (direction)
            {
                case Vertical.Down:
                    {
                        points[0].X = rectangle.X;
                        points[0].Y = rectangle.Y;

                        points[1].X = rectangle.X + rectangle.Width;
                        points[1].Y = rectangle.Y;

                        points[2].X = rectangle.X + (rectangle.Width / 2);
                        points[2].Y = rectangle.Y + rectangle.Height;
                        break;
                    }

                case Vertical.Up:
                    {
                        points[0].X = rectangle.X + (rectangle.Width / 2);
                        points[0].Y = rectangle.Y;

                        points[1].X = rectangle.X;
                        points[1].Y = rectangle.Y + rectangle.Height;

                        points[2].X = rectangle.X + rectangle.Width;
                        points[2].Y = rectangle.Y + rectangle.Height;
                        break;
                    }
            }

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.FillPolygon(new SolidBrush(color), points);
        }

        /// <summary>
        /// Draws a check box control in the specified state and with the specified text.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="checkOptions">The check options.</param>
        /// <param name="state">The toggle state of the check mark.</param>
        /// <param name="enabled">The state to draw the check mark in.</param>
        /// <param name="color">The brush used to fill the background.</param>
        /// <param name="backgroundImage">The background Image.</param>
        /// <param name="mouseState">The state of the mouse on the control.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="foreColor">The fore Color.</param>
        /// <param name="textPoint">The text Point.</param>
        public static void DrawCheckBox(Graphics graphics, CheckOptions checkOptions, bool state, bool enabled, Color color, Image backgroundImage, MouseStates mouseState, string text, Font font, Color foreColor, Point textPoint)
        {
            DrawCheckBox(graphics, checkOptions, state, enabled, color, backgroundImage, mouseState);
            graphics.DrawString(text, font, new SolidBrush(foreColor), textPoint);
        }

        /// <summary>
        /// Draws a check box control in the specified state and location.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="checkOptions">The check options.</param>
        /// <param name="checkState">The check State.</param>
        /// <param name="enabled">The state to draw the check mark in.</param>
        /// <param name="color">The background color.</param>
        /// <param name="backgroundImage">The background Image.</param>
        /// <param name="mouseStates">The mouse States.</param>
        public static void DrawCheckBox(Graphics graphics, CheckOptions checkOptions, bool checkState, bool enabled, Color color, Image backgroundImage, MouseStates mouseStates)
        {
            GraphicsPath _boxGraphicsPath = checkOptions.BoxBorder.CreatePath(checkOptions.Box);

            graphics.SetClip(_boxGraphicsPath);
            ImageRender.Render(graphics, color, backgroundImage, checkOptions.Box, checkOptions.BoxBorder);

            if (checkState)
            {
                DrawCheckMark(graphics, checkOptions);
            }

            Border.Render(graphics, checkOptions.BoxBorder, mouseStates, _boxGraphicsPath);
            graphics.ResetClip();
        }

        /// <summary>
        /// Draws the checkmark.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="color">The color.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="thickness">The thickness.</param>
        public static void DrawCheckmark(Graphics graphics, Color color, Rectangle rectangle, float thickness = 2)
        {
            Point[] _locations = {
                new Point((rectangle.Width / 4) - 1, rectangle.Y + 4 + (rectangle.Height / 3)),
                new Point((rectangle.Width / 4) + 3, rectangle.Y + 7 + (rectangle.Height / 3)),
                new Point((rectangle.Width / 4) + 9, rectangle.Y + (rectangle.Height / 3)) };

            graphics.DrawLines(new Pen(color, thickness), _locations);
        }

        /// <summary>
        /// Draws a check mark control in the specified state, on the specified graphics surface,
        /// and within the specified bounds.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="checkStyle">The check mark type.</param>
        public static void DrawCheckMark(Graphics graphics, CheckOptions checkStyle)
        {
            Point location = new Point(0, 0);

            if (checkStyle.AutoSize)
            {
                Size _characterSize = StringUtilities.MeasureText(checkStyle.Character.ToString(), checkStyle.Font, graphics);
                location = new Point(checkStyle.Check.X + (checkStyle.Check.Width / 2) - (_characterSize.Width / 2), checkStyle.Check.Y + (checkStyle.Check.Height / 2) - (_characterSize.Height / 2));
            }
            else
            {
                location = checkStyle.Check.Location;
            }

            switch (checkStyle.Style)
            {
                case CheckOptions.CheckStyle.Check:
                    DrawCheckmark(graphics, checkStyle.Color, checkStyle.Check, checkStyle.CheckBorder.Thickness);
                    break;

                case CheckOptions.CheckStyle.Image:
                    if (checkStyle.Image != null)
                    {
                        Rectangle _imageRectangle = new Rectangle(location, checkStyle.Box.Size);
                        graphics.DrawImage(checkStyle.Image, _imageRectangle);
                    }
                    break;

                case CheckOptions.CheckStyle.Shape:
                    GraphicsPath shapePath = checkStyle.CheckBorder.CreatePath(checkStyle.Check);
                    graphics.FillPath(new SolidBrush(checkStyle.Color), shapePath);
                    break;

                case CheckOptions.CheckStyle.Symbol:
                    graphics.DrawString(checkStyle.Character.ToString(), checkStyle.Font, new SolidBrush(checkStyle.Color), location);
                    break;
            }
        }

        #endregion Public Methods
    }
}