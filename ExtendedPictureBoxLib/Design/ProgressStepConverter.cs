using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace ExtendedPictureBoxLib.Design
{
    /// <summary>
    /// Designer converter class for <see cref="ProgressStep"/> s.
    /// </summary>
    public class ProgressStepConverter : ExpandableObjectConverter
    {
        #region Overridden from ExpandableObjectConverter

        /// <summary>
        /// Determines whether this converter can convert a <see cref="ProgressStep"/> to a given
        /// type in the specified context.
        /// </summary>
        /// <param name="context">The formatting context.</param>
        /// <param name="destType">The type the conversion should result into.</param>
        /// <returns>True if the converter can handle the conversion, otherwise false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            if (destType == typeof(InstanceDescriptor))
                return true;

            return base.CanConvertTo(context, destType);
        }

        /// <summary>
        /// Converts a specified value (which must be a <see cref="ProgressStep"/>) into a given
        /// type un the specified context.
        /// </summary>
        /// <param name="context">The formatting context.</param>
        /// <param name="info">The culture under which the conversion should be performed.</param>
        /// <param name="value">Value to convert.</param>
        /// <param name="destType">The type the conversion should result into.</param>
        /// <returns>The converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo info, object value, Type destType)
        {
            if (destType == typeof(InstanceDescriptor))
            {
                ProgressStep step = (ProgressStep)value;
                Type[] ctorTypes = new Type[] { typeof(Image), typeof(string), typeof(string), typeof(string) };
                object[] ctorParams = new object[] { step.Image, step.Name, step.Text, step.Description };
                return new InstanceDescriptor(typeof(ProgressStep).GetConstructor(ctorTypes), ctorParams, true);
            }

            return base.ConvertTo(context, info, value, destType);
        }

        #endregion
    }
}