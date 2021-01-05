using System;
using System.Collections.Generic;
using System.Text;

namespace IKYonetimSistemi 
{
    public class KisilerAgaciListesi
    {
        public Agac bas;
        public Agac son;
        //Liste uzunluğu
        public int Count()
        {
            int n = 0;
            Agac temp = bas;
            while (temp != null)
            {
                n++;
                temp = temp.sonraki;
            }
            return n;
        }
        //Listeye ağaç Ekleme(sona ekler)
        public void Add(Agac data)
        {
            Agac agac = data;
            if (bas == null)
            {
                bas = agac;
                son = agac;
                son.sonraki = null;
            }
            else
            {
                agac.onceki = son;
                son.sonraki = agac;
                son = agac;
                son.sonraki = null;
            }
        }
        //Listeyi Temizler
        public void Clear()
        {
            bas = null;
            son = null;
        }
        //Listedeki n.elemanını çağırır
        public Agac GetirAgac(int data)
        {
            Agac temp = bas;
            for (int i = 0; i < data; i++)
            {
                temp = temp.sonraki;
            }
            return temp;
        }
        public Agac this[int index] => GetirAgac(index);
        //Listedeki  istenilen ağacı siler(değer ile)
        public void RemoveAt(int order)
        {
            Agac temp = bas;
            int count = Count();
            if (count <= order)
            {
                //HATA
            }
            else
            {
                for (int i = 0; i < order; i++)
                {
                    temp = temp.sonraki;
                }
                if (temp == bas)
                {
                    if (bas == son)
                    {
                        bas = null;
                        son = null;
                    }
                    else
                    {
                        bas = bas.sonraki;
                        bas.onceki = null;
                    }
                }
                else if (temp == son)
                {
                    son = son.onceki;
                    bas.sonraki = null;
                }
                else
                {
                    temp.onceki.sonraki = temp.sonraki;
                    temp.sonraki.onceki = temp.onceki;

                }
            }
        }
    }
    public class Dugum
    {
        public string data;
        public Dugum(string data)
        {
            this.data = data;
        }
    }
    public class KisiselBilgileri
    {
        public Dugum ad, soyAd, telefon, adres, dogumTarihi, yabanciDil, ehliyet, ePosta;
        public void Ad(string ad)
        {
            Dugum dugum = new Dugum(ad);
            this.ad = dugum;
        }
        public void SoyAd(string soyAd)
        {
            Dugum dugum = new Dugum(soyAd);
            this.soyAd = dugum;
        }
        
        public void Telefon(string telefon)
        {
            Dugum dugum = new Dugum(telefon);
            this.telefon = dugum;
        }
        public void Adres(string adres)
        {
            Dugum dugum = new Dugum(adres);
            this.adres = dugum;
        }
        public void DogumTarihi(string dogumTarihi)
        {
            Dugum dugum = new Dugum(dogumTarihi);
            this.dogumTarihi = dugum;
        }
        public void YabanciDil(string yabanciDil)
        {
            Dugum dugum = new Dugum(yabanciDil);
            this.yabanciDil = dugum;
        }
        public void Ehliyet(string ehliyet)
        {
            Dugum dugum = new Dugum(ehliyet);
            this.ehliyet = dugum;
        }
        public void EPosta(string ePosta)
        {
            Dugum dugum = new Dugum(ePosta);
            this.ePosta = dugum;
        }
        public KisiselBilgileri(string ad, string soyAd, string telefon,  string adres, string dogumTarihi, string yabanciDil, string ehliyet,string ePosta)
        {
            Dugum dugum = new Dugum(ad);
            this.ad = dugum;
            dugum = new Dugum(soyAd);
            this.soyAd = dugum;
            dugum = new Dugum(telefon);
            this.telefon = dugum;
            dugum = new Dugum(adres);
            this.adres = dugum;
            dugum = new Dugum(dogumTarihi);
            this.dogumTarihi = dugum;
            dugum = new Dugum(yabanciDil);
            this.yabanciDil = dugum;
            dugum = new Dugum(ehliyet);
            this.ehliyet = dugum;
            dugum = new Dugum(ePosta);
            this.ePosta = dugum;
        }
        public KisiselBilgileri() { }
    }

    public class IsDeneyimi
    {
        public Dugum ad, adres, pozisyon, istec;
        public void Ad(string ad)
        {
            Dugum dugum = new Dugum(ad);
            this.ad = dugum;
        }
        public void Adres(string adres)
        {
            Dugum dugum = new Dugum(adres);
            this.adres = dugum;
        }
        public void Pozisyon(string pozisyon)
        {
            Dugum dugum = new Dugum(pozisyon);
            this.pozisyon = dugum;
        }
        public void Istecrübesi(string istec)
        {
            Dugum dugum = new Dugum(istec);
            this.istec = dugum;
        }
       
        public IsDeneyimi(string ad, string adres, string pozisyon, string istec)
        {
            Dugum dugum = new Dugum(ad);
            this.ad = dugum;
            dugum = new Dugum(adres);
            this.adres = dugum;
            dugum = new Dugum(pozisyon);
            this.pozisyon = dugum;
            dugum = new Dugum(istec);
            this.istec= dugum;

        }
        public IsDeneyimi() { }
    }
    public class Egitimi
    {
        public Dugum  okulAdi,durum, bolum, baslangicTarihi, bitisTarihi, notOrtalamasi;
        public void Durum(string ad)
        {
            Dugum dugum = new Dugum(ad);
            this.durum = dugum;
        }
        public void OkulAdi(string okulAdi)
        {
            Dugum dugum = new Dugum(okulAdi);
            this.okulAdi = dugum;
        }
        public void Bolum(string bolum)
        {
            Dugum dugum = new Dugum(bolum);
            this.bolum = dugum;
        }
        public void BaslangicTarihi(string baslangicTarihi)
        {
            Dugum dugum = new Dugum(baslangicTarihi);
            this.baslangicTarihi = dugum;
        }
        public void BitisTarihi(string bitisTarihi)
        {
            Dugum dugum = new Dugum(bitisTarihi);
            this.bitisTarihi = dugum;
        }
        public void NotOrtalamasi(string notOrtalamasi)
        {
            Dugum dugum = new Dugum(notOrtalamasi);
            this.notOrtalamasi = dugum;
        }
        public Egitimi(string okulAdi, string durum, string bolum, string baslangicTarihi, string bitisTarihi, string notOrtalamasi)
        {
            Dugum dugum = new Dugum(durum);
            this.durum = dugum;
            dugum = new Dugum(okulAdi);
            this.okulAdi = dugum;
            dugum = new Dugum(bolum);
            this.bolum = dugum;
            dugum = new Dugum(baslangicTarihi);
            this.baslangicTarihi = dugum;
            dugum = new Dugum(bitisTarihi);
            this.bitisTarihi = dugum;
            dugum = new Dugum(notOrtalamasi);
            this.notOrtalamasi = dugum;
        }
        public Egitimi() { }
    }
    public class Agac
    {
        public KisiselBilgileri kisiselBilgileri;
        public List<IsDeneyimi> isDeneyimi;
        public List<Egitimi> egitimi;
        public Agac onceki;
        public Agac sonraki;
        public Agac(KisiselBilgileri kisiselBilgileri, List<IsDeneyimi> isDeneyimi, List<Egitimi> egitimi)
        {
            this.kisiselBilgileri = kisiselBilgileri;
            this.isDeneyimi = isDeneyimi;
            this.egitimi = egitimi;
        }
    }
}
