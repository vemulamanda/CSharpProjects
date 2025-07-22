using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Collections;
using System.Drawing.Text;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Serialization;
using System.Net;
using System.Windows.Forms.VisualStyles;
using System.Net.Configuration;

namespace PizzaStore_Project
{
    public partial class MainPizzaForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public GroupBox gb;
        public ComboBox cb1;
        public ComboBox cb2;
        public Button btn;
        public RichTextBox CartPName_RTB;
        public Button CartRemove_Btn;
        public Button CartEdit_Btn;
        public RichTextBox associatedRTB;
        public Button ConfirmChangeBtn;

        public string selectedSize;
        public string selectedCrust;
        public double PizzaOriginalPrice;
        int PizzaCount = 1;
        public double FinalAmount;

        private EditBtn_Form EF;
        private AreaSelectForm ASF;

        public MainPizzaForm(AreaSelectForm _ASF)
        {
            InitializeComponent();
            EF = new EditBtn_Form(this);
            ASF = _ASF;

            this.FormClosed += MainPizzaForm_FormClosed;
        }

        private void MainPizzaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainPizzaForm_Load(object sender, EventArgs e)
        {
            string sqlcon = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            con = new SqlConnection(sqlcon);

            cmd = new SqlCommand("SELECT PizzaID, PizzaName, Price, Picture FROM Pizza;", con);

            con.Open();

            dr = cmd.ExecuteReader();

            DisplayData();

            con.Close();

            Welcome_lbl.Focus();

            //ASF.OrderType = C_OrderType_lbl?.Text;
            //ASF.Address = C_Address_lbl?.Text;
            //ASF.StoreArea = C_PickupStore_lbl?.Text;
        }

