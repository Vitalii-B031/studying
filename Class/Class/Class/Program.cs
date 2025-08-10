namespace Class;

class Program
{
    static void Main(string[] args)
    {
       Person p = new Person();
       p.Print(); 
       
       Person p2 = new Person("Андрей");
       p2.Print();
       
       Person p3 = p;
       p3.Name = "Изменеие класса";
       p.Print();
       
       PersonStruct ps = new PersonStruct();
       PersonStruct ps2 = ps;
       ps2.Name = "Изменение структуры";
       ps.Print();
    }
}

class Person
{
    public int Age;
    public string Name;

    public Person() 
    {
        Name = "Неизвестно";
        Age = 18;
    }

    public Person(string name)
    {
        Name = name;
        Age = 18;
    }
    public void Print()
    {
        Console.WriteLine($"Имя: {Name}, Возраст: {Age}");
    }
    public void Deconstruct(out string name, out int age)
    {
        name = Name;
        age = Age;
    }
    
}

struct PersonStruct
{
    public int Age;
    public string Name;

    public PersonStruct()
    {
        Name = "Fedr";
        Age = 21;
        
    }

    public void Print()
    {
        Console.WriteLine($"Имя: {Name}, Возраст: {Age}");
    }
}