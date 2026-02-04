namespace DigitalisNyomozas
{
    internal class Program
    {
        static DataStore ds = new DataStore();
        static CaseManager caseManager = new CaseManager(ds);
        static EvidenceManager evidenceManager = new EvidenceManager();
        static DecisionEngine engine = new DecisionEngine();

        static void Main(string[] args)
        {
            // Alapértelmezett felhasználó
            ds.Felhasznalok.Add(new User("Sherlock Holmes", "001", "nyomozó"));

            bool programFut = true;
            while (programFut)
            {
                Console.Clear();
                Console.WriteLine("--- DIGITÁLIS NYOMOZÁSI RENDSZER ---");
                Console.WriteLine("1. Ügyek kezelése (Új ügy / Listázás)");
                Console.WriteLine("2. Személy hozzáadása ügyhöz");
                Console.WriteLine("3. Bizonyíték rögzítése");
                Console.WriteLine("4. Idővonal és Állapot módosítás");
                Console.WriteLine("5. Elemzés (Gyanúsított értékelése)");
                Console.WriteLine("6. Kilépés");
                Console.Write("\nVálassz egy menüpontot: ");

                string valasztasInput = Console.ReadLine();
                switch (valasztasInput)
                {
                    case "1": UgyekKezelese(); break;
                    case "2": SzemelyHozzaadasaUgyhoz(); break;
                    case "3": BizonyitekHozzaadasaUgyhoz(); break;
                    case "4": EsemenyekKezelese(); break;
                    case "5": Elemzes(); break;
                    case "6": programFut = false; break;
                }
            }
        }

        static void UgyekKezelese()
        {
            Console.WriteLine("1. Új ügy | 2. Listázás");
            var sub = Console.ReadLine();
            if (sub == "1")
            {
                Console.Write("Azonosító: "); string id = Console.ReadLine();
                Console.Write("Cím: "); string title = Console.ReadLine();
                Console.Write("Leírás: "); string desc = Console.ReadLine();
                caseManager.UgyLetrehozasa(id, title, desc);
            }
            else
            {
                caseManager.UgyekListazasa();
            }

            Console.ReadKey();
        }

        static void SzemelyHozzaadasaUgyhoz()
        {
            var ugy = UgyKivalasztasa();
            if (ugy == null)
            {
                return;
            }

            Console.Write("Név: "); string nevInput = Console.ReadLine();
            Console.Write("Életkor: "); int eletkorInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Típus: 1. Gyanúsított | 2. Tanú");
            string valasztasInput = Console.ReadLine();

            Person szemely = new Person(nevInput, eletkorInput, "");
            if (valasztasInput == "1")
            {
                ugy.GyanusitottLista.Add(new Suspect(szemely));
            } 
            else
            {
                Console.Write("Vallomás: "); string vallomasInput = Console.ReadLine();
                ugy.TanuLista.Add(new Witness(szemely, vallomasInput));
            }
            Console.WriteLine("Személy hozzáadva.");
            Console.ReadKey();
        }

        static void BizonyitekHozzaadasaUgyhoz()
        {
            var ugy = UgyKivalasztasa();
            if (ugy == null)
            {
                return;
            }

            Console.Write("Bizonyíték ID: "); string idInput = Console.ReadLine();
            Console.Write("Leírás: "); string leirasInput = Console.ReadLine();
            Console.Write("Típus: "); string tipusInput = Console.ReadLine();
            Console.Write("Megbízhatóság (1-5): "); int megbizhatosagInput = int.Parse(Console.ReadLine());

            evidenceManager.BizonyitekHozzaadasa(ugy, new Evidence(idInput, leirasInput, tipusInput, megbizhatosagInput));
            Console.WriteLine("Bizonyíték rögzítve.");
            Console.ReadKey();
        }

        static void EsemenyekKezelese()
        {
            var ugy = UgyKivalasztasa();
            if (ugy == null)
            {
                return;
            }

            Console.WriteLine("1. Idővonal megtekintése | 2. Állapot váltás");
            string valasztasInput = Console.ReadLine();
            if (valasztasInput == "1")
            {
                foreach (var i in ugy.EsemenyLista) Console.WriteLine($"{i.Datum}: {i.Leiras}");
            }
            else
            {
                Console.WriteLine("Add meg az állapotot (nyitott, folyamatban, lezárt): ");
                string allapotInput = Console.ReadLine();
                ugy.Allapot.SatuszMegvaltoztatasa(allapotInput);
            }
            Console.ReadKey();
        }

        static void Elemzes()
        {
            var ugy = UgyKivalasztasa();
            if (ugy == null || ugy.GyanusitottLista.Count == 0)
            {
                return;
            } 

            foreach (var i in ugy.GyanusitottLista)
            {
                engine.GyanusitotErtekelese(i, ugy);
            }
                

            Console.ReadKey();
        }

        static Case UgyKivalasztasa()
        {
            caseManager.UgyekListazasa();
            Console.Write("Válassz ügyet azonosító alapján: ");
            string id = Console.ReadLine();
            return ds.Ugyek.FirstOrDefault(x => x.Id == id);
        }
    }
}
