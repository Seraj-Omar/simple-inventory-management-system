public class Inventory
{
    List<Product> products=new List<Product>();

    private Product? checkIfExist(string name){
        return products.Find(p=>p.name==name);
    }
    public void addProduct()
    {
        Console.WriteLine("Enter Product Name:");
        string? name=Console.ReadLine();
        if (name == null){
            return;
        }
        if (checkIfExist(name)!=null){
            Console.WriteLine("This Product already exists\n");
            return;
        }
        Console.WriteLine("Enter the Product Price:");
        string?input=Console.ReadLine();
        if(input==null)
            return;

        double price;
        if(!double.TryParse(input,out price)){
            Console.WriteLine("The price should be a valid number\n");
            return;
        }

        Console.WriteLine("Enter the Product Quantity:");
        input=Console.ReadLine();
        int quantity;
        if(!int.TryParse(input,out quantity)){
            Console.WriteLine("Quantity should be a valid integer\n");
            return;
        }

        Product p=new Product(){name=name,price=price,quantity=quantity};
        products.Add(p);
        return;
    }

    public void viewProducts()
    {
        if (products.Count == 0){
            Console.WriteLine("There is no products currently in our inventory.\n");
            return;
        }
        for(int i=0;i<products.Count;i++)
        {
            Product product=products[i];
            Console.WriteLine($"{i+1} - Name: {product.name}, Price: {product.price}, Quantity: {product.quantity}");
        }
        return;
    }

    public void editProduct()
    {
        Console.WriteLine("Enter the product name that you want to edit:");
        string? input=Console.ReadLine();
        if(input==null){
            Console.WriteLine("Enter a valid name\n");
            return;
        }
        Product? product=checkIfExist(input);
        if(product==null){
            Console.WriteLine("No product exit with this name\n");
            return;
        }

        Console.WriteLine("Enter a new Name (press enter to keep the current):\n");
        input=Console.ReadLine();
        if(input!=null){
            product.name=input;
        }

        Console.WriteLine("Enter a new Price (press enter to keep the current):");
        input=Console.ReadLine();
        
        if(input!=null){
            double price;
            if(!double.TryParse(input,out price)||price<0){
                Console.WriteLine("Price should be a valid positive number\n");
                return;
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
                Console.WriteLine("Quantity should be a valid positive integer\n");
                return;
            }
            
            if(quantity!=0){
                product.quantity=quantity;
            }
        }

        return;
    }

    public void deleteProduct()
    {
        Console.WriteLine("Enter the product name that you want to delete:");
        string? input=Console.ReadLine();
        if(input==null){
            Console.WriteLine("Enter a valid name\n");
            return;
        }
        Product? product=checkIfExist(input);
        if(product==null){
            Console.WriteLine("No product exit with this name\n");
            return;
        }

        products.Remove(product);
        return;
    }

    public void searchProduct()
    {
        Console.WriteLine("Enter the product name:");
        string? input=Console.ReadLine();
        if(input==null){
            Console.WriteLine("Enter a valid name\n");
            return;
        }
        Product? product=checkIfExist(input);
        if(product==null){
            Console.WriteLine("No product exit with this name\n");
            return;
        }
        Console.WriteLine($"Name: {product.name}, Price: {product.price}, Quantity: {product.quantity} \n");
        return;
    }
}