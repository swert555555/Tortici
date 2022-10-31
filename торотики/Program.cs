namespace торотики
{
    internal class Program
    {
        static void Main()
        {

            Console.WriteLine("Меню торта: ");
            List<string> list = new List<string>() { "Форма", "Размер", "Количество коржей", "Вкус", "Глазурь", "Декор" };
            int i = 1;
            foreach (string item in list)
            {
                Console.WriteLine("\t" + i + ". " + item);
                i++;
            }
            Тортики выбор = new Тортики();
            выбор.position = 1;
            Strelka(выбор.position);
        }
        static void Strelka(int position)
        {
            
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow)
                    position--;
                else
                    position++;
                Console.Clear();
                Menu();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                key = Console.ReadKey();
            }
            Console.Clear();
            nod_pynct(position);
        }
        static void nod_pynct(int position)
        {
            Тортики выбор = new Тортики();
            if (position == 1)
            {
                Console.WriteLine("\t" + выбор.forma[0]);
                Console.WriteLine("\t" + выбор.forma[1]);
                Console.WriteLine("\t" + выбор.forma[2]);

            }
            else if (position == 2)
            {
                Console.WriteLine("\t" + выбор.razmer[0]);
                Console.WriteLine("\t" + выбор.razmer[1]);
                Console.WriteLine("\t" + выбор.razmer[2]);
            }
            else if (position == 3)
            {
                Console.WriteLine("\t" + выбор.kol_korz[0]);
                Console.WriteLine("\t" + выбор.kol_korz[1]);
                Console.WriteLine("\t" + выбор.kol_korz[2]);
            }
            else if (position == 4)
            {
                Console.WriteLine("\t" + выбор.vkus[0]);
                Console.WriteLine("\t" + выбор.vkus[1]);
                Console.WriteLine("\t" + выбор.vkus[2]);
            }
            else if (position == 5)
            {
                Console.WriteLine("\t" + выбор.glazur[0]);
                Console.WriteLine("\t" + выбор.glazur[1]);
                Console.WriteLine("\t" + выбор.glazur[2]);
            }
            else if (position == 6)
            {
                Console.WriteLine("\t" + выбор.decor[0]);
                Console.WriteLine("\t" + выбор.decor[1]);
                Console.WriteLine("\t" + выбор.decor[2]);
            }
            Strelka2(position);
        }
        static void Menu()
        {
            Console.WriteLine("Меню торта: ");
            List<string> list = new List<string>() { "Форма", "Размер", "Количество коржей", "Вкус", "Глазурь", "Декор" };
            int i = 1;
            foreach (string item in list)
            {
                Console.WriteLine("\t" + i + ". " + item);
                i++;
            }
        }
        static void Strelka2(int position)
        {

            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow)
                    position--;
                else
                    position++;
                Console.Clear();
                nod_pynct(position);
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                key = Console.ReadKey();
            }
            Console.Clear();
            Main();
        }
    }
}