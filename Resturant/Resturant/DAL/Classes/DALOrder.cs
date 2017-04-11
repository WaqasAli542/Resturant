using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
public class DALOrder
{

    ResturantDatabase database = null;

    public DALOrder()
    {
        database = new ResturantDatabase();
    }
    #region Order
    public bool addOrder(Order Order)
    {
        database.Orders.Add(Order);
        return database.SaveChanges() != -1? true : false;
    }

    public bool updateOrder(Order Order)
    {
        database.Entry(Order).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteOrder(Order Order)
    {
        database.Orders.Remove(Order);
        return database.SaveChanges() != -1 ? true : false;
    }

    public Order getOrderById(int id)
    {
        return database.Orders.FirstOrDefault(Order => Order.Id == id);
    }

    public List<Order> getListOfOrder()
    {
        return database.Orders.ToList();
    }
    #endregion


}
    
}