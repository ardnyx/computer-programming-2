using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Inventory_Management
{
    internal class Program
    {
        private static string[,] currentInventory =
            {  //  Item     Qty   Price
                { "[0] Shampoo", "30", "20.00" },
                { "[1] Soap", "50", "25.00" },
                { "[2] Instant Noodles", "50", "15.00" },
                { "[3] Chips", "50", "8.00" },
                { "[4] Crackers", "80", "5.00" },
                { "[5] Soda", "25", "75.00" },
                { "[6] Bottled Water", "100", "25.00" },
                { "[7] Sandwich Spread", "65", "40.00" },
                { "[8] Soup Sachet", "50", "25.00" },
            };
        private static string[,] inventorySales =
            {  //  Item     Qty   Price
                { "Shampoo", "30", "0.00" },
                { "Soap", "50", "0.00" },
                { "Instant Noodles", "50", "0.00" },
                { "Chips", "50", "0.00" },
                { "Crackers", "80", "0.00" },
                { "Soda", "25", "0.00" },
                { "Bottled Water", "100", "0.00" },
                { "Sandwich Spread", "65", "0.00" },
                { "Soup Sachet", "50", "0.00" },
            };
        private static string[,] customerCart =
            {  //  Item     Qty   Price
                { "Shampoo", "0", "0.00" },
                { "Soap", "0", "0.00" },
                { "Instant Noodles", "0", "0.00" },
                { "Chips", "0", "0.00" },
                { "Crackers", "0", "0.00" },
                { "Soda", "0", "0.00" },
                { "Bottled Water", "0", "0.00" },
                { "Sandwich Spread", "0", "0.00" },
                { "Soup Sachet", "0", "0.00" },
            };
        private static int itemCounter = 0;
        static void Main(string[] args)
        {
            bool exitProgram = false;
            do
            {
                Write("Welcome to Sari Sari Store Version 1 Final Na\n" +
                      "\nWould you like to enter as a: \n(1) Customer\n(2) Administrator\n ");
                Write("\nInput: ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Clear();
                        customerGuest();
                        break;
                    case 2:
                        Administrator();
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
                Clear();

            } while (!exitProgram);
        }

        static void Administrator()
        {
            Clear();
            double totalSale = 0;
            for (int rows = 0; rows < inventorySales.GetLength(0); rows++)
            {
                WriteLine(string.Format("{0,-20} {1,-10} {2,-10}", inventorySales[rows, 0], inventorySales[rows, 1], $"Php {inventorySales[rows, 2]}"));
                totalSale += Convert.ToDouble(inventorySales[rows, 2]);
            }
            Console.WriteLine("--------------------------------------------------");
            WriteLine($"Total Sale: Php {totalSale}");

            Console.WriteLine("Type BACK to go back to the homepage.\n");
            Write("> ");
            string input = Console.ReadLine();
            if (input.ToLower() == "back")
            {
                return;
            }
        }


        static void customerGuest()
        {
            for (int rows = 0; rows < currentInventory.GetLength(0); rows++)
            {
                if (Convert.ToInt32(currentInventory[rows, 1]) == 0)
                {
                    WriteLine($"{currentInventory[rows, 0]} - Out of stock");
                    continue;
                }
                WriteLine(string.Format("{0,-26} {1,-14} {2,-10}", currentInventory[rows, 0], currentInventory[rows, 1], $"Php {currentInventory[rows, 2]}"));
            }
            WriteLine("---------------------------------------------------");
            if (itemCounter == 10)
            {
                Checkout();
            }
            else
            {
                WriteLine($"Your cart is {itemCounter}/10");
                Write("Please type the number of the item (0-8). Press 9 if you want to checkout.");
                int rowItemOrder = int.Parse(ReadLine());
                if (rowItemOrder == 10)
                {
                    Checkout();
                }
                else if (rowItemOrder == 9)
                {
                    Checkout();
                }
                else
                {
                    AddToCart(rowItemOrder);
                }
            }
        }

        static void AddToCart(int rowItemOrder)
        {
            if (Convert.ToInt32(currentInventory[rowItemOrder, 1]) == 0)
            {
                Console.WriteLine("This item is out of stock\n\nPress any key to continue.");
                ReadKey();
                Clear();
                customerGuest();
                return;
            }

            double PriceInventory = Convert.ToDouble(currentInventory[rowItemOrder, 2]);
            int itemQuantity = Convert.ToInt32(currentInventory[rowItemOrder, 1]);

            Console.WriteLine($"How many quantities of {currentInventory[rowItemOrder, 0]}?");
            int quantity = int.Parse(ReadLine());

            if (itemQuantity - quantity < 0)
            {
                Console.WriteLine($"Only {itemQuantity} left in stock.");
                ReadKey();
                Clear();
                customerGuest();
                return;
            }

            if (itemCounter + quantity > 10)
            {
                int remainingSpace = 10 - itemCounter;
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"You only have {remainingSpace} slots left in your cart.");
                ForegroundColor = ConsoleColor.White;
                WriteLine();
                ReadKey();
                Clear();
                customerGuest();
                return;
            }

            double totalPrice = quantity * PriceInventory;

            customerCart[rowItemOrder, 1] = (Convert.ToInt32(customerCart[rowItemOrder, 1]) + quantity).ToString();
            customerCart[rowItemOrder, 2] = (Convert.ToDouble(customerCart[rowItemOrder, 2]) + totalPrice).ToString();

            itemCounter += quantity;
            itemQuantity -= quantity;

            currentInventory[rowItemOrder, 1] = itemQuantity.ToString();
            Clear();
            customerGuest();
        }


        static void Checkout()
        {
            double totalBill = 0;
            for (int rows = 0; rows < customerCart.GetLength(0); rows++)
            {
                WriteLine(string.Format("{0,-20} {1,-10} {2,-10}", customerCart[rows, 0], customerCart[rows, 1], $"Php {customerCart[rows, 2]}"));
                totalBill += Convert.ToDouble(customerCart[rows, 2]);
            }
            WriteLine("--------------------------------------------------");

            double vat = totalBill * 0.20; // Calculating VAT (20%)
            double totalBillWithVAT = totalBill + vat; // Total bill with VAT

            WriteLine($"Total bill (before VAT): Php {totalBill}");
            WriteLine($"VAT (20%): Php {vat}");
            WriteLine($"Total bill (after VAT): Php {totalBillWithVAT}");

            Write("Would you like to proceed with checkout? (yes/no): ");
            string choice = ReadLine();
            if (choice.ToLower() == "yes")
            {
                UpdateInventory();
                WriteLine("Thank you for your purchase!");
                itemCounter = 0;
            }
            else if (choice.ToLower() == "no")
            {
                RestoreInventory();
                WriteLine("Checkout cancelled.");
                itemCounter = 0;
            }
            ReadKey();
        }


        static void UpdateInventory()
        {
            for (int rows = 0; rows < customerCart.GetLength(0); rows++)
            {
                int adminInventory = Convert.ToInt32(inventorySales[rows, 1]);
                double adminPriceInventory = Convert.ToDouble(inventorySales[rows, 2]);

                int customerInventory = Convert.ToInt32(customerCart[rows, 1]);
                double totalPrice = Convert.ToDouble(customerCart[rows, 2]);

                adminInventory -= customerInventory;
                adminPriceInventory += totalPrice;

                inventorySales[rows, 1] = adminInventory.ToString();
                inventorySales[rows, 2] = adminPriceInventory.ToString();

                customerCart[rows, 1] = "0";
                customerCart[rows, 2] = "0.00";
            }
        }

        static void RestoreInventory()
        {
            for (int rows = 0; rows < customerCart.GetLength(0); rows++)
            {
                int itemQuantity = Convert.ToInt32(currentInventory[rows, 1]);
                int cartQuantity = Convert.ToInt32(customerCart[rows, 1]);

                itemQuantity += cartQuantity;
                currentInventory[rows, 1] = itemQuantity.ToString();

                customerCart[rows, 1] = "0";
                customerCart[rows, 2] = "0.00";
            }
        }
    }
}
