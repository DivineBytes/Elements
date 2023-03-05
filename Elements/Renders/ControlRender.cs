using Elements.Enumerators;
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
    }
}