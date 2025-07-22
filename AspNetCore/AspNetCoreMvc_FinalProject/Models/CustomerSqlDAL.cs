using AspNetCoreMvc_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetCoreMvc_FinalProject.Models
{
    public class CustomerSqlDAL : ICustomer
    {
        MvcCoreDBContext dc;
        
        public CustomerSqlDAL(MvcCoreDBContext dc)
        {
            this.dc = dc;
        }

        public List<Customer> Customers_Select()
        {
            var Customers = dc.Customers.Where(C => C.Status == true).ToList();
            return Customers;
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
            customer.Status = true;
            dc.Update(customer);
            dc.SaveChanges();
        }
        public void Customer_Delete(int Custid)
        {
            var customer = dc.Customers.Find(Custid);
            customer.Status = false;
            dc.SaveChanges();
        }
    }
}
