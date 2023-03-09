using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elements.Events
{
    /// <summary>
    /// The <see cref="ControlBoxEventArgs"/> class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ControlBoxEventArgs : EventArgs
    {
        private Form _form;

        /// <summary>Initializes a new instance of the <see cref="ControlBoxEventArgs" /> class.</summary>
        /// <param name="form">The form.</param>
        public ControlBoxEventArgs(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form), "Cannot be null.");
            }

            _form = form;
        }

        /// <summary>
        /// Gets or sets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public Form Form
        {
            get
            {
                return _form;
            }

            set
            {
                _form = value;
            }
        }
    }
}
