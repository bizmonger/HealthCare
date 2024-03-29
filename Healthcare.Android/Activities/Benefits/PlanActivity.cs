﻿using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Plan", Icon = "@drawable/icon")]
    partial class PlanActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Plan);

            CreateViewModel();
            LoadListView();
        }
    }
}