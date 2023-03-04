using Elements.Constants;
using Elements.TypeConverters;
using System;
using System.ComponentModel;

namespace Elements.Controls.Toggle
{
    /// <summary>
    /// The <see cref="ToggleOptions"/> class.
    /// </summary>
    [Category(PropertyCategory.Behavior)]
    [Description("The toggle options.")]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class ToggleOptions
    {
        /// <summary>
        /// The no yes.
        /// </summary>
        public static readonly ToggleOptions NoYes = new ToggleOptions("No", "Yes");

        /// <summary>
        /// The off on.
        /// </summary>
        public static readonly ToggleOptions OffOn = new ToggleOptions("Off", "On");

        /// <summary>
        /// The oi.
        /// </summary>
        public static readonly ToggleOptions OI = new ToggleOptions("O", "I");

        private string _falseText;
        private string _trueText;
        private ToggleTypes _toggleType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleOptions"/> class.
        /// </summary>
        public ToggleOptions()
        {
            _falseText = "No";
            _trueText = "Yes";
            _toggleType = ToggleTypes.YesNo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleOptions"/> class.
        /// </summary>
        /// <param name="_false">The false.</param>
        /// <param name="_true">The true.</param>
        /// <param name="type">The type.</param>
        public ToggleOptions(string _false, string _true, ToggleTypes type = ToggleTypes.Custom) : this()
        {
            if (string.IsNullOrEmpty(_false))
            {
                throw new ArgumentNullException(nameof(_false), "Cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(_true))
            {
                throw new ArgumentNullException(nameof(_true), "Cannot be null or empty.");
            }

            _falseText = _false;
            _trueText = _true;
            _toggleType = type;
        }

        /// <summary>
        /// Gets or sets the false text.
        /// </summary>
        /// <value>The false text.</value>
        public string FalseText
        {
            get
            {
                return _falseText;
            }

            set
            {
                _falseText = value;
            }
        }

        /// <summary>
        /// Gets or sets the true text.
        /// </summary>
        /// <value>The true text.</value>
        public string TrueText
        {
            get
            {
                return _trueText;
            }

            set
            {
                _trueText = value;
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public ToggleTypes Type
        {
            get
            {
                return _toggleType;
            }

            set
            {
                _toggleType = value;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="toggle">if set to <c>true</c> [toggle].</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        public string GetValue(bool toggle)
        {
            string returnValue;
            if (toggle)
            {
                returnValue = _falseText;
            } 
            else
            {
                returnValue = _trueText;
            }

            return returnValue;
        }
    }
}