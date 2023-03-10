using Elements.Base;
using Elements.Constants;
using Elements.Enumerators;
using Elements.Models;
using Elements.Renders;
using Elements.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.GroupBox
{
    /// <summary>
    /// The <see cref="GroupBox"/> class.
    /// </summary>
    /// <seealso cref="NestedControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [Description("The GroupBox")]
    [Designer(typeof(GroupBoxDesigner))]
    [ToolboxBitmap(typeof(GroupBox), "GroupBox.bmp")]
    [ToolboxItem(true)]
    public class GroupBox : NestedControlBase
    {
        #region Private Fields

        private Border _border;
        private GroupBoxStyle _boxStyle;
        private Image _image;
        private ElementImageLayout _imageLayout;
        private Separator.Separator _separator;
        private StringAlignment _textAlignment;
        private TextImageRelation _textImageRelation;
        private StringAlignment _textLineAlignment;
        private int _titleBoxHeight;
        private Rectangle _titleBoxRectangle;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupBox"/> class.
        /// </summary>
        public GroupBox()
        {
            BackColor = Color.Transparent;

            _border = new Border();
            _separator = new Separator.Separator
            {
                BackColor = Color.Transparent,
                ForeColor = Color.Transparent
            };

            _boxStyle = GroupBoxStyle.Default;
            _titleBoxHeight = 25;
            _textImageRelation = TextImageRelation.ImageBeforeText;
            _textAlignment = StringAlignment.Center;
            _textLineAlignment = StringAlignment.Center;

            _imageLayout = ElementImageLayout.Stretch;

            Size = new Size(220, 180);

            BackColorState.Enabled = Color.FromArgb(241, 244, 249);
            BackColorState.Disabled = Color.FromArgb(220, 220, 220);

            Padding = new Padding(5, _titleBoxHeight + _border.Thickness, 5, 5);

            Controls.Add(_separator);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the background image layout.
        /// </summary>
        /// <value>The background image layout.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.ImageLayout)]
        public new ElementImageLayout BackgroundImageLayout
        {
            get
            {
                return _imageLayout;
            }

            set
            {
                _imageLayout = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Border Border
        {
            get
            {
                return _border;
            }

            set
            {
                _border = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the box style.
        /// </summary>
        /// <value>The box style.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.GroupBoxStyle)]
        public GroupBoxStyle BoxStyle
        {
            get
            {
                return _boxStyle;
            }

            set
            {
                _boxStyle = value;

                if (_boxStyle == GroupBoxStyle.Classic)
                {
                    _separator.Visible = false;
                }
                else
                {
                    _separator.Visible = true;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Image)]
        public Image Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GroupBox"/> is separator.
        /// </summary>
        /// <value><c>true</c> if separator; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Control)]
        public bool Separator
        {
            get
            {
                return _separator.Visible;
            }

            set
            {
                _separator.Visible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the separator.
        /// </summary>
        /// <value>The color of the separator.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color SeparatorColor
        {
            get
            {
                return _separator.Line;
            }

            set
            {
                _separator.Line = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the separator shadow.
        /// </summary>
        /// <value>The separator shadow.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color SeparatorShadow
        {
            get
            {
                return _separator.Shadow;
            }

            set
            {
                _separator.Shadow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.TextAlignment)]
        public StringAlignment TextAlignment
        {
            get
            {
                return _textAlignment;
            }

            set
            {
                _textAlignment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text image relation.
        /// </summary>
        /// <value>The text image relation.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.TextImageRelation)]
        public TextImageRelation TextImageRelation
        {
            get
            {
                return _textImageRelation;
            }

            set
            {
                _textImageRelation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text line alignment.
        /// </summary>
        /// <value>The text line alignment.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.TextAlignment)]
        public StringAlignment TextLineAlignment
        {
            get
            {
                return _textLineAlignment;
            }

            set
            {
                _textLineAlignment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the height of the title box.
        /// </summary>
        /// <value>The height of the title box.</value>
        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Size)]
        public int TitleBoxHeight
        {
            get
            {
                return _titleBoxHeight;
            }

            set
            {
                _titleBoxHeight = value;
                Invalidate();
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.GammaCorrected;

            Size textArea = StringUtilities.MeasureText(Text, Font, graphics);
            Rectangle group = ConfigureStyleBox(textArea);
            Rectangle title = ConfigureStyleTitleBox(textArea);

            _titleBoxRectangle = new Rectangle(title.X, title.Y, title.Width - 1, title.Height);

            Rectangle _clientRectangle = new Rectangle(group.X, group.Y, group.Width, group.Height);
            GraphicsPath controlGraphicsPath = Border.CreatePath(_border, _clientRectangle);

            graphics.SetClip(controlGraphicsPath);

            Color _backColor = Enabled ? BackColorState.Enabled : BackColorState.Disabled;
            graphics.FillRectangle(new SolidBrush(_backColor), _clientRectangle);

            ImageRender.Render(graphics, BackgroundImage, _imageLayout, group);

            if (_separator.Visible)
            {
                _separator.Location = new Point(_titleBoxRectangle.X + _border.Thickness, _titleBoxRectangle.Bottom);

                int buffer = 0;

                switch (_border.Shape)
                {
                    case TileShape.Rectangle:
                        buffer = 2;
                        break;

                    case TileShape.Rounded:
                        buffer = 1;
                        break;
                }

                _separator.Size = new Size(Width - _border.Thickness - buffer, 1);
            }

            if (_boxStyle == GroupBoxStyle.Classic)
            {
                Size _newSize;
                if (_image != null)
                {
                    _newSize = _image.Size;
                }
                else
                {
                    _newSize = new Size(0, 0);
                }

                _titleBoxRectangle = new Rectangle(5, 0, title.Width - 1, title.Height);
                Point _titleBoxBackground = RelationUtilities.GetTextImageRelationLocation(graphics, _textImageRelation, new Rectangle(new Point(0, 0), _newSize), Text, Font, _titleBoxRectangle, ImageTextRelation.Text);
                graphics.FillRectangle(new SolidBrush(BackColorState.Enabled), new Rectangle(new Point(_titleBoxBackground.X, _titleBoxBackground.Y), new Size(_titleBoxRectangle.Width, _titleBoxRectangle.Height)));
            }

            if (_image != null)
            {
                ControlRender.RenderContent(e.Graphics, _titleBoxRectangle, Text, Font, ForeColor, _image, _image.Size, _textImageRelation);
            }
            else
            {
                StringFormat _stringFormat = new StringFormat { Alignment = _textAlignment, LineAlignment = _textLineAlignment };

                StringUtilities.Render(e.Graphics, _titleBoxRectangle, Text, Font, ForeColor, _stringFormat);
            }

            graphics.ResetClip();

            Border.Render(e.Graphics, _border, MouseState, controlGraphicsPath);

            base.OnPaint(e);
        }

        /// <summary>
        /// Raises the <see cref="E:PaintBackground"/> event.
        /// </summary>
        /// <param name="pevent">
        /// The <see cref="PaintEventArgs"/> instance containing the event data.
        /// </param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            if (Parent != null)
            {
                if (Parent is NestedControlBase nestedControlBase)
                {
                    pevent.Graphics.Clear(nestedControlBase.BackColorState.Enabled);
                }
                else
                {
                    pevent.Graphics.Clear(Parent.BackColor);
                }
            }
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Configures the style box.
        /// </summary>
        /// <param name="textArea">The text area.</param>
        /// <returns></returns>
        private Rectangle ConfigureStyleBox(Size textArea)
        {
            Size groupBoxSize = new Size();
            Point groupBoxPoint = new Point(0, 0);

            switch (_boxStyle)
            {
                case GroupBoxStyle.Default:
                    {
                        groupBoxSize = new Size(ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                        break;
                    }

                case GroupBoxStyle.Classic:
                    {
                        groupBoxPoint = new Point(0, textArea.Height / 2);
                        groupBoxSize = new Size(Width - _border.Thickness, Height - (textArea.Height / 2) - _border.Thickness);

                        break;
                    }
            }

            Rectangle groupBoxRectangle = new Rectangle(groupBoxPoint, groupBoxSize);

            return groupBoxRectangle;
        }

        /// <summary>
        /// Configures the style title box.
        /// </summary>
        /// <param name="textArea">The text area.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private Rectangle ConfigureStyleTitleBox(Size textArea)
        {
            Size titleSize = new Size(Width, _titleBoxHeight);
            Point titlePoint = new Point(0, 0);

            switch (_boxStyle)
            {
                case GroupBoxStyle.Default:
                    {
                        titlePoint = new Point(titlePoint.X, 0);

                        break;
                    }

                case GroupBoxStyle.Classic:
                    {
                        const int Spacing = 5;

                        titlePoint = new Point(titlePoint.X, 0);

                        // +1 extra whitespace in case of FontStyle=Bold
                        titleSize = new Size(textArea.Width + 2, textArea.Height);

                        switch (_textAlignment)
                        {
                            case StringAlignment.Near:
                                {
                                    titlePoint.X += 5;
                                    break;
                                }

                            case StringAlignment.Center:
                                {
                                    titlePoint.X = (Width / 2) - (textArea.Width / 2);
                                    break;
                                }

                            case StringAlignment.Far:
                                {
                                    titlePoint.X = Width - textArea.Width - Spacing;
                                    break;
                                }

                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            return new Rectangle(titlePoint, titleSize);
        }

        #endregion Private Methods
    }
}