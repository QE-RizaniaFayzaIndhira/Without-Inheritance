using System;

namespace komisi_plus_gajipokok_pegawai_tanpainheritance
{
  public class KomisiPlusGajiPokokPegawai : object
  {
    public string NamaDepan { get; }
    public string NamaBelakang { get; }
    public string NomerKTP { get; }
    private decimal pendapatanKotor;
    private decimal tarifKomisi;
    private decimal gajiPokok;

  public KomisiPlusGajiPokokPegawai(string namaDepan, string namaBelakang, string nomerKTP, decimal pendapatanKotor, decimal tarifKomisi, decimal gajiPokok)
  {
     NamaDepan = namaDepan;
     NamaBelakang = namaBelakang;
     NomerKTP = nomerKTP;
     PendapatanKotor = pendapatanKotor;
     TarifKomisi = tarifKomisi;
     GajiPokok = gajiPokok; 
     }
     public decimal PendapatanKotor
     {
       get
       {
          return pendapatanKotor;
          }
          set
          {
             if (value < 0)
             {
                 throw new ArgumentOutOfRangeException(nameof(value),
                 value, $"{nameof(PendapatanKotor)} must be >=0");
             }
                 pendapatanKotor = value;
             }
          }
     public decimal TarifKomisi
     {
       get
       {
          return tarifKomisi;
          }
          set
          {
             if (value <= 0 || value >= 1)
             {
                 throw new ArgumentOutOfRangeException(nameof(value),
                 value, $"{nameof(TarifKomisi)} must be >0 and <1");
             }
                 tarifKomisi = value;
          }
       }
     public decimal GajiPokok
     {
       get
       {
           return gajiPokok;
       }
       set
       {
           if (value < 0)
           {
                throw new ArgumentOutOfRangeException(nameof(value),
                value, $"{nameof(GajiPokok)} must be >=0");
           }
                gajiPokok = value;
       }
     }

        public decimal Pendapatan() => gajiPokok + (tarifKomisi * pendapatanKotor);
        public override string ToString() =>
             $"Gaji Pegawai = {NamaDepan}{NamaBelakang}\n" +
             $"Nomer KTP = {NomerKTP}\n" +
             $"Pendapatan Kotor = {pendapatanKotor:C}\n" +
             $"Tingkat Gaji = {tarifKomisi:F2}" +
             $"Gaji Pokok = {gajiPokok:C}";
  }
  class KomisiPegawaiTest
  {
  static void Main()
  {
                var pegawai = new KomisiPlusGajiPokokPegawai("Bob", "Lewis", "333-33-333", 5000.00M, .04M, 300.00M);
                Console.WriteLine("Pendapatan Pegawai yang diperoleh \n");
                Console.WriteLine($"Nama Pertama = {pegawai.NamaDepan}");
                Console.WriteLine($"Nama Terakhir = {pegawai.NamaBelakang}");
                Console.WriteLine($"Nomer KTP = {pegawai.NomerKTP}");
                Console.WriteLine($"Pendapatan Kotor = {pegawai.PendapatanKotor:C}");
                Console.WriteLine($"Tingkat Gaji = {pegawai.TarifKomisi:F2}");
                Console.WriteLine($"Pendapatan = {pegawai.Pendapatan():C}");
                Console.WriteLine($"Gaji Pokok = {pegawai.GajiPokok:C}");

                pegawai.GajiPokok = 1000.00M;

                Console.WriteLine("\nInformasi Pegawai Terbaru\n");
                Console.WriteLine(pegawai);
                Console.WriteLine($"Pendapatan = {pegawai.Pendapatan():C}");
                Console.ReadLine();
            }
        }
}
