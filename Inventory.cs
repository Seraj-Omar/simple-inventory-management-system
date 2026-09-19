public class Inventory
{
    List<Product> products=new List<Product>();

    private Product? checkIfExist(string name){
        return products.Find(p=>p.name==name);
    }
    public bool addProduct()
    {
        Console.WriteLine("Enter Product Name:");
        string? name=Console.ReadLine();
        if (name == null){
            return false;
        }
        if (checkIfExist(name)==null){
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

    public bool viewProducts()
    {
        if (products.Count == 0){
            Console.WriteLine("There is no products currently in our inventory.");
            return false;
        }
        for(int i=0;i<products.Count;i++)
        {
            Product product=products[i];
            Console.WriteLine($"{i+1} - Name: {product.name}, Price: {product.price}, Quantity: {product.quantity}");
        }
        return true;
    }

    public bool editProduct()
    {
        Console.WriteLine("Enter the product name that you want to edit:");
        string? input=Console.ReadLine();
        if(input==null){
            Console.WriteLine("Enter a valid name");
            return false;
        }
        Product? product=checkIfExist(input);
        if(product==null){
            Console.WriteLine("No product exit with this name");
            return false;
        }

        Console.WriteLine("Enter a new Name (press enter to keep the current):");
        input=Console.ReadLine();
        if(input!=null){
            product.name=input;
        }

        Console.WriteLine("Enter a new Price (press enter to keep the current):");
        input=Console.ReadLine();
        
        if(input!=null){
            double price;
            if(!double.TryParse(input,out price)||price<0){
                Console.WriteLine("Price should be a valid positive number");
                return false;
            }
            
            if(price!=0){
                product.price=price;
            }
        }
        
        Console.WriteLine("Enter a new Quantity (press enter to keep the current):");
        input=Console.ReadLine();

        if(input!=null){
            int quantity;
            if(!int.TryParse(input,out quantity)||quantity<0){
                Console.WriteLine("Quantity should be a valid positive integer");
                return false;
            }
            
            if(quantity!=0){
                product.quantity=quantity;
            }
        }

        return true;
    }

    public bool deleteProduct()
    {
        Console.WriteLine("Enter the product name that you want to delete:");
        string? input=Console.ReadLine();
        if(input==null){
            Console.WriteLine("Enter a valid name");
            return false;
        }
        Product? product=checkIfExist(input);
        if(product==null){
            Console.WriteLine("No product exit with this name");
            return false;
        }

        products.Remove(product);
        return true;
    }
}