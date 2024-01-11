using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("External assembly Viewer");
        string assName = "";
        Assembly asm = null;

        do
        {
            Console.WriteLine("Enter  an assembly to evalute");
            assName = Console.ReadLine();
            try
            {
                asm = Assembly.LoadFrom(assName);
                DisplayTypesInAsm(asm);
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, can't find assembly");
            }
        } while (true);
    }

    private static void DisplayTypesInAsm(Assembly asm)
    {
        Console.WriteLine("Types in assmbly");
        Console.WriteLine($"-> {asm.FullName}");
        Type[] types = asm.GetTypes();

        foreach (Type type in types)
        {
            Console.WriteLine($"Type: {type}");
        }
        Console.WriteLine("");
    }
}