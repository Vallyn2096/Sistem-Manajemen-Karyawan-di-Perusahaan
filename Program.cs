using System;

class Karyawan//kelas induk (base class) yang memiliki properti dan method umum
{
    private string nama;//nama karyawan
    private string id;//id karyawan
    private double gajiPokok;//gaji dasar

    public string Nama//getter dan setter
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public virtual double HitungGaji()//untuk mengembalikan gaji pokok
    {
        return gajiPokok;//mengembalikan gaji pokok
    }
}

class KaryawanTetap : Karyawan
{
    public override double HitungGaji()
    {
        return GajiPokok + 500000;//Tambahan gaji tetap sebesar Rp500.000.
    }
}

class KaryawanKontrak : Karyawan
{
    public override double HitungGaji()
    {
        return GajiPokok - 200000;//Gaji dipotong biaya kontrak Rp200.000.
    }
}

class KaryawanMagang : Karyawan
{
    public override double HitungGaji()
    {
        return GajiPokok;//Tidak ada tambahan atau potongan.
    }
}

class Program//method Main() — titik masuk program

{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistem Manajemen Karyawan ===");
        Console.Write("Jenis Karyawan (tetap/kontrak/magang): ");
        string jenis = Console.ReadLine().ToLower();

        Console.Write("Nama Karyawan: ");//menerima input tetap(nama)
        string nama = Console.ReadLine();

        Console.Write("ID Karyawan: ");//menerima input tetap(id)
        string id = Console.ReadLine();

        Console.Write("Gaji Pokok: ");//menerima input tetap(gaji pokok)
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;//objek karyawan akan berisi instansiasi dari subclass yang sesuai

        if (jenis == "tetap")
        {
            karyawan = new KaryawanTetap();
        }
        else if (jenis == "kontrak")
        {
            karyawan = new KaryawanKontrak();
        }
        else if (jenis == "magang")
        {
            karyawan = new KaryawanMagang();
        }
        else
        {
            Console.WriteLine("Jenis karyawan tidak valid!");
            return;
        }
        //Setter digunakan untuk mengisi properti objek.
        karyawan.Nama = nama;
        karyawan.ID = id;
        karyawan.GajiPokok = gajiPokok;

        Console.WriteLine("\n=== Data Karyawan ===");
        Console.WriteLine($"Nama       : {karyawan.Nama}");//menanmpilkan nama
        Console.WriteLine($"ID         : {karyawan.ID}");//menampilkan id
        Console.WriteLine($"Gaji Akhir : {karyawan.HitungGaji():C}");//menampilkan gaji akhir (menggunakan HitungGaji() yang akan dijalankan berdasarkan subclass yang dibuat)
    }
}