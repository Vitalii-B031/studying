namespace Rust;

public abstract class Weapon : Item

{
    public string Name{get;set;}
    public int Damage{get;set;}
    public int Health{get;set;}

    public Weapon(string name, int damage, int count, int health): base(count)
    {
        Name=name;
        Damage=damage;
        Health=health;
        
    }
}