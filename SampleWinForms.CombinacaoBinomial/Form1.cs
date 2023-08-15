using System;
using System.Windows.Forms;

namespace SampleWinForms.CombinacaoBinomial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static long Factorial(long x)
        {
            if (x <= 1)
                return 1;
            else
                return x * Factorial(x - 1);
        }

        private static long Combination(long a, long b)
        {
            if (a <= 1)
                return 1;

            return Factorial(a) / (Factorial(b) * Factorial(a - b));
        }

        private double BinomialProbability(int trials, int successes, double probabilityOfSuccess)
        {
            double probOfFailures = 1 - probabilityOfSuccess;

            double c = Combination(trials, successes);
            double px = Math.Pow(probabilityOfSuccess, successes);
            double qnx = Math.Pow(probOfFailures, trials - successes);

            return c * px * qnx;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int nbrOfTrials = 0, nbrOfSuccesses = 0;
            double probOfSuccesses = 0.00;
            double binomial = 0.00;

            try
            {
                nbrOfTrials = int.Parse(txtTrials.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("The number of trials is not valid", "Binomial Probability");
            }

            try
            {
                nbrOfSuccesses = int.Parse(txtSuccesses.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("The number of successes is not valid", "Binomial Probability");
            }

            try
            {
                probOfSuccesses = double.Parse(txtProbabilitySuccess.Text);

                binomial = BinomialProbability(nbrOfTrials, nbrOfSuccesses, probOfSuccesses);
                txtBinomialProbability.Text = binomial.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("The number of trials is not valid",
                                "Binomial Probability");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
