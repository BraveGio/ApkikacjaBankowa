﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;


namespace ApkikacjaBankowa
{
    [Activity(Label = "ApkikacjaBankowa", MainLauncher = true)]
    public class MainActivity : Activity
    {

        public static Button zaloguj;
        public static TextView login, haslo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            zaloguj = (Button)FindViewById(Resource.Id.zaloguj);
            login = (TextView)FindViewById(Resource.Id.login);
            haslo = (TextView)FindViewById(Resource.Id.hasło);
            zaloguj.Click += (s, e) =>
            {
                if (sprawdz())
                {
                    Intent klik = new Intent(this, typeof(glowna));
                    StartActivity(klik);
                }
                else
                {
                    Toast.MakeText(this, "zły login lub chasło", ToastLength.Short).Show();
                }
            };
        }
        public static bool sprawdz()
        {
            
            DoBazy logowanie = new DoBazy();
            logowanie.logowanie(login.Text, haslo.Text);
            bool odp;
            if (logowanie.id!=null)
            {
                ISharedPreferences shared = Application.Context.GetSharedPreferences("userInfo", FileCreationMode.Private);
                ISharedPreferencesEditor edit = shared.Edit();
                edit.PutString("id", logowanie.id);
                edit.Apply();
                odp = true;
            }
            else
            {
                odp = false;
            }

            return odp;
        }
        
    }
}

