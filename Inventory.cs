public class Inventory
{
    private readonly List<Product> products=new List<Product>();

    private Product? checkIfExist(string name){
        return products.Find(p=>string.Equals(p.name,name,StringComparison.OrdinalIgnoreCase));
    }
    public void addProduct()
    {
        Console.WriteLine("Enter Product Name:");
        string? name=Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Product name cannot be empty.\n");
            return;
        }

        if (checkIfExist(name)!=null){
            Console.WriteLine("This Product already exists\n");
            return;
        }

        Console.WriteLine("Enter the Product Price:");
        string?input=Console.ReadLine()?.Trim();

        if(!double.TryParse(input,out double price)||price<0){
            Console.WriteLine("The price should be a valid non-negative number\n");
            return;
        }

        Console.WriteLine("Enter the Product Quantity:");
        input=Console.ReadLine()?.Trim();

        if(!int.TryParse(input,out int quantity)||quantity<0){
            Console.WriteLine("Quantity should be a valid non-negative integer\n");
            return;
        }

        Product p=new Product(){name=name,price=price,quantity=quantity};
        products.Add(p);
        Console.WriteLine("Product added Successfully\n");
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
        string? input=Console.ReadLine()?.Trim();
        if(string.IsNullOrEmpty(input)){
            Console.WriteLine("Enter a valid name\n");
            return;
        }

        Product? product=checkIfExist(input.Trim());
        if(product==null){
            Console.WriteLine("No product exists with this name\n");
            return;
        }

        Console.WriteLine("Enter a new Name (press enter to keep the current):\n");
        input=Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(input))
        {
            if (!string.Equals(input, product.name, StringComparison.OrdinalIgnoreCase) && checkIfExist(input) != null)
            {
                Console.WriteLine("A product with this name already exists.\n");
                return;
            }
            product.name=input;
        }

        Console.WriteLine("Enter a new Price (press enter to keep the current):");
        input=Console.ReadLine()?.Trim();
        
        if(!string.IsNullOrEmpty(input)){
            if(!double.TryParse(input,out double price)||price<0){
                Console.WriteLine("Price should be a valid positive number\n");
                return;
            }
            product.price=price;
        }
        
        Console.WriteLine("Enter a new Quantity (press enter to keep the current):");
        input=Console.ReadLine()?.Trim();

        if(!string.IsNullOrEmpty(input)){
            if(!int.TryParse(input,out int quantity)||quantity<0){
                Console.WriteLine("Quantity should be a valid positive integer\n");
                return;
            }
            product.quantity=quantity;
        }
        Console.WriteLine("Product updated successfully!\n");
        return;
    }

    public void deleteProduct()
    {
        Console.WriteLine("Enter the product name that you want to delete:");
        string? input=Console.ReadLine()?.Trim();
        if(string.IsNullOrEmpty(input)){
            Console.WriteLine("Enter a valid name\n");
            return;
        }
        Product? product=checkIfExist(input);
        if(product==null){
            Console.WriteLine("No product exit with this name\n");
            return;
        }

        products.Remove(product);
        Console.WriteLine("Product deleted successfully!\n");
        return;
    }

    public void searchProduct()
    {
        Console.WriteLine("Enter the product name:");
        string? input=Console.ReadLine()?.Trim();
        if(string.IsNullOrEmpty(input)){
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