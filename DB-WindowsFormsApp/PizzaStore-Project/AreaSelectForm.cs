using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaStore_Project
{
    public partial class AreaSelectForm : Form
    {
        public RichTextBox Del_Address_RTB;
        public ComboBox CB_SelectSuburb;
        public Label Pickup_Dis_Lbl;

        public string OrderType { get; set; }
        //public string Address { get; set; }
        //public string StoreArea { get; set; }

        public MainPizzaForm MPF;

        public AreaSelectForm()
        {
            InitializeComponent();
            MPF = new MainPizzaForm(this);
        }

        private void Delivery_RBtn_CheckedChanged(object sender, EventArgs e)
        {
            OrderType = "Delivery";

            OrderType_panel.Controls.Clear();

            if (Delivery_RBtn.Checked)
            {
                Label Del_Dis_Lbl = new Label();
                Del_Dis_Lbl.Text = "Please enter your address: ";
                Del_Dis_Lbl.AutoSize = true;
                Del_Dis_Lbl.Font = new Font("Sitka Text", 12, FontStyle.Bold);
                Del_Dis_Lbl.ForeColor = Color.Brown;

                Del_Address_RTB = new RichTextBox();
                Del_Address_RTB.Font = new Font("Sitka Text", 12, FontStyle.Bold);
                Del_Address_RTB.Location = new Point(Del_Dis_Lbl.Left, Del_Dis_Lbl.Bottom + 20);
                Del_Address_RTB.Size = new Size(300, 100);

                OrderType_panel.Controls.Add(Del_Dis_Lbl);
                OrderType_panel.Controls.Add(Del_Address_RTB);
            }
        }

        private void Pickup_RBtn_CheckedChanged(object sender, EventArgs e)
        {
            OrderType = "Pickup";

            OrderType_panel.Controls.Clear();

            string[] suburbs = {
        "none", "Carlton", "Fitzroy", "South Yarra", "St Kilda", "Richmond", "Docklands", "Southbank",
        "East Melbourne", "North Melbourne", "West Melbourne", "Kensington", "Parkville",
        "Collingwood", "Abbotsford", "Port Melbourne", "Albert Park", "Middle Park",
        "Prahran", "Windsor", "Flemington", "Footscray", "Brunswick", "Brunswick East",
        "Brunswick West", "Carlton North", "Clifton Hill", "South Melbourne", "Toorak",
        "Armadale", "Hawthorn", "Hawthorn East", "Kew", "Kew East", "Balwyn", "Balwyn North",
        "Camberwell", "Glen Iris", "Malvern", "Malvern East", "Caulfield", "Caulfield North",
        "Caulfield South", "Elsternwick", "Elwood", "Brighton", "Brighton East", "Hampton",
        "Sandringham", "Highett", "Bentleigh", "Bentleigh East", "Moorabbin", "Cheltenham",
        "Mentone", "Mordialloc", "Aspendale", "Edithvale", "Chelsea", "Bonbeach", "Carrum",
        "Seaford", "Frankston", "Frankston South", "Mount Eliza", "Mornington", "Mount Martha",
        "Dromana", "Rosebud", "Rye", "Sorrento", "Portsea", "Dandenong", "Dandenong North",
        "Dandenong South", "Noble Park", "Noble Park North", "Springvale", "Springvale South",
        "Keysborough", "Mulgrave", "Wheelers Hill", "Glen Waverley", "Mount Waverley",
        "Notting Hill", "Clayton", "Clayton South", "Oakleigh", "Oakleigh East", "Oakleigh South",
        "Huntingdale", "Chadstone", "Ashwood", "Ashburton", "Burwood", "Burwood East", "Box Hill",
        "Box Hill North", "Box Hill South", "Blackburn", "Blackburn North", "Blackburn South",
        "Forest Hill", "Nunawading", "Mitcham", "Vermont", "Vermont South", "Ringwood",
        "Ringwood East", "Ringwood North", "Croydon", "Croydon North", "Croydon South",
        "Croydon Hills", "Bayswater", "Bayswater North", "Boronia", "Ferntree Gully",
        "Upper Ferntree Gully", "Rowville", "Lysterfield", "Scoresby", "Knoxfield",
        "Wantirna", "Wantirna South", "Heathmont", "Warrandyte", "Warrandyte South",
        "Park Orchards", "Donvale", "Doncaster", "Doncaster East", "Templestowe",
        "Templestowe Lower", "Bulleen", "Surrey Hills", "Mont Albert", "Mont Albert North",
        "Deepdene", "Kooyong", "Ripponlea", "Black Rock", "Beaumaris", "Dingley Village",
        "Clarinda", "Heatherton", "Murrumbeena", "Ormond", "McKinnon", "Carnegie",
        "Hughesdale", "Glen Huntly", "Hampton East", "Moorabbin Airport", "Cheltenham North"
    };

            if (Pickup_RBtn.Checked)
            {
                Pickup_Dis_Lbl = new Label();
                Pickup_Dis_Lbl.Text = "Please select your nearest store : ";
                Pickup_Dis_Lbl.AutoSize = true;
                Pickup_Dis_Lbl.Font = new Font("Sitka Text", 12, FontStyle.Bold);
                Pickup_Dis_Lbl.ForeColor = Color.Brown;

                CB_SelectSuburb = new ComboBox();
                CB_SelectSuburb.Items.AddRange(suburbs);
                CB_SelectSuburb.Font = new Font("Sitka Text", 12, FontStyle.Bold);
                CB_SelectSuburb.Location = new Point(Pickup_Dis_Lbl.Left, Pickup_Dis_Lbl.Bottom + 20);
                CB_SelectSuburb.DropDownStyle = ComboBoxStyle.DropDownList;
                CB_SelectSuburb.Size = new Size(200, 80);
                CB_SelectSuburb.SelectedIndex = 0;

                OrderType_panel.Controls.Add(Pickup_Dis_Lbl);
                OrderType_panel.Controls.Add(CB_SelectSuburb);
            }
        }

        public void ConfirmBtn_Click(object sender = null, EventArgs e = null)
        {
            HandleConfirmation();
        }

        public void HandleConfirmation()
        {
            if (OrderType == "Delivery")
            {
                if (Del_Address_RTB.Text.Trim() == "" || Del_Address_RTB.Text.Trim() == null)
                {
                    MessageBox.Show("You have selected delivery. Please enter Delivery address..");
                }
                else
                {
                    MPF.PickupStore_Dis_lbl.Visible = false;
                    MPF.C_PickupStore_lbl.Visible = false;
                    MPF.C_Address_lbl.Visible = true;

                    MPF.C_OrderType_lbl.Text = OrderType?.ToString();
                    MPF.C_Address_lbl.Text = Del_Address_RTB?.Text.ToString().Trim();

                    this.Hide();
                    MPF.Show();
                }
            }
            else if (OrderType == "Pickup")
            {
                if (CB_SelectSuburb.SelectedIndex == 0)
                {
                    MessageBox.Show("You have selected Pickup. Please select the store..");
                }
                else
                {
                    MPF.PickupStore_Dis_lbl.Visible = true;
                    MPF.C_PickupStore_lbl.Visible = true;
                    MPF.C_Address_lbl.Visible = false;

                    MPF.C_OrderType_lbl.Text = OrderType?.ToString();
                    MPF.C_PickupStore_lbl.Text = CB_SelectSuburb?.SelectedItem.ToString();

                    this.Hide();
                    MPF.Show();
                }
            }
        }
    }
}
