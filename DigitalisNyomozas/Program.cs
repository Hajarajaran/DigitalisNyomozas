namespace DigitalisNyomozas
{
    internal class Program
    {
        static DataStore ds = new DataStore();
        static CaseManager caseManager = new CaseManager(ds);
        static EvidenceManager evidenceManager = new EvidenceManager(ds);
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
				} else
                {
                    Console.WriteLine("A megadott érték helytelen");
                }
			}

			if (valasztasInput == "1")
			{
				helyesValasz = false;
                string idInput = "";
                bool letezikMar = false;

				while (!helyesValasz)
                {
                    letezikMar = false;
                    Console.Write("Azonosító: ");
					idInput = Console.ReadLine();
					foreach (var i in ds.Ugyek)
					{
						if (i.Id == idInput)
						{
							Console.WriteLine("Helytelen azonosító!");
                            letezikMar = true;
                            break;
						}
					}
                    if (!letezikMar)
                    {
                        helyesValasz = true;
                    }
				}
								
				Console.Write("Cím: ");
				string cimInput = Console.ReadLine();
				Console.Write("Leírás: ");
				string leirasInput = Console.ReadLine();
				caseManager.UgyLetrehozasa(new Case(idInput, cimInput, leirasInput));
				Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
				Console.ReadKey();
			}
			else if (valasztasInput == "2")
			{
				caseManager.UgyekListazasa();
				Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
				Console.ReadKey();
			}


		}

        static void SzemelyHozzaadasaUgyhoz()
        {
			bool helyesValasz = false;
			var ugy = UgyKivalasztasa();
            if (ugy == null)
            {
                return;
            }
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
                    Console.Write("Státusz (szabad, megfigyelt, őrizetben): ");
                    string statusz = Console.ReadLine();
                    Suspect ujGyanusitott = new Suspect(szemely, statusz);
                    ds.Gyanusitottak.Add(ujGyanusitott);
					ugy.GyanusitottLista.Add(ujGyanusitott);
                    ugy.EsemenyLista.Add(new TimelineEvent($"Új gyanúsított rögzítve: {szemely.Nev}"));
                    Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
					Console.ReadKey();
					helyesValasz = true;
				}
				else if (valasztasInput == "2")
				{
					Console.Write("Vallomás: ");
					string vallomasInput = Console.ReadLine();
                    Witness ujTanu = new Witness(szemely, vallomasInput);
                    ds.Tanuk.Add(ujTanu);
                    ugy.TanuLista.Add(ujTanu);
                    ugy.EsemenyLista.Add(new TimelineEvent($"Új tanú rögzítve: {szemely.Nev}"));
                    Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
					Console.ReadKey();
					helyesValasz = true;
				}
                else
                {
                    Console.WriteLine("A megadott érték helytelen");
                }
			}
        }

        static void BizonyitekHozzaadasaUgyhoz()
        {
            bool helyesValasz = false;
            bool letezikMar = false;
            string idInput = "";
            var ugy = UgyKivalasztasa();
            if (ugy == null)
            {
                return;
            }

            while (!helyesValasz)
            {
                letezikMar = false;
                Console.Write("Bizonyíték ID: ");
                idInput = Console.ReadLine();
                foreach (var i in ds.Bizonyitekok)
                {
                    if (i.Id == idInput)
                    {
                        Console.WriteLine("Ez az azonosító már létezik!");
                        letezikMar = true;
                        break;
                    }
                }
                if (!letezikMar)
                {
                    helyesValasz = true;
                }
            }

            Console.Write("Leírás: ");
            string leirasInput = Console.ReadLine();
            Console.Write("Típus: ");
            string tipusInput = Console.ReadLine();

            helyesValasz = false;

            while (!helyesValasz)
            {
                Console.Write("Megbízhatóság (1-5): ");
                int megbizhatosagInput = int.Parse(Console.ReadLine());
                if (megbizhatosagInput >= 1 && megbizhatosagInput <= 5)
                {
                    evidenceManager.BizonyitekHozzaadasa(ugy, new Evidence(idInput, leirasInput, tipusInput, megbizhatosagInput));
                    Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
                    Console.ReadKey();
                    helyesValasz = true;
                } else
                {
                    Console.WriteLine("A megadott érték helytelen");
                }
            }
        }

        static void EsemenyekKezelese()
        {
            bool helyesValasz = false;
            var ugy = UgyKivalasztasa();
            if (ugy == null)
            {
                return;
            }

            

            while (!helyesValasz)
            {
                Console.WriteLine("1. Idővonal megtekintése | 2. Állapot váltás");
                string valasztasInput = Console.ReadLine();
                if (valasztasInput == "1")
                {
                    foreach (var i in ugy.EsemenyLista)
                    {
                        Console.WriteLine($"{i.Datum}: {i.Leiras}");
                    }
                    Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
                    Console.ReadKey();
                    helyesValasz = true;
                }
                else if (valasztasInput == "2")
                {
                    Console.Write("Állapot (nyitott, folyamatban, lezárt): ");
                    string allapotInput = Console.ReadLine();
                    ugy.Allapot.SatuszMegvaltoztatasa(allapotInput);
                    Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
                    Console.ReadKey();
                    helyesValasz = true;
                }
            }
        }

        static void Elemzes()
        {
            var ugy = UgyKivalasztasa();
            if (ugy == null)
            {
                return;
            }

            if (ugy.GyanusitottLista.Count == 0)
            {
                Console.WriteLine("Nincs elég gyanusított a művelet végrehajtásához");
                Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
                Console.ReadKey();
                return;

            }

            foreach (var i in ugy.GyanusitottLista)
            {
                engine.GyanusitottErtekelese(i, ugy);
            }
            Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
            Console.ReadKey();
        }

        static Case UgyKivalasztasa()
        {
			if (ds.Ugyek.Count == 0)
			{
				Console.WriteLine("A műveletet nem lehet végrehajtani, mert az ügyek listája üres");
                Console.Write("[Nyomjon le egy billentyűt a folytatáshoz]");
                Console.ReadKey();
                return null;
			}
			caseManager.UgyekListazasa();
			bool helyesValasz = false;
            bool letezikMar = false;

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
                if (!letezikMar)
                {
                    Console.WriteLine("A megadott azonosító helytelen.");
                }
            }
            return null;
		}
	}
}
