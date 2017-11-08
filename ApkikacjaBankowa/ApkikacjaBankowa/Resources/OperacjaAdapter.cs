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
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtdata { get; set; }
        public TextView txtkwota { get; set; }
    }
    public class OperacjaAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Operacja> operacje;

        public OperacjaAdapter(Activity activity, List<Operacja> operacje)
        {
            this.activity = activity;
            this.operacje = operacje;
        }

        public override int Count
        {
            get
            {
               return operacje.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return operacje[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.operacja, parent, false);
            var txtdata = view.FindViewById<TextView>(Resource.Id.data);
            var txtkwota = view.FindViewById<TextView>(Resource.Id.Kwota);
            txtdata.Text = operacje[position].Data;
            txtkwota.Text = operacje[position].Kwota;
            return view;
        }
    }
}