using Android.App;
using Android.OS;
using Android.Util;
using Android.Widget;
using InputMask.Helper;
using System.Collections.Generic;

namespace InputMask.Sample
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            SetupPrefixSample();
            SetupSuffixSample();
        }

        private void SetupPrefixSample()
        {
            var editText = FindViewById<EditText>(Resource.Id.prefix_edit_text);
            var checkBox = FindViewById<CheckBox>(Resource.Id.prefix_check_box);
            var affineFormats = new List<string>
            {
                "8 ([000]) [000]-[00]-[00]"
            };

            var listener = MaskedTextChangedListener.Companion.InstallOn(editText,
                "+7 ([000]) [000]-[00]-[00]",
                affineFormats, AffinityCalculationStrategy.Prefix,
                new ValueListener((maskFilled, extractedValue, formattedValue) =>
                {
                    LogValueListener(maskFilled, extractedValue, formattedValue);
                    checkBox.Checked = maskFilled;
                }));

            editText.Hint = listener.Placeholder();
        }

        private void SetupSuffixSample()
        {
            var editText = FindViewById<EditText>(Resource.Id.suffix_edit_text);
            var checkBox = FindViewById<CheckBox>(Resource.Id.suffix_check_box);
            var affineFormats = new List<string>
            {
                "+7 ([000]) [000]-[00]-[00]#[000]"
            };

            var listener = MaskedTextChangedListener.Companion.InstallOn(editText,
                "+7 ([000]) [000]-[00]-[00]",
                affineFormats, AffinityCalculationStrategy.WholeString,
                new ValueListener((maskFilled, extractedValue, formattedValue) =>
                {
                    LogValueListener(maskFilled, extractedValue, formattedValue);
                    checkBox.Checked = maskFilled;
                }));

            editText.Hint = listener.Placeholder();
        }

        private void LogValueListener(bool maskFilled, string extractedValue, string formattedValue)
        {
            var tag = nameof(MainActivity);
            Log.Debug(tag, maskFilled.ToString());
            Log.Debug(tag, extractedValue);
            Log.Debug(tag, formattedValue);
        }
    }
}