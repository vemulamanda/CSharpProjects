using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppExample.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact { Name="Sudheer Kumar", Email="Sudheerkumar.v3@gmail.com"},
            new Contact { Name="Eswar Kumar", Email="Eswarkumar@gmail.com"},
            new Contact { Name="Srija", Email="srija@gmail.com"},
            new Contact { Name="Siri", Email="Siri@gmail.com"},
        };

        public static List<Contact> GetContacts() => _contacts;
        public static Contact GetContactById(int ContactId)
        {
            return _contacts.FirstOrDefault(x => x.ContactId ==  ContactId);
        }
    }
}
