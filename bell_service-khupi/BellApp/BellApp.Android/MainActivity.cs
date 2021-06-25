using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;
using System.Drawing;
using Android.Views;
using Xamarin.Essentials;

namespace BellApp.Droid
{
    [Activity(Label = "BellApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
         
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "database.sqlite");
            LoadApplication(new App(dbPath.ToString()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

       

        public interface IStatusBarPlatformSpecific
        {
            void SetStatusBarColor(Color color);
        }

        private void UpdateColor(string hex)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            }
            var color = Color.DarkGray;
            var system = color;
            var system2 = DarkerColor(system);
            var fin = system2.ToPlatformColor();
            Window.SetStatusBarColor(fin);

        }

        private System.Drawing.Color DarkerColor(System.Drawing.Color color, float correctionfactory = 50f)
        {
            const float hundredpercent = 100f;
            return System.Drawing.Color.FromArgb((int)(((float)color.R / hundredpercent) * correctionfactory),
            (int)(((float)color.G / hundredpercent) * correctionfactory), (int)(((float)color.B / hundredpercent) * correctionfactory));
        }

       public override void OnBackPressed()
        {
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
           
        }


    }
}