        public void DisplayData()
        {
            int groupboxwidth = 205;
            int groupboxheight = 275;
            int x = 50; // Starting X-coordinate
            int y = 100; // Fixed Y-coordinate for alignment
            int padding = 100; // Gap between PictureBoxes
            int maxPerRow = 3; // Maximum number of PictureBoxes per row
            int pictureboxWidth = 189; // PictureBox width
            int pictureboxHeight = 157; // PictureBox height
            int count = 0;
            int i = 1;

            while (dr.Read())
            {
                gb = new GroupBox
                {
                    Text = dr["PizzaName"].ToString(),
                    Font = new Font("Sitka Text", 12, FontStyle.Italic),
                    ForeColor = Color.Maroon,
                    Location = new Point(x, y), // Position on the form
                    Size = new Size(groupboxwidth, groupboxheight), // Set the size of the GroupBox
                    AutoSize = false, // Ensure fixed size; you can change it dynamically later                 
                };

                if (dr["Picture"] != DBNull.Value)
                {
                    byte[] imgdata = (byte[])dr["Picture"];

                    MemoryStream ms = new MemoryStream(imgdata);

                    PictureBox pb = new PictureBox();
                    {
                        pb.Image = Image.FromStream(ms);
                        pb.Name = $"pictureBox{i}";
                        pb.Location = new Point(5, 21);
                        pb.Size = new Size(pictureboxWidth, pictureboxHeight);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.BorderStyle = BorderStyle.FixedSingle;
                    }

                    Label lb = new Label();
                    {
                        lb.Text = "Price: " + dr["Price"].ToString();
                        lb.Size = new Size(100, 20);
                        lb.Name = $"lbl{i}";
                        lb.Location = new Point(3, 178);
                        lb.ForeColor = Color.DarkGreen;
                        //lb.BackColor = Color.White;
                        lb.Font = new Font("Sitka Text", 11, FontStyle.Italic);
                    }

                    btn = new Button();
                    {
                        btn.Text = "Add";
                        btn.Name = $"btn{i}";
                        btn.BackColor = Color.White;
                        btn.ForeColor = Color.Maroon;
                        btn.Size = new Size(80, 30);
                        btn.Location = new Point(115, 178);
                        btn.Font = new Font("sitka Text", 11, FontStyle.Italic);
                        btn.Tag = dr["PizzaID"].ToString();
                        btn.Click += AddToCart_Btn;
                    }

                    cb1 = new ComboBox();
                    {
                        //cb1.Size = new Size(110, 15);
                        cb1.Name = $"PizzaSizecomboBox{i}";
                        cb1.Location = new Point(10, 215);
                        cb1.DropDownStyle = ComboBoxStyle.DropDownList;
                        cb1.Font = new Font("Sitka Text", 10, FontStyle.Italic);
                        cb1.MouseWheel += CB_MouseWheel;

                    }

                    cb1.Items.AddRange(new object[] { "Mini Pizza", "Large Pizza", "Extra Large Pizza" });

                    cb1.SelectedIndex = 1;

                    cb2 = new ComboBox();
                    {
                        cb2.Size = new Size(180, 24);
                        cb2.Name = $"PizzaCrustcomboBox{i}";
                        cb2.Location = new Point(10, 243);
                        cb2.DropDownStyle = ComboBoxStyle.DropDownList;
                        cb2.Font = new Font("Sitka Text", 10, FontStyle.Italic);
                        cb2.BackColor = Color.White;
                        cb2.MouseWheel += CB_MouseWheel;
                    }

                    cb2.Items.AddRange(new object[] { "Cheese Burst Crust", "Double Decadence Crust", "Cheesy Crust",
                    "Classic Crust", "Deep Pan", "Thin 'n' Crispy", "Garlic Cheesy Crust", "Gluten Free Sourdough Base"});

                    cb2.SelectedIndex = 3;

                    gb.Controls.Add(cb1);
                    gb.Controls.Add(cb2);
                    gb.Controls.Add(btn);
                    gb.Controls.Add(pb);
                    gb.Controls.Add(lb);
                    this.Controls.Add(gb);

                    count++;
                    if (count % maxPerRow == 0) // Move to the next row
                    {
                        x = 50; // Reset X-coordinate for the new row
                        y += 220 + padding; // Move down for the next row
                    }
                    else // Move to the next column
                    {
                        x += 150 + padding; // Move to the right
                    }
                }
                i++;
            }
        }
        public void CB_MouseWheel(object sender, MouseEventArgs e)
        {
            //The event argument e contains data about the mouse wheel event.
            //You cast e to HandledMouseEventArgs to access the Handled property.
            //Setting Handled = true effectively "blocks" the default behavior of scrolling in response to the mouse wheel.

            // Suppress the mouse wheel scroll
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void VoucherCodetxtBox_Click(object sender, EventArgs e)
        {
            VoucherCodetxtBox.Clear();
            VoucherCodetxtBox.ForeColor = Color.Black;
        }

        private void VoucherApplyBtn_Click(object sender, EventArgs e)
        {
            if (VoucherCodetxtBox.Text == "SUDHEER")
            {
                VouDiscountDisLbl.ForeColor = Color.Green;
                VouDiscountDisLbl.Text = "Discount Added..";
            }
            else
            {
                VouDiscountDisLbl.ForeColor = Color.Red;
                VouDiscountDisLbl.Text = "Voucher Not found..";
            }
            VoucherCodetxtBox.Clear();
        }

        private void AddToCart_Btn(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;

                GroupBox parentGroupBox = b.Parent as GroupBox;

                if (parentGroupBox != null)
                {
                    // Find the ComboBoxes within the parent GroupBox
                    ComboBox sizeComboBox = parentGroupBox.Controls
                        .OfType<ComboBox>()
                        .FirstOrDefault(cb => cb.Name.StartsWith("PizzaSizecomboBox"));

                    ComboBox crustComboBox = parentGroupBox.Controls
                        .OfType<ComboBox>()
                        .FirstOrDefault(cb => cb.Name.StartsWith("PizzaCrustcomboBox"));

                    if (sizeComboBox != null && crustComboBox != null)
                    {
                        // Retrieve the selected items
                        selectedSize = sizeComboBox.SelectedItem.ToString();
                        selectedCrust = crustComboBox.SelectedItem.ToString();
                    }
                }

                AddItemsToCartDisplay_lbl.Visible = false;

                cmd = new SqlCommand($"Select PizzaName, Price From dbo.Pizza Where PizzaID={b.Tag.ToString()}", con);

                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int RTB_X = 0;
                    int RTB_Y = 120;
                    int RTBCount = CartPanel.Controls.OfType<RichTextBox>().Count();
                    int BtnGap = RTBCount * RTB_Y + 120; ;
                    //string pizzaName = dr["PizzaName"].ToString();

                    var existingRTB = CartPanel.Controls.OfType<RichTextBox>().FirstOrDefault(rtb => rtb.Text.Contains(dr["PizzaName"].ToString()));

                    if (existingRTB != null && existingRTB.Lines[2].Trim() == selectedSize && existingRTB.Lines[3].Trim() == selectedCrust)
                    {
                        string[] RTB_Lines = existingRTB.Lines;
                        string PizzaName_Line = RTB_Lines[0];
                        string[] Line_Parts = PizzaName_Line.Split('x');
                        int PizzaCount = int.Parse(Line_Parts[0].Trim());

                        string Price_Line = RTB_Lines[1];
                        string[] PriceLineParts = Price_Line.Split(':');
                        double PriceCount = double.Parse(PriceLineParts[1].ToString().Trim());
                        existingRTB.Tag = dr["Price"].ToString();
                        PizzaCount++;

                        //string P_Size = RTB_Lines[2].Trim();
                        //string P_Crust = RTB_Lines[3].Trim();

                            double New_Price;
                            double Ori_Price = Convert.ToDouble(dr["Price"]);
                            New_Price = Ori_Price + PriceCount;

                            existingRTB.Lines = new[]
                            {
                            $"{PizzaCount} x {Line_Parts[1].Trim()}",
                            $"Price: {New_Price}",
                            selectedSize,
                            selectedCrust
                            };
                        
                        }
                    else
                    {
                        CartPName_RTB = new RichTextBox();
                        {
                            CartPName_RTB.Tag = dr["Price"].ToString();
                            CartPName_RTB.AppendText($"{PizzaCount} x {dr["PizzaName"].ToString()}\nPrice: {dr["Price"].ToString()}\n");
                            CartPName_RTB.AppendText(selectedSize + "\n");
                            CartPName_RTB.AppendText(selectedCrust);
                            CartPName_RTB.ScrollBars = RichTextBoxScrollBars.None;
                            CartPName_RTB.Enabled = false;
                            CartPName_RTB.Size = new Size(270, 80);

                            if (RTBCount == 0)
                            {
                                CartPName_RTB.Location = new Point(RTB_X, 40);
                            }
                            else
                            {
                                CartPName_RTB.Location = new Point(RTB_X, RTBCount * RTB_Y + 40);
                            }

                            CartPName_RTB.BackColor = Color.White;
                            CartPName_RTB.ForeColor = Color.DarkCyan;
                            CartPName_RTB.Font = new Font("Sitka Text", 11, FontStyle.Bold);
                        }

                        CartRemove_Btn = new Button();
                        {
                            CartRemove_Btn.Text = "Remove";
                            CartRemove_Btn.Size = new Size(65, 25);
                            if (RTBCount == 0)
                            {
                                CartRemove_Btn.Location = new Point(35, 120);
                            }
                            else
                            {
                                CartRemove_Btn.Location = new Point(35, BtnGap);
                            }

                            CartRemove_Btn.BackColor = Color.Tomato;
                            CartRemove_Btn.ForeColor = Color.White;
                            CartRemove_Btn.Font = new Font("Sitka Text", 9, FontStyle.Bold);
                            CartRemove_Btn.Click += RemoveBtn_Click;
                        }

                        CartEdit_Btn = new Button();
                        {
                            CartEdit_Btn.Text = "Edit";
                            CartEdit_Btn.Size = new Size(60, 25);
                            if (RTBCount == 0)
                            {
                                CartEdit_Btn.Location = new Point(100, 120);
                            }
                            else
                            {
                                CartEdit_Btn.Location = new Point(100, BtnGap);
                            }

                            CartEdit_Btn.BackColor = Color.SkyBlue;
                            CartEdit_Btn.ForeColor = Color.White;
                            CartEdit_Btn.Font = new Font("Sitka Text", 9, FontStyle.Bold);
                            CartEdit_Btn.Click += EditBtn_Click;
                        }
                    }

                    FinalAmount += Convert.ToDouble(dr["Price"]);
                    FinalPrice.Text = "" + FinalAmount;

                    CartPanel.Controls.Add(CartPName_RTB);
                    CartPanel.Controls.Add(CartRemove_Btn);
                    CartPanel.Controls.Add(CartEdit_Btn);
                }
            }
            con.Close();
        }

        public async void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button CartRemove_Btn)
            {
                CartRemove_Btn = (Button)sender;
                int buttonY = CartRemove_Btn.Location.Y;

                Button editButton = null;

                foreach (Control control in CartPanel.Controls)
                {
                    if (control is RichTextBox rtb && rtb.Location.Y == buttonY - 80)
                    {
                        associatedRTB = rtb;

                    }
                    else if (control is Button btn && btn.Text == "Edit" && btn.Location.Y == buttonY)
                    {
                        editButton = btn;
                    }
                }

                if (associatedRTB != null)
                {
                    string[] RTB_Lines = associatedRTB.Lines;

                    string PizzaCount = RTB_Lines[0];
                    string[] PCount_Parts = PizzaCount.Split('x');
                    int PCount = int.Parse(PCount_Parts[0]);

                    string PizzaPrice_Line = RTB_Lines[1];
                    string[] Line_Parts = PizzaPrice_Line.Split(':');
                    double Remove_PizzaPrice = double.Parse(Line_Parts[1].Trim());

                    string FA = FinalPrice.Text;
                    double FA2 = double.Parse(FA);

                    FinalAmount = FA2 - Remove_PizzaPrice;
                    FinalPrice.Text = "" + FinalAmount;

                    await Task.Delay(100);

                    CartPanel.Controls.Remove(associatedRTB);
                }

                if (editButton != null)
                {
                    CartPanel.Controls.Remove(editButton);
                }
                CartPanel.Controls.Remove(CartRemove_Btn);

                // Reorganize the remaining controls
                foreach (Control ctrl in CartPanel.Controls)
                {
                    // Move controls that are below the deleted ones
                    if (ctrl.Location.Y > buttonY)
                    {
                        ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y - 120); // Adjust the offset (90 is total height of deleted controls)
                    }
                }

                bool richTextBoxFound = false;

                foreach (Control ctrl in CartPanel.Controls)
                {
                    if (ctrl is RichTextBox)
                    {
                        richTextBoxFound = true;
                        break; // Exit loop as soon as a RichTextBox is found
                    }
                }

                // Update label visibility based on the result
                AddItemsToCartDisplay_lbl.Visible = !richTextBoxFound;
            }
        }

        // Expose ComboBox items as a List
        public List<string> GetComboBoxItems(ComboBox comboBox)
        {
            return comboBox.Items.Cast<string>().ToList();
        }


        public void EditBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button CartEdit_Btn)
            {
                CartEdit_Btn = (Button)sender;
                int buttonY = CartEdit_Btn.Location.Y;

                // Get ComboBox items from MainPizzaForm
                List<string> sizeItems = GetComboBoxItems(cb1);
                List<string> crustItems = GetComboBoxItems(cb2);

                // Set ComboBox items in EditBtn_Form
                EF.SetComboBoxItems(EF.PSize_EditCB, sizeItems);
                EF.SetComboBoxItems(EF.PCrust_EditCB, crustItems);
                
                foreach (Control ctrl in CartPanel.Controls)
                {
                    if (ctrl is RichTextBox rtb && rtb.Location.Y == buttonY - 80)
                    {
                        associatedRTB = rtb;
                    }
                }

                if (associatedRTB != null)
                {
                    string[] RTB_Lines = associatedRTB.Lines;

                    string pizzaCountLine = RTB_Lines[0];
                    string pizzaPriceLine = RTB_Lines[1];
                    string pizzaSizeLine = RTB_Lines[2];
                    string pizzaCrustLine = RTB_Lines[3];

                    string[] countParts = pizzaCountLine.Split('x');
                    string pizzaCount = countParts[0].Trim();
                    string pizzaName = countParts[1].Trim();
                    string pizzaPrice = pizzaPriceLine.Split(':')[1].Trim();
                    string pizzaSize = pizzaSizeLine.Trim();
                    string pizzaCrust = pizzaCrustLine.Trim();

                    EF.QuantityBoxValue = pizzaCount;
                    EF.PizzaNameBoxValue = pizzaName;
                    EF.PriceBoxValue = "0";
                    EF.PizzaSizeValue = pizzaSize;
                    EF.PizzaCrustValue = pizzaCrust;
                                       
                    PizzaOriginalPrice = double.Parse(associatedRTB.Tag.ToString());

                    if (EF.QuantityBoxValue == "1")
                    {
                        EF.MinusBtn.Enabled = false;
                    }
                    else
                    {
                        EF.MinusBtn.Enabled = true;
                    }
                }

                EF.ShowDialog();
            }
        }

        public void ConfirmChgBtn_Click(object sender, EventArgs e)
        {    
            ASF.HandleConfirmation();
        }

        private void EditOrderTypeBtn_Click(object sender, EventArgs e)
        {   
            ASF.ConfirmBtn.Visible = false;

            ConfirmChangeBtn = new Button();
            ConfirmChangeBtn.Location = new Point(250, 340);
            ConfirmChangeBtn.Text = "Confirm Change";
            ConfirmChangeBtn.AutoSize = true;
            ConfirmChangeBtn.ForeColor = Color.DarkGreen;
            ConfirmChangeBtn.Font = new Font("Sitka Text", 14, FontStyle.Bold);
            ConfirmChangeBtn.Click += ConfirmChgBtn_Click;

            ASF.Controls.Add(ConfirmChangeBtn);

            ASF.Show();
            this.Hide();

        }
    }
}