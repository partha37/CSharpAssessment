using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Customer
    {
        public Customer(int customerID, string name, string address, double hotelPrice)
        {
            CustomerID = customerID;
            Name = name;
            Address = address;
            HotelPrice = hotelPrice;
        }

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double HotelPrice { get; set; }
    }
    interface ICustomerManager
    {
        bool AddCustomer(Customer bk);
        bool DeleteCustomer(int id);
        Customer[] FindCustomers(string Name);
        bool UpdateCustomer(int id);
        bool ViewAllCustomers();
    }
    class CustomerManager : ICustomerManager
    {
        HashSet<Customer> Customers = new HashSet<Customer>();
        public bool AddCustomer(Customer bk)
        {
            return Customers.Add(bk);
        }

        public bool DeleteCustomer(int id)
        {
            foreach (Customer bk in Customers)
            {
                if (bk.CustomerID == id)
                {
                    Customers.Remove(bk);
                    return true;
                }
            }
            return false;
        }

        public Customer[] FindCustomers(string Name)
        {
            List<Customer> findlist = new List<Customer>();
            foreach (Customer bk in Customers)
            {
                if (bk.Name.Contains(Name))
                {
                    findlist.Add(bk);
                }
            }
            return findlist.ToArray();
        }

        public bool UpdateCustomer(int id)
        {
            foreach (Customer bk in Customers)
            {
                if (bk.CustomerID == id)
                {
                    Console.Write("Enter the New Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter the New Address: ");
                    string newAddress = Console.ReadLine();
                    Console.Write("Enter the New HotelPrice: ");
                    double newHotelPrice = double.Parse(Console.ReadLine());
                    bk.Name = newName;
                    bk.Address = newAddress;
                    bk.HotelPrice = newHotelPrice;
                    return true;
                }
            }
            return false;
        }
        public bool ViewAllCustomers()
        {
            foreach (var bk in Customers)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Customer ID: {bk.CustomerID}");
                Console.WriteLine($"Name: {bk.Name}");
                Console.WriteLine($"Address: {bk.Address}");
                Console.WriteLine($"HotelPrice: {bk.HotelPrice}");
                Console.WriteLine("-------------------------------");
            }
            return true;
        }
        public void PrintFind(Customer[] temp)
        {
            Console.WriteLine("The Record Found are: \n");
            foreach (var item in temp)
            {
                Console.WriteLine(item.CustomerID);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.HotelPrice+"\n");
            }

        }

        
        
    }

    class PrintMenu
    {
        
        public static void MyConsole()
        {
            Customer bk = new Customer(82, "padhu", "Vellore", 4000);
            Customer bk2 = new Customer(83, "parthi", "Mysore", 8000);
            CustomerManager mgr = new CustomerManager();
            mgr.AddCustomer(bk);
            mgr.AddCustomer(bk2);

            do
            {
                Console.WriteLine("\n----Menu-----");
                Console.WriteLine("1.View All Customers\n2.Add Customer\n3.Find Customer\n4.Update Customer\n5.Delete Customer\n6.Exit");
                int choice = Int32.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    mgr.ViewAllCustomers();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter The CustomerId:  ");
                    int id = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter The Customer name:  ");
                    string name = (Console.ReadLine());
                    Console.WriteLine("Enter The Customer Address:  ");
                    string Address = (Console.ReadLine());
                    Console.WriteLine("Enter The Hote Price:  ");
                    int price = Int32.Parse(Console.ReadLine());
                    Customer bk1 = new Customer(id,name,Address,price);
                    mgr.AddCustomer(bk1);
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the name to Find: ");
                    string str = Console.ReadLine();
                    Customer[] temp = mgr.FindCustomers(str);
                    mgr.PrintFind(temp);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter the Customer ID: ");
                    int id = Int32.Parse( Console.ReadLine());
                    mgr.UpdateCustomer(id);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Enter the Customer ID: ");
                    int id = Int32.Parse(Console.ReadLine());
                    mgr.DeleteCustomer(id);
                }
                else if(choice==6)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter The Correct Number");
                }

            } while (true);
        }
    }

    class CustomerCallManager
    {
        static void Main(string[] args)
        {
            PrintMenu.MyConsole();
        }

    }
}