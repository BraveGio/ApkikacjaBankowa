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

using ApkikacjaBankowa.Resources;

namespace ApkikacjaBankowa
{
    [Activity(Label = "glowna")]
    public class glowna : Activity
    {
        
        public static TextView saldo, zablokowane, dostepne;
        public ListView tranzakcje;
        List<Operacja> listaoperacji = new List<Operacja>();
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
           
        }

       public void deneokoncie()
        {
            string saldozbazy ="", dostepnezbazy="", zablokowanezbazy="";
            saldo.Text = saldozbazy;
            dostepne.Text = dostepnezbazy;
            zablokowane.Text = zablokowanezbazy;
        }
        
            
    }
}