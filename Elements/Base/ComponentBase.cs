using System.ComponentModel;

namespace Elements.Base
{
    /// <summary>
    /// The <see cref="ComponentBase"/> class.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component"/>
    /// <seealso cref="System.ICloneable"/>
    public abstract class ComponentBase : Component
    {
        #region Public Methods

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion Public Methods
    }
}