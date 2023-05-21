
using GoldBageChallenge.Data;

public class DeliveryRepository
{
   
    private readonly List<Delivery> _deliveryDb = new List<Delivery>();
    private int _count = 0;

    //C.R.U.D

    //Create-Add a new delivery to the history
    public bool AddNewDeliveriesToHistory(Delivery deliveries)
    {
        if (deliveries != null)
        {
            _count++;
            deliveries.ID = _count;
            _deliveryDb.Add(deliveries);
            return true;
        }
        else
        {
            return false;
        }
    }

    //Read All-List all en route deliveries
    public List<Delivery> AllEnrouteDelieveries()
    {
        //Make an empty list of deliveries
        List<Delivery> enrouteDeliveries = new List<Delivery>();

        //we need to loop through the database 
        foreach (Delivery d in _deliveryDb)
        {
            //if the delivery orderstatus is equal to enroute then we will add it to the empty list
            if (d.DeliveryStatus == GoldBageChallenge.Data.OrderStatus.EnRoute)
            {
                //add delivery
                enrouteDeliveries.Add(d);
            }
        }
        return enrouteDeliveries;
    }
    // all completed deliveries 
    public List<Delivery> AllCompletedDeliveries()
    {
        List<Delivery> completeDeliveries = new List<Delivery>();

        foreach (Delivery d in _deliveryDb)
        {
            if (d.DeliveryStatus == GoldBageChallenge.Data.OrderStatus.Complete)
            {
                completeDeliveries.Add(d);
            }
        }
        return completeDeliveries;
    }

    //Read By Id
    public Delivery GetDeliveriesById(int deliveryId)
    {
        return _deliveryDb.FirstOrDefault(d => d.ID == deliveryId)!;
    }

    //Update-Update the status of a delivery
    public bool UpdateDeliveriesStatus(int deliveryId, OrderStatus newOrderStatus)
    {
        var oldDeliveriesData = GetDeliveriesById(deliveryId);
        if (oldDeliveriesData != null)
        {
            oldDeliveriesData.DeliveryStatus = newOrderStatus;
            return true;
        }
        return false;
    }

    //Delete-Cancel a delivery
    public bool DeleteDeliveries(int deliveryId)
    {
        return _deliveryDb.Remove(GetDeliveriesById(deliveryId));
    }

}
