using System;

namespace InputMask
{
    public class ValueListener : Java.Lang.Object, MaskedTextChangedListener.IValueListener
    {
        private readonly Action<bool, string, string> _onTextChanged;

        public ValueListener(Action<bool, string, string> onTextChanged)
        {
            _onTextChanged = onTextChanged;
        }

        public void OnTextChanged(bool maskFilled, string extractedValue, string formattedValue)
        {
            _onTextChanged?.Invoke(maskFilled, extractedValue, formattedValue);
        }
    }
}