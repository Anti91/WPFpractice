namespace Ersa.Global.Controls.Converters.UniversalConverter
{
    public abstract class EDC_UniversalToBoolConverter<TValue> : EDC_UniversalConverter<TValue, bool>
    {
        protected EDC_UniversalToBoolConverter()
        {
            PRO_objTrueWert = true;
            PRO_objFalseWert = false;
        }
    }
}
