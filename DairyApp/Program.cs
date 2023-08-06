using System;

namespace DairyApp
{
    class Program
    {
        static string EskiKayitlardanOku(int DateTime)
        {
            return $"{DateTime}";
        }

        static string TumKayitlariListele(string bilgiMesaji)
        {
            Console.Write(bilgiMesaji);
            return Console.ReadLine();
        }
        static void MenuGoster()
        {
            Console.WriteLine("********************MENÜ********************");
            Console.WriteLine("1.Seçenek: Menü için 1");
            Console.WriteLine("2.Seçenek: Günlüğe devam etmek için 2");
            Console.WriteLine("3.Seçenek: Çıkış yapmak için 3'e bas.");
            Console.WriteLine("********************************************");
        }

        static void DevamEt()
        {
            string metin = Console.ReadLine();
        }

        static void CikisYap()
        {
            bool cikis=false;
        }
        //static void YeniSatirEkle()
        //{
        //    Console.WriteLine("Enter tuşuna basın (Çıkmak için 'q' tuşuna basın)");
        //    string input = string.Empty;
        //}
        static string SinirliMetinOlustur(string metin, int maksimumKelimeSayisi)
        {
            string[] kelimeler=metin.Split(' ');

            if(kelimeler.Length <=maksimumKelimeSayisi)
            {
                return metin;
            }
            else
            {
                string sinirliMetin=string.Join(" ", kelimeler,0,maksimumKelimeSayisi);
                return sinirliMetin + " ... ";
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            string name = "Bgm35";
            string sifre = "999";
            Console.Write("Lütfen kullanıcı adını ve şifreni gir:");
            //Console.WriteLine("");
            //Console.Write("Kullanıcı Adın: ");
            //Console.ReadLine();
            //Console.Write("Şifren: ");
            //Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Kullanıcı adın: ");
            string inputname = Console.ReadLine();

            Console.Write("Şifren: ");
            string inputsifre = Console.ReadLine();

            if (inputname == name && inputsifre == sifre)
            {
                Console.WriteLine("Hoşgeldin Bgm35");
            }
            else
            {
                Console.WriteLine("Bilgiler hatalı");
            }

            string inputDateTime = TumKayitlariListele("Kayıtlarınız: ");
            DateTime bugununTarihi = DateTime.Today;
            Console.WriteLine(bugununTarihi);


            //List<string> eskiKayitlar = new List<string>();
            //List<string> yeniKayitlar = new List<string>();
           

            //günlük dosyasının yolunu ve adını yazdık.
            string dosyaYolu = "günlük.txt";

            Console.WriteLine("Bugünün günlüğüne hoşgeldin!!!");

            //Kullanıcıdan kendisi kaç kelime yazmak istiyorsa onu yazmasını istiyoruz.
            string metin = Console.ReadLine();
            Console.WriteLine("Bugün kaç kelime yazmak istersin?: ");
            int maksimumKelimeSayisi = Convert.ToInt32(Console.ReadLine());

            //Kullanıcıdan günlük girişini aldık.
            Console.WriteLine("Bugün neler yaptığını benimle paylaş :)");
            string gunlukGirisi = Console.ReadLine();


            //Main methodunun içerisinde kelime sınırlaması için başka bir method oluşturuyoruz.
            string sinirliMetin = SinirliMetinOlustur(metin, maksimumKelimeSayisi);
            //Console.WriteLine("Sınırlı Metin: ");
            Console.WriteLine(sinirliMetin);

            //Günlük girşini dosyaya kaydetme
            try
            {
                //Günlük dosyasını da bu şekilde açtık ve oluşturduk.
                using (StreamWriter dosya = File.AppendText(dosyaYolu))
                {
                    dosya.WriteLine(DateTime.Now.ToString());
                    dosya.WriteLine(gunlukGirisi);
                    dosya.WriteLine();
                }
     
                Console.WriteLine("Günlüğün başarılı bir şekilde kaydedildi.");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Günlüğün kaydedilirken bir hata oluştu: ");
            }
            bool cikis = false;

            while (!cikis)
            {
                Console.WriteLine("********************MENÜ********************");
                Console.WriteLine("1.Seçenek: Menü için 1");
                Console.WriteLine("2.Seçenek: Günlüğe devam etmek için 2");
                Console.WriteLine("3.Seçenek: Çıkış yapmak için 3'e bas.");
                Console.WriteLine("********************************************");

                Console.Write("Seçimini bekliyorum:)):");
                string secim = Console.ReadLine();

                if(secim=="1")
                {
                    Console.WriteLine("Seçenek 1 seçildi.");
                    MenuGoster();
                    //List<string> eskiKayitlar = new List<string>();
                    //List<string> yeniKayitlar = new List<string>();

                }
                else if(secim=="2")
                {
                    Console.WriteLine("Seçenek 2 seçildi.");
                    DevamEt();

                    using (StreamWriter dosya = File.AppendText(dosyaYolu))
                    {
                        dosya.WriteLine(DateTime.Now.ToString());
                        dosya.WriteLine(gunlukGirisi);
                        dosya.WriteLine();
                    }

                    Console.WriteLine("Günlüğün başarılı bir şekilde kaydedildi.");
                }
                else if(secim=="3")
                {
                    cikis=true;
                    CikisYap();
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim.Lütfen tekrar dene:(");
                }
                Console.WriteLine();
                Console.ReadKey();
            }
            }
        }
    }
