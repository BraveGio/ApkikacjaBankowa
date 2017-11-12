using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.Widget;

namespace ApkikacjaBankowa
{

    public class DrawerAdapter : RecyclerView.Adapter
    {
        public enum ViewType
        {
            Header = 0,
            Item = 1
        }

        string[] navTitles;
        

        public DrawerAdapter(string[] titles)
        {
            navTitles = titles;
            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            
             if (viewType == (int)ViewType.Item)
            {
                var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ItemRow, parent, false);
                return new DrawerViewHolder(view, ViewType.Item);
            }

            return null;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as DrawerViewHolder;

            if (viewHolder.HolderType == ViewType.Item)
            {
                viewHolder.TextView.Text = navTitles[position - 1];
             
            }
            else
            {
                /*
				holder.profile.setImageResource(profile);           // Similarly we set the resources for header view
				holder.Name.setText(name);
				holder.email.setText(email);
				*/
            }
        }

        public override int ItemCount
        {
            get
            {
                return navTitles.Length + 1;
            }
        }

        public override int GetItemViewType(int position)
        {
            return IsPositionHeader(position) ? (int)ViewType.Header : (int)ViewType.Item;

        }

        private static bool IsPositionHeader(int position)
        {
            return position == 0;
        }


        public class DrawerViewHolder : RecyclerView.ViewHolder
        {
            public ViewType HolderType { get; private set; }

            public TextView TextView { get; private set; }

          

            public DrawerViewHolder(View itemView, ViewType viewType) : base(itemView)
            {
                HolderType = viewType;

                if (viewType == ViewType.Item)
                {
                    TextView = itemView.FindViewById<TextView>(Resource.Id.rowText);
                    
                }
                else
                {
                    /*
					Name = (TextView) itemView.findViewById(R.id.name);         // Creating Text View object from header.xml for name
					email = (TextView) itemView.findViewById(R.id.email);       // Creating Text View object from header.xml for email
					profile = (ImageView) itemView.findViewById(R.id.circleView);// Creating Image view object from header.xml for profile pic	
					*/
                }

            }
        }


    }

}
