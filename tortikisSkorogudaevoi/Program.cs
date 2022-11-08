using System.Collections.Generic;
using tortikisSkorogudaevoi;
using System.IO;
using System.Diagnostics;

internal class Program
{
    private static int С_Вас = 0;
    private static string В_Итоге = "";
    static void Main()
    {
        Podpunkt krug = new Podpunkt("Круг", 100);
        Podpunkt serd = new Podpunkt("Сердечко", 150);
        Podpunkt kvadr = new Podpunkt("Квадрат", 120);
        
        Punkt forma = new Punkt();
        forma.Name = "Форма";
        forma.Podpunkts =  new List<Podpunkt> { krug, serd, kvadr }; 
        
        Podpunkt kol1 = new Podpunkt("1 корж", 50);
        Podpunkt kol2 = new Podpunkt("2 коржа", 100);
        Podpunkt kol3 = new Podpunkt("3 коржа", 150);

        Punkt kolichestvo = new Punkt();
        kolichestvo.Name = "Количество коржей";
        kolichestvo.Podpunkts = new List<Podpunkt> { kol1, kol2, kol3 };

        Podpunkt mal = new Podpunkt("диаметор - 10", 300);
        Podpunkt sred = new Podpunkt("диаметор - 17", 450);
        Podpunkt bolsh = new Podpunkt("диаметор - 25", 780);
        
        Punkt razmer = new Punkt();
        razmer.Name = "Размер торта";
        razmer.Podpunkts = new List<Podpunkt> { mal, sred, bolsh };
        
        Podpunkt sladk = new Podpunkt("Ягодный вкус", 10);
        Podpunkt kislii = new Podpunkt("Кислый вкус", 10);
        Podpunkt ananas = new Podpunkt("Ананасовый вкус", 10);

        Punkt vkys = new Punkt();
        vkys.Name = "Вкусы";
        vkys.Podpunkts = new List<Podpunkt> { sladk, kislii, ananas };

        Podpunkt caramel = new Podpunkt("Карамель", 85);
        Podpunkt shokol = new Podpunkt("Горький шоколад", 10);
        Podpunkt pixeling = new Podpunkt("Пиксели", 10);

        Punkt glazur = new Punkt();
        glazur.Name = "Глазурь";
        glazur.Podpunkts = new List<Podpunkt> { caramel, shokol, pixeling };

        Podpunkt posipca = new Podpunkt("Посыпка", 60);
        Podpunkt steclo = new Podpunkt("Секрет", 20);
        Podpunkt krugoch = new Podpunkt("Шарики", 50);

        Punkt decor = new Punkt();
        decor.Name = "Декор";
        decor.Podpunkts = new List<Podpunkt> { posipca, steclo, krugoch };

        List<Punkt> punkts = new List<Punkt> { forma, razmer, kolichestvo, vkys, glazur, decor };

        int pos = 0;
        int pos1 = 0;
        Menu(punkts, pos, pos1);
    }
    static void Menu(List<Punkt> punkts, int pos, int pos1)
    {
         foreach (Punkt item in punkts)
         {
             Console.WriteLine("\t" + item.Name);   
         }
        //вывод
        Console.WriteLine("\t" + "Сохранить заказ");
        Console.WriteLine("\t" + "Итоговая цена: " + С_Вас);
        pos = Arrow(punkts, pos, pos1);
        Arrow(punkts, pos, pos1);         
    }
    static void Pod_Menu(List<Punkt> punkts, int pos, int pos1)
    {
        foreach (Podpunkt podpunkt in punkts[pos].Podpunkts)
        {
            Console.WriteLine("\t" + podpunkt.Name + " - " + podpunkt.Price);
        }
        Pod_Arrow(punkts, pos, pos1);
        //действие добавления в файл
        Menu(punkts, pos, pos1);
    }
    static int Arrow(List<Punkt> punkts, int pos, int pos1)
    {
 
        //действия для стрелочки
        Console.SetCursorPosition(0, pos);
        Console.WriteLine("->");
        ConsoleKeyInfo key = Console.ReadKey();
        while (key.Key != ConsoleKey.Enter)
        {
            if (key.Key == ConsoleKey.UpArrow)
                pos--;
            else if (key.Key == ConsoleKey.DownArrow)
                pos++;
            if (pos == -1)
                pos = 6;
            else if (pos == 7)
                pos = 0;

            Console.Clear();

            if (pos == 6) Zagruz_In_File();
            
            Menu(punkts, pos, pos1);
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("->");
            key = Console.ReadKey();
            
        }
        Console.Clear();
        Pod_Menu(punkts, pos, pos1);
        return pos;
    }
    static int Pod_Arrow(List<Punkt> punkts, int pos, int pos1)
    {
        //действия для под стрелочки
        Console.SetCursorPosition(0, pos1);
        Console.WriteLine("->");
        ConsoleKeyInfo key = Console.ReadKey();
        while (key.Key != ConsoleKey.Enter)
        {
            if (key.Key == ConsoleKey.UpArrow)
                pos1--;
            else if (key.Key == ConsoleKey.DownArrow)
                pos1++;
            if (pos1 == -1)
                pos1 = 2;
            else if (pos1 == 3)
                pos1 = 0;

            ClearArrows();
            Console.SetCursorPosition(0, pos1);
            Console.WriteLine("->");
            key = Console.ReadKey();
        }
        Console.Clear();
        //Добавление данных в переменные для вывода
        С_Вас += punkts[pos].Podpunkts[pos1].Price;
        В_Итоге += punkts[pos].Podpunkts[pos1].Name + ", ";
        return pos1;
    }

    static void ClearArrows()
    {
        for (int i = 0; i < 4; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine("  ");
        }
    }
    static void Zagruz_In_File()
    {
        Console.WriteLine("Заказ принят, ожидайте!\nНажмите любую клавишу, если желаете сделать еще один заказ\n<3");
        Zagruzka Файл = new();
        Файл.V_Itoge = В_Итоге;
        Файл.S_Vas = С_Вас;
        Файл.file();
        В_Итоге = "";
        С_Вас = 0;
        ConsoleKeyInfo key = Console.ReadKey();
        Console.Clear();
        Main();
    }
}