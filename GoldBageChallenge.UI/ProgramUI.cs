
public class NewBaseType
{
    private bool ValidateDeliveryDatabase(int userInputDeliveryId)
    {
        if (deliveriesInDb.Count > 0)
        {
            Console.Clear();
            foreach (Developer dev in devsInDb)
            {
                DisplayDevData(dev);
            }

        }
        else
        {
            Console.WriteLine("There are no developers in the database.");
        }
    }
}

public class ProgramUI : NewBaseType
{
    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("DeliveryApp\n" +
            "1. Add a new delivery to the history\n" +
            "2. List all Enroute deliveries\n" +
            "3. List of Completed Deliveries\n" +
            "4. Update Delivery Status\n" +
            "5. Delete/Cancel Delivery\n" +
            "6. Close Application\n" +
            "========================================\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddANewDelivery();
                    break;

                case "2":
                    ListAllEnroute();
                    break;

                case "3":
                    ListCompleted();
                    break;

                case "4":
                    UpdateStatus();
                    break;

                case "5":
                    DeleteDelivery();
                    break;

                case "6":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKey();
                    break;
            }
        }
    }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thanks For Using The Delivery App");
        PressAnyKey();
        Console.Clear();
        return false;
    }

    private void DeleteDelivery()
    {
        Console.Clear();
        System.Console.WriteLine("=======Delete Delivery========");
        try
        {
            System.Console.WriteLine("Select A Delivery");
            int userInputDeliveryId = int.Parse(Console.ReadLine()!);
            var isValidated = ValidateDeliveryDatabase(userInputDeliveryId);

            if (isValidated)
            {
                System.Console.WriteLine("Do you want to delete this Delivery? y/n");
                string userConfirmation = Console.ReadLine()!.ToLower();
                if (userConfirmation == "y")
                {
                    if (_dRepo.DeleteDelivery(userInputDeliveryId))
                    {
                        System.Console.WriteLine($"The Delivery was Deleted!");
                    }
                    else
                    {
                        System.Console.WriteLine($"The Delivery is not Deleted!");
                    }
                }
            }
            else
            {
                System.Console.WriteLine($"The Delivery with id: {userInputDeliveryId} doesn't exist!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex);
            SomethingWentWrong();
        }
        PressAnyKey();
    }

    private void SomethingWentWrong()
    {
        Console.WriteLine("Something went wrong.\n" +
                          "Please try again\n" +
                          "Returning to Delivery Menu\n");
    }

    private void UpdateStatus()
    {
        Console.Clear();

        PressAnyKey();
    }

    private void ListCompleted()
    {
        Console.Clear();

        PressAnyKey();
    }

    private void ListAllEnroute()
    {
        Console.Clear();

        PressAnyKey();
    }

    private void AddANewDelivery()
    {
        Console.Clear();
       var newDelivery = new Delivery();
       System.Console.WriteLine("Please enter Customer ID Number\n"+
                                "Please enter new Item Number\n"+
                                "Please enter new Item Quantity\n");
        bool isSuccessful = DeliveryRepository.AddNewDelivery(newDelivery);
        if(isSuccessful)
        {
            System.Console.WriteLine($"New Delivery {newDelivery.CustomerID} was added to DB.");
        }
        else
        {
            System.Console.WriteLine("Failed to add new Delivery.");
        }
        PressAnyKey();
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press Any Key To Continue");
        Console.ReadKey();
    }
}
