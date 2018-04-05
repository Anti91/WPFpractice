using System;
using System.Windows.Data;
using Ersa.Global.Controls.Converters.UniversalConverter;

namespace Ersa.Global.Controls.Converters
{
    /// <summary>
    /// Konvertiert eine Instanz vom Typ <see cref="object"/> in einen Wert vom Typ <see cref="bool"/> und prüft dabei, ob der zu konvertierende Wert <code>null</code> ist.
    /// </summary>
    [ValueConversion(typeof(object), typeof(bool))]
    public class EDC_ObjectNachIstObjectNullConverter : EDC_UniversalToBoolConverter<object>
    {
        protected override Func<object, bool> PRO_delPruefung
        {
            get { return i_objObject => i_objObject == null; }
        }
    }
}
