using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Patrick McKee                    *
 * CIS123 - OOP                     *
 * May 19, 2022                     *
 * Ex 8-1: Use an array and a list  */

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        // Patrick McKee - CIS123 - Ex8.1 
        // Step 9 - modify to use a list (part 1)

        decimal[] invoiceTotalsArray = new decimal[5];
        int totalIndex = 0;

        List<decimal> invoiceTotalsList = new List<decimal>();

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSubtotal.Text == "")
                {
                    MessageBox.Show(
                    "Subtotal is a required field.", "Entry Error");
                }
                else
                {
                    decimal subtotal = Decimal.Parse(txtSubtotal.Text);
                    if (subtotal > 0 && subtotal < 10000)
                    {
                        decimal discountPercent = 0m;
                        if (subtotal >= 500)
                            discountPercent = .2m;
                        else if (subtotal >= 250 & subtotal < 500)
                            discountPercent = .15m;
                        else if (subtotal >= 100 & subtotal < 250)
                            discountPercent = .1m;
                        decimal discountAmount = subtotal * discountPercent;
                        decimal invoiceTotal = subtotal - discountAmount;

                        discountAmount = Math.Round(discountAmount, 2);
                        invoiceTotal = Math.Round(invoiceTotal, 2);

                        // Patrick McKee - CIS123 - Ex8.1 
                        // Step 9 - modify to use a list (part 2)

                        invoiceTotalsArray[totalIndex] = invoiceTotal;
                        totalIndex++;

                        invoiceTotalsList.Add(invoiceTotal);

                        txtDiscountPercent.Text = discountPercent.ToString("p1");
                        txtDiscountAmount.Text = discountAmount.ToString();
                        txtTotal.Text = invoiceTotal.ToString();

                    }

                    else
                    {
                        MessageBox.Show(
                            "Subtotal must be greater than 0 and less than 10,000.",
                            "Entry Error");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Please enter a valid number for the Subtotal field.",
                    "Entry Error");
            }

            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Can only have 5 elements", "Array issue");
            }
            txtSubtotal.Focus();
        }

        // Patrick McKee - CIS123 - Ex8.1 
        // Step 9 - modify to use a list (Part 3)
        private void btnExit_Click(object sender, EventArgs e)
        {
            { 
            string msg = "";
            Array.Sort(invoiceTotalsArray);
            foreach (decimal total in invoiceTotalsArray)
            {
                if (total != 0)
                {
                    msg += total.ToString("c") + "\n";
                }
            }

            MessageBox.Show(msg, "Order Totals - Array");
            }
            {
                string msg = "";
                invoiceTotalsList.Sort();
            foreach (decimal total in invoiceTotalsList)
            {
                if (total != 0)
                {
                    msg += total.ToString("c") + "\n";
                }
            }

            MessageBox.Show(msg, "Order Totals - List");
            this.Close();
            }
        }

    }
}
