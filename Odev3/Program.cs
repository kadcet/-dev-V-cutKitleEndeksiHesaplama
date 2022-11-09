
public class Program
{
    
    
    struct VKI
    {
        public double boy;
        public double kilo;

        public double VKIHesapla()
        {
             return kilo / (boy * boy);   // kilo/boy2
        }

        public void EkranaYaz()
        {
            Console.WriteLine($"Boy : {boy}");
            Console.WriteLine($"Kilo : {kilo}");
            Console.WriteLine($"Vücut Kitle Endeksi :{VKIHesapla()}");
        }

    }

    public static void Main()
    {
        Console.Title = "Pratik VKI";
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        VKI v;
        Console.WriteLine("1. Boy giriniz :");
        v.boy = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("2. Kilo giriniz :");
        v.kilo = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"Vücut Kitle Endeksi : {v.VKIHesapla()}");
        Console.Clear();
        v.EkranaYaz();

        double endex = v.VKIHesapla();
        if (endex < 18.49)
            Console.WriteLine("ZAYIF");
        else if (endex > 18.55 && endex < 24.99)
            Console.WriteLine("İDEAL");
        else if (endex > 25.00 && endex < 29.99)
            Console.WriteLine("HAFİF KİLOLU");
        else if (endex > 30)
            Console.WriteLine("OBEZ");

        Again();

    }

    private static void Again()
    {
        
        Console.WriteLine("Yeni bir hesaplama yapmak istiyor musunuz? (E/H) ");
        string cevap = Console.ReadLine().ToLower();
        if (cevap == "e" )
            Menu();
        else if (cevap=="h")
        {
            Environment.Exit(0);
        }

        else
        {
            Console.Clear();
            Console.WriteLine("Hatalı giriş yaptınız");
            Again();
        }
            

    }
    
}
