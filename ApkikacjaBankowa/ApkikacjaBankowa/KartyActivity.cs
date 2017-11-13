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
using ApkikacjaBankowa.Resources;

namespace ApkikacjaBankowa
{
    [Activity(Label = "KartyActivity", Theme = "@style/AppTheme")]
    public class KartyActivity : AppCompatActivity
    {
        public ListView listViewKarty;
        List<Karta> listakart = new List<Karta>();
        private DrawerLayout mDrawerLayout;
        private ActionBarDrawerToggle mtoggle;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Karty);
            listViewKarty = (ListView)FindViewById(Resource.Id.listViewkarty);
            var adapter = new KartaAdapter(this, listakart);
            listViewKarty.Adapter = adapter;
            mDrawerLayout = (DrawerLayout)FindViewById(Resource.Id.toolbar_drawer);
            mtoggle = new ActionBarDrawerToggle(this, mDrawerLayout, Resource.String.open, Resource.String.close);
            mDrawerLayout.AddDrawerListener(mtoggle);
            mtoggle.SyncState();
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