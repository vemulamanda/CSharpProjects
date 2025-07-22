using System.Data;

namespace AspNetCoreWebApiExample.Models
{
    public class CustomerXmlDAL : ICustomerDAL
    {
        DataSet ds;

        public CustomerXmlDAL()
        {
            ds = new DataSet();
            ds.ReadXml("Customer.xml");
            //Adding primary key on data set
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["Custid"] };
        }

        public List<Customer> Customers_Select()
        {
            List<Customer> Customers = new List<Customer>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Customer obj = new Customer
                {
                    Custid = Convert.ToInt32(dr["Custid"]),
                    Name = Convert.ToString(dr["Name"]),
                    Balance = Convert.ToDecimal(dr["Balance"]),
                    City = Convert.ToString(dr["City"]),
                    Status = Convert.ToBoolean(dr["Status"])
                };
                Customers.Add(obj);
            }
            return Customers;
        }

        public Customer Customer_Select(int Custid)
        {
            //Finding data row based on its primary key value
            DataRow dr = ds.Tables[0].Rows.Find(Custid);

            Customer c = new Customer
            {
                Custid = Convert.ToInt32(dr["Custid"]),
                Name = Convert.ToString(dr["Name"]),
                Balance = Convert.ToDecimal(dr["Balance"]),
                City = Convert.ToString(dr["City"]),
                Status = Convert.ToBoolean(dr["Status"])
            };
            return c;
        }

        public void Customer_Insert(Customer customer)
        {
            //If you want to insert data into new row, you need to create datarow first

            DataRow dr = ds.Tables[0].NewRow();

            //Now assign values to each column in the new row.

            dr["Custid"] = customer.Custid;
            dr["Name"] = customer.Name;
            dr["Balance"] = customer.Balance;
            dr["City"] = customer.City;
            dr["Status"] = customer.Status;

            //Now adding new datarow to datatable
            ds.Tables[0].Rows.Add(dr);

            //Saving data to xml file
            ds.WriteXml("Customer.xml");
        }

        public void Customer_Update(Customer customer)
        {
            //Finding datarow based on primary key
            DataRow dr = ds.Tables[0].Rows.Find(customer.Custid);

            //Finding the index of datarow by calling indexof method
            int index = ds.Tables[0].Rows.IndexOf(dr);

            //Overriding the old values in row with new values based on index.
            ds.Tables[0].Rows[index]["Name"] = customer.Name;
            ds.Tables[0].Rows[index]["Balance"] = customer.Balance;
            ds.Tables[0].Rows[index]["City"] = customer.City;

            //saving data back to xml file
            ds.WriteXml("Customer.xml");
        }

        public void Customer_Delete(int Custid)
        {
            //Finding datarow based on primary key
            DataRow dr = ds.Tables[0].Rows.Find(Custid);

            //Finding the index of datarow by calling indexof method
            int index = ds.Tables[0].Rows.IndexOf(dr);

            //deleting datarow from data table by using index
            ds.Tables[0].Rows[index].Delete();

            //saving data back to xml file
            ds.WriteXml("Customer.xml");
        }
    }
}

