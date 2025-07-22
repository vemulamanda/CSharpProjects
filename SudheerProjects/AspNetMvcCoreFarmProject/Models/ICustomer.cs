namespace AspNetMvcCoreFarmProject.Models
{
    public interface ICustomer
    {
        List<Customer> Customers_Select();
        Customer Customer_Select(int Custid);
        void Customer_Insert(Customer customer);
        void Customer_Update(Customer customer);
        void Customer_Delete(int Custid);
        List<Customer> EditAllCustomers(string userid);
    }
}
