public class Inventory
{
    List<Product> products=new List<Product>();

    bool checkIfExist(string name){
        return products.Exists(p=>p.name==name);
    }
    public bool addProduct()
    {
        Console.WriteLine("Enter Product Name:");
        string? name=Console.ReadLine();
        if (name == null){
            return false;
        }
        if (checkIfExist(name)){
            Console.WriteLine("This Product already exists");
        }
        Console.WriteLine("Enter the Product Price:");
        string?input=Console.ReadLine();
        if(input==null)
            return false;

        double price;
        if(!double.TryParse(input,out price)){
            Console.WriteLine("The price should be a valid number");
            return false;
        }

        Console.WriteLine("Enter the Product Quantity:");
        input=Console.ReadLine();
        int quantity;
        if(!int.TryParse(input,out quantity)){
            Console.WriteLine("Quantity should be a valid integer");
            return false;
        }

        Product p=new Product(){name=name,price=price,quantity=quantity};
        products.Add(p);
        return true;
    }
}