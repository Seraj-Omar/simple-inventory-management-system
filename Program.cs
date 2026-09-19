Inventory inventory=new Inventory();

while (true)
{
    Console.WriteLine("""
    Inventory Management:

    1- Add Product
    2- View All Products
    3- Edit Product
    4- Delete Product
    5- Search Product
    6- Exit
    Enter the number of the service you want:
    """);

    int choice;
    string? input=Console.ReadLine();
    if(!int.TryParse(input,out choice)||choice is <1 or >6){
        Console.WriteLine("Your choice should be an integer from 1 to 6.");
        continue;
    }

    Action action=choice switch
    {
        1 => ()=>inventory.addProduct(),
        2 => ()=>inventory.viewProducts(),
        3 => ()=>inventory.editProduct(),
        4 => ()=>inventory.deleteProduct(),
        5 => ()=>inventory.searchProduct(),
        6 => ()=>Environment.Exit(0),
        _ => ()=>Console.WriteLine("Invalid Option")
    };
    action();
}