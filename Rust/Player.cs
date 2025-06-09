namespace Rust;

public class Player
{
    public string Name{get;set;}
    public int Health{get;set;}
    public Weapon Weapon{get;set;}

    public void Hit(Player target)
    {
        target.Health-=Weapon.Damage;
        Console.WriteLine($"{Name} нанес {Weapon.Damage} урона по игроку {target.Name} оружием {Weapon.Name}");
    }

    public void Print()
    {
        Console.WriteLine("Hello World!");
    }

    public Player(string name, Weapon weapon)
    {
        Name=name;
        Health=100;
        Weapon = weapon;
        

    }

}