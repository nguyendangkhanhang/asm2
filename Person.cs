using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    public class Person
    {
        protected static int id = 0;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Person(string name, string address, string phoneNumber)
        {
            this.ID = ++id; // Gán giá trị của ID bằng giá trị của biến tĩnh id và sau đó tăng giá trị của id
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
