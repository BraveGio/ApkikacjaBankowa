using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;

namespace ApkikacjaBankowa
{
    [Activity(Label = "Przelew", Theme = "@style/AppTheme")]
    public class Przelew : AppCompatActivity
    {
        private DrawerLayout mDrawerLayout;
        private ActionBarDrawerToggle mtoggle;
        public EditText Imie, nazwisko, nrkonta, kwota;
        public Button wykonajprzelew;
        String dodImie, dodnazwisko, dodnrkonta, dodkwota;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Przelew);
            Imie = (EditText)FindViewById(Resource.Id.imie);
            nazwisko = (EditText)FindViewById(Resource.Id.Nazwisko);
            nrkonta = (EditText)FindViewById(Resource.Id.nrkonta);
            kwota = (EditText)FindViewById(Resource.Id.Kwota);
            wykonajprzelew = (Button)FindViewById(Resource.Id.przelewprzycisk);
            mDrawerLayout = (DrawerLayout)FindViewById(Resource.Id.toolbar_drawer);
            mtoggle = new ActionBarDrawerToggle(this, mDrawerLayout, Resource.String.open, Resource.String.close);
            mDrawerLayout.AddDrawerListener(mtoggle);
            mtoggle.SyncState();
            wykonajprzelew.Click += (s, e) =>
            {
                dodImie = Imie.Text;
                dodnazwisko = nazwisko.Text;
                dodnrkonta = nrkonta.Text;
                dodkwota = kwota.Text;
            };
        }
        public void przelewmetoda()
        {

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var id = item.ItemId;
            switch (id)
            {
                case Resource.Id.przelew:
                    Intent klik = new Intent(this, typeof(Przelew));
                    StartActivity(klik);
                    break;
                case Resource.Id.karty:
                    Intent klik2 = new Intent(this, typeof(KartyActivity));
                    StartActivity(klik2);
                    break;
                case Resource.Id.lokaty:

                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
        public override void OnBackPressed()
        {
            //nothing
        }
    }
}