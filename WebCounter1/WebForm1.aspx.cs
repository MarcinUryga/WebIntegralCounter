using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace WebCounter1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Count_Button(object sender, EventArgs e)
        {
            CountIntegralTemplate integral = null;
           
            try
            {
                if (DropDownList1.SelectedItem.Text.Equals("Metoda trapezów"))
                    integral = new TrapezoidMethod(Convert.ToDouble(odX.Text), Convert.ToDouble(doX.Text), 
                     checkBoxParallel.Checked, Convert.ToDouble(dokladnoscBox.Text.Replace(".", ",")), Convert.ToInt32(lprzedzTextBox.Text));

                if (DropDownList1.SelectedItem.Text.Equals("Metoda Monte Carlo I"))
                    integral = new FirstMonteCarloMethod(Convert.ToDouble(odY.Text), Convert.ToDouble(doY.Text), Convert.ToDouble(odX.Text), Convert.ToDouble(doX.Text),
                     checkBoxParallel.Checked, Convert.ToDouble(dokladnoscBox.Text.Replace(".", ",")), Convert.ToInt32(lprzedzTextBox.Text));

                if (DropDownList1.SelectedItem.Text.Equals("Metoda Monte Carlo II"))    
                        integral = new SecondMonteCarloMethod(Convert.ToDouble(odX.Text), Convert.ToDouble(doX.Text),
                     checkBoxParallel.Checked, Convert.ToDouble(dokladnoscBox.Text.Replace(".", ",")), Convert.ToInt32(lprzedzTextBox.Text));

                integral.returnCountIntegralValue(SinusChart);

                resultLabel.Text = Convert.ToDecimal(integral.IntegralResult).ToString();
                timeLabel.Text = integral.Time;
            }
            catch (Exception exception)
            {
                errorLabel.Text = "Error: " + exception.Message;
            }
        }
        
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}