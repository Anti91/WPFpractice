using System;
using System.Globalization;
using System.Windows.Data;

namespace Ersa.Global.Controls.Converters.UniversalConverter
{
    /// <summary>
    /// Universeller Converter, bei dem eine Prüfung des zu konvertierenden Wertes und Rückgabewerte für den positiven und negativen Fall festgelegt werden können.
    /// Die Prüfung kann zudem invertiert werden.
    /// </summary>
    /// <typeparam name="TValue">Typ des zu konvertierenden Wertes.</typeparam>
    /// <typeparam name="TResult">Typ des Rückgabewertes.</typeparam>
    public abstract class EDC_UniversalConverter<TValue, TResult> : IValueConverter
    {
        /// <summary>
        /// Legt den Wert fest, der für den Wert <see cref="bool.True"/> zurück gegeben wird.
        /// </summary>
        public TResult PRO_objTrueWert { get; set; }

        /// <summary>
        /// Legt den Wert fest, der für den Wert <see cref="bool.False"/> zurück gegeben wird.
        /// </summary>
        public TResult PRO_objFalseWert { get; set; }

        /// <summary>
        /// Legt fest, ob die Berechnung invertiert ausgeführt werden soll.
        /// </summary>
        public bool PRO_blnIstInvertiert { get; set; }

        /// <summary>
        /// Legt eine Prüfroutine fest, die entscheidet, welcher Wert zurückgegeben wird.
        /// </summary>
        protected abstract Func<TValue, bool> PRO_delPruefung { get; }

        protected virtual Func<bool, TValue> PRO_delBackPruefung
        {
            get
            {
                // eine Rückwärtskonvertierung ist nicht vorgesehen. (müsste überschrieben werden)
                throw new NotImplementedException();
            }
        }

        public object Convert(object i_objValue, Type i_fdcTargetType, object i_objParameter, CultureInfo i_fdcCulture)
        {
            if (i_objValue is TValue)
            {
                var objValue = (TValue)i_objValue;
                bool blnBedingungErfuellt = PRO_delPruefung(objValue);
                return blnBedingungErfuellt ^ PRO_blnIstInvertiert ? PRO_objTrueWert : PRO_objFalseWert;
            }

            if (PRO_blnIstInvertiert)
                return PRO_objFalseWert;

            return PRO_objTrueWert;
        }

        public object ConvertBack(object i_objValue, Type i_fdcTargetType, object i_objParameter, CultureInfo i_fdcCulture)
        {
            if (i_objValue is bool)
            {
                var blnWert = (bool)i_objValue ^ PRO_blnIstInvertiert;
                return PRO_delBackPruefung(blnWert);
            }

            return Binding.DoNothing;
        }
    }
}
