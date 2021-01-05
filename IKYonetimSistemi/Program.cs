using System;
using System.Collections.Generic;
using System.IO;

namespace IKYonetimSistemi
{
    public class Program
    {
        static MenuType Menu()
        {
            Console.WriteLine("0: İş Arayan\n1: İşVeren");
            string type;
        Devam:
            type = Console.ReadLine();
            if (type != "0" && type != "1")
            {
                Console.WriteLine("Yanlış tuşlama.");
                goto Devam;
            }
            return (MenuType)Convert.ToInt32(type);
        }
        static string IsArayanMenu()
        {
            Console.WriteLine("0: Kişi Listeleme\n1: Sisteme Kayıt\n2: Sistemden Çıkma\n3: Sistemdeki Bilgileri Güncelle\n4: Sistemde Bilgileri Görüntüle\n5: Menüye Dön");
            string type;
        Devam:
            type = Console.ReadLine();
            if (type != "0" && type != "1" && type != "2" && type != "3" && type != "4" && type != "5")
            {
                Console.WriteLine("Yanlış tuşlama.");
                goto Devam;
            }
            return type;
        }
        static string IsVeren()
        {
            Console.WriteLine("0: Kişilerin Adlarını Düzeyleri ile Listeleme\n1: Tüm Kişileri Listele\n2: Kişi Ara\n3: Lisans Mezunu Ara\n4: İngilizce Bilen Kişileri Ara\n5: Birden Fazla Dil Bilenleri Ara\n6: 5 yıl Deneyimlileri Listele\n7:Deneyimsizleri Listele\n8: Yaş Değeri Altındaki Kişileri Listele\n9:Ehliyeti Olanları Listele\n10:Çoklu Filtreleme\n11:Menüye Dön");
            string type;
        Devam:
            type = Console.ReadLine();
            if (type != "0" && type != "1" && type != "2" && type != "3" && type != "4" && type != "5" && type != "6" && type != "7" && type != "8" && type != "9" && type != "10" && type != "11")
            {
                Console.WriteLine("Yanlış tuşlama.");
                goto Devam;
            }
            return type;
        }
        enum MenuType
        {
            IsArayan = 0,
            IsVeren = 1
        }
        static void Main(string[] args)
        {
            KisilerAgaciListesi liste = Data.DataSet();
            int i = 0;
            while (i == 0)
            {
            Menu:
                MenuType type = Menu();
                if (type == MenuType.IsArayan)
                {
                    var result = IsArayanMenu();
                    switch (result)
                    {
                        case "0":
                            {
                                Listele(liste);
                                break;
                            }
                        case "1":
                            {
                                liste.Add(AgacInput());
                                break;
                            }
                        case "2":
                            {
                                Listele(liste);
                                Console.WriteLine("Numaranızı Yazınız");
                                liste.RemoveAt(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                        case "3":
                            {
                                Listele(liste);
                                Console.Write("Numaranızı Yazınız");
                                int index = Convert.ToInt32(Console.ReadLine());
                                var agac = liste[index];
                                bool boolean = true;
                                while (boolean)
                                {
                                    GetAgac(agac);
                                Geri:
                                    Console.WriteLine("Güncellemek İstediğiniz Bilgiyi Seçiniz\n1.Kişisel Bilgiler\n2.EğitimBilgileri\n3.İş Deneyimleri4.Anamenü");
                                    string bilgiMenu = Console.ReadLine();
                                    if (bilgiMenu == "1")
                                    {
                                        Console.WriteLine("Seçiniz\n1.Adı\n2.Soyadı\n3.Adresi\n4.Telno\n5.Eposta\n6.Doğum Tarihi\n7.Ehliyet\n8.YabancıDil\n9.Geri");
                                        string kisiMenu = Console.ReadLine();
                                        switch (kisiMenu)
                                        {
                                            case "1": agac.kisiselBilgileri.Ad(Console.ReadLine()); break;
                                            case "2": agac.kisiselBilgileri.SoyAd(Console.ReadLine()); break;
                                            case "3": agac.kisiselBilgileri.Adres(Console.ReadLine()); break;
                                            case "4": agac.kisiselBilgileri.Telefon(Console.ReadLine()); break;
                                            case "5": agac.kisiselBilgileri.EPosta(Console.ReadLine()); break;
                                            case "6": agac.kisiselBilgileri.DogumTarihi(Console.ReadLine()); break;
                                            case "7": agac.kisiselBilgileri.Ehliyet(Console.ReadLine()); break;
                                            case "8": agac.kisiselBilgileri.YabanciDil(Console.ReadLine()); break;
                                            case "9": goto Geri;
                                        }
                                        liste[index].kisiselBilgileri = agac.kisiselBilgileri;
                                    }
                                    else if (bilgiMenu == "2")
                                    {
                                        Console.WriteLine("Seçiniz\n1. Durum\n2. Okul Adı\n3. Bölüm\n4. Başlangıç Tarihi\n5. Bitiş Tarihi\n6.Not Ortalaması\n7.Geri");
                                        string egitimMenu = Console.ReadLine();
                                        Egitimi egitimi = new Egitimi();
                                        switch (egitimMenu)
                                        {
                                            case "1": egitimi.Durum(Console.ReadLine()); break;
                                            case "2": egitimi.OkulAdi(Console.ReadLine()); break;
                                            case "3": egitimi.Bolum(Console.ReadLine()); break;
                                            case "4": egitimi.BaslangicTarihi(Console.ReadLine()); break;
                                            case "5": egitimi.BitisTarihi(Console.ReadLine()); break;
                                            case "6": egitimi.NotOrtalamasi(Console.ReadLine()); break;
                                            case "7": goto Geri;
                                        }
                                        agac.egitimi.Add(egitimi);
                                        liste[index].egitimi = agac.egitimi;
                                    }
                                    else if (bilgiMenu == "3")
                                    {
                                        Console.WriteLine("Seçiniz\n1.İşYeri Adı\n2.Adresi\n3.Pozisyon\n4.Başlangıç Süresi\n5.Bitiş Süresi\n6.Geri");
                                        string isMenu = Console.ReadLine();
                                        IsDeneyimi isDeneyimi = new IsDeneyimi();
                                        switch (isMenu)
                                        {
                                            case "1": isDeneyimi.Ad(Console.ReadLine()); break;
                                            case "2": isDeneyimi.Adres(Console.ReadLine()); break;
                                            case "3": isDeneyimi.Pozisyon(Console.ReadLine()); break;
                                            case "4": isDeneyimi.Istecrübesi(Console.ReadLine()); break;
                                            case "5": goto Geri;
                                        }
                                        agac.isDeneyimi.Add(isDeneyimi);
                                        liste[index].isDeneyimi = agac.isDeneyimi;
                                    }
                                    else if (bilgiMenu == "4")
                                    {
                                        goto Menu;
                                    }
                                }
                                break;
                            }
                        case "4":
                            {
                                Listele(liste);
                                Console.Write("Numaranızı Yazınız");
                                int index = Convert.ToInt32(Console.ReadLine());
                                var agac = liste[index];
                                GetAgac(agac);
                                break;
                            }
                        case "5":
                            {
                                goto Menu;
                            }
                    }
                }
                else
                {
                    var result = IsVeren();
                    switch (result)
                    {
                        case ("1"):
                            {
                                Listele(liste);
                                break;
                            }
                        case ("2"):
                            {
                                Console.Write("Kişi Adı Giriniz:");
                                GetAgac(liste, Console.ReadLine());
                                break;
                            }
                        case ("3"): GetLisans(liste); break;
                        case ("4"): GetIngilizce(liste); break;
                        case ("5"): GetBirdenFazlaDil(liste); break;
                        case ("6"): GetDeneyimli(liste); break;
                        case ("7"): GetDeneyimsiz(liste); break;
                        case ("8"):
                            {
                                Console.Write("Girilecek Maksimum Yaş Değerini Yazınız:");
                            YasTekrarDene:
                                try
                                {
                                    GetMaxYas(liste, Convert.ToInt16(Console.ReadLine()));
                                }
                                catch
                                {
                                    goto YasTekrarDene;
                                }
                                break;
                            }
                        case ("9"): GetEhliyetiOlanlar(liste); break;
                        case ("10"): GetCokluFiltreleme(liste); break;
                        case ("11"):
                            {
                                goto Menu;
                            }
                    }
                }
            }
        }
        static Agac PostAgac(KisiselBilgileri kisiselBilgileri, List<IsDeneyimi> isDeneyimi, List<Egitimi> egitimi)
        {
            Agac agac = new Agac(kisiselBilgileri, isDeneyimi, egitimi);
            return agac;
        }
        static void GetAgac(Agac liste)
        {
            var kisiselBilgiler = liste.kisiselBilgileri;
            var egitimBilgileri = liste.egitimi;
            var isDeneyimi = liste.isDeneyimi;
            Console.WriteLine(kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data + " |");
            foreach (var item in egitimBilgileri)
            {
                Console.WriteLine(item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
            }
            foreach (var item in isDeneyimi)
            {

                Console.WriteLine(item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
            }
        }
        static void GetAgac(KisilerAgaciListesi liste, string ad)
        {
            string FileName = @"Ad.txt";
            StreamWriter FileWrite = File.AppendText(FileName);
            for (int i = 0; i < liste.Count(); i++)
            {
                if (liste[i].kisiselBilgileri.ad.data == ad)
                {
                    var kisiselBilgiler = liste[i].kisiselBilgileri;
                    var egitimBilgileri = liste[i].egitimi;
                    var isDeneyimi = liste[i].isDeneyimi;
                    var value = kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data;
                    foreach (var item in egitimBilgileri)
                    {
                        value = value + (item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                    }
                    foreach (var item in isDeneyimi)
                    {
                        value = value + (item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
                    }
                    Console.WriteLine(value);
                    FileWrite.WriteLine(value);
                    FileWrite.Close();
                }
                else if (i == liste.Count() - 1)
                {
                    Console.WriteLine(ad + "isimli aday sistemde kayıtlı değil.");
                }
            }
        }
        static void GetLisans(KisilerAgaciListesi liste)
        {
            string FileName = "Lisans.txt";
            StreamWriter FileWrite = File.AppendText(FileName);
            for (int i = 0; i < liste.Count(); i++)
            {
                foreach (var itemEgitim in liste[i].egitimi)
                {
                    if (itemEgitim.durum.data == "Lisans" || itemEgitim.durum.data == "lisans")
                    {
                        var kisiselBilgiler = liste[i].kisiselBilgileri;
                        var egitimBilgileri = liste[i].egitimi;
                        var isDeneyimi = liste[i].isDeneyimi;
                        var value = kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data;
                        foreach (var item in egitimBilgileri)
                        {
                            value = value + (item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                        }
                        foreach (var item in isDeneyimi)
                        {
                            value = value + (item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
                        }
                        Console.WriteLine(value);
                        FileWrite.WriteLine(value);

                    }
                    else if (i == liste.Count() - 1)
                    {
                        Console.WriteLine("Eğitimi Lisans derecesi olan aday yok.");
                    }
                }
            }
            FileWrite.Close();
        }
        static void GetIngilizce(KisilerAgaciListesi liste)
        {
            for (int i = 0; i < liste.Count(); i++)
            {
                var data = liste[i].kisiselBilgileri.yabanciDil.data;
                string yabanciDil = "";
                foreach (var itemChar in data)
                {
                    if (itemChar != ',')
                    {
                        yabanciDil = yabanciDil + itemChar;
                    }
                    else
                    {
                        if (yabanciDil == "İngilizce" || yabanciDil == "ingilizce")
                        {
                            string FileName = "Ingilizce.txt";
                            StreamWriter FileWrite = File.AppendText(FileName);
                            var kisiselBilgiler = liste[i].kisiselBilgileri;
                            var egitimBilgileri = liste[i].egitimi;
                            var isDeneyimi = liste[i].isDeneyimi;
                            var value = kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data;
                            foreach (var item in egitimBilgileri)
                            {
                                value = value + (item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                            }
                            foreach (var item in isDeneyimi)
                            {
                                value = value + (item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
                            }
                            Console.WriteLine(value);
                            FileWrite.WriteLine(value);
                            FileWrite.Close();
                        }
                        yabanciDil = "";
                    }
                }
            }
        }
        static void GetBirdenFazlaDil(KisilerAgaciListesi liste)
        {
            string FileName = "BirdenFazlaDil.txt";
            StreamWriter FileWrite = File.AppendText(FileName);
            for (int i = 0; i < liste.Count(); i++)
            {
                var data = liste[i].kisiselBilgileri.yabanciDil.data;
                int adet = 0;
                foreach (var itemChar in data)
                {
                    if (itemChar == ',')
                    {
                        adet++;
                    }
                    if (adet > 1)
                    {
                        var kisiselBilgiler = liste[i].kisiselBilgileri;
                        var egitimBilgileri = liste[i].egitimi;
                        var isDeneyimi = liste[i].isDeneyimi;
                        var value = kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data;
                        foreach (var item in egitimBilgileri)
                        {
                            value = value + (item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                        }
                        foreach (var item in isDeneyimi)
                        {
                            value = value + (item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
                        }
                        Console.WriteLine(value);
                        FileWrite.WriteLine(value);
                        break;
                    }
                }
            }
            FileWrite.Close();
        }
        static void GetDeneyimli(KisilerAgaciListesi liste)
        {
            string FileName = "Deneyimli.txt";
            StreamWriter FileWrite = File.AppendText(FileName);
            for (int i = 0; i < liste.Count(); i++)
            {
                var data = liste[i].isDeneyimi;
                if (data != null)
                {
                    foreach (var itemDeneyim in data)
                    {
                        if (itemDeneyim.istec.data != "")
                        {
                            if ((Convert.ToDouble(itemDeneyim.istec.data)) >= 5.0)
                            {
                                var kisiselBilgiler = liste[i].kisiselBilgileri;
                                var egitimBilgileri = liste[i].egitimi;
                                var isDeneyimi = liste[i].isDeneyimi;
                                var value = kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data;
                                foreach (var item in egitimBilgileri)
                                {
                                    value = value + (item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                                }
                                foreach (var item in isDeneyimi)
                                {

                                    value = value + (item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
                                }
                                Console.WriteLine(value);
                                FileWrite.WriteLine(value);
                            }
                        }
                    }
                }
            }
            FileWrite.Close();
        }
        static void GetDeneyimsiz(KisilerAgaciListesi liste)
        {
            string FileName = "Deneyimsiz.txt";
            StreamWriter FileWrite = File.AppendText(FileName);
            for (int i = 0; i < liste.Count(); i++)
            {
                var data = liste[i].isDeneyimi;
                if (data[0].ad.data == "" && data[0].adres.data == "" && data[0].istec.data == "" && data[0].pozisyon.data == "" || data == null)
                {
                    var kisiselBilgiler = liste[i].kisiselBilgileri;
                    var egitimBilgileri = liste[i].egitimi;
                    var isDeneyimi = liste[i].isDeneyimi;
                    var value = kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data;
                    foreach (var item in egitimBilgileri)
                    {
                        value = value + (item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                    }
                    Console.WriteLine(value);
                    FileWrite.WriteLine(value);
                }
            }
            FileWrite.Close();

        }
        static void GetMaxYas(KisilerAgaciListesi liste, int index)
        {
            for (int i = 0; i < liste.Count(); i++)
            {
                string FileName = "MaxYas.txt";
                StreamWriter FileWrite = File.AppendText(FileName);
                var data = liste[i].kisiselBilgileri.dogumTarihi.data;
                DateTime dogumTarihi;
                try
                {
                    dogumTarihi = Convert.ToDateTime(data);
                }
                catch
                {
                    dogumTarihi = DateTime.Parse(data);
                }
                DateTime bugun = DateTime.Now;
                int yas = bugun.Year - dogumTarihi.Year;
                if (index > yas)
                {
                    var kisiselBilgiler = liste[i].kisiselBilgileri;
                    var egitimBilgileri = liste[i].egitimi;
                    var isDeneyimi = liste[i].isDeneyimi;
                    var value = kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data;
                    foreach (var item in egitimBilgileri)
                    {
                        value = value + (item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                    }
                    foreach (var item in isDeneyimi)
                    {
                        value = value + (item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
                    }
                    Console.WriteLine(value);
                    FileWrite.WriteLine(value);
                    FileWrite.Close();
                }
            }
        }
        static void GetEhliyetiOlanlar(KisilerAgaciListesi liste)
        {
            string FileName = "EhliyetiOlanlar.txt";
            StreamWriter FileWrite = File.AppendText(FileName);
            for (int i = 0; i < liste.Count(); i++)
            {
                var data = liste[i].kisiselBilgileri.ehliyet.data;

                if (data != null)
                {
                    var kisiselBilgiler = liste[i].kisiselBilgileri;
                    var egitimBilgileri = liste[i].egitimi;
                    var isDeneyimi = liste[i].isDeneyimi;
                    var value = kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data;
                    foreach (var item in egitimBilgileri)
                    {
                        value = value + (item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                    }
                    foreach (var item in isDeneyimi)
                    {
                        value = value + (item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
                    }
                    Console.WriteLine(value);
                    FileWrite.WriteLine(value);


                }
            }
            FileWrite.Close();
        }

        static void GetCokluFiltreleme(KisilerAgaciListesi liste)
        {
            string FileName = "CokluFiltreleme.txt";
            StreamWriter FileWrite = File.AppendText(FileName);
            Console.Write("Adı(Boş Geçmek için 0'a basınız):");
            string ad = Console.ReadLine();
            Console.Write("Lisans Mezunu Ara?(e/h)");
            string lisans = Console.ReadLine();
            Console.Write("Deneyimli Kişileri Ara?(e/h)");
            string deneyimli = Console.ReadLine();
            Console.Write("Yaş Sınırı Giriniz(Boş Geçmek için 0'a basınız):");
            int yas = Convert.ToInt16(Console.ReadLine());
            Console.Write("Ehliyeti Olanları Ara?(e/h)");
            string ehliyet = Console.ReadLine();
            if (ad != "0")
            {
                KisilerAgaciListesi listeFilt = new KisilerAgaciListesi();
                for (int i = 0; i < liste.Count(); i++)
                {
                    if (liste[i].kisiselBilgileri.ad.data == ad)
                    {
                        listeFilt.Add(liste[i]);
                    }
                }
                liste = listeFilt;
            }
            if (lisans == "e")
            {
                KisilerAgaciListesi listeFilt = new KisilerAgaciListesi();
                for (int i = 0; i < liste.Count(); i++)
                {
                    foreach (var item in liste[i].egitimi)
                    {
                        if (item.durum.data == "Lisans")
                        {
                            listeFilt.Add(liste[i]);
                        }
                    }
                }
                liste = listeFilt;
            }
            if (deneyimli == "e")
            {
                KisilerAgaciListesi listeFilt = new KisilerAgaciListesi();
                for (int i = 0; i < liste.Count(); i++)
                {
                    if (liste[i].isDeneyimi != null)
                    {
                        listeFilt.Add(liste[i]);
                    }
                }
                liste = listeFilt;
            }
            if (yas != 0)
            {
                KisilerAgaciListesi listeFilt = new KisilerAgaciListesi();
                for (int i = 0; i < liste.Count(); i++)
                {
                    if (yas > Convert.ToInt16(liste[i].kisiselBilgileri.telefon.data))
                    {
                        listeFilt.Add(liste[i]);
                    }
                }
                liste = listeFilt;
            }
            if (ehliyet == "e")
            {
                KisilerAgaciListesi listeFilt = new KisilerAgaciListesi();
                for (int i = 0; i < liste.Count(); i++)
                {
                    if (liste[i].kisiselBilgileri.ehliyet != null)
                    {
                        listeFilt.Add(liste[i]);
                    }
                }
                liste = listeFilt;
            }
            for (int i = 0; i < liste.Count(); i++)
            {
                var kisiselBilgiler = liste[i].kisiselBilgileri;
                var egitimBilgileri = liste[i].egitimi;
                var isDeneyimi = liste[i].isDeneyimi;
                var value = kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data;
                foreach (var item in egitimBilgileri)
                {
                    value = value + (item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                }
                foreach (var item in isDeneyimi)
                {
                    value = value + (item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
                }
                Console.WriteLine(value);
                FileWrite.WriteLine(value);
            }
            FileWrite.Close();
        }
        static void Listele(KisilerAgaciListesi liste)
        {
            for (int i = 0; i < liste.Count(); i++)
            {
                var kisiselBilgiler = liste.GetirAgac(i).kisiselBilgileri;
                var egitimBilgileri = liste.GetirAgac(i).egitimi;
                var isDeneyimi = liste.GetirAgac(i).isDeneyimi;
                Console.WriteLine(i + " |" + kisiselBilgiler.ad.data + " |" + kisiselBilgiler.soyAd.data + " |" + kisiselBilgiler.telefon.data + " |" + kisiselBilgiler.yabanciDil.data + " |" + kisiselBilgiler.adres.data + " |" + kisiselBilgiler.dogumTarihi.data + " |" + kisiselBilgiler.ehliyet.data + " |" + kisiselBilgiler.ePosta.data + " |");
                foreach (var item in egitimBilgileri)
                {
                    Console.WriteLine(item.okulAdi.data + " |" + item.durum.data + " |" + item.bolum.data + " |" + item.baslangicTarihi.data + " |" + item.bitisTarihi.data + "|" + item.notOrtalamasi.data + "|");
                }
                foreach (var item in isDeneyimi)
                {
                    Console.WriteLine(item.ad.data + " |" + item.adres.data + " |" + item.istec.data + " |" + item.pozisyon.data);
                }

            }
        }
        static Agac AgacInput()
        {
            KisiselBilgileri kisiselBilgileri = new KisiselBilgileri();
            Console.WriteLine("Kişisel Bilgiler");
            Console.Write("Ad:");
            kisiselBilgileri.Ad(Console.ReadLine());
            Console.Write("Soyad:");
            kisiselBilgileri.SoyAd(Console.ReadLine());
            Console.Write("Adres:");
            kisiselBilgileri.Adres(Console.ReadLine());
            Console.Write("Telefon:");
            kisiselBilgileri.Telefon(Console.ReadLine());
            Console.Write("Eposta:");
            kisiselBilgileri.EPosta(Console.ReadLine());
            Console.Write("Doğum Tarihi:");
            kisiselBilgileri.DogumTarihi(Console.ReadLine());
            Console.Write("Yabancı Dil:");
            kisiselBilgileri.YabanciDil(Console.ReadLine());
            Console.Write("Ehliyet:");
            kisiselBilgileri.Ehliyet(Console.ReadLine());

            List<Egitimi> egitimList = new List<Egitimi>();
            Egitimi egitimi = new Egitimi();
            Console.WriteLine("Eğitim Bilgiler");
            Console.Write("Durum:");
            egitimi.Durum(Console.ReadLine());
            Console.Write("Okul Adı:");
            egitimi.OkulAdi(Console.ReadLine());
            Console.Write("Bölüm:");
            egitimi.Bolum(Console.ReadLine());
            Console.Write("Başlangıç Tarihi :");
            egitimi.BaslangicTarihi(Console.ReadLine());
            Console.Write("Bitiş Tarihi:");
            egitimi.BitisTarihi(Console.ReadLine());
            Console.Write("Not Ortalaması:");
            egitimi.NotOrtalamasi(Console.ReadLine());
            egitimList.Add(egitimi);

            List<IsDeneyimi> deneyimList = new List<IsDeneyimi>();
            IsDeneyimi isDeneyimi = new IsDeneyimi();
            Console.WriteLine("İş Deneyimi");
            Console.Write("İşyeri Adı :");
            isDeneyimi.Ad(Console.ReadLine());
            Console.Write("Adresi :");
            isDeneyimi.Adres(Console.ReadLine());
            Console.Write("Pozisyonu :");
            isDeneyimi.Pozisyon(Console.ReadLine());
            Console.Write("İş Tecrübesi:");
            isDeneyimi.Istecrübesi(Console.ReadLine());
            deneyimList.Add(isDeneyimi);
            return PostAgac(kisiselBilgileri, deneyimList, egitimList);
        }
    }
}