using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace TipCalculator
{
    [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText costText;
        EditText tipText;
        Button calculateButton;
        TextView totalCostText;
        float totalCost;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            costText = FindViewById<EditText>(Resource.Id.txtCost);
            tipText = FindViewById<EditText>(Resource.Id.txtTip);
            calculateButton = FindViewById<Button>(Resource.Id.btnCalculate);
            totalCostText = FindViewById<TextView>(Resource.Id.txtFinalCost);
            buttonClick();
        }

        private void buttonClick()
        {
            calculateButton.Click += delegate {
                calculateTotalCost();
                printTotalCost();
            };
        }

        private void printTotalCost()
        {
            totalCostText.Text = totalCost.ToString();
        }

        private void calculateTotalCost()
        {
            float cost = float.Parse(costText.Text);
            float tip = float.Parse(tipText.Text);
            tip = tip / 100;
            totalCost = cost + (cost * tip);
        }
    }
}

