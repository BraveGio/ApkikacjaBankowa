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
using Java.Lang;

namespace ApkikacjaBankowa.Resources
{
    public class kartaViewHolder : Java.Lang.Object
    {
        public ImageView image { get; set; }
        public TextView nrkarty { get; set; }
        public TextView datawaznoscikarty { get; set; }
    }
   public class KartaAdapter : BaseAdapter
    {

        private Activity activity;
        private List<Karta> karty;

        public KartaAdapter(Activity activity, List<Karta> karty)
        {
            this.activity = activity;
            this.karty = karty;
        }
        public override int Count
        {
            get
            {
                return karty.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return karty[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.karta, parent, false);
            var nrkarty = view.FindViewById<TextView>(Resource.Id.NumerKarty);
            var datawaznoscikarty = view.FindViewById<TextView>(Resource.Id.DataWaznosciKarty);
            nrkarty.Text = karty[position].nrkarty;
            datawaznoscikarty.Text = karty[position].datawaznoscikarty;
            return view;
        }
    }
}