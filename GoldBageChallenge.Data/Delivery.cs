using GoldBageChallenge.Data;

public class Delivery
{
    public Delivery()
    {
          DeliveryStatus = OrderStatus.Scheduled;
    }
    public Delivery(int customerID, int itemNumber, int deliveryQuantity)
    {
        CustomerID = customerID;
        DeliveryStatus = OrderStatus.Scheduled;
        ItemNumber = itemNumber;
        DeliveryQuantity = deliveryQuantity;
    }

    public int ID { get; set; }
    public int CustomerID { get; set; } 
    public DateTime  DeliveryDate 
    {
         get
         {
            return OrderDate.AddDays(7);
         }
    } 
    public DateTime  OrderDate { get; set; } = DateTime.Now;
    public OrderStatus DeliveryStatus { get; set; }
    public int ItemNumber { get; set; } 
    public int DeliveryQuantity { get; set; }
  
    public override string ToString()
    {
        var str = $"ID: {ID}\n"+
        $"CustomerId: {CustomerID}\n"+
        $"ItemNumber: {ItemNumber}\n"+
        $"DeliveryQuantity: {DeliveryQuantity}\n"+
        $"OderDate: {OrderDate}\n"+
        $"DeliveryStatus: {DeliveryStatus}\n"+
        $"DeliveryDate: {DeliveryDate}";
        return str;
    }

}
