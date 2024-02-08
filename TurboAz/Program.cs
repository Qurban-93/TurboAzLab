using TurboAz.Extensions;
using TurboAz.Models;

namespace TurboAz
{
    internal class Program
    {
        static List<Marka> markaList = new();
        static List<Model> modelList = new();
        static List<Anouncement> anouncementList = new();
        static void Main(string[] args)
        {
            int answer;
            do
            {
                Console.WriteLine("1 - Marka elave ele :");
                Console.WriteLine("2 - Marka sil :");
                Console.WriteLine("3 - Marka hamisin goster :");
                Console.WriteLine("4 - Marka Id ile axtar :");
                Console.WriteLine("5 - Marka duzelish ele :");
                Console.WriteLine("6 - Model elave ele :");
                Console.WriteLine("7 - Model sil :");
                Console.WriteLine("8 - Butun modelleri goster :");
                Console.WriteLine("9 - Model Id ile axtar :");
                Console.WriteLine("10 - Modele duzelish ele :");

                answer = Helper.ReadInt("Siayhidan secim edin", "Sehv daxil etdiniz");


                switch (answer)
                {
                    case 1:
                        AddNewMarka();
                        break;
                    case 2:
                        DeleteMarka();
                        break;
                    case 3:
                        GetAllMarka();
                        break;
                    case 4:
                        GetMarkaById();
                        break;
                    case 5:
                        EditMarka();
                        break;
                    case 6:
                        AddNewModel();
                        break;
                    case 7:
                        DeleteModel();
                        break;
                    case 8:
                        GetAllModedls();
                        break;
                    case 9:
                        GetModelById();
                        break;
                    case 10:
                        EditModel();
                        break;
                    default:
                        break;
                }

            } while (true);


        }

        private static void EditModel()
        {
            int modelId;

            foreach (var item in modelList)
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.Marka.Name}");
            }
        l1:
            modelId = Helper.ReadInt("Duzelish etmek istediyiniz modelin Id-sini daxil edin !", "Sehv daxil etdiniz");
            Model model = modelList.FirstOrDefault(m => m.Id == modelId);
            if (model == null)
            {
                Console.WriteLine($"{modelId} - Id li Model siyahida yoxdur!");
                goto l1;
            }

            string newModelName = Helper.ReadString("Modelin yeni adini daxil edin!", "Sehv daxil etdiniz");

            foreach (var item in markaList)
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }

            int markaId;

        l2:
            markaId = Helper.ReadInt("Yeni markanin Id-sini daxil ele", "Sehv daxil etdiniz!");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka == null)
            {
                Console.WriteLine($"{markaId} - Id li Marka siyahida yoxdur!");
                goto l2;
            }

            model.Marka = marka;
            model.Name = newModelName;

            Console.WriteLine("Deyisiklik edildi ! \n");


        }

        private static void GetModelById()
        {
            int modelId;
        l1:
            modelId = Helper.ReadInt("Tapmaq istediyiniz Modelin Id-sini daxil edin", "Sehv daxil etdiniz");

            Model model = modelList.FirstOrDefault(x => x.Id == modelId);
            if (model == null)
            {
                Console.WriteLine("Bu Id-ile model tapilmadi!");
                goto l1;
            }

            Console.WriteLine($"Id - {model.Id} Adi - {model.Name}  Markasi - {model.Marka.Name}");
            Console.WriteLine("\n");

        }

        private static void GetAllModedls()
        {
            if (modelList.Count < 1)
            {
                Console.WriteLine("Model siyahisi boshdur!");
                return;
            }

            foreach (var item in modelList)
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.Marka.Name}");
            }

            Console.WriteLine("\n");

        }

        private static void DeleteModel()
        {
            int deleteId;
            Console.WriteLine();
            foreach (var item in modelList)
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.Marka.Name}");
            }
        l1:
            deleteId = Helper.ReadInt("Silmek istediyiniz modelin Id-sini daxil edin!", "Sehv daxil etdiniz !");
            Model model = modelList.FirstOrDefault(m => m.Id == deleteId);
            if (model is null)
            {
                Console.WriteLine("Daxil etdiyiniz Id- ile model movcud deil!");
                goto l1;
            }

            modelList.Remove(model);
            Console.WriteLine("Silindi!\n");

        }

        private static void AddNewModel()
        {
            if (markaList.Count < 1)
            {
                Console.WriteLine("Marka siyahisi boshdu ! Zehmet olmasa Marka elave edin!");
                return;
            }

            string modelName = Helper.ReadString("Modelin adini daxil edin :", "Sehv daxil etdiniz");
            int markaId;
            foreach (var item in markaList)
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }

        l1:
            markaId = Helper.ReadInt("Modelin Markasini secin !", "Sehv daxil etdiniz !");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine("Sehv Id- daxil etmisiz!");
                goto l1;
            }

            Model model = new Model();
            model.Marka = marka;
            model.Name = modelName;

            modelList.Add(model);

            Console.WriteLine("Elave olundu ! \n");

        }

        private static void EditMarka()
        {
            int markaId;
            foreach (Marka item in markaList)
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }
        l1:
            markaId = Helper.ReadInt("Deyisiklik etmek istediyiniz Markanin Id-sini daxil edin", "Sehv daxil etdiniz");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi");
                goto l1;

            }

            string newMarkaName = Helper.ReadString("Markanin yeni adini daxil edin:", "Sehv daxil etdiniz");
            marka.Name = newMarkaName;

            Console.WriteLine( "Deyisiklik edildi! \n");

        }

        private static void GetMarkaById()
        {
            int markaId = Helper.ReadInt("Markanin Id-sini daxil edin", "Sehv daxil etdiniz");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi");
            }

            Console.WriteLine($"Id - {marka.Id} Adi - {marka.Name} \n");
        }

        private static void DeleteMarka()
        {
            if (markaList.Count < 1)
            {
                Console.WriteLine("Siyahida marka yoxdu !");
                return;
            }

        l1:
            int markaId = Helper.ReadInt("Markanin Id-sini daxil edin", "Sehv daxil etdiniz");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi");
                goto l1;
            }

            markaList.Remove(marka);
            Console.WriteLine("Silindi ! \n");

        }

        private static void GetAllMarka()
        {
            if (markaList.Count > 0)
            {
                foreach (var item in markaList)
                {
                    Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("Marka siyahisi boshdu ! \n");
            }


        }

        private static void AddNewMarka()
        {
            string markaName;
        l1:
            Console.Write("Markanin adini daxil edin: ");
            markaName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(markaName) || markaName.Length < 2)
            {
                Console.WriteLine("Bosh olmaz ve minimum simvol 3 eded !");
                goto l1;
            }

            Marka marka = new Marka()
            {
                Name = markaName,
            };

            markaList.Add(marka);

            Console.WriteLine("Elave olundu! \n");

        }
    }
}