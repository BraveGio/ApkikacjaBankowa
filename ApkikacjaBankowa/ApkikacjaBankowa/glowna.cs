﻿using System;
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
        public Toolbar mToolbar;
        public static TextView saldo, zablokowane, dostepne;
        public ListView tranzakcje;
        List<Operacja> listaoperacji = new List<Operacja>();
        private DrawerLayout mDrawerLayout;
        private ActionBarDrawerToggle mtoggle;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.glowna);
            mToolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            saldo = (TextView)FindViewById(Resource.Id.saldo);
            zablokowane = (TextView)FindViewById(Resource.Id.zablokowane);
            dostepne = (TextView)FindViewById(Resource.Id.dostepne);
            tranzakcje = (ListView)FindViewById(Resource.Id.listatranzakcji);
            var adapter = new OperacjaAdapter(this, listaoperacji);
            tranzakcje.Adapter = adapter;
            SetSupportActionBar(mToolbar);
            mDrawerLayout = (DrawerLayout)FindViewById(Resource.Id.toolbar_drawer);
            mtoggle = new ActionBarDrawerToggle(this, mDrawerLayout, Resource.String.open, Resource.String.close);
            mDrawerLayout.AddDrawerListener(mtoggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            
            mtoggle.SyncState();
            

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var id = item.ItemId;
            switch (id)
            {
                case 1:
                    Intent klik = new Intent(this, typeof(Przelew));
                    StartActivity(klik);
                    return true;
                case 0:
                    Intent klik2 = new Intent(this, typeof(KartyActivity));
                    StartActivity(klik2);
                    return true;
                case Resource.Id.lokaty:

                    return true;
            }
            return true;
            
        }
        public override void OnBackPressed()
        {
            //nothing
        }




    }
}