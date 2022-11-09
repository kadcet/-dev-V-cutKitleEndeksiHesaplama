using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public class Program
{
    struct DOCTOR
    {
        public int doktorNo;
        public string doktorAd;
        public string dokorSoyad;

        public void EkranaYazDoctor()
        {
            Console.WriteLine($"doktor No : {doktorNo}");
            Console.WriteLine($"Doktor Adı : {doktorAd}");
            Console.WriteLine($"Doktor Soyadı : {dokorSoyad}");
        }

       

    }
    static List<DOCTOR> DoktorList = new List<DOCTOR>();




    struct VKI
    {
        
        public string ad;
        public string soyad;
        public double boy;
        public double kilo;
        public DOCTOR Doctor;

        public double VKIHesapla()
        {
            return kilo / (boy * boy);   // kilo/boy2
        }

        

        public void EkranaYaz()
        {
            Console.WriteLine($"Hasta Adı : {ad}");
            Console.WriteLine($"Hasta Soyadı : {soyad}");
            Console.WriteLine($" Boy : {boy}");
            Console.WriteLine($"Kilo : {kilo}");
            Console.WriteLine($"Doktor Adı : {Doctor.doktorAd} Doktor Soyad : {Doctor.dokorSoyad}");



            if (VKIHesapla() <= 18.40)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("TEŞHİS : ZAYIF");
            }

            else if (VKIHesapla() >= 18.50 && VKIHesapla() <= 24.90)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TEŞHİS : İDEAL");
            }

            else if (VKIHesapla() >= 25.00 && VKIHesapla() <= 29.99)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("TEŞHİS : HAFİF KİLOLU");
            }

            else if (VKIHesapla() >= 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("TEŞHİS : OBEZ");
            }

        }
    }

    static List<VKI> VkıList = new List<VKI>();



    public static void Main()
    {
        Console.Title = "Pratik VKI";
        Menu();
    }

    static void Menu()
    {
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine("1- Yeni Hasta\n2- Hasta Listesi\n3- Yeni Doktor \n4- Doktor Listele\n5- Çıkış");

        MenuSelection();
    }

    static void MenuSelection()
    {

        Console.WriteLine("Yapılacak işlemi seçin :");
        string cevap = Console.ReadLine();
        Console.Clear();

        if (cevap == "1")
        {
            YeniHasta();

        }

        else if (cevap == "2")
        {
            ListOfVkı();
        }

        else if (cevap == "3")
        {
            DoktorEkle();
        }

        else if (cevap == "4")
        {
            DoktorListele();
        }

        else if (cevap == "5")
        {
            Environment.Exit(0);
        }

        else
        {
            Console.WriteLine("Hatalı Seçim Yaptınız :");
            Again();
        }

    }

    private static void DoktorListele()
    {

        LoadFileDoctorFile();
        foreach (var item in DoktorList)
        {
            item.EkranaYazDoctor();
        }

        
        
    }

    static void DoktorEkle()
    {
        DOCTOR d;

        Console.WriteLine("Doktor No:");
        d.doktorNo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("doktor Adı :");
        d.doktorAd = Console.ReadLine();
        Console.WriteLine("Doktor Soyad :");
        d.dokorSoyad = Console.ReadLine();
        LoadFileDoctorFile();
        DoktorList.Add(d);
        WriteFileDoctorFile();
        Again();


    }

    static void YeniHasta()
    {

        VKI v;
        Console.WriteLine("Hasta Adı :");
        v.ad = Console.ReadLine();
        Console.WriteLine("Hasta Soyadı :");
        v.soyad = Console.ReadLine();
        Console.WriteLine("Hastanın Boyu :");
        v.boy = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Hastanın Kilosu :");
        v.kilo = Convert.ToDouble(Console.ReadLine());
        DoktorListele();
        Console.WriteLine("Doktor Seçimi");
        var doktorNoGelen = Convert.ToInt32(Console.ReadLine());
        v.Doctor = DoktorList.FirstOrDefault(x => x.doktorNo == doktorNoGelen);


        



        Console.WriteLine($"Vücut Kitle Endeksi : {v.VKIHesapla()}");


        if (v.VKIHesapla() <= 18.40)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TEŞHİS : ZAYIF");
        }

        else if (v.VKIHesapla() >= 18.50 && v.VKIHesapla() <= 24.90)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TEŞHİS : İDEAL");
        }

        else if (v.VKIHesapla() >= 25.00 && v.VKIHesapla() <= 29.99)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TEŞHİS : HAFİF KİLOLU");
        }

        else if (v.VKIHesapla() >= 30)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("TEŞHİS : OBEZ");
        }

        VkıList.Add(v);
        ReadFile();
        Console.ResetColor();
        Again();
    }

    private static void ListOfVkı()
    {
        Read();
        Console.Clear();
        foreach (var item in VkıList)
        {

            item.EkranaYaz();
            Console.ResetColor();
            Console.WriteLine("-----------------------");


        }
        LoadFile();
        Again();
    }



    // go to: again
    static void Again()
    {

        Console.WriteLine("Menüye dönmek için ENTER");
        Console.ReadLine();
        Menu();
    }




    private const string filePathDoctor = "doctor.txt";
    private const string filePath = "data.txt";

    public static void Write(string data)
    {
        File.WriteAllText(filePath, data);
    }

    public static void WriteDoctor(string data)
    {
        File.WriteAllText(filePathDoctor, data);
    }

    public static string Read()
    {
        if (File.Exists(filePath))
            return File.ReadAllText(filePath);
        else
            return null;
    }

    public static string ReadDoctor()
    {
        if (File.Exists(filePathDoctor))
            return File.ReadAllText(filePathDoctor);
        else
            return null;
    }

    static void ReadFile()
    {
        string json = JsonSerializer.Serialize(VkıList, new JsonSerializerOptions { IncludeFields = true });
        Write(json);
    }

    static void WriteFileDoctorFile()
    {
        string json = JsonSerializer.Serialize(DoktorList, new JsonSerializerOptions { IncludeFields = true });
        WriteDoctor(json);
    }

    static void LoadFile()
    {
        string json = Read();
        VkıList = JsonSerializer.Deserialize<List<VKI>>(json, new JsonSerializerOptions { IncludeFields = true });
    }

    static void LoadFileDoctorFile()
    {
        string json = ReadDoctor();
        if (String.IsNullOrEmpty(json))
             DoktorList= new List<DOCTOR>();
        else
        DoktorList = JsonSerializer.Deserialize<List<DOCTOR>>(json, new JsonSerializerOptions { IncludeFields = true });
    }

}
