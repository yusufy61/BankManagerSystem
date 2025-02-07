

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
        Hesap hesap1 = new Hesap(1111, 1000, 1);
        Hesap hesap2 = new Hesap(1112, 2000, 2);
        Hesap hesap3 = new Hesap(1113, 3000, 3);

        try
        {
            Console.WriteLine("Havale işlemi :");
            hesap1.Havale(hesap2, 500);
            
        }
        catch (NegatifDegerException ex)
        {
            Console.WriteLine(ex.Message);
            Logger.Logla(ex.Message);
        }
        catch (YetersizBakiyeException ex)
        {
            Console.WriteLine(ex.Message);
            Logger.Logla(ex.Message);
        }
        catch (HesapBulunamadiException ex)
        {
            Console.WriteLine(ex.Message);
            Logger.Logla(ex.Message);
        }

        try
        {
            hesap2.Havale(hesap3, 4000);
            hesap3.Havale(hesap1, 1500);
        }
        catch (NegatifDegerException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (YetersizBakiyeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (HesapBulunamadiException ex)
        {
            Console.WriteLine(ex.Message);
        }

        finally
        {
            Console.WriteLine("İşlemler tamamlandı"); // bize işlemlerin tamamlandığını gösterir. İşlemlerin başarılı olduğunu söylemez.
        }
    }
}