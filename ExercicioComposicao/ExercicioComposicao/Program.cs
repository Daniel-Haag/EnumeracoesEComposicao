using System;
using ExercicioComposicao.Entities;

namespace ExercicioComposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Email:");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order Data:");
            Console.Write("Status - (PendingPayment/Processing/Shipped/Delivered):");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(orderStatus, client);

            Console.Write("How many items to this order?");
            int quantity = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantity; i++)
            {
                Console.WriteLine($"Enter #{i+1} item data:");
                Console.Write("Product Name:");
                string productName = Console.ReadLine();
                Console.Write("Product Price:");
                double productPrice = double.Parse(Console.ReadLine());
                Console.Write("Quantity:");
                int productQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(productQuantity, productPrice, product);

                orderItem.subTotal();

                order.AddItem(orderItem);
            }

            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine($"Order moment: {order.Moment}");
            Console.WriteLine("Order status: " + order.Status.ToString());
            Console.WriteLine($"Client: {order.Client.Name} - {order.Client.BirthDate} - {order.Client.Email}");
            Console.WriteLine("Order items:");

            foreach (var item in order.orderItems)
            {
                Console.Write($"{item.Product.Name}, ${item.Product.Price}, Quantity: {item.Quantity}, SubTotal: {item.subTotal()}");
            }


        }
    }
}
