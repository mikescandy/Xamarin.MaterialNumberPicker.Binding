using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Biz.Kasual.Materialnumberpicker;
using Java.Lang;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace SampleApp
{
    [Activity(Label = "SampleApp", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NumberPicker.IFormatter
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var b = FindViewById<Button>(Resource.Id.btn1);
            b.Click += (sender, e) =>
            {
                NumberPicker picker;
                string alertTitle;
                var numberPickerBuilder = new MaterialNumberPickerBound.Builder(this);

                alertTitle = "Title";
                numberPickerBuilder
                    .MinValue(1)
                    .MaxValue(50)
                    .DefaultValue(10)
                    .SeparatorColor(ContextCompat.GetColor(this, Resource.Color.colorAccent))
                    .TextColor(ContextCompat.GetColor(this, Resource.Color.colorPrimary))
                    .TextSize(25)
                    .Formatter(this);

                picker = numberPickerBuilder.Build();
                new AlertDialog.Builder(this)
                    .SetTitle(alertTitle)
                    .SetView(picker)
                    .SetNegativeButton("Cancel", (o, args) => { })
                    .SetPositiveButton("OK", (o, args) =>
                    {
                        Snackbar.Make(FindViewById(Resource.Id.main_container),$"{picker.Value}", Snackbar.LengthLong).Show();
                    })
                    .Show();
            };
        }

        public string Format(int value)
        {
            return "Formatted text for value " + value;
        }
    }
}