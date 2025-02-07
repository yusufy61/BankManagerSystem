using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagerSystem.Exceptions;
using BankManagerSystem.Logs;
using BankManagerSystem.Models;

namespace BankManagerSystem.Services
{
    public static class HesapYönetim
    {
        private static List<Hesap> hesaplar = new List<Hesap>();

        /*
         * Bağımlılığı azaltmak için parametre olarak Hesap nesnesi alındı.
         * (Objenin prop ları parametre olarak alınmadı!!)
         */
        public static void HesapAc(Hesap yeniHesap)
        {
            try
            {
                if (yeniHesap.Bakiye < 0)
                {
                    throw new Exceptions.NegatifDegerException("Bakiye negatif olamaz!");
                }
                else if (hesaplar.Any(x => x.HesapNo == yeniHesap.HesapNo))
                {
                    throw new Exceptions.HesapBulunamadiException($"Hesabı zaten mevcut! | Hesap No : {yeniHesap.HesapNo}");
                }
                hesaplar.Add(yeniHesap);
                Console.WriteLine($"Yeni hesap oluşturuldu | Hesap No : {yeniHesap.HesapNo}");

            }
            catch (NegatifDegerException ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Logla(ex.Message);
            }
            catch (HesapBulunamadiException ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Logla(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Beklenmeyen bir hata oluştu!");
                Logger.Logla(ex.Message);
            }

        }

        public static void HesapSil(int hesapNo)
        {
            try
            {
                Hesap? silinecekHesap = hesaplar.FirstOrDefault(x => x.HesapNo == hesapNo);
                if (silinecekHesap == null)
                {
                    throw new Exceptions.HesapBulunamadiException("Hesap bulunamadı!");
                }
                hesaplar.Remove(silinecekHesap);
                Console.WriteLine($" {silinecekHesap.HesapNo} Numaralı hesap silindi! ");
            }
            catch (HesapBulunamadiException ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Logla(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Beklenmeyen bir hata oluştu!");
                Logger.Logla(ex.Message);
            }


        }

        public static void HesapListele()
        {
            foreach (var hesap in hesaplar)
            {
                Console.WriteLine($"Hesap No : {hesap.HesapNo} \n Bakiye : {hesap.Bakiye} \n Müşteri Id : {hesap.MusteriId} \n");
            }
        }

        public static void HesapIslemleri()
        {
            bool durum = true;
            while (durum)
            {
                Console.WriteLine("Hesap Islemleri");
                Console.WriteLine("1. Para Yatır");
                Console.WriteLine("2. Para Çek");
                Console.WriteLine("3. Havale");
                Console.WriteLine("4. Geri");
                Console.Write("Seçiminiz : ");
                int secim = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (secim)
                {
                    case 1:
                        // Para Yatırma işlemi
                        try
                        {
                            Console.Write("Hesap No : ");
                            int hesapNo = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Miktar : ");
                            decimal miktar = Convert.ToDecimal(Console.ReadLine());
                            Hesap? hesap = hesaplar.FirstOrDefault(x => x.HesapNo == hesapNo);
                            if (hesap == null)
                            {
                                throw new Exceptions.HesapBulunamadiException("Hesap bulunamadı!");
                            }
                            hesap.ParaYatir(miktar);
                        }
                        catch(NegatifDegerException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Logger.Logla(ex.Message);
                        }
                        catch (HesapBulunamadiException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Logger.Logla(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Beklenmeyen bir hata oluştu!");
                            Logger.Logla(ex.Message);
                        }
                        break;
                    case 2:

                        // Para Çekme işlemi
                        try
                        {
                            Console.Write("Hesap No : ");
                            int hesapNo2 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Miktar : ");
                            decimal miktar2 = Convert.ToDecimal(Console.ReadLine());
                            Hesap? hesap2 = hesaplar.FirstOrDefault(x => x.HesapNo == hesapNo2);
                            if (hesap2 == null)
                            {
                                throw new Exceptions.HesapBulunamadiException("Hesap bulunamadı!");
                            }
                            hesap2.ParaCek(miktar2);
                        }
                        catch(HesapBulunamadiException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Logger.Logla(ex.Message);
                        }
                        catch(YetersizBakiyeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Logger.Logla(ex.Message);
                        }
                        catch (NegatifDegerException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Logger.Logla(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Beklenmeyen bir hata oluştu!");
                            Logger.Logla(ex.Message);
                        }

                        break;
                    case 3:

                        // Havale işlemi

                        try
                        {
                            Console.Write("Hesap No : ");
                            int hesapNo3 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Hedef Hesap No : ");
                            int hedefHesapNo = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Miktar : ");
                            decimal miktar3 = Convert.ToDecimal(Console.ReadLine());
                            Hesap? hesap3 = hesaplar.FirstOrDefault(x => x.HesapNo == hesapNo3);
                            Hesap? hedefHesap = hesaplar.FirstOrDefault(x => x.HesapNo == hedefHesapNo);
                            if (hesap3 == null || hedefHesap == null)
                            {
                                throw new Exceptions.HesapBulunamadiException("Hesap bulunamadı!");
                            }
                            hesap3.Havale(hedefHesap, miktar3);
                        }
                        catch(NegatifDegerException ex)
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
                        catch (Exception ex)
                        {
                            Console.WriteLine("Beklenmeyen bir hata oluştu!");
                            Logger.Logla(ex.Message);
                        }
                        break;
                    case 4:
                        durum = false;
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız!");
                        break;
                }
            }
        }
    }
}
