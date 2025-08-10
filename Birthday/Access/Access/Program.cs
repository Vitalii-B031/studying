namespace Access;
using MyLib1;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class State 
{
    //То же что и private string defaultVar 
    string defaultVar="default"; 
    //поле доступа только из текущего класса
    private string privateVar="private";
    //доступ из текущего класса и производных классов, которые определены в этом же проекте
    protected private string protectedPrivateVar = "protected private";
    //доступ из текущего класса и производных классов
    protected string protectedVar = "protected";
    //доступ в любом месте текущего проекта
    internal string internalVar = "internal";
    //доступ в любом месте текущего проекта и из классов наследников ы других проектрах
    protected internal string protectedInternalVar = "protected internal";
    //доступ в любом месте программы, а также для других программ и сборок
    public string publicVar = "public";
    
    // по умолчанию имеет модификатор private
    void Print() => Console.WriteLine(defaultVar);
 
    // метод доступен только из текущего класса
    private void PrintPrivate() => Console.WriteLine(privateVar);
 
    // доступен из текущего класса и производных классов, которые определены в этом же проекте
    protected private void PrintProtectedPrivate() => Console.WriteLine(protectedPrivateVar);
 
    // доступен из текущего класса и производных классов
    protected void PrintProtected() => Console.WriteLine(protectedVar);
 
    // доступен в любом месте текущего проекта
    internal void PrintInternal() => Console.WriteLine(internalVar);
 
    // доступен в любом месте текущего проекта и из классов-наследников в других проектах
    protected internal void PrintProtectedInternal() => Console.WriteLine(protectedInternalVar);
 
    // доступен в любом месте программы, а также для других программ и сборок
    public void PrintPublic() => Console.WriteLine(publicVar);

}

class StateCostumer
{
    public void PrintState(State state)
    {
        State state = new State();
        
        // обратиться к переменной defaultVar у нас не получится,
        // так как она имеет модификатор private и класс StateConsumer ее не видит
        Console.WriteLine(state.defaultVar); //Ошибка, получить доступ нельзя
 
        // то же самое относится и к переменной privateVar
        Console.WriteLine(state.privateVar); // Ошибка, получить доступ нельзя
 
        // обратиться к переменной protectedPrivateVar не получится,
        // так как класс StateConsumer не является классом-наследником класса State
        Console.WriteLine(state.protectedPrivateVar); // Ошибка, получить доступ нельзя
 
        // обратиться к переменной protectedVar тоже не получится,
        // так как класс StateConsumer не является классом-наследником класса State
        Console.WriteLine(state.protectedVar); // Ошибка, получить доступ нельзя
 
        // переменная internalVar с модификатором internal доступна из любого места текущего проекта
        // поэтому можно получить или изменить ее значение
        Console.WriteLine(state.internalVar);
 
        // переменная protectedInternalVar так же доступна из любого места текущего проекта
        Console.WriteLine(state.protectedInternalVar);
 
        // переменная publicVar общедоступна
        Console.WriteLine(state.publicVar);
        
        State state = new State();
 
        state.Print(); //Ошибка, получить доступ нельзя
 
        state.PrintPrivate(); // Ошибка, получить доступ нельзя
 
        state.PrintProtectedPrivate(); // Ошибка, получить доступ нельзя
 
        state.PrintProtected(); // Ошибка, получить доступ нельзя
 
        state.PrintInternal();    // норм
 
        state.PrintProtectedInternal();  // норм
 
        state.PrintPublic();      // норм
    }

    public void PrintStateMyLib()
    {
        // Ошибка DefaultState - по умолчанию internal, поэтому нет доступа
        DefaultState dafaultState = new DefaultState();
        // Ошибка InternalState - internal, поэтому нет доступа
        InternalState internalState = new InternalState();
        
        // норм, PublicState - public, доступен из других программ
        PublicState publicState = new PublicState();
        // Ошибка, нет доступа - метод доступен только в свой сборке
        publicState.PrintInternal();
        // Ошибка, нет доступа - StateConsumer НЕ является классом-наследником от класса PublicState,
        // поэтому метод не доступен
        publicState.PrintProtectedInternal();  // нет доступа
        // норм - общедоступный метод
        publicState.PrintPublic();      // норм
    }
}
    
