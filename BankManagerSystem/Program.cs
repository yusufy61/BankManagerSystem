

using BankManagerSystem.Exceptions;
using BankManagerSystem.Logs;
using BankManagerSystem.Models;
using BankManagerSystem.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hesap Yönetim Sistemi");
        Console.WriteLine();
        bool durum = true;
        while (durum) {
            Console.WriteLine("1. Hesap Oluştur");
            Console.WriteLine("2. Hesap Sil");
            Console.WriteLine("3. Hesap Listele");
            Console.WriteLine("4. Hesap İşlemleri");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminiz : ");
            int secim = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (secim)
            {
                case 1:
                    Console.Write("Hesap No :");
                    int hesapNo = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Bakiye :");
                    decimal bakiye = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Müşteri Id :");
                    int musteriId = Convert.ToInt32(Console.ReadLine());
                    HesapYönetim.HesapAc(new Hesap(hesapNo, bakiye, musteriId)); // Fonksiyon Parametre olarak Hesap sınıfından bir nesne alır.
                    break;
                case 2:
                    Console.Write("Hesap No :");
                    int silinecekHesapNo = Convert.ToInt32(Console.ReadLine());
                    HesapYönetim.HesapSil(silinecekHesapNo);
                    break;
                case 3:
                    HesapYönetim.HesapListele();
                    break;
                case 4:
                    HesapYönetim.HesapIslemleri();
                    break;
                case 5:
                    durum = false;
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!");
                    break;
            }
        }
    }
}
