using System;
using System.Windows.Data;

namespace Ersa.Global.Controls.Converters.UniversalConverter
{
    /// <summary>
    /// Konvertiert einen Wert vom Typ <see cref="bool"/> zu einem Wert vom Typ <see cref="T"/>.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(object))]
    public abstract class EDC_UniversalBoolConverter<T> : EDC_UniversalConverter<bool, T>
    {
        protected override Func<bool, bool> PRO_delPruefung
        {
            get { return i_blnWert => i_blnWert; }
        }
    }
}
