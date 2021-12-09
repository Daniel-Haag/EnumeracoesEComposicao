using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioComposicao.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public Client Client { get; set; }

        public List<OrderItem> orderItems = new List<OrderItem>();

        public Order()
        {

        }
        public Order(OrderStatus status, Client client)
        {
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            orderItems.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            orderItems.Remove(item);
        }

        public double Total()
        {
            double total = 0;

            foreach (var item in orderItems)
            {
                total += item.subTotal();
            }

            return total;
        }
    }
}
