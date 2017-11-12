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
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;


using ApkikacjaBankowa.Resources;

namespace ApkikacjaBankowa
{
    [Activity(Label = "glowna", Theme = "@style/AppTheme")]
    public class glowna : AppCompatActivity
    {
        string[] Titles = { "przelew", "karty" };
        public static TextView saldo, zablokowane, dostepne;
        public ListView tranzakcje;
        List<Operacja> listaoperacji = new List<Operacja>();
        private Toolbar toolbar;
        private RecyclerView recyclerView;
        private RecyclerView.Adapter adapter2;
        private RecyclerView.LayoutManager layoutManager;
        private DrawerLayout drawer;
        private ActionBarDrawerToggle drawerToggle;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.glowna);
            saldo = (TextView)FindViewById(Resource.Id.saldo);
            zablokowane = (TextView)FindViewById(Resource.Id.zablokowane);
            dostepne = (TextView)FindViewById(Resource.Id.dostepne);
            tranzakcje = (ListView)FindViewById(Resource.Id.listatranzakcji);
            var adapter = new OperacjaAdapter(this, listaoperacji);
            tranzakcje.Adapter = adapter;
///////
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);
            recyclerView.HasFixedSize = true;

            var minDrawerMargin = (int)Resources.GetDimension(Resource.Dimension.navigation_drawer_min_margin);
            var maxDrawerWidth = Resources.DisplayMetrics.WidthPixels - minDrawerMargin;
            recyclerView.LayoutParameters.Width = Math.Min(recyclerView.LayoutParameters.Width, maxDrawerWidth);

            adapter2 = new DrawerAdapter(Titles);
            recyclerView.SetAdapter(adapter2);

            layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            drawer = FindViewById<DrawerLayout>(Resource.Id.DrawerLayout);
            drawerToggle = new DrawerToggle(this, drawer, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawer.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
        }

      
        


    }
}