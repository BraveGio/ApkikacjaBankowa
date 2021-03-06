﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Android.Support.Design.Widget;


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
        private int id;
        private DoBazy danezbazy=new DoBazy();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ISharedPreferences shared = Application.Context.GetSharedPreferences("userInfo", FileCreationMode.Private);
            id = Convert.ToInt32(shared.GetString("id", string.Empty));
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.glowna);
            string[] dane = new string[3];
            przyciski();
            dane = danezbazy.odczytstanów(id);
            saldo.Text = dane[0];
            dostepne.Text = dane[1];
            zablokowane.Text = dane[2];
            listaoperacji = danezbazy.lista5operacji(id);
            //zadaniaTask();
            //SprawdźsaldaAsyncTask(id);
            //piecoperacji(id);
            var adapter = new OperacjaAdapter(this, listaoperacji);
            tranzakcje.Adapter = adapter;
            SetSupportActionBar(mToolbar);
            mDrawerLayout = (DrawerLayout)FindViewById(Resource.Id.toolbar_drawer);
            if (mDrawerLayout != null)
            {
                var nav = FindViewById<NavigationView>(Resource.Id.navigation);
                nav.NavigationItemSelected += (sender, e) =>
                {
                    menuBoczne(e.MenuItem);
                };
            }
            mtoggle = new ActionBarDrawerToggle(this, mDrawerLayout, Resource.String.open, Resource.String.close);
            mDrawerLayout.AddDrawerListener(mtoggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mtoggle.SyncState();
        }

        private void przyciski()
        {
            mToolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            saldo = (TextView)FindViewById(Resource.Id.saldo);
            zablokowane = (TextView)FindViewById(Resource.Id.zablokowane);
            dostepne = (TextView)FindViewById(Resource.Id.dostepne);
            tranzakcje = (ListView)FindViewById(Resource.Id.listatranzakcji);
        }
           private async Task zadaniaTask()
        {
            SprawdźsaldaAsyncTask(id);
            await piecoperacji(id);
        }
        public bool menuBoczne(IMenuItem item)
        {
            var id = item.ItemId;
            switch (id)
            {
                case Resource.Id.karty:
                    Intent klik2 = new Intent(this, typeof(KartyActivity));
                    StartActivity(klik2);
                    return true;
                case Resource.Id.przelew :
                    Intent klik = new Intent(this, typeof(Przelew));
                    StartActivity(klik);
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
        private async Task SprawdźsaldaAsyncTask(int id)
        {
                await Task.Run(() =>
                {
                    string[] dane = new string[3];
                    dane = danezbazy.odczytstanów(id);
                    saldo.Text = dane[0];
                    dostepne.Text = dane[1];
                    zablokowane.Text = dane[2];
                }
            );
        }
        private async Task piecoperacji(int id)
        {
            await Task.Run(() =>
                {
                    listaoperacji = danezbazy.lista5operacji(id);
                }
            );
        }
    }
}