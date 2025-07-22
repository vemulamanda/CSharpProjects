using AspNetMvcCoreFarmProject.Models;
using Microsoft.AspNetCore.Components;

namespace AspNetMvcCoreFarmProject.Models
{
    public class CustomerSqlDAL : ICustomer
    {
        private readonly FarmersDbContext dc;

        public CustomerSqlDAL(FarmersDbContext dc)
        {
            this.dc = dc;
        }

        public List<Customer> Customers_Select()
        {
            var customers = dc.Customers.ToList();
            return customers;
        }
        public Customer Customer_Select(int Custid)
        {
            var customer = dc.Customers.Find(Custid);
            return customer;
        }
        public void Customer_Insert(Customer customer)
        {
            dc.Customers.Add(customer);
            dc.SaveChanges();
        }
        public void Customer_Update(Customer customer)
        {
            var existing = dc.Customers.Find(customer.Custid);

            if (existing != null)
            {
                // Update only the fields you want
                existing.Name = customer.Name;
                //existing.Email = customer.Email;
                //existing.MobileNumber = customer.MobileNumber;
                existing.Address = customer.Address;
                existing.FirstBreed = customer.FirstBreed;
                existing.FB_Price = customer.FB_Price;
                existing.FB_Pieces = customer.FB_Pieces;
                existing.SecondBreed = customer.SecondBreed;
                existing.SB_Price = customer.SB_Price;
                existing.SB_Pieces = customer.SB_Pieces;
                existing.ThirdBreed = customer.ThirdBreed;
                existing.TB_Price = customer.TB_Price;
                existing.TB_Pieces = customer.TB_Pieces;
                existing.ImagePath = customer.ImagePath;

                dc.SaveChanges();
            }
        }

        public void Customer_Delete(int Custid)
        {
            var customer = dc.Customers.Find(Custid);
            dc.Customers.Remove(customer);
            dc.SaveChanges();
        }

        //public void AddSingleCustomer(SingleCustomer sin_cus)
        //{            
        //    dc.SingleCustomer.Add(sin_cus);
        //    dc.SaveChanges();
        //}

        public List<Customer> EditAllCustomers(string Loggedinuserid)
        {
            List<Customer> EditCustList = new List<Customer>();
            
            var AllCustomerAds = dc.Customers.ToList();
            foreach(var SingleCustAds in AllCustomerAds)
            {
                if (SingleCustAds.Identity_userId == Loggedinuserid)
                {
                    EditCustList.Add(SingleCustAds);        
                }
            }
            return EditCustList;
        }
    }
}
