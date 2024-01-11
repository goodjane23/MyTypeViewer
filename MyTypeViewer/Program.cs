using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Fun with reflection");
        string typeName;

        do
        {
            Console.WriteLine("Enter type");
            typeName = Console.ReadLine();
            try
            {
                Type type = Type.GetType(typeName);
                if (type is null && typeName.Equals("System.Console", StringComparison.OrdinalIgnoreCase))
                {
                    type = typeof(Console);
                }
                Console.WriteLine("");
                ListVariousStats(type);
                ListFiled(type);
                ListPropertes(type);
                ListMethod(type);
                ListInterfaces(type);
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, can't find type");
            }

        }
        while (true);
    }
    private static void ListMethod(Type t)
    {
        Console.WriteLine("Methods");
        MethodInfo[] mi = t.GetMethods();
        foreach (MethodInfo m in mi)
        {
            string retVal = m.ReturnType.FullName;
            string paramInfo = "(";
            foreach (ParameterInfo pi in m.GetParameters())
            {
                paramInfo += pi.ParameterType + pi.Name;
            }
            paramInfo += ")";
            Console.WriteLine($"-> {retVal} {m.Name} {paramInfo}");
            Console.WriteLine($"-> {m.Name}");
        }

       
        Console.WriteLine();
    }

    private static void ListFiled(Type t)
    {
        Console.WriteLine("Fields");
        var filedsName = from f in t.GetFields() select f.Name;
        foreach(var f in filedsName)
        {
            Console.WriteLine($"-> {f}");
        }
        Console.WriteLine();
    }

    private static void ListPropertes(Type t)
    {
        var propNames = from prop in t.GetProperties() select prop.Name;
        foreach (var pn in propNames)
        {
            Console.WriteLine($"-> {pn}");
        }
        Console.WriteLine();
    }

    private static void ListInterfaces(Type t)
    {
        Console.WriteLine("interfaces");
        var interfaces = from i in t.GetInterfaces() select i;
        foreach (var i in interfaces)
        {
            Console.WriteLine($"->{i.Name}");
        }
        Console.WriteLine();
    }

    private static void ListVariousStats(Type t)
    {
        Console.WriteLine("Various statistics");
        Console.WriteLine($"Base class is: {t.BaseType}");
        Console.WriteLine($"Is type abstract: {t.IsAbstract}");
        Console.WriteLine($"Is type sealed: {t.IsSealed}");
        Console.WriteLine($"Is type generic {t.IsGenericTypeDefinition}");
        Console.WriteLine($"Is type a class type: {t.IsClass}");
        Console.WriteLine();
    }
}