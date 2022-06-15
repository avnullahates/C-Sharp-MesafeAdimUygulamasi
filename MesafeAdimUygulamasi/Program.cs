using System;

namespace MesafeAdimUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            Giris();

            byte ortalamaAdimCm = OrtalamaAdimCmMetot();

            int dakikaAdim = DakikaAdimMetot();

            int kosuSuresiDakika = SaatveDakika();

            double sonuc = GunlukKosuMesafesi(ortalamaAdimCm, dakikaAdim, kosuSuresiDakika);
            Console.WriteLine();
            Console.WriteLine("Gunluk kosu mesafeniz: {0} metredir", sonuc);

            Cikis();

        }


        private static void Giris()
        {
            Console.WriteLine("Hosgeldiniz. Bu uygulamada gun sonunda sizin vereceginiz bilgiler dahilinde mesafenizi olcecegiz." +
                " Yonlendirmelere gore belirtilen veri turunu griniz. Biz size sonuclara ekrana yazdiracaz.");
            Console.WriteLine();
        }
        private static void Cikis()
        {
            Console.WriteLine();
            Console.WriteLine("Programi tamamladiniz. toplam kosu mesafenizi metre cinsinden size bildirdik. Umarim begenmissinizdir. Iyi gunler dileriz :)");
        }
        private static byte OrtalamaAdimCmMetot()
        {
            Console.WriteLine("Lutfen ortalama bir adiminizin kac santimetre oldugunu yaziniz: ");
            byte sayi;
            bool sayiMi = byte.TryParse(Console.ReadLine(), out sayi);
            if (!sayiMi || sayi < 0 || sayi > byte.MaxValue - 1)
            {
                Console.WriteLine("Girilen deger tam sayi degil veya sayi izin verilen aralik disinda girildi (0-{0})", byte.MaxValue);
                return OrtalamaAdimCmMetot();
            }
            byte ortalamaAdimCmSayisi = sayi;
            return ortalamaAdimCmSayisi;

        }


        private static int DakikaAdimMetot()
        {
            Console.WriteLine();
            Console.WriteLine("Bu kisimda bir dakikada kac adim kostugunuzu giriniz: ");
            int sayi;
            bool sayiMi = int.TryParse(Console.ReadLine(), out sayi);
            if (!sayiMi || sayi < 0 || sayi > int.MaxValue - 1)
            {
                Console.WriteLine("Girilen deger tam sayi degil veya sayi izin verilen aralik disinda girildi (0-{0})", int.MaxValue);
                return DakikaAdimMetot();
            }

            int dakikadaAdimSayisi = sayi;
            return dakikadaAdimSayisi;
        }


        private static int SaatveDakika()
        {
            Console.WriteLine();
            Console.WriteLine("Bu bolumde kac saat ve dakika kostugunuzu giriniz. \nIlk once saat daha sonra dakika bilgisini isteyecez.");
            Console.WriteLine();
            Console.Write("Saat'i giriniz: ");
            int saat;
            bool sayiMi = int.TryParse(Console.ReadLine(), out saat);
            if (!sayiMi || saat < 0 || saat > int.MaxValue - 1)
            {
                Console.WriteLine("Girilen deger tam sayi degil veya sayi izin verilen aralik disinda girildi (0-{0})", int.MaxValue);
                return SaatveDakika();
            }

            int saatBilgisi = saat;
            int dakika = DakikaAl();
            int toplamDakika = dakika + (saatBilgisi * 60);
            return toplamDakika;

        }

        private static int DakikaAl()
        {
            Console.WriteLine();
            Console.Write("Dakika'yi giriniz: ");
            int dakika;
            bool sayiMi = int.TryParse(Console.ReadLine(), out dakika);
            if (!sayiMi || dakika < 0 || dakika > int.MaxValue - 1)
            {
                Console.WriteLine("Girilen deger tam sayi degil veya sayi izin verilen aralik disinda girildi (0-{0})", int.MaxValue);
                return DakikaAl();
            }

            int dakikaBilgisi = dakika;
            return dakikaBilgisi;
        }


        private static double GunlukKosuMesafesi(byte ortalamaAdimCm, int dakikaAdim, int kosuSuresiDakika)
        {
            int dakikadaToplamCm = (int)(ortalamaAdimCm) * dakikaAdim;
            double toplamMesafeCm = dakikadaToplamCm * kosuSuresiDakika;

            double toplamMesafeMetre = toplamMesafeCm / 100.0;
            return toplamMesafeMetre;
        }
    }
}
