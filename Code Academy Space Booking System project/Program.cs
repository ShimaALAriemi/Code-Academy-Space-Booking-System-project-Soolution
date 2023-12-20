using Code_Academy_Space_Booking_System_project.Model;
using Code_Academy_Space_Booking_System_project.MyDBContext;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Code_Academy_Space_Booking_System_project
{
    internal class Program
    {
        static ApplicationDbContext dbContext = new ApplicationDbContext();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Space Booking System!");

            Customer customer = Customer_Details();
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            Console.WriteLine("\nSelect a Space:");

            Bill bill;
            Booking booking = Book_Space(customer, out bill);
            dbContext.Book.Add(booking);
            dbContext.SaveChanges();

            Console.WriteLine("\nReceive you bill");

            var book = (from B in dbContext.Book
                       select B).ToList();

            foreach (var item in book)
            {

                Console.Write("Duration :"+(item?.Duration ?? 0) + "  || ");
                Console.Write("Start Day:" + item?.Start_Day + "  ||  " ?? "NA  ||  ");
                Console.Write("End Day:" + item?.End_Day + "  ||  " ?? "NA  ||  ");
                Console.WriteLine("Cost:"+(item?.Cost ?? 0.0m) + "  || ");
                Console.Write("Building_Name:"+item?.Space?.Building_Name  + "  || ");
                Console.Write("Payment_Status:"+(item?.Bills.Payment_Status + "  ||  " ?? "NA  ||  "));
                Console.Write("Customer Name:" + item?.Customer.FName ?? "NA  ||  ");

                Console.WriteLine();

            }

            Console.WriteLine("\n\n\tThank you for using the Space Booking System!");

        }

        public static Customer Customer_Details()
        {
            Console.Write("\n\nEnter Your First Name:");
            string fname = Console.ReadLine();

            Console.Write("Enter Your Last Name:");
            string lname = Console.ReadLine();

            Console.Write("Enter Birthday : Exp YYYY-MM-DD ");
            string Birthday = Console.ReadLine();

            int age;

            do
            {
                Console.Write("Enter Your Age:");

            } while (!int.TryParse(Console.ReadLine(), out age) && age >= 0);

            Console.Write("Enter Your Email:");
            string email = Console.ReadLine();

            Console.Write("Enter Your Street:");
            string Streets = Console.ReadLine();

            Console.Write("Enter Your House Num:");
            long HouseNum = (long)Convert.ToUInt64(Console.ReadLine());

            Console.Write("Enter Your Phone:");
            string phone = Console.ReadLine();

            Customer customer = new Customer()
            {
                FName = fname,
                LName = lname,
                DoB = Birthday,
                Age = age,
                Email = email,
                Street = Streets,
                House_Num = HouseNum,
                Phone = phone
            };

            return customer;
        }

        public static Booking Book_Space(Customer customer, out Bill bill) {
            Console.Write("Enter Start_Day : Exp YYYY-MM-DD ");
            string start_Day = Console.ReadLine();

            Console.Write("Enter End_Day : Exp YYYY-MM-DD ");
            string end_Day = Console.ReadLine();

            Console.WriteLine("\n");
            var Spa = (from S in dbContext.Spaces
                       select S).ToList();


            foreach (var item in Spa)
            {
                Console.Write((item?.Space_ID ?? 0) + "  || ");
                Console.Write(item?.Location + "  ||  " ?? "NA  ||  ");
                Console.WriteLine((item?.Width  ?? 0.0) + "  || ");
                Console.Write((item?.Hight ?? 0.0) + "  || ");
                Console.Write((item?.Building_Name + "  ||  " ?? "NA  ||  "));
                Console.Write(item?.Space_Status ?? " Booked ");

                Console.WriteLine();

            }


            int Space;
            do
            {
                Console.Write($"Select your Space:(1-{Spa.Count()}) ");
            } while (!int.TryParse(Console.ReadLine(), out Space) && Space > 0 && Space <= Spa.Count());


            //Editing the status of space
            var AS = (from I in dbContext.Spaces
                              where I.Space_ID == Space
                      select I).FirstOrDefault();

            AS.Space_Status = "Booked";
            dbContext.Spaces.Update(AS);
            dbContext.SaveChanges();
            
            

            String Payment;
            bool WillPayment;
            do
            {
                Console.Write("\nWill you Payment Know? (yes/no): ");
                Payment = Console.ReadLine().ToLower().Trim();
                WillPayment = (Payment == "yes" || Payment == "y") ? true : false;
            } while (!(Payment == "yes" || Payment == "no" || Payment == "n" || Payment == "y"));

            Console.Write("How whould like to Pay: (Cash => c , Visa => v , Credit Card => a)");
            char PaymentWay = Convert.ToChar(Console.ReadLine());
            string PaymentType= "";
            switch (PaymentWay)
            {
                case 'c': PaymentType = "Cash"; break;
                case 'v': PaymentType = "Visa"; break;
                case 'a': PaymentType = "Credit Card "; break;
                default: PaymentType = "not Payed";break;
            }

            int customerId = (from I in dbContext.Customers
                                   where I.Email == customer.Email
                              select I.Customer_ID).FirstOrDefault();

            bill = new Bill()
            {
                Payment_Status = WillPayment,
                Payment_Type = PaymentType,
                CustomerID = customerId,
            };
            dbContext.Bills.Add(bill);
            dbContext.SaveChanges();

            var billID= (from I in dbContext.Bills
                              where I.CustomerID == customer.Customer_ID
                              select I).FirstOrDefault();

            int du = Booking.countDuration(start_Day, end_Day);

            Booking booking = new Booking()
            {
                Duration = du,
                Start_Day = start_Day,
                End_Day = end_Day,
                Cost = Booking.countCost(du),
                SpaceID = Space,
                BillID = billID.Bill_Id,
                CustomerID = customerId
            };
            booking.Bills = billID;
            booking.Customer = customer;

            return booking;
        }

    }
}