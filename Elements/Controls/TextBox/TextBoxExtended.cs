using Elements.Base;
using Elements.Constants;
using Elements.Enumerators;
using Elements.Models;
using Elements.Renders;
using Elements.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.TextBox
{
    /// <summary>
    /// The <see cref="TextBoxExtended"/> class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TextBox"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("TextChanged")]
    [DefaultProperty("Text")]
    [Description("The TextBox")]
    [Designer(typeof(TextBoxDesigner))]
    [ToolboxBitmap(typeof(TextBoxExtended), "TextBox.bmp")]
    [ToolboxItem(true)]
    public class TextBoxExtended : ContainedControlBase
    {
        #region Private Fields

        private const int InternalTextBoxMargin = 10;

        private Border _border;
        private ColorState _colorState;
        private TextBoxEx _textBox;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxExtended"/> class.
        /// </summary>
        public TextBoxExtended()
        {
            // Contains another control
            SetStyle(ControlStyles.ContainerControl, true);

            // Cannot select this control, only the child and does not generate a click event
            SetStyle(ControlStyles.Selectable | ControlStyles.StandardClick, false);

            UpdateStyles();

            MinimumSize = new Size(0, 25);
            Size = new Size(135, 25);

            _border = new Border();
            _colorState = new ColorState();

            _textBox = new TextBoxEx()
            {
                Size = new Size(Size.Width - InternalTextBoxMargin, Size.Height),
                Location = new Point(_border.BorderCurve, _border.BorderCurve),
                Text = string.Empty,
                BorderStyle = BorderStyle.None,
                TextAlign = HorizontalAlignment.Left,
                Font = DefaultFont,
                ForeColor = DefaultForeColor,
                BackColor = _colorState.Enabled,
                Multiline = false
            };

            _textBox.KeyDown += TextBox_KeyDown;
            _textBox.Leave += OnLeave;
            _textBox.LostFocus += OnLeave;
            _textBox.MouseLeave += OnLeave;
            _textBox.Enter += OnEnter;
            _textBox.MouseEnter += OnEnter;
            _textBox.GotFocus += OnEnter;

            Controls.Add(_textBox);
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when [key down].
        /// </summary>
        [Browsable(true)]
        [Description("Property Event Changed")]
        [Category(EventCategory.PropertyChanged)]
        public new event KeyEventHandler KeyDown
        {
            add
            {
                _textBox.KeyDown += value;
            }

            remove
            {
                _textBox.KeyDown -= value;
            }
        }

        /// <summary>
        /// Occurs when [key press].
        /// </summary>
        [Browsable(true)]
        [Description("Property Event Changed")]
        [Category(EventCategory.PropertyChanged)]
        public new event KeyPressEventHandler KeyPress
        {
            add
            {
                _textBox.KeyPress += value;
            }

            remove
            {
                _textBox.KeyPress -= value;
            }
        }

        /// <summary>
        /// Occurs when [key up].
        /// </summary>
        [Browsable(true)]
        [Description("Property Event Changed")]
        [Category(EventCategory.PropertyChanged)]
        public new event KeyEventHandler KeyUp
        {
            add
            {
                _textBox.KeyUp += value;
            }

            remove
            {
                _textBox.KeyUp -= value;
            }
        }

        /// <summary>
        /// Occurs when [preview key down].
        /// </summary>
        [Browsable(true)]
        [Description("Property Event Changed")]
        [Category(EventCategory.PropertyChanged)]
        public new event PreviewKeyDownEventHandler PreviewKeyDown
        {
            add
            {
                _textBox.PreviewKeyDown += value;
            }

            remove
            {
                _textBox.PreviewKeyDown -= value;
            }
        }

        /// <summary>
        /// Occurs when [text changed].
        /// </summary>
        [Browsable(true)]
        [Description("Text Changed")]
        [Category(EventCategory.PropertyChanged)]
        public new event EventHandler TextChanged
        {
            add
            {
                _textBox.TextChanged += value;
            }

            remove
            {
                _textBox.TextChanged -= value;
            }
        }

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the automatic complete custom source.
        /// </summary>
        /// <value>The automatic complete custom source.</value>
        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description("AutoCompleteCustomSource")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public virtual AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return _textBox.AutoCompleteCustomSource;
            }

            set
            {
                _textBox.AutoCompleteCustomSource = value;
            }
        }

        /// <summary>
        /// Gets or sets the automatic complete mode.
        /// </summary>
        /// <value>The automatic complete mode.</value>
        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [DefaultValue(typeof(AutoCompleteMode), "None")]
        [Description("AutoCompleteMode")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public virtual AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return _textBox.AutoCompleteMode;
            }

            set
            {
                _textBox.AutoCompleteMode = value;
            }
        }

        /// <summary>
        /// Gets or sets the automatic complete source.
        /// </summary>
        /// <value>The automatic complete source.</value>
        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [DefaultValue(typeof(AutoCompleteSource), "None")]
        [Description("AutoCompleteSource")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public virtual AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return _textBox.AutoCompleteSource;
            }

            set
            {
                _textBox.AutoCompleteSource = value;
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //[EditorBrowsable(EditorBrowsableState.Always)]
        public virtual Border Border
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
        /// Gets or sets the state of the color.
        /// </summary>
        /// <value>The state of the color.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public virtual ColorState ColorState
        {
            get
            {
                return _colorState;
            }

            set
            {
                _colorState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public virtual new Font Font
        {
            get
            {
                return _textBox.Font;
            }

            set
            {
                _textBox.Font = value;
                base.Font = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public virtual new Color ForeColor
        {
            get
            {
                return _textBox.ForeColor;
            }

            set
            {
                _textBox.ForeColor = value;
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description("Max Length")]
        [DefaultValue(32767)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public virtual int MaxLength
        {
            get
            {
                return _textBox.MaxLength;
            }

            set
            {
                _textBox.MaxLength = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [multi line].
        /// </summary>
        /// <value><c>true</c> if [multi line]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Behavior)]
        [Description("MultiLine")]
        [DefaultValue(false)]
        public virtual bool MultiLine
        {
            get
            {
                return _textBox.Multiline;
            }

            set
            {
                _textBox.Multiline = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the password character.
        /// </summary>
        /// <value>The password character.</value>
        [DefaultValue('*')]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description("Password Char")]
        public virtual char PasswordChar
        {
            get
            {
                return _textBox.PasswordChar;
            }

            set
            {
                _textBox.PasswordChar = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [read only].
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Behavior)]
        [Description("ReadOnly")]
        public virtual bool ReadOnly
        {
            get
            {
                return _textBox.ReadOnly;
            }

            set
            {
                _textBox.ReadOnly = value;
            }
        }

        /// <summary>
        /// Gets or sets the scroll bars.
        /// </summary>
        /// <value>The scroll bars.</value>
        [Category(PropertyCategory.Behavior)]
        [Description("ScrollBars")]
        public virtual ScrollBars ScrollBars
        {
            get
            {
                return _textBox.ScrollBars;
            }

            set
            {
                _textBox.ScrollBars = value;
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Bindable(true)]
        [Browsable(true)]
        [Category(PropertyCategory.Appearance)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(false)]
        public virtual new string Text
        {
            get
            {
                return _textBox.Text;
            }

            set
            {
                _textBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        [DefaultValue(typeof(HorizontalAlignment), "Left")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description("TextAlign")]
        public virtual HorizontalAlignment TextAlign
        {
            get
            {
                return _textBox.TextAlign;
            }

            set
            {
                _textBox.TextAlign = value;
            }
        }

        /// <summary>
        /// Gets or sets the text box ex.
        /// </summary>
        /// <value>The text box ex.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public virtual TextBoxEx TextBox
        {
            get
            {
                return _textBox;
            }

            set
            {
                _textBox = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets the length of text in the control.
        /// </summary>
        /// <returns>The number of characters contained in the text of the control.</returns>
        [Browsable(false)]
        public virtual int TextLength
        {
            get
            {
                return _textBox.TextLength;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use system password character].
        /// </summary>
        /// <value><c>true</c> if [use system password character]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description("Use System Password Char")]
        public virtual bool UseSystemPasswordChar
        {
            get
            {
                return _textBox.UseSystemPasswordChar;
            }

            set
            {
                _textBox.UseSystemPasswordChar = value;
            }
        }

        /// <summary>
        /// Gets or sets the watermark.
        /// </summary>
        /// <value>The watermark.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual Watermark Watermark
        {
            get
            {
                return _textBox.Watermark;
            }

            set
            {
                _textBox.Watermark = value;

                if (IsHandleCreated)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [word wrap].
        /// </summary>
        /// <value><c>true</c> if [word wrap]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Behavior)]
        [Description("Word Wrap")]
        public virtual bool WordWrap
        {
            get
            {
                return _textBox.WordWrap;
            }

            set
            {
                _textBox.WordWrap = value;
                Invalidate();
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Appends text to the current text of a rich text box.
        /// </summary>
        /// <param name="text">The text to append to the current contents of the text box.</param>
        public void AppendText(string text)
        {
            _textBox.AppendText(text);
        }

        /// <summary>
        /// Clears all text from the text box control.
        /// </summary>
        public void Clear()
        {
            _textBox.Clear();
        }

        /// <summary>
        /// Clears information about the most recent operation from the undo buffer of the rich text box.
        /// </summary>
        public void ClearUndo()
        {
            _textBox.ClearUndo();
        }

        /// <summary>
        /// Copies the current selection in the text box to the Clipboard.
        /// </summary>
        public void Copy()
        {
            _textBox.Copy();
        }

        /// <summary>
        /// Moves the current selection in the text box to the Clipboard.
        /// </summary>
        public void Cut()
        {
            _textBox.Cut();
        }

        /// <summary>
        /// Specifies that the value of the SelectionLength property is zero so that no characters
        /// are selected in the control.
        /// </summary>
        public void DeselectAll()
        {
            _textBox.DeselectAll();
        }

        /// <summary>
        /// Retrieves the character that is closest to the specified location within the control.
        /// </summary>
        /// <param name="pt">The location from which to seek the nearest character.</param>
        /// <returns>The character at the specified location.</returns>
        public int GetCharFromPosition(Point pt)
        {
            return _textBox.GetCharFromPosition(pt);
        }

        /// <summary>
        /// Retrieves the index of the character nearest to the specified location.
        /// </summary>
        /// <param name="pt">The location to search.</param>
        /// <returns>The zero-based character index at the specified location.</returns>
        public int GetCharIndexFromPosition(Point pt)
        {
            return _textBox.GetCharIndexFromPosition(pt);
        }

        /// <summary>
        /// Retrieves the index of the first character of a given line.
        /// </summary>
        /// <param name="lineNumber">The line for which to get the index of its first character.</param>
        /// <returns>The zero-based character index in the specified line.</returns>
        public int GetFirstCharIndexFromLine(int lineNumber)
        {
            return _textBox.GetFirstCharIndexFromLine(lineNumber);
        }

        /// <summary>
        /// Retrieves the index of the first character of the current line.
        /// </summary>
        /// <returns>The zero-based character index in the current line.</returns>
        public int GetFirstCharIndexOfCurrentLine()
        {
            return _textBox.GetFirstCharIndexOfCurrentLine();
        }

        /// <summary>
        /// Retrieves the line number from the specified character position within the text of the
        /// RichTextBox control.
        /// </summary>
        /// <param name="index">The character index position to search.</param>
        /// <returns>The zero-based line number in which the character index is located.</returns>
        public int GetLineFromCharIndex(int index)
        {
            return _textBox.GetLineFromCharIndex(index);
        }

        /// <summary>
        /// Retrieves the location within the control at the specified character index.
        /// </summary>
        /// <param name="index">The index of the character for which to retrieve the location.</param>
        /// <returns>The location of the specified character.</returns>
        public Point GetPositionFromCharIndex(int index)
        {
            return _textBox.GetPositionFromCharIndex(index);
        }

        /// <summary>
        /// Replaces the current selection in the text box with the contents of the Clipboard.
        /// </summary>
        public void Paste()
        {
            _textBox.Paste();
        }

        /// <summary>
        /// Scrolls the contents of the control to the current caret position.
        /// </summary>
        public void ScrollToCaret()
        {
            _textBox.ScrollToCaret();
        }

        /// <summary>
        /// Selects a range of text in the control.
        /// </summary>
        /// <param name="start">
        /// The position of the first character in the current text selection within the text box.
        /// </param>
        /// <param name="length">The number of characters to select.</param>
        public void Select(int start, int length)
        {
            _textBox.Select(start, length);
        }

        /// <summary>
        /// Selects all text in the control.
        /// </summary>
        public void SelectAll()
        {
            _textBox.SelectAll();
        }

        /// <summary>
        /// Undoes the last edit operation in the text box.
        /// </summary>
        public void Undo()
        {
            _textBox.Undo();
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Creates the handle.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            AutoSize = true;
        }

        /// <summary>
        /// Raises the <see cref="E:GotFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _textBox.Focus();
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (!_textBox.Focused)
            {
                OnMouseStateChanged(this, new Events.MouseStateEventArgs(MouseStates.Normal));
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

            Graphics graphics = e.Graphics;
            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            System.Drawing.Drawing2D.GraphicsPath controlGraphicsPath = Border.CreatePath(_border, _clientRectangle);

            Color _backColor = Enabled ? _colorState.Enabled : _colorState.Disabled;
            _textBox.BackColor = _backColor;

            graphics.SetClip(controlGraphicsPath);

            ImageRender.Render(graphics, _backColor, BackgroundImage, _clientRectangle, _border);

            graphics.ResetClip();

            Border.Render(e.Graphics, _border, MouseState, controlGraphicsPath);
        }
        /// <summary>
        /// Raises the <see cref="E:Resize"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_textBox != null)
            {
                if (_textBox.Multiline)
                {
                    _textBox.Location = GetInternalControlLocation(_border);
                    _textBox.Size = GetInternalControlSize(Size, _border);
                }
                else
                {
                    _textBox.Height = GetTextBoxHeight();
                    _textBox.Width = Width - _border.Thickness - InternalTextBoxMargin;
                    Size = new Size(Width, _border.BorderCurve + _textBox.Height + _border.BorderCurve);
                }
            }

            Invalidate();
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the height of the text box.
        /// </summary>
        /// <returns></returns>
        private int GetTextBoxHeight()
        {
            if (_textBox.TextLength > 0)
            {
                return StringUtilities.MeasureText(Text, Font).Height;
            }
            else
            {
                return StringUtilities.MeasureText("Hello World.", Font).Height;
            }
        }

        /// <summary>
        /// Called when [enter].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnEnter(object sender, EventArgs e)
        {
            OnMouseStateChanged(this, new Events.MouseStateEventArgs(MouseStates.Hover));
            Invalidate();
        }

        /// <summary>
        /// Called when [leave].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnLeave(object sender, EventArgs e)
        {
            if (!_textBox.Focused)
            {
                OnMouseStateChanged(this, new Events.MouseStateEventArgs(MouseStates.Normal));
                Invalidate();
            }
        }
        /// <summary>
        /// Handles the KeyDown event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Select all
            if (e.Control && (e.KeyCode == Keys.A))
            {
                _textBox.SelectAll();
                e.SuppressKeyPress = true;
            }

            // Cut
            if (e.Control && (e.KeyCode == Keys.X))
            {
                _textBox.Cut();
                e.SuppressKeyPress = true;
            }

            // Copy
            if (e.Control && (e.KeyCode == Keys.C))
            {
                _textBox.Copy();
                e.SuppressKeyPress = true;
            }

            // Paste
            if (e.Control && (e.KeyCode == Keys.V))
            {
                _textBox.Paste();
                e.SuppressKeyPress = true;
            }
        }

        #endregion Private Methods
    }
}