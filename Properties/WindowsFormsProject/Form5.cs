using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace WindowsFormsProject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Save data to database
            DialogResult dr = MessageBox.Show("Please Confirm to save data to database", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                MessageBox.Show("Data successfully saved to database");               
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if(ctrl is TextBoxBase)
                {
                    TextBoxBase tbb = (TextBoxBase)ctrl;
                    tbb.Clear();
                }
               /* if(ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Clear();
                }
                if(ctrl is RichTextBox)
                {
                    RichTextBox tb = (RichTextBox)ctrl;
                    tb.Clear();
                }
                if(ctrl is MaskedTextBox)
                {
                    MaskedTextBox tb = (MaskedTextBox)ctrl;
                    tb.Clear();
                }*/
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to close the form", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                //This will stop validating the form when close button is clicked at any point of time..
                //You have to set CauseValidation property in the UI to false for the close button.
                AutoValidate = AutoValidate.Disable;
                this.Close();
                //return;
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            TextBoxBase tbb = (TextBoxBase)sender;

            if (tbb.Name == "txtUsername")  //|| tbb.Name == "txtPassword")
            {
                if (tbb.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Have you entered Username.");
                    e.Cancel = true; //this e.cancel property will do the same thing as focus.
                    //return;
                }
            }


            if (tbb.Name == "txtPassword")
            {               
                if (tbb.Text.Trim().Length < 8)
                {
                    MessageBox.Show("The password should be between 8-16 characters.");
                    e.Cancel = true;
                    //return;
                }
            }

            if (tbb.Name == "txtConfirmPwd")
            {
                if (txtConfirmPwd.Text != txtPassword.Text)
                {
                    DialogResult dr = MessageBox.Show("The passwords didnt match. \n\n Do you want to reset password?", "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dr == DialogResult.Yes)
                    {
                        txtPassword.Clear();
                        txtConfirmPwd.Clear();
                        txtPassword.Focus();
                        
                    } else
                    {
                        txtConfirmPwd.Clear();
                        txtConfirmPwd.Focus();
                    }
                }
            }
        }
      
        private void txtDOB_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            //MessageBox.Show("length: " + txtDOB.Text.Replace("/", "").Trim().Length);

            if (txtDOB.Text.Replace("/", "").Trim().Length == 0)
            {
                DialogResult dr = MessageBox.Show("Please enter your DOB", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (dr == DialogResult.OK)
                {
                    txtDOB.Focus();
                } else
                {
                    //DateTime dt = DateTime.Parse(txtDOB.Text); //This will give error because the format of date time is US format.
                    //bool status = DateTime.TryParse(txtDOB.Text, out DateTime dt); //This will not through application error but gives th boolean value
                                                                                      //and with this you can rite if else logic
                                                                                      //But the issue again comes with date time format now. to resolve this finally use below tryparseexact.
                    bool status = DateTime.TryParseExact(txtDOB.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime dt);
                    MessageBox.Show(status.ToString());

                    if (status == false)
                    {
                        MessageBox.Show("Enter date of birth in DD/MM/YYYY format", "DOB Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    } else
                    {
                        if(dt > DateTime.Now.AddYears(-18))
                        {
                            MessageBox.Show("you should attain 18 years to signup", "Date error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel= true;
                        }
                    }
                }
            }
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("character entered: " + e.KeyChar); // to find character entered.
            //MessageBox.Show("number entered: " + char.IsDigit(e.KeyChar)); // to find out if eneterd character is digit or not.
            // to find out if enetered character is a alphabet there is method called isletter.

            if(char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Please enter only digits");
                e.Handled = true;
            }
        }

        //If mobile number is normal text box and you want restrict user to enter only 10 digits and also 
        //start with 6,7,8,9 digits. you can do this using regular exp's and use validating event..
        private void txtMobileNumber_Validating(object sender, CancelEventArgs e)
        {
            /*Regex PhoneValidation = new Regex("^[6-9]\\d{9}");
            if (PhoneValidation.IsMatch(txtMobileNumber.Text) == false)
            {
                MessageBox.Show("Invalid Mobile number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }*/
        }


        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsLetter(e.KeyChar) == false || Convert.ToInt32(e.KeyChar) == 32)
            {
                MessageBox.Show("numbers and spaces are not allowed.");
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (Convert.ToInt32(e.KeyChar) == 32)
            {
                MessageBox.Show("Spaces are not allowed.");
                e.Handled = true;
            }
        }

        private void txtEmailID_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmailID.Text.Trim().Length > 0)
            {
                Regex EmailValidation = new Regex(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}");
                if (EmailValidation.IsMatch(txtMobileNumber.Text) == false)
                {
                    MessageBox.Show("Invalid email-id.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }
    }
}
