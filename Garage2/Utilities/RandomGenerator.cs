using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Utilities
{
    public class RandomGenerator
    {
        Random _random = new Random();

        private IReadOnlyDictionary<string, List<string>> _aeroplanes = new Dictionary<string, List<string>> {
            { "Airbus", new List<string> {
                "A300", "A310", "A318", "A319", "A320", "A321", "A330", "A340", "A350XWB", "A380" }
            },
            { "Antonov", new List<string> {
                "An-22", "An-30", "An-32", "An-38", "An-70", "An-72", "An-124", "An-225" }
            },
            { "Boeing", new List<string> {
                "247", "314", "377 Stratocruiser", "707", "720", "717", "727", "737", "747 Jumbojet",
                "757", "767", "777", "787 Dreamliner" }
            },
            { "Cessna", new List<string> {
                "120", "140", "150", "152", "162 Skycatcher", "165 Airmaster", "170", "172 Skyhawk",
                "175 Skylark", "177 Cardinal", "180 Skywagon", "182 Skylane", "185 Skywagon", "187",
                "188 Agwagon", "190", "195" }
            },
            { "Douglas", new List<string> {
                "DC-3", "TBD Devastator", "A-20 Havoc", "SBD Dauntless", "Douglas DC-4E", "B-23 Dragon",
                "DC-4", "DC-5", "Douglas XB-19", "A-26 Invader", "BTD Destroyer", "XA-42", "A-1 Skyraider",
                "C-74 Globemaster", "XB-43", "DC-6", "D-558-1 Skystreak", "D-558-2 Skyrocket", "F3D Skyknight",
                "C-124 Globemaster II", "A2D Skyshark", "F4D Skyray", "A-3 Skywarrior", "X-3 Stiletto",
                "A-4 Skyhawk", "B-66 Destroyer", "DC-7", "F5D Skylancer", "C-133 Cargomaster",
                "F6D Missileer", "DC-8", "DC-9", "DC-10" }
            },
            { "Lockheed Martin", new List<string> {
                "A-12", "C-130 Hercules", "C-5 Galaxy", "F-117 Nighthawk", "F-16 Fighting Falcon", "F-22 Raptor" }
            },
            { "Piper", new List<string> {
                "PA-18A Super", "L-18 Super Cub", "PA-19 Super Cub", "PA-20 Pacer", "PA-22 Tri-Pacer",
                "PA-23 Apache", "PA-23-250 Aztec", "PA-24 Comanche", "PA-25 Pawnee", "PA-28 Cherokee",
                "PA-28R Arrow Cherokee", "PA-30 Twin Comanche", "PA-31 Navajo", "PA-31P Mojave Navajo" }
            }
        };

        private IReadOnlyDictionary<string, List<string>> _boats = new Dictionary<string, List<string>> {
            { "Buster", new List<string> { "Cabin E", "Lx", "M2", "Magnum E", "Mini", "S Fish", "XL", "XS" } },
            { "Flipper", new List<string> { "600 DC", "600 SC", "600 ST", "640 DC", "640 SC", "640 ST", "670 DC", "670 ST", "760 DC", "880 ST" } },
            { "Nimbus", new List<string> { "21 Nova", "27 Nova S", "305 Coupé", "31 Nova S", "335 Coupé", "34 Nova", "365 Coupé", "405 Coupé" } },
            { "Sea Ray", new List<string> { "210 Sun Sport", "240 Sun Sport", "240 Sundeck", "270 SLX", "270 Sundeck", "300 SLX", "310 Sundancer",
                                            "330 Sundancer", "350 SLX", "350 Sundancer", "355 Sundancer", "370 Sundancer" } },
            { "Storebro", new List<string> { "435 Commander", "435 SunTop", "460 Commander", "90 E" } }
        };

        private IReadOnlyDictionary<string, List<string>> _busses = new Dictionary<string, List<string>> {
            { "Neoplan", new List<string> { "Jetliner", "Cityliner", "Skyliner", "Tourliner" } },
            { "Scania", new List<string> { "Irizar i6", "Touring", "Van Hool TDX 27 Astromega", "Van Hool TX16" } },
            { "Setra", new List<string> { "ComfortClass S 511 HD", "ComfortClass S 515 HD", "ComfortClass S 515 MD", "MultiClass S 412 UL",
                                          "MultiClass S 415 H", "MultiClass S 415 LE business", "MultiClass S 415 UL", "MultiClass S 415 UL business",
                                          "MultiClass S 416 UL business", "TopClass S 515 HDH" } },
            { "Volvo", new List<string> { "7900", "8900", "9500", "9700", "9900" } }
        };

        private IReadOnlyDictionary<string, List<string>> _cars = new Dictionary<string, List<string>> {
            { "Audi", new List<string> { "80", "100", "A1", "A2", "A3", "A4", "A5", "A6", "A8", "Quattro", "R8", "TT", "V8" }},
            { "Fiat", new List<string> { "124", "125", "131", "500", "600", "Croma", "Punto", "Ritmo", "Tipo", "Uno", "X1/9" }},
            { "Ford", new List<string> { "Cortina", "Fairlane", "Focus", "Escort", "Granada", "Scorpio", "Sierra", "Taunus", "Zephyr" }},
            { "Opel", new List<string> { "Ascona", "Astra", "Kadett", "Kapitän", "Record" }},
            { "Porsche", new List<string> { "911", "914", "924", "928", "944", "Boxter", "Carrera GT", "Cayenne" }},
            { "Lada", new List<string> { "Granta", "Largus Cross", "Niva" }},
            { "Renault", new List<string> { "Clio", "Espace", "Kangoo", "Megane", "R4", "R5", "R8", "R14", "R16" }},
            { "Volvo", new List<string> { "144", "164", "240", "340", "360", "740", "Amazon", "S40", "S60", "V70", "XC90" }},
            { "Volkswagen", new List<string> { "Bora", "Caddy", "Caravelle", "Corado", "Golf", "Jetta", "Lupo", "New Beetle", "Polo", "Passat", "Typ 1" }}
        };

        private IReadOnlyDictionary<string, List<string>> _motorcycles = new Dictionary<string, List<string>> {
            { "Harley-Davidson", new List<string> { "FL Hydra Glide", "FL Duo Glide", "FLH Electra Glide", "FLHS Electra Glide Sport", "Low Rider FXS",
                                                    "Fat Bob FXEF", "Sturgis FXB", "Street Bob FXDB", "Softail Deuce", "Night Train", "Cross Bones" } },
            { "Husqvarna", new List<string> { "Modell 120", "Modell 160", "Modell 22 Änglavinge", "Modell 24 Svartqvarna", "Modell 25", "Modell 27 Rödqvarna",
                                              "Modell 281 Drömbågen", "Modell 282 Silverpilen", "Modell 283 Guldpilen", "Modell 30", "Modell 301", "Modell 32",
                                              "Modell 35", "Modell 610", "Modell 65 MotoReve" } },
            { "Norton", new List<string> { "Classic", "Commander", "F1 Sport", "F1", "Interpol 2", "NRS588", "RC588", "RCW588" } },
            { "Suzuki", new List<string> { "GS1000", "GS500", "GSX1100", "GSX550", "GSX750", "GT380", "GT550", "GT750" } },
            { "Yamaha", new List<string> { "DT125", "MT-01", "MT-03", "MT-07", "RD250", "RD350", "SR250", "SR400", "SR500", "TDR 250", "TZR 125", "TZR 250",
                                           "XJR1200", "XJR1300", "XJR400" } }
        };

        private string[] _colors = {
                "akvamarin", "aprikos", "babyblå", "becksvart", "beige", "blodröd", "blå", "blåklintsblå", "blåvit", "brandgul", "brun", "bärnstensgul",
                "cerise", "citrongul", "cyan", "fuchsia", "gredelin", "gräddvit", "grå", "grön", "gul", "gyllenbrun", "havsblå", "indigo", "isabellafärgad",
                "isblå", "jeansblå", "kaffebrun", "kaffefärgad", "kaki", "karmosinröd", "kastanjefärgad", "knallröd", "koboltblå", "kornblå", "lila",
                "lingul", "ljusblå", "ljusgul", "ljusröd", "marinblå", "mint", "mörkblå", "mörkgrön", "mörklila", "mörkrosa", "olivgrön", "orange",
                "purpur", "rosa", "röd", "scharlakansröd", "skär", "smaragdgrön", "snövit", "solgul", "svart", "turkos", "vinröd", "viol", "violett",
                "vit", "äggul"
        };

        private const string _regNumChars = "ABCDEFGHJKLMNOPRSSTUXYZ"; // A-Z but not I,V and Q.

        private enum _gender
        {
            female,
            male
        }

        private List<string>[] _firstNames = {
            new List<string>() {
                "Agnes", "Alice", "Alicia", "Alma", "Alva", "Amanda", "Amelia", "Anna", "Astrid", "Celine", "Cornelia", "Ebba", "Edith", "Elin", "Elina",
                "Elisa", "Elise", "Ella", "Ellen", "Ellie", "Ellinor", "Elsa", "Elvira", "Emelie", "Emilia", "Emma", "Emmy", "Ester", "Felicia", "Filippa",
                "Freja", "Greta", "Hanna", "Hedda", "Hilda", "Hilma", "Ida", "Ines", "Ingrid", "Iris", "Isabella", "Isabelle", "Jasmine", "Jenny", "Joline",
                "Julia", "Juni", "Klara", "Leah", "Leia", "Lilly", "Linn", "Linnea", "Lisa", "Liv", "Livia", "Lotta", "Lova", "Lovis", "Lovisa", "Luna",
                "Lykke", "Maja", "Majken", "Maria", "Matilda", "Meja", "Melissa", "Minna", "Mira", "Moa", "Molly", "My", "Märta", "Nathalie", "Nellie",
                "Nicole", "Nora", "Nova", "Novalie", "Olivia", "Ronja", "Rut", "Saga", "Sally", "Sara", "Selma", "Signe", "Sigrid", "Siri", "Sofia", "Stella",
                "Stina", "Svea", "Thea", "Tilda", "Tilde", "Tindra", "Tuva", "Tyra", "Vera", "Victoria", "Wilma"
            },
            new List<string>() {
                "Adam", "Adrian", "Albin", "Alex", "Alexander", "Alfred", "Ali", "Alvin", "Anders", "Anton", "Aron", "Arvid", "August", "Axel", "Benjamin",
                "Carl", "Casper", "Charlie", "Colin", "Daniel", "Dante", "David", "Ebbe", "Eddie", "Edward", "Edvin", "Elias", "Elis", "Elliot", "Elton",
                "Elvin", "Emil", "Erik", "Felix", "Filip", "Frank", "Gabriel", "Gustav", "Hampus", "Harry", "Henry", "Hjalmar", "Hugo", "Isak", "Ivar", "Jack",
                "Jacob", "Joel", "John", "Jonathan", "Josef", "Julian", "Kalle", "Kevin", "Leo", "Leon", "Liam", "Linus", "Loke", "Loui", "Love", "Lucas",
                "Ludvig", "Malte", "Matteo", "Max", "Maximilian", "Melker", "Melvin", "Milo", "Milton", "Mio", "Mohamed", "Neo", "Nils", "Noah", "Noel",
                "Oliver", "Olle", "Oscar", "Otto", "Rasmus", "Sam", "Samuel",  "Sebastian", "Sigge", "Simon", "Sixten", "Svante", "Tage", "Theo", "Theodor",
                "Valter", "Vidar", "Viggo", "Viktor", "Vilgot", "Wilhelm", "Ville", "William", "Wilmer", "Vincent"
            }
        };

        private List<string> _lastNames = new List<string>() {
            "Abrahamsson", "Ali", "Andersson", "Andreasson", "Arvidsson", "Axelsson", "Bengtsson", "Berg", "Berggren", "Berglund", "Bergman", "Bergqvist",
            "Bergström", "Björk", "Björklund", "Blom", "Blomqvist", "Claesson", "Dahlberg", "Danielsson", "Ek", "Eklund", "Ekström", "Eliasson", "Engström",
            "Eriksson", "Falk", "Forsberg", "Fransson", "Fredriksson", "Gran", "Gunnarsson", "Gustafsson", "Hansen", "Hansson", "Hedlund", "Hellström",
            "Henriksson", "Hermansson", "Holm", "Holmberg", "Holmgren", "Holmqvist", "Håkansson", "Isaksson", "Jakobsson", "Jansson", "Johansson", "Jonasson",
            "Jonsson", "Jönsson", "Karlsson", "Larsson", "Lind", "Lindberg", "Lindgren", "Lindholm", "Lindqvist", "Lindström", "Lund", "Lundberg", "Lundgren",
            "Lundin", "Lundqvist", "Lundström", "Löfgren", "Magnusson", "Martinsson", "Mattsson", "Mohamed", "Månsson", "Mårtensson", "Nilsson", "Norberg",
            "Nordin", "Nordström", "Nyberg", "Nyström", "Olofsson", "Olsson", "Persson", "Pettersson", "Pålsson", "Samuelsson", "Sandberg", "Sandström",
            "Sjöberg", "Sjögren", "Skog", "Ström", "Strömberg", "Sundberg", "Sundström", "Svensson", "Söderberg", "Wallin", "Viklund", "Wikström", "Åberg",
            "Åkesson", "Åström", "Öberg"
        };

        public List<Tuple<string, string>> AeroplaneModels(int count)
        {
            string[] keys = _aeroplanes.Keys.ToArray();
            List<Tuple<string, string>> am = new List<Tuple<string, string>>();

            for (int i = 0; i < count; i++)
            {
                string key = keys[_random.Next(keys.Length)];
                am.Add(
                    new Tuple<string, string>(
                        key,
                        _aeroplanes[key][_random.Next(_aeroplanes[key].Count)]
                        )
                    );
            }
            return am;
        }

        public List<Tuple<string, string>> BoatModels(int count)
        {
            string[] keys = _boats.Keys.ToArray();
            List<Tuple<string, string>> bm = new List<Tuple<string, string>>();

            for (int i = 0; i < count; i++)
            {
                string key = keys[_random.Next(keys.Length)];
                bm.Add(
                    new Tuple<string, string>(
                        key,
                        _boats[key][_random.Next(_boats[key].Count)]
                        )
                    );
            }
            return bm;
        }

        public List<Tuple<string, string>> BusModels(int count)
        {
            string[] keys = _busses.Keys.ToArray();
            List<Tuple<string, string>> bm = new List<Tuple<string, string>>();

            for (int i = 0; i < count; i++)
            {
                string key = keys[_random.Next(keys.Length)];
                bm.Add(
                    new Tuple<string, string>(
                        key,
                        _busses[key][_random.Next(_busses[key].Count)]
                        )
                    );
            }
            return bm;
        }

        public List<Tuple<string, string>> CarModels(int count)
        {
            string[] keys = _cars.Keys.ToArray();
            List<Tuple<string, string>> cm = new List<Tuple<string, string>>();

            for (int i = 0; i < count; i++)
            {
                string key = keys[_random.Next(keys.Length)];
                cm.Add(
                    new Tuple<string, string>(
                        key,
                        _cars[key][_random.Next(_cars[key].Count)]
                        )
                    );
            }
            return cm;
        }

        public List<Tuple<string, string>> MotorcykleModels(int count)
        {
            string[] keys = _motorcycles.Keys.ToArray();
            List<Tuple<string, string>> mm = new List<Tuple<string, string>>();

            for (int i = 0; i < count; i++)
            {
                string key = keys[_random.Next(keys.Length)];
                mm.Add(
                    new Tuple<string, string>(
                        key,
                        _motorcycles[key][_random.Next(_motorcycles[key].Count)]
                        )
                    );
            }
            return mm;
        }

        public List<string> RegNumbers(int count)
        {
            HashSet<string> regNums = new HashSet<string>();

            //for (int i = 0; i < count; i++)
            while (regNums.Count < count)
            {
                string rn = "";

                for (int j = 0; j < 3; j++)
                {
                    rn += _regNumChars[_random.Next(_regNumChars.Length)];
                }
                rn += string.Format("{0:D3}", _random.Next(1000));
                //for (int k = 0; k < 3; k++)
                //{
                //    rn += _random.Next(10);
                //}

                regNums.Add(rn);
            }

            return regNums.ToList();
        }

        public List<string> Colors(int count)
        {
            List<string> colors = new List<string>();

            for (int i = 0; i < count; i++)
            {
                colors.Add(_colors[_random.Next(_colors.Length)]);
            }

            return colors;
        }

        public List<Tuple<string, string>> People(int count)
        {
            List<Tuple<string, string>> people = new List<Tuple<string, string>>();

            for (int i = 0; i < count; i++)
            {
                int gender = _random.Next(2);

                people.Add(
                    new Tuple<string, string>(
                        _firstNames[gender][_random.Next(_firstNames[gender].Count)],
                        _lastNames[_random.Next(_lastNames.Count)]
                        )
                    );
            }

            return people;
        }

        public DateTime DateAndTime(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(_random.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }

        public List<DateTime> DatesAndTimes(int count, DateTime from, DateTime to)
        {
            List<DateTime> dateTimes = new List<DateTime>();

            for (int i = 0; i < count; i++)
            {
                dateTimes.Add(DateAndTime(from, to));
            }

            return dateTimes;
        }

        public List<int> Integers(int count, int minValue, int maxValue)
        {
            List<int> ints = new List<int>();

            for (int i = 0; i < count; i++)
            {
                ints.Add(_random.Next(minValue, maxValue));
            }

            return ints;
        }
    }
}