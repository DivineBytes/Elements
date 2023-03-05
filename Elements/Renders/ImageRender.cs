using Elements.Enumerators;
using Elements.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Elements.Renders
{
    /// <summary>
    /// The <see cref="ImageRender"/> class.
    /// </summary>
    public static class ImageRender
    {
        /// <summary>Fills the background graphics path.</summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="background">The background color.</param>
        /// <param name="rectangle">The coordinates of the rectangle to draw.</param>
        /// <param name="border">The border type.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        private static GraphicsPath CreateBackgroundFill(Graphics graphics, Color background, Rectangle rectangle, Border border)
        {
            GraphicsPath backgroundPath = Border.CreatePath(border, rectangle);
            graphics.SetClip(backgroundPath);
            graphics.FillRectangle(new SolidBrush(background), rectangle);
            graphics.ResetClip();
            return backgroundPath;
        }

        /// <summary>Draws the control background, with a BackColor and the specified BackgroundImage.</summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="backColor">The color to use for the background.</param>
        /// <param name="backgroundImage">The background image to use for the background.</param>
        /// <param name="rectangle">The coordinates of the rectangle to draw.</param>
        /// <param name="border">The shape settings.</param>
        public static void Render(Graphics graphics, Color backColor, Image backgroundImage, Rectangle rectangle, Border border)
        {
            GraphicsPath _controlGraphicsPath = CreateBackgroundFill(graphics, backColor, rectangle, border);

            if (backgroundImage != null)
            {
                Point _location = new Point(rectangle.Width - backgroundImage.Width, rectangle.Height - backgroundImage.Height);
                Size _size = new Size(backgroundImage.Width, backgroundImage.Height);
                graphics.SetClip(_controlGraphicsPath);
                graphics.DrawImage(backgroundImage, new Rectangle(_location, _size));
                graphics.ResetClip();
            }
        }

        /// <summary>
        /// Renders the image.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="color">The color.</param>
        /// <param name="image">The image.</param>
        /// <param name="imageLayout">The image Layout.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        public static void Render(Graphics graphics, Color color, Image image, ElementImageLayout imageLayout, Rectangle clientRectangle)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            if (color == Color.Empty)
            {
                throw new ArgumentNullException(nameof(color));
            }

            if (clientRectangle == Rectangle.Empty)
            {
                throw new ArgumentNullException(nameof(clientRectangle));
            }

            graphics.FillRectangle(new SolidBrush(color), clientRectangle);
            Render(graphics, image, imageLayout, clientRectangle);
        }

        /// <summary>
        /// Render the image.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="image">The image.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        public static void Render(Graphics graphics, Image image, ElementImageLayout layout, Rectangle clientRectangle)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            if (image == null)
            {
                return;
            }

            if (clientRectangle == Rectangle.Empty)
            {
                throw new ArgumentNullException(nameof(clientRectangle));
            }

            switch (layout)
            {
                case ElementImageLayout.None:
                    {
                        Render(graphics, image);
                        break;
                    }

                case ElementImageLayout.Center:
                    {
                        RenderCentered(graphics, clientRectangle, image);
                        break;
                    }

                case ElementImageLayout.Stretch:
                    {
                        RenderFilled(graphics, clientRectangle, image);
                        break;
                    }
            }
        }

        /// <summary>
        /// Renders the full image.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="image">The image to draw.</param>
        public static void Render(Graphics graphics, Image image)
        {
            graphics.DrawImage(image, new Point(0, 0));
        }

        /// <summary>
        /// Render the image in the center of the client rectangle using the image size.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="image">The image to draw.</param>
        /// <param name="offset">The location offset.</param>
        public static void RenderCentered(Graphics graphics, Rectangle clientRectangle, Image image, Point offset = new Point())
        {
            Point _location = new Point((clientRectangle.Width / 2) - (image.Width / 2) + offset.X, (clientRectangle.Height / 2) - (image.Height / 2) + offset.Y);
            graphics.DrawImage(image, _location);
        }

        /// <summary>
        /// Render the image in the center of the client rectangle using the client size to make the
        /// image fit if it's too large.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="image">The image to draw.</param>
        public static void RenderCenteredFit(Graphics graphics, Rectangle clientRectangle, Image image)
        {
            Rectangle centerRectangle = new Rectangle { Location = new Point(clientRectangle.Width / 4, clientRectangle.Height / 4), Size = new Size(clientRectangle.Width / 2, clientRectangle.Height / 2) };

            graphics.DrawImage(image, centerRectangle);
        }

        /// <summary>
        /// Render the image.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="image">The image to draw.</param>
        public static void RenderFilled(Graphics graphics, Rectangle clientRectangle, Image image)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            graphics.DrawImage(image, clientRectangle);
        }
    }
}