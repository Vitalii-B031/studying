namespace Rust;

public class Player
{
    public string Name{get;set;}
    public int Health{get;set;}
    public Weapon Weapon{get;set;}
    public bool IsDead{get;set;}



    public void Hit(Player target)
    {
        double damage = 0;
        var rand = new Random();
        var chance = rand.Next(1, 101);
        if (chance > 80)
        {
            damage = Weapon.Damage * 1.5;
        }
        else if (chance < 80 && chance > 20)
        {
            damage = Weapon.Damage;
        }
        else
        {
            damage = Weapon.Damage / 2.0;
        }

        target.Health -= (int)damage;
        if (target.Health <= 0)
        {
            Console.WriteLine($"игрок {Name} убил игрока {target.Name}");
            IsDead = true;
        }
        else
        {
            Console.WriteLine($"{Name} нанес {Weapon.Damage} урона по игроку {target.Name} оружием {Weapon.Name}");
        }
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