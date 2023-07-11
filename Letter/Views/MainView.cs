using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Tabs.AppCompat.App;
using Letter.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Letter.Views
{
    public class MainView
    {
        public MainView(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();

            List<string> frase = mainViewModel.GetSentenceSimple("lesson 1");

            TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_1);
            text_pronoun.Text = frase[0];
            TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_2);
            text_verb.Text = frase[1];
            TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_3);
            text_noun.Text = frase[2];
        }

    }

}