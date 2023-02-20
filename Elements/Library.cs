using Elements.Properties;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Elements
{
    /// <summary>
    /// A collection of retrievable <see cref="Elements"/> framework information.
    /// </summary>
    public static class Library
    {
        /// <summary>
        /// Returns the <c>Description</c> of the <see cref="Elements "/> framework.
        /// </summary>
        public static string Description
        {
            get
            {
                try
                {
                    // Retrieve default assembly description attributes
                    AssemblyDescriptionAttribute descriptionAttribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).OfType<AssemblyDescriptionAttribute>().FirstOrDefault();

                    // Check if the description attribute is null then display default message
                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
                catch
                {
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Returns the <see cref="DirectoryInfo"/> for the <see cref="Elements"/> framework.
        /// </summary>
        public static DirectoryInfo DirectoryInfo
        {
            get
            {
                return FileInfo.Directory;
            }
        }

        /// <summary>
        /// Returns the <c>File</c> of the <see cref="Elements"/> framework.
        /// </summary>
        public static FileInfo FileInfo
        {
            get
            {
                return new FileInfo(Location);
            }
        }

        /// <summary>
        /// Returns the file path of the <see cref="Elements"/> framework.
        /// </summary>
        public static string Location
        {
            get
            {
                return Assembly.GetExecutingAssembly().Location;
            }
        }

        /// <summary>
        /// Returns the <c>Name</c> of the <see cref="Elements"/> framework.
        /// </summary>
        public static string Name
        {
            get
            {
                return Elements.GetName().Name;
            }
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the releases of the <see cref="Elements"/> framework.
        /// </summary>
        public static Uri Releases
        {
            get
            {
                return new Uri(Settings.Default.Website + "/releases");
            }
        }

        /// <summary>
        /// Returns the <c>Website</c> of the <see cref="Elements"/> framework.
        /// </summary>
        public static Uri Website
        {
            get
            {
                return new Uri(Settings.Default.Website);
            }
        }

        /// <summary>
        /// Returns the <c>Version</c> of the <see cref="Elements"/> framework.
        /// </summary>
        public static Version Version
        {
            get
            {
                return Elements.GetName().Version;
            }
        }

        /// <summary>
        /// Returns the <c>Assembly</c> of the <see cref="Elements"/> framework.
        /// </summary>
        public static Assembly Elements
        {
            get
            {
                return Assembly.LoadFile(Location);
            }
        }
    }
}