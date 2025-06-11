using Rust.Instruments;

namespace Rust;

public class Player
{
    public string Name{get;set;}
    public int Health{get;set;}
    public Weapon Weapon{get;set;}
    public bool IsDead{get;set;}

    public Inventory Inventory{get;set;}

    public void Hit(Player target)
    {
        double damage = 0;
        if (IsDead)
        {
            return;
        }
        var rand = new Random();
        var chance = rand.Next(1, 101);
        if (chance > 70)
        {
            damage = Weapon.Damage * 1.5;
        }
        else if (chance < 70 && chance > 30)
        {
            damage = Weapon.Damage;
        }
        else
        {
            damage = Weapon.Damage * 0.5;
        }

        target.Health -= (int)damage;
        if (target.Health <= 0)
        {
            Console.WriteLine($"игрок {Name} убил игрока {target.Name}");
            target.IsDead = true;
        }
            Console.WriteLine($"{Name} нанес {damage} урона по игроку {target.Name} оружием {Weapon.Name}");
    }
    public Player(string name, Weapon weapon)
    {
        Name=name;
        Health=100;
        Weapon = weapon;
        Inventory = new Inventory(new List<Item>()
        {
            new Torch(1),
            new Rock(1),
            weapon
            
        });
    }

}