namespace EloadasProject
{
    public class Eloadas
    {
        private bool[,] foglalasok;

        
        public Eloadas(int sorokSzama, int helyekSzama)
        {
            if (sorokSzama <= 0 || helyekSzama <= 0)
            {
                throw new ArgumentException("A sorok száma és a helyek száma nagyobb kell legyen mint 0.");
            }

            foglalasok = new bool[sorokSzama, helyekSzama];
        }

        
        public bool Foglalas(int sor, int oszlop)
        {
            if (!foglalasok[sor, oszlop])
            {
                foglalasok[sor, oszlop] = true;
                return true;
            }
            return false;
        }

        
        public bool FoglalasFeloldasa(int sor, int oszlop)
        {
            if (foglalasok[sor, oszlop])
            {
                foglalasok[sor, oszlop] = false;
                return true;
            }
            return false;
        }

        
        public bool EllenorizFoglaltsag(int sor, int oszlop)
        {
            return foglalasok[sor, oszlop];
        }

        
        public bool Lefoglal()
        {
            for (int i = 0; i < foglalasok.GetLength(0); i++)
            {
                for (int j = 0; j < foglalasok.GetLength(1); j++)
                {
                    if (!foglalasok[i, j])
                    {
                        foglalasok[i, j] = true;
                        return true;
                    }
                }
            }
            return false; 
        }

        
        public int SzabadHelyek
        {
            get
            {
                int count = 0;
                for (int i = 0; i < foglalasok.GetLength(0); i++)
                {
                    for (int j = 0; j < foglalasok.GetLength(1); j++)
                    {
                        if (!foglalasok[i, j])
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }

        
        public bool Teli
        {
            get
            {
                for (int i = 0; i < foglalasok.GetLength(0); i++)
                {
                    for (int j = 0; j < foglalasok.GetLength(1); j++)
                    {
                        if (!foglalasok[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true; 
            }
        }

        
        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorSzam < 1 || helySzam < 1 || sorSzam > foglalasok.GetLength(0) || helySzam > foglalasok.GetLength(1))
            {
                throw new ArgumentException("Érvénytelen sor vagy hely szám.");
            }
            return foglalasok[sorSzam - 1, helySzam - 1];
        }

        
        public override string ToString()
        {
            int sorokSzama = foglalasok.GetLength(0);
            int oszlopokSzama = foglalasok.GetLength(1);
            string result = "";

            for (int i = 0; i < sorokSzama; i++)
            {
                for (int j = 0; j < oszlopokSzama; j++)
                {
                    result += foglalasok[i, j] ? "X " : "O ";
                }
                result = result.TrimEnd() + "\n";
            }
            return result.TrimEnd();
        }

        public static void Main(string[] args)
        {
            try
            {
                Eloadas eloadas = new Eloadas(5, 5);
                Console.WriteLine(eloadas);

                eloadas.Foglalas(2, 3);
                Console.WriteLine(eloadas);

                eloadas.FoglalasFeloldasa(2, 3);
                Console.WriteLine(eloadas);

                Console.WriteLine(eloadas.EllenorizFoglaltsag(2, 3));

               
                eloadas.Lefoglal();
                Console.WriteLine(eloadas);

                
                Console.WriteLine("Szabad helyek száma: " + eloadas.SzabadHelyek);

                
                Console.WriteLine("Tele van az előadás? " + eloadas.Teli);

                
                Console.WriteLine("A 3. sor 4. helye foglalt? " + eloadas.Foglalt(3, 4));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                
                Eloadas hibasEloadas = new Eloadas(0, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message); 
            }

        }
    }
}
