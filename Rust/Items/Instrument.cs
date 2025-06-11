namespace Rust;

public abstract class Instrument : Item
{
    public int Health { get; set; }

    public Instrument (int health, int count): base(count)
    {
        Health = health;
    }
}