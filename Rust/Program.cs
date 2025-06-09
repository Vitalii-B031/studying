namespace Rust;

class Program
{
    static void Main(string[] args)
    {

        var p = GetPlayer(GetWeapon(WeaponType.Bow));
        var p2 = GetPlayer(GetWeapon(WeaponType.Revolver));
        Console.WriteLine($"{p.Name} в игре");
        Console.WriteLine($"{p2.Name} в игре");
        while (!p.IsDead && !p2.IsDead)
        {
            p.Hit(p2);
            p2.Hit(p);
            Console.WriteLine($"{p.Health} {p2.Health}");
            
        }
       
    }

    static Player GetPlayer(Weapon weapon)
    {
        var player = new Player(Console.ReadLine(), weapon);
        return player;
    }

    static Weapon GetWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Bow:
                return new Bow();
            case WeaponType.Revolver:
                return new Revolver();

            default: throw new ArgumentException();
        }
    }
}