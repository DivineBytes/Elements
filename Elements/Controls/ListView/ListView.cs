namespace Elements.Controls.ListView
{
    /// <summary>
    /// The <see cref="ListView"/> class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ListView"/>
    public class ListView : System.Windows.Forms.ListView
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ListView"/> class.
        /// </summary>
        public ListView()
        {
            FullRowSelect = true;
            GridLines = true;
            View = System.Windows.Forms.View.Details;
            Size = new System.Drawing.Size(250, 150);

            Columns.Add("Text", 150);
            Columns.Add("Value", 50);
        }

        #endregion Public Constructors
    }
}