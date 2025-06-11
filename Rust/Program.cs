namespace Rust;

class Program
{
    static void Main(string[] args)
    {
        
        var p = GetPlayer(GetWeapon(WeaponType.Revolver));
        var p2 = GetPlayer(GetWeapon(WeaponType.Revolver));
        Console.WriteLine($"{p.Name} в игре");
        Console.WriteLine($"{p2.Name} в игре");
        while (!p.IsDead && !p2.IsDead)
        {
            p.Hit(p2);
            p2.Hit(p);
            Console.WriteLine($"{p.Health} {p2.Health}");
        }

        if (p.IsDead)
        {
            foreach (var item in p2.Inventory.Items)
            {
                   item.Count += p.Inventory.Items.First(x => x.GetType()==item.GetType()).Count;
                   p.Inventory.Items.Remove(p.Inventory.Items.First(x => x.GetType()==item.GetType()));
            }
            PrintLoot(p2);
            
        }
        if (p2.IsDead)
        {
            foreach (var item in p.Inventory.Items)
            {
                item.Count += p2.Inventory.Items.First(x => x.GetType()==item.GetType()).Count;
                p2.Inventory.Items.Remove(p2.Inventory.Items.First(x => x.GetType()==item.GetType()));
            }
            PrintLoot(p);
        }
    }
    static Player GetPlayer(Weapon weapon)
    {
        var rand = new Random();
        var player = new Player(Console.ReadLine(), weapon);
        player.Inventory.Items.Add(new Scrap(rand.Next(1, 200)));
        player.Inventory.Items.Add(new Sulfur(rand.Next(1, 200)));
        player.Inventory.Items.Add(new Cloath(rand.Next(1, 200)));
        return player;
    }
    static Weapon GetWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Bow:
                return new Bow(1);
            case WeaponType.Revolver:
                return new Revolver(1);

            default: throw new ArgumentException();
        }
    }

    static void PrintLoot(Player player)
    {
        Console.WriteLine($"Лут игрока: {player.Name}");
        foreach (var item in player.Inventory.Items)
        {
            Console.WriteLine($"{item.GetType()}: {item.Count}");
        }
    }
}