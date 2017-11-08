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

namespace ApkikacjaBankowa
{
    
    public class Operacja
    {
        public int id { get; set; }
        public string Data { get; set; }
        public string Kwota { get; set; }
    }
}