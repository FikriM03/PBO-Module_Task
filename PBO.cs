using System;
using System.Collections.Generic;

class Item
{
    public string judul { get; set; }
    public int tahun { get; set; }

    public Item(string judul, int tahun)
    {
        this.judul = judul;
        this.tahun = tahun;
    }

    public virtual void Deskripsi()
    {
        Console.WriteLine($"[Item] Judul: {judul}, Tahun: {tahun}");
    }

    public void InfoItem()
    {
        Console.WriteLine($"Judul: {judul} | Tahun: {tahun}");
    }
}

class Buku : Item
{
    public string penulis { get; set; }

    public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
    {
        this.penulis = penulis;
    }

    public void CekPenulis()
    {
        Console.WriteLine($"Penulis buku '{judul}' adalah: {penulis}");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"[Buku] Judul: {judul}, Tahun: {tahun}, Penulis: {penulis}");
    }
}

class Majalah : Item
{
    public int edisi { get; set; }

    public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
    {
        this.edisi = edisi;
    }

    public void InfoEdisi()
    {
        Console.WriteLine($"Majalah '{judul}' - Edisi: {edisi}");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"[Majalah] Judul: {judul}, Tahun: {tahun}, Edisi: {edisi}");
    }
}

class Novel : Buku
{
    public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis)
    {
    }

    public void BacaSinopsis()
    {
        Console.WriteLine($"Membaca sinopsis novel '{judul}' karya {penulis}...");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"[Novel] Judul: {judul}, Tahun: {tahun}, Penulis: {penulis}");
    }
}

class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis)
    {
    }

    public void TampilkanIlustrasi()
    {
        Console.WriteLine($"Menampilkan ilustrasi komik '{judul}'...");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"[Komik] Judul: {judul}, Tahun: {tahun}, Penulis: {penulis}");
    }
}

class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi)
    {
    }

    public void KategoriAnak()
    {
        Console.WriteLine($"'{judul}' adalah majalah untuk anak-anak (Edisi {edisi}).");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"[MajalahAnak] Judul: {judul}, Tahun: {tahun}, Edisi: {edisi}");
    }
}

class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi)
    {
    }

    public void TopikTeknologi()
    {
        Console.WriteLine($"'{judul}' membahas topik-topik teknologi terkini (Edisi {edisi}).");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"[MajalahTeknologi] Judul: {judul}, Tahun: {tahun}, Edisi: {edisi}");
    }
}

class Perpustakaan
{
    private List<Item> daftarItem = new List<Item>();

    public void TambahItem(Item item)
    {
        daftarItem.Add(item);
    }

    public void DaftarItem()
    {
        foreach (Item item in daftarItem)
        {
            item.Deskripsi();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Perpustakaan perpustakaan = new Perpustakaan();

        Novel novel1 = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
        Komik komik1 = new Komik("Naruto Vol.1", 2000, "Masashi Kishimoto");
        MajalahAnak maj1 = new MajalahAnak("Bobo", 2023, 15);
        MajalahTeknologi maj2 = new MajalahTeknologi("National Geographic", 2024, 3);
        Majalah majalah1 = new Majalah("Tempo", 2022, 10);

        perpustakaan.TambahItem(novel1);
        perpustakaan.TambahItem(komik1);
        perpustakaan.TambahItem(maj1);
        perpustakaan.TambahItem(maj2);
        perpustakaan.TambahItem(majalah1);

        perpustakaan.DaftarItem();

        novel1.Deskripsi();
        majalah1.Deskripsi();

        novel1.BacaSinopsis();

        Console.WriteLine($"Judul: {novel1.judul}, Tahun: {novel1.tahun}, Penulis: {novel1.penulis}");

        maj2.TopikTeknologi();

        Item itemPolymorphism = new Komik("One Piece Vol.1", 1997, "Eiichiro Oda");
        itemPolymorphism.Deskripsi();

        Console.ReadLine();
    }
}