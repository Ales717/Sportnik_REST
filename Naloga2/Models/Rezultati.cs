namespace Naloga2.Models
{
    public class Rezultati
    {
        public int id { get; set; }
        public string ime_tekmovalca { get; set; }
        public string uvrstitev_spol { get; set; }
        public string uvrstitev_kategorija { get; set; }
        public string uvrstitev_skupna { get; set; }
        public string bib { get; set; }
        public string kategorija { get; set; }
        public string starost { get; set; }
        public string kraj { get; set; }
        public string drzava { get; set; }
        public string poklic { get; set; }
        public string tocke { get; set; }
        public string cas_plavanja { get; set; }
        public string cas_t1 { get; set; }
        public string cas_kolesarjenja { get; set; }
        public string cas_t2 { get; set; }
        public string cas_teka { get; set; }
        public string skupni_cas { get; set; }
        public string starostna_kategorija { get; set; }
        public string komentar { get; set; }
        public int tekmovanje_id { get; set; }
        public string user_id { get; set; }
        //public Tekmovanje tekmovanje { get; set; }
    }
}
