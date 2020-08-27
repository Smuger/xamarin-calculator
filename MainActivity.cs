using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace project13
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button clearButton, mRCButton, mMinusButton, mPlusButton, offButton, sqrtButton, percentageButton, divideButton, sevenButton, eightButton, nineButton, multiplyButton, fourButton, fiveButton, sixButton, minusButton, oneButton, twoButton, threeButton, plusButton, zeroButton, dotButton, equalButton;
        EditText resultEditText;
        string[] signs = new string[6] { ".", "+", "-", "*", "/", "%" };
        Boolean resultsJustShown = false;
        double calculatorMemory = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var numbers2 = new List<int>() { 2, 3, 5, 7 };

            clearButton = FindViewById<Button>(Resource.Id.clearButton);
            mRCButton = FindViewById<Button>(Resource.Id.mRCButton);
            mMinusButton = FindViewById<Button>(Resource.Id.mMinusButton);
            mPlusButton = FindViewById<Button>(Resource.Id.mPlusButton);
            offButton = FindViewById<Button>(Resource.Id.offButton);
            sqrtButton = FindViewById<Button>(Resource.Id.sqrtButton);
            percentageButton = FindViewById<Button>(Resource.Id.percentageButton);
            divideButton = FindViewById<Button>(Resource.Id.divideButton);
            sevenButton = FindViewById<Button>(Resource.Id.sevenButton);
            eightButton = FindViewById<Button>(Resource.Id.eightButton);
            nineButton = FindViewById<Button>(Resource.Id.nineButton);
            multiplyButton = FindViewById<Button>(Resource.Id.multiplyButton);
            fourButton = FindViewById<Button>(Resource.Id.fourButton);
            fiveButton = FindViewById<Button>(Resource.Id.fiveButton);
            sixButton = FindViewById<Button>(Resource.Id.sixButton);
            minusButton = FindViewById<Button>(Resource.Id.minusButton);
            oneButton = FindViewById<Button>(Resource.Id.oneButton);
            twoButton = FindViewById<Button>(Resource.Id.twoButton);
            threeButton = FindViewById<Button>(Resource.Id.threeButton);
            plusButton = FindViewById<Button>(Resource.Id.plusButton);
            zeroButton = FindViewById<Button>(Resource.Id.zeroButton);
            dotButton = FindViewById<Button>(Resource.Id.dotButton);
            equalButton = FindViewById<Button>(Resource.Id.equalButton);

            resultEditText = FindViewById<EditText>(Resource.Id.resultEditText);

            clearButton.Click += OnClickClear;
            mRCButton.Click += OnClickMRC;
            mMinusButton.Click += OnClickMMinus;
            mPlusButton.Click += OnClickMPlus;
            offButton.Click += OnClickOff;
            sqrtButton.Click += OnClickSqrt;
            percentageButton.Click += OnClickPercentage;
            divideButton.Click += OnClickDivide;
            sevenButton.Click += OnClickSeven;
            eightButton.Click += OnClickEight;
            nineButton.Click += OnClickNine;
            multiplyButton.Click += OnClickMultiply;
            fourButton.Click += OnClickFour;
            fiveButton.Click += OnClickFive;
            sixButton.Click += OnClickSix;
            minusButton.Click += OnClickMinus;
            oneButton.Click += OnClickOne;
            twoButton.Click += OnClickTwo;
            threeButton.Click += OnClickThree;
            plusButton.Click += OnClickPlus;
            zeroButton.Click += OnClickZero;
            dotButton.Click += OnClickDot;
            equalButton.Click += OnClickEqual;
        }

        void OnClickClear(object sender, EventArgs e)
        {
            resultEditText.Text = "";
            calculatorMemory = 0;
        }

        void OnClickMRC(object sender, EventArgs e)
        {
            resultEditText.Text = calculatorMemory.ToString();
            resultEditText.SetSelection(resultEditText.Text.Length);
        }

        void OnClickMMinus(object sender, EventArgs e)
        {
            Expression displayedEquation = new Expression(resultEditText.Text);
            double result = displayedEquation.calculate();

            calculatorMemory -= result;
            resultEditText.Text = "";
        }

        void OnClickMPlus(object sender, EventArgs e)
        {
            Expression displayedEquation = new Expression(resultEditText.Text);
            double result = displayedEquation.calculate();

            calculatorMemory += result;
            resultEditText.Text = "";
        }

        void OnClickOff(object sender, EventArgs e)
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        void OnClickSqrt(object sender, EventArgs e)
        {
            try
            {
                Expression displayedEquation = new Expression(resultEditText.Text);
                double result = displayedEquation.calculate();
                result = Math.Sqrt(result);
                resultEditText.Text = result.ToString();
                resultsJustShown = true;
                resultEditText.SetSelection(resultEditText.Text.Length);
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Program thrown exception after user pressed " +
                    "SQRT button on main screen. Exception: " + exception);
                resultEditText.Text = "";
            }
        }

        void OnClickPercentage(object sender, EventArgs e)
        {
            try
            {
                if (signs.Any(s => s.Contains(Convert.ToString(resultEditText.Text[resultEditText.Text.Length - 1]))))
                {

                }
                else
                {
                    resultEditText.Text += "%";
                    resultEditText.SetSelection(resultEditText.Text.Length);
                }
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Program thrown exception after user pressed " +
                    "% button on main screen. Exception: " + exception);
                resultEditText.Text = "";
            }
        }

        void OnClickDivide(object sender, EventArgs e)
        {
            try
            {
                if (signs.Any(s => s.Contains(Convert.ToString(resultEditText.Text[resultEditText.Text.Length - 1]))))
                {

                }
                else
                {
                    resultEditText.Text += "/";
                    resultEditText.SetSelection(resultEditText.Text.Length);
                }
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Program thrown exception after user pressed " +
                    "/ button on main screen. Exception: " + exception);
                resultEditText.Text = "";
            }
        }

        void OnClickSeven(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "7";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "7";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }

        void OnClickEight(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "8";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "8";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }

        void OnClickNine(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "9";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "9";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }

        void OnClickMultiply(object sender, EventArgs e)
        {
            try
            {
                if (signs.Any(s => s.Contains(Convert.ToString(resultEditText.Text[resultEditText.Text.Length - 1]))))
                {

                }
                else
                {
                    resultEditText.Text += "*";
                    resultEditText.SetSelection(resultEditText.Text.Length);
                }
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Program thrown exception after user pressed " +
                    "* button on main screen. Exception: " + exception);
                resultEditText.Text = "0";
            }
        }

        void OnClickFour(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "4";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "4";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }
        void OnClickFive(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "5";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "5";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }
        void OnClickSix(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "6";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "6";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }
        void OnClickMinus(object sender, EventArgs e)
        {
            try
            {
                if (signs.Any(s => s.Contains(Convert.ToString(resultEditText.Text[resultEditText.Text.Length - 1]))))
                {
                }
                else
                {
                    resultEditText.Text += "-";
                    resultEditText.SetSelection(resultEditText.Text.Length);
                }
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Program thrown exception after user pressed " +
                    "- button on main screen. Exception: " + exception);
                resultEditText.Text = "0";
            }
        }
        void OnClickOne(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "1";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "1";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }
        void OnClickTwo(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "2";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "2";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }
        void OnClickThree(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "3";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "3";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }
        void OnClickPlus(object sender, EventArgs e)
        {
            try
            {
                if (signs.Any(s => s.Contains(Convert.ToString(resultEditText.Text[resultEditText.Text.Length - 1]))))
                {
                }
                else
                {
                    resultEditText.Text += "+";
                    resultEditText.SetSelection(resultEditText.Text.Length);
                }
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Program thrown exception after user pressed " +
                    "+ button on main screen. Exception: " + exception);
                resultEditText.Text = "0";
            }
        }
        void OnClickZero(object sender, EventArgs e)
        {
            if (resultsJustShown)
            {
                resultEditText.Text = "0";
                resultsJustShown = false;
            }
            else
            {
                resultEditText.Text += "0";
            }
            resultEditText.SetSelection(resultEditText.Text.Length);
        }
        void OnClickDot(object sender, EventArgs e)
        {
            try
            {
                if (signs.Any(s => s.Contains(Convert.ToString(resultEditText.Text[resultEditText.Text.Length - 1]))))
                {

                }
                else
                {
                    resultEditText.Text += ".";
                    resultEditText.SetSelection(resultEditText.Text.Length);
                }
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Program thrown exception after user pressed " +
                    ". button on main screen. Exception: " + exception);
                resultEditText.Text = "0";
            }
        }
        void OnClickEqual(object sender, EventArgs e)
        {
            try
            {
                string displayedEquationText = resultEditText.Text;
                Boolean containsPercentage = false;
                for (int i = 0; i < displayedEquationText.Length; i++)
                {
                    if (signs.Any(s => s.Contains(Convert.ToString(displayedEquationText[i]))))
                    {
                        if (displayedEquationText[i].ToString() == "%")
                        {
                            containsPercentage = true;
                        }

                    }
                }
                displayedEquationText = displayedEquationText.Replace("%", "*0.01*");
                Expression displayedEquation = new Expression(displayedEquationText);
                double result = displayedEquation.calculate();
                resultEditText.Text = result.ToString();

                resultEditText.SetSelection(resultEditText.Text.Length);

            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Program thrown exception after user pressed " +
                    "= button on main screen. Exception: " + exception);
                resultEditText.Text = "0";
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}