using Elements.Enumerators;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elements.Utilities
{
    /// <summary>
    /// The <see cref="RelationUtilities"/> class.
    /// </summary>
    public static class RelationUtilities
    {
        /// <summary>
        /// Draws the text image relation.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="textImageRelation">The text Image ImageTextRelation.</param>
        /// <param name="image">The image rectangle.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="bounds">The outer bounds.</param>
        /// <param name="relation">The relation type.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        public static Point GetTextImageRelationLocation(Graphics graphics, TextImageRelation textImageRelation, Rectangle image, string text, Font font, Rectangle bounds, ImageTextRelation relation)
        {
            Point imageLocation;
            Point textLocation;
            Size textSize = StringUtilities.MeasureText(text, font, graphics);

            switch (textImageRelation)
            {
                case TextImageRelation.Overlay:
                    {
                        imageLocation = Overlay(image, bounds, textSize, ImageTextRelation.Image);
                        textLocation = Overlay(image, bounds, textSize, ImageTextRelation.Text);
                        break;
                    }

                case TextImageRelation.ImageBeforeText:
                    {
                        imageLocation = ImageBeforeText(image, bounds, textSize, ImageTextRelation.Image);
                        textLocation = ImageBeforeText(image, bounds, textSize, ImageTextRelation.Text);
                        break;
                    }

                case TextImageRelation.TextBeforeImage:
                    {
                        imageLocation = TextBeforeImage(image, bounds, textSize, ImageTextRelation.Image);
                        textLocation = TextBeforeImage(image, bounds, textSize, ImageTextRelation.Text);
                        break;
                    }

                case TextImageRelation.ImageAboveText:
                    {
                        imageLocation = ImageAboveText(image, bounds, textSize, ImageTextRelation.Image);
                        textLocation = ImageAboveText(image, bounds, textSize, ImageTextRelation.Text);
                        break;
                    }

                case TextImageRelation.TextAboveImage:
                    {
                        imageLocation = TextAboveImage(image, bounds, textSize, ImageTextRelation.Image);
                        textLocation = TextAboveImage(image, bounds, textSize, ImageTextRelation.Text);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(relation), relation, null);
                    }
            }

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>
        /// Retrieves the relation location.
        /// </summary>
        /// <param name="relation">The relation.</param>
        /// <param name="imageLocation">The image location.</param>
        /// <param name="textLocation">The text location.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        private static Point GetRelationPoint(ImageTextRelation relation, Point imageLocation, Point textLocation)
        {
            Point result;
            switch (relation)
            {
                case ImageTextRelation.Image:
                    {
                        result = imageLocation;
                        break;
                    }

                case ImageTextRelation.Text:
                    {
                        result = textLocation;
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(relation), relation, null);
                    }
            }

            return result;
        }

        /// <summary>
        /// The image above text location.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        private static Point ImageAboveText(Rectangle image, Rectangle bounds, Size textSize, ImageTextRelation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point { X = bounds.Width / 2 };

            // Set image
            imageLocation.X = newPosition.X - (image.Width / 2);
            imageLocation.Y = newPosition.Y + 4;

            // Set text
            textLocation.X = newPosition.X - (textSize.Width / 2);
            textLocation.Y = imageLocation.Y + image.Height;

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>
        /// The image before text location.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        private static Point ImageBeforeText(Rectangle image, Rectangle bounds, Size textSize, ImageTextRelation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point { Y = bounds.Height / 2 };

            // Set image
            imageLocation.X = newPosition.X + 4;
            imageLocation.Y = newPosition.Y - (image.Height / 2);

            // Set text
            textLocation.X = imageLocation.X + image.Width;
            textLocation.Y = newPosition.Y - (textSize.Height / 2);

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>
        /// The overlay location.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        private static Point Overlay(Rectangle image, Rectangle bounds, Size textSize, ImageTextRelation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point { X = bounds.Width / 2, Y = bounds.Height / 2 };

            // Set image
            imageLocation.X = newPosition.X - (image.Width / 2);
            imageLocation.Y = newPosition.Y - (image.Height / 2);

            // Set text
            textLocation.X = newPosition.X - (textSize.Width / 2);
            textLocation.Y = newPosition.Y - (textSize.Height / 2);

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>
        /// The text above image location.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        private static Point TextAboveImage(Rectangle image, Rectangle bounds, Size textSize, ImageTextRelation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point { X = bounds.Width / 2 };

            // Set text
            textLocation.X = newPosition.X - (textSize.Width / 2);
            textLocation.Y = imageLocation.Y + 4;

            // Set image
            imageLocation.X = newPosition.X - (image.Width / 2);
            imageLocation.Y = newPosition.Y + textSize.Height + 4;

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>
        /// The text before image location.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        private static Point TextBeforeImage(Rectangle image, Rectangle bounds, Size textSize, ImageTextRelation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point { Y = bounds.Height / 2 };

            // Set text
            textLocation.X = newPosition.X + 4;
            textLocation.Y = newPosition.Y - (textSize.Height / 2);

            // Set image
            imageLocation.X = textLocation.X + textSize.Width;
            imageLocation.Y = newPosition.Y - (image.Height / 2);

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }
    }
}