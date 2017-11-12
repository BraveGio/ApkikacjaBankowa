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
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace ApkikacjaBankowa
{
    public class DrawerToggle : ActionBarDrawerToggle
    {
        public DrawerToggle(glowna activity, DrawerLayout drawerLayout, SupportToolbar toolbar, int openDrawerContentDescRes, int closeDrawerContentDescRes)
            : base(activity, drawerLayout, toolbar, openDrawerContentDescRes, closeDrawerContentDescRes)
        {
            
        }

        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);

            // code here will execute once the drawer is opened( As I dont want anything happened whe drawer is
            // open I am not going to put anything here)
        }

        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);

            // Code here will execute once drawer is closed
        }
    }
}