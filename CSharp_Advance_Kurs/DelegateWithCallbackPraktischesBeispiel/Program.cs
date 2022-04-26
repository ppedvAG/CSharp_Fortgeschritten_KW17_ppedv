using System;

namespace DelegateWithCallbackPraktischesBeispiel
{

    public delegate void ProduktionsschrittDelegate(string maschine);

    public delegate void PruefungsDelegate(string msg);

    public delegate void FinishDelegate(string maschine);

    internal class Program 
    {
        static void Main(string[] args)
        {
            Maschine maschine;
            for (int i = 0; i < 100; i++)
            {
                maschine = new Maschine(i.ToString());

                Produktionskette(maschine);
            }
        }

        public static void Produktionskette (Maschine maschine)
        {
            ProduktionsControllingApp produktionsControllingApp = new ProduktionsControllingApp();

            ProduktionsschrittDelegate produktionsschrittDelegate = new ProduktionsschrittDelegate(produktionsControllingApp.AktuellerMaschinenProduktionsschritt);

           

            Maschinengeruest_wird_gebaut(maschine, produktionsschrittDelegate);
            ChipsWerdenInstalliert(maschine, produktionsschrittDelegate);
            VerkablungZuChips(maschine, produktionsschrittDelegate);
            GehäuseWirdAngebracht(maschine, produktionsschrittDelegate);




            PruefungsDelegate pruefungsDelegate = new PruefungsDelegate(produktionsControllingApp.FunktioniertMaschine);
            QualitätsPrüfer qualitätsPrüfer = new QualitätsPrüfer();
            qualitätsPrüfer.TesteMaschine(maschine, pruefungsDelegate);

            FinishDelegate finishDelegate = new FinishDelegate(produktionsControllingApp.MaschinenProduktionFertig);
            MaschineWurdeGePrüftUndIstDanachFertig(maschine, finishDelegate);
        }

        private static void Maschinengeruest_wird_gebaut(Maschine maschine, ProduktionsschrittDelegate produktionsschrittDelegate)
        {
            maschine.HatGerüst = true;

            produktionsschrittDelegate($"{maschine.MaschinenNr} Gehäuse wurde montiert");
        }

        private static void ChipsWerdenInstalliert (Maschine maschine, ProduktionsschrittDelegate produktionsschrittDelegate)
        {
            maschine.HatChips = true;
            produktionsschrittDelegate($"{maschine.MaschinenNr} Chips werden installiert");
        }

        private static void VerkablungZuChips(Maschine maschine, ProduktionsschrittDelegate produktionsschrittDelegate)
        {
            maschine.HatVerkablung = true;
            produktionsschrittDelegate($"{maschine.MaschinenNr} Verkabelung wird installiert");
        }

        private static void GehäuseWirdAngebracht(Maschine maschine, ProduktionsschrittDelegate produktionsschrittDelegate)
        {
            maschine.HatGehäuse = true;
            produktionsschrittDelegate($"{maschine.MaschinenNr} Gehäuse wird angebracht");
        }

        

        private static void MaschineWurdeGePrüftUndIstDanachFertig(Maschine maschine, FinishDelegate finishDelegate)
        {

        }
    }

    public class QualitätsPrüfer
    {
        public void TesteMaschine(Maschine maschine, PruefungsDelegate pruefungsDelegate)
        {
            if (maschine.HatVerkablung && maschine.HatChips && maschine.HatGerüst && maschine.HatGehäuse)
            {
                pruefungsDelegate($"{maschine.MaschinenNr} wurde ohne Fehler produziert");
            }
        }
    }


    public class Maschine
    {
        public Maschine(string MaschinenNr)
        {
            this.MaschinenNr = MaschinenNr;
        }
        public string MaschinenNr { get; set; }
        public bool HatGerüst { get; set; }
        public bool HatChips { get; set; }
        public bool HatVerkablung { get; set; }
        public bool HatGehäuse { get; set; }
    }


    //MonitoringApp für Produktionsstraße -> Überwacher der Produktstraße 
    public class ProduktionsControllingApp
    {
        public void AktuellerMaschinenProduktionsschritt(string message)
        {
            Console.WriteLine(message);
        }

        public void FunktioniertMaschine(string message)
        {
            Console.WriteLine(message);
        }

        public void MaschinenProduktionFertig(string msg)
        {
            Console.WriteLine(msg);
        }
    }

  


    


}
