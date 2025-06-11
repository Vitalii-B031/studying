namespace Rust;

public abstract class Item
{
    public int Count {get; set;}

    public Item(int count)
    {
        Count = count;
    }
}