using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagerSystem.Exceptions;

namespace BankManagerSystem.Models
{
    public class Hesap
    {
        public int Id { get; set; }
        public int HesapNo { get; set; }
        public decimal Bakiye { get; set; }
        public int MusteriId { get; set; }
        public Hesap()
        {
            
        }
        public Hesap(int hesapNo, decimal bakiye, int musteriId)
        {
            HesapNo = hesapNo;
            Bakiye = bakiye;
            MusteriId = musteriId;
        }

        public void ParaYatir(decimal miktar)
        {
            if (miktar < 0)
            {
                throw new NegatifDegerException("Negatif değer girişi yapıldı!");
            }
            Bakiye += miktar;
            Console.WriteLine($"{HesapNo} Hesabına {miktar}tl Para Yatırma işlemi başarılı bir şekilde gerçekleştirildi <>");
        }

        public void ParaCek(decimal miktar)
        {
            if (miktar < 0)
            {
                throw new NegatifDegerException("Negatif değer girişi yapıldı!");
            }
            if (Bakiye < miktar)
            {
                throw new YetersizBakiyeException("Yetersiz bakiye! Lütfen daha düşük bir miktar girin.");
            }
            Bakiye -= miktar;
            Console.WriteLine($"{HesapNo} Numaralı hesaptan {miktar}tl para çekme işlemi başarılı bir şekilde gerçekleştirildi <>");
        }

        public void Havale(Hesap hedefHesap, decimal miktar)
        {
            if (miktar < 0)
            {
                throw new NegatifDegerException("Negatif değer girişi yapıldı!");
            }
            else if (Bakiye < miktar)
            {
                throw new YetersizBakiyeException("Yetersiz bakiye! Lütfen daha düşük bir miktar girin.");
            }
            else if (hedefHesap == null)
            {
                throw new HesapBulunamadiException("Hedef hesap bulunamadı! Lütfen başka bir hesap deneyiniz.");
            }
            else
            {
                ParaCek(miktar);
                hedefHesap.ParaYatir(miktar);
                Console.WriteLine($"{HesapNo} Numralı hesaptan {hedefHesap.HesapNo} hesabına {miktar}tl para gönderildi! <>");
            }
            
        }

    }
}
