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
			bool helyesValasz = false;
            string valasztasInput = "";


			while (!helyesValasz)
            {
				Console.WriteLine("1. Új ügy | 2. Listázás");
				valasztasInput = Console.ReadLine();
				if (valasztasInput == "1" || valasztasInput == "2")
				{
                    helyesValasz = true;
				}
			}

			if (valasztasInput == "1")
			{
				helyesValasz = false;
                string idInput = "";

				while (!helyesValasz)
                {
					Console.Write("Azonosító: ");
					idInput = Console.ReadLine();
					foreach (var i in ds.Ugyek)
					{
						if (i.Id == idInput)
						{
							Console.WriteLine("Ez az azonosító már létezik!"); //!!!!!!!!!!!!!!!!!!!!!!!
						}
					}
				}
								
				Console.Write("Cím: ");
				string cimInput = Console.ReadLine();
				Console.Write("Leírás: ");
				string leirasInput = Console.ReadLine();
				caseManager.UgyLetrehozasa(idInput, cimInput, leirasInput);
				Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
				Console.ReadKey();
				helyesValasz = true;
			}
			else if (valasztasInput == "2")
			{
				caseManager.UgyekListazasa();

				Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
				Console.ReadKey();
				helyesValasz = true;
			}


		}

        static void SzemelyHozzaadasaUgyhoz()
        {
			bool helyesValasz = false;
			var ugy = UgyKivalasztasa();
			Console.Write("Név: ");
			string nevInput = Console.ReadLine();
			Console.Write("Életkor: ");
			int eletkorInput = int.Parse(Console.ReadLine());
            while (!helyesValasz)
            {
				Console.WriteLine("Típus: 1. Gyanúsított | 2. Tanú");
				string valasztasInput = Console.ReadLine();
				Person szemely = new Person(nevInput, eletkorInput, "");
				if (valasztasInput == "1")
				{
					ugy.GyanusitottLista.Add(new Suspect(szemely));
					Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
					Console.ReadKey();
					helyesValasz = true;
				}
				else if (valasztasInput == "2")
				{
					Console.Write("Vallomás: ");
					string vallomasInput = Console.ReadLine();
					ugy.TanuLista.Add(new Witness(szemely, vallomasInput));
					Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
					Console.ReadKey();
					helyesValasz = true;
				}
			}
        }

        static void BizonyitekHozzaadasaUgyhoz()
        {
            var ugy = UgyKivalasztasa();
            if (ugy == null)
            {
                return;
            }

            Console.Write("Bizonyíték ID: ");
            string idInput = Console.ReadLine();
            Console.Write("Leírás: ");
            string leirasInput = Console.ReadLine();
            Console.Write("Típus: ");
            string tipusInput = Console.ReadLine();
            Console.Write("Megbízhatóság (1-5): ");
            int megbizhatosagInput = int.Parse(Console.ReadLine());

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
                foreach (var i in ugy.EsemenyLista)
                {
                    Console.WriteLine($"{i.Datum}: {i.Leiras}");
                } 
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
			if (ds.Ugyek.Count == 0)
			{
				Console.WriteLine("Az ügyek listája üres");
                return default;
			}

			caseManager.UgyekListazasa();
			bool helyesValasz = false;
            while (!helyesValasz)
            {
				Console.Write("Válassz ügyet azonosító alapján: ");
				string idInput = Console.ReadLine();
				foreach (Case i in ds.Ugyek)
				{
					if (i.Id == idInput)
					{
						return i;                      
					}
				}
			}
			return default;
		}
	}
}
