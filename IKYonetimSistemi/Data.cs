using System;
using System.Collections.Generic;
using System.Text;

namespace IKYonetimSistemi
{
    public class Data
    {
        public static KisilerAgaciListesi DataSet()
        {
            List<Egitimi> egitimListesi = new List<Egitimi>();
            List<IsDeneyimi> isDeneyimiListesi = new List<IsDeneyimi>();
            KisilerAgaciListesi list = new KisilerAgaciListesi();
            // ALİ KAYA
            KisiselBilgileri kisiselBilgileri = new KisiselBilgileri("Ali", "Kaya", "5321234567", "İstanbul", "09.03.1985", "ingilizce,fransızca,", "A2,B", "akaya@gmail.com");
            Egitimi egitimi = new Egitimi("Galatasaray Lisesi", "Lise", "Sayısal", "1999", "2003", "82");
            IsDeneyimi deneyim = new IsDeneyimi("Burger", "İstanbul", "Vardiya Müdürü", "2");
            isDeneyimiListesi.Add(deneyim);
            egitimListesi.Add(egitimi);
            isDeneyimiListesi = new List<IsDeneyimi> { deneyim };
            deneyim = new IsDeneyimi("Armada PC", "İstanbul", "Yazılım Uzmanı", "1");
            isDeneyimiListesi.Add(deneyim);
            deneyim = new IsDeneyimi("Comodo Yazılım","Ankara", "Front End Developer", "0.5");
            isDeneyimiListesi.Add(deneyim);
            deneyim = new IsDeneyimi("Destek Group", "İstanbul,Ankara", "Bilgisayar Mühendisi", "2");
            isDeneyimiListesi.Add(deneyim);
            deneyim = new IsDeneyimi("Otokar", "Kocaeli", "Network ve Güvenlik Mühendisi", "1.5");
            isDeneyimiListesi.Add(deneyim);
            deneyim = new IsDeneyimi("Vodafone", "İstanbul", "Mediation Solutions Senior Specialist ", "1.5");
            isDeneyimiListesi.Add(deneyim);
            egitimListesi = new List<Egitimi> { egitimi };
            egitimi = new Egitimi("Yıldız Teknik Üniversitesi", "Lisans", "Bilgisayar Müh", "2004", "2009", "80");
            egitimListesi.Add(egitimi);
            egitimi = new Egitimi("Yıldız Teknik Üniversitesi", "Yüksek Lisans", "Bilgisayar Müh", "2010", "2013", "95");
            egitimListesi.Add(egitimi);
            egitimi = new Egitimi("Boğaziçi Üni", "Doktora", "Bilgisayar Müh", "2013", "D", "e");
            egitimListesi.Add(egitimi);
            list.Add(PostAgac(kisiselBilgileri, isDeneyimiListesi, egitimListesi));
            //MEHMET SAĞLAM
            kisiselBilgileri = new KisiselBilgileri("Mehmet", "Sağlam", "5051234567", "Kocaeli", "09.03.1990", "", "B", "msaglam@hotmail.com");
            egitimi = new Egitimi("Isparta Anadolu Lisesi", "Lise", "Sayısal", "2005", "2009", "92");
            deneyim = new IsDeneyimi("", "", "", "");
            isDeneyimiListesi = new List<IsDeneyimi> { deneyim };
            egitimListesi = new List<Egitimi> { egitimi };
            egitimi = new Egitimi("Kocaeli Üniversitesi", "Lisans", "Bilgisayar Müh", "2010", "2015", "75");
            egitimListesi.Add(egitimi);
            list.Add(PostAgac(kisiselBilgileri, isDeneyimiListesi, egitimListesi));
            //ASLI YEL
            kisiselBilgileri = new KisiselBilgileri("Aslı", "Yel", "5421234567", "Trabzon", "09.03.1970", "İngilizce,", "", "ayel@yahoo.com");
            egitimi = new Egitimi("Of Kız Anadolu Lisesi", "Lise", "Sayısal", "1985", "1990", "79");
            deneyim = new IsDeneyimi("Türk Telekom", "Trabzon", "Mühendis", "10");
            isDeneyimiListesi = new List<IsDeneyimi> { deneyim };
            deneyim = new IsDeneyimi("Türk Telekom", "Ankara", "Müdür", "14");
            isDeneyimiListesi.Add(deneyim);
            egitimListesi = new List<Egitimi> { egitimi };
            egitimi = new Egitimi("ODTÜ ", "Lisans", "Elektrik- Elektronik Mühendisliği", "1992", "1996", "80");
            egitimListesi.Add(egitimi);
            list.Add(PostAgac(kisiselBilgileri, isDeneyimiListesi, egitimListesi));
            //NERİMAN KOÇ
            kisiselBilgileri = new KisiselBilgileri("Neriman", "Koç", "5331234567", "Ankara", "09.03.1988", "Almanca,", "E", "nkoca@ymail.com");
            egitimi = new Egitimi("Ankara Anadolu Lisesi", "Lise", "Sayısal", "2002", "2005", "90");
            deneyim = new IsDeneyimi("Ege Üni Elektronik Haberleşme", "İzmir", "Araştırma Görevlisi", "5");
            isDeneyimiListesi = new List<IsDeneyimi> { deneyim };
            egitimListesi = new List<Egitimi> { egitimi };
            egitimi = new Egitimi("Ege Üniversitesi", "Lisans", "Elektronik Haberleşme Müh", "2005", "2010", "70");
            egitimListesi.Add(egitimi);
            egitimi = new Egitimi("Ege Üniversitesi", "Yüksek Lisans", "Elektronik Haberleşme Müh", "2011", "D", "e");
            egitimListesi.Add(egitimi);
            list.Add(PostAgac(kisiselBilgileri, isDeneyimiListesi, egitimListesi));
            //AHMET SARI
            kisiselBilgileri = new KisiselBilgileri("Ahmet", "Sarı", "5071234567", "Manisa", "09.03.1989", "İngilizce, Almanca,İspanyolca,", "B", "asari@gmail.com");
            egitimi = new Egitimi("Manisa Lisesi", "Lise", "Sayısal", "2003", "2006", "70");
            deneyim = new IsDeneyimi("AG Software", "Konya", "Programcı", "2");
            isDeneyimiListesi = new List<IsDeneyimi> { deneyim };
            deneyim = new IsDeneyimi("Randstad Professionals", "Ankara", "Firmware Engineer", "2");
            isDeneyimiListesi.Add(deneyim);
            egitimListesi = new List<Egitimi> { egitimi };
            egitimi = new Egitimi("Yalvaç MYO", "Yüksek Okul", "Bilgisayar Programcılığı", "2006", "2008", "95");
            egitimListesi.Add(egitimi);
            egitimi = new Egitimi("Selçuk Üniversitesi", "Lisans", "Matematik Bilgisayar", "2009", "2012", "90");
            egitimListesi.Add(egitimi);
            egitimi = new Egitimi("Gazi Üniversitesi", "Lise", "Sayısal", "2012", "2015", "92");
            egitimListesi.Add(egitimi);
            list.Add(PostAgac(kisiselBilgileri, isDeneyimiListesi, egitimListesi));
            //SELİM MERT
            kisiselBilgileri = new KisiselBilgileri("Selim", "Mert", "506123456", "İstanbul", "09.03.1985", "", "B", "smert@gmail.com");
            egitimi = new Egitimi("Çorum Lisesi", "Lise", "Sayısal", "1999", "2002", "80");
            deneyim = new IsDeneyimi("KAREL", "İstanbul", "Gömülü Yazılım Mühendisi", "5");
            isDeneyimiListesi = new List<IsDeneyimi> { deneyim };
            egitimListesi = new List<Egitimi> { egitimi };
            egitimi = new Egitimi("Marmara Üniversitesi", "Lisans", "Elektronik Mühendisliği", "2004", "2010", "77");
            list.Add(PostAgac(kisiselBilgileri, isDeneyimiListesi, egitimListesi));
            return list;
        }
        static Agac PostAgac(KisiselBilgileri kisiselBilgileri, List<IsDeneyimi> isDeneyimi, List<Egitimi> egitimi)
        {
            Agac agac = new Agac(kisiselBilgileri, isDeneyimi, egitimi);
            return agac;
        }
    }
}
