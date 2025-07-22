using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaStore_Project
{
    public partial class EditBtn_Form : Form
    {
        double EditedFinalPrice;
        private MainPizzaForm MPF;
        private double FP;
        public EditBtn_Form(MainPizzaForm _MPF)
        {
            InitializeComponent();
            MPF = _MPF;
        }

        // Expose TextBox as a public property
        public string QuantityBoxValue
        {
            get { return Quantity_EditTB.Text; }
            set { Quantity_EditTB.Text = value; }
        }
        public string PizzaNameBoxValue
        {
            get { return PizzaName_EditTB.Text; }
            set { PizzaName_EditTB.Text = value; }
        }
        public string PriceBoxValue
        {
            get { return Price_EditTB.Text; }
            set { Price_EditTB.Text = value; }
        }
        public string PizzaSizeValue
        {
            get { return PSize_EditCB.Text; }
            set { PSize_EditCB.Text = value; }
        }
        public string PizzaCrustValue
        {
            get { return PCrust_EditCB.Text; }
            set { PCrust_EditCB.Text = value; }
        }
        
        public Button SaveChangesBtnValue
        {
            get { return EditSaveChanges; }
            set { EditSaveChanges = value; }
        }

        // Set ComboBox items
        public void SetComboBoxItems(ComboBox comboBox, List<string> items)
        {
            comboBox.Items.Clear(); // Clear existing items
            comboBox.Items.AddRange(items.ToArray()); // Add new items
        }

     
        private void PlusBtn_Click(object sender, EventArgs e)
        {
            //Update Quantity
            int PizzaAddOrRemove = int.Parse(Quantity_EditTB.Text);
            PizzaAddOrRemove++;
            Quantity_EditTB.Text = PizzaAddOrRemove.ToString();

            if (PizzaAddOrRemove >= 1)
            {
                MinusBtn.Enabled = true;
            }

            //Update price
            double UpdatedPrice = double.Parse(Price_EditTB.Text);
            EditedFinalPrice = UpdatedPrice + MPF.PizzaOriginalPrice;

            Price_EditTB.Text = EditedFinalPrice.ToString();
        }


        private void MinusBtn_Click(object sender, EventArgs e)
        {
            int PizzaAddOrRemove = int.Parse(Quantity_EditTB.Text);
            PizzaAddOrRemove--;
            Quantity_EditTB.Text = PizzaAddOrRemove.ToString();

            if (PizzaAddOrRemove <= 1)
            {
                MinusBtn.Enabled = false;
            }

            //Update price
            double UpdatedPrice = double.Parse(Price_EditTB.Text);
            EditedFinalPrice = UpdatedPrice - MPF.PizzaOriginalPrice;

            Price_EditTB.Text = EditedFinalPrice.ToString();
        }

        private void EditSaveChanges_Click(object sender, EventArgs e)
        {

            MPF.associatedRTB.Clear();

            int Single_Pizza_Quantity = int.Parse(Quantity_EditTB.Text);
            double Single_Pizza_EditPrice = double.Parse(MPF.associatedRTB.Tag.ToString());

            MPF.associatedRTB.AppendText(QuantityBoxValue + " x " + PizzaNameBoxValue.ToString() + Environment.NewLine);
            MPF.associatedRTB.AppendText("Price: " + Single_Pizza_Quantity * Single_Pizza_EditPrice + Environment.NewLine);
            MPF.associatedRTB.AppendText(PSize_EditCB.SelectedItem.ToString() + Environment.NewLine);
            MPF.associatedRTB.AppendText(PCrust_EditCB.SelectedItem.ToString());

            //MessageBox.Show("This is MPF. Final Amount: " + MPF.FinalPrice.Text);
            //MessageBox.Show("This is Edited Final Price: " + EditedFinalPrice);

            double TotalPrice = double.Parse(MPF.FinalPrice.Text);
            FP = (TotalPrice) + EditedFinalPrice;
            MPF.FinalPrice.Text = FP.ToString();

            this.Close();

            EditedFinalPrice = 0;
            MPF.FinalAmount = 0;
        }

    }
}
