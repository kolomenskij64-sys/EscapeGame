using System;

class EscapeRoom
{
    static string playerName;
    static bool hasArtifact1 = false;
    static bool hasArtifact2 = false;
    static bool hasArtifact3 = false;
    static bool statueActivated = false;
    static bool hasKey = false;
    static bool boxOpened = false;
    static bool hasPicklock = false;
    static int ventilationAttempts = 0;

    static void Main()
    {
        Console.WriteLine("Ты проснулся в странной комнате и пытаешься вспомнить имя");
        Console.Write("Введите имя персонажа: ");
        playerName = Console.ReadLine();

        Console.WriteLine($"\nПривет, {playerName}! добро пожаловать.\n");


        while (true)
        {
            ShowOptions();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TryOpenDoor();
                    break;
                case "2":
                    LookUnderBed();
                    break;
                case "3":
                    OpenBox();
                    break;
                case "4":
                    OpenVentilation();
                    break;
                case "5":
                    LookAtNightstand();
                    break;
                case "6":
                    LookAtStatue();
                    break;
                default:
                    Console.WriteLine(" Выберите действие 1 - 6.");
                    break;
            }
            if (HasEscaped())
                break;
        }
    }

    static void ShowOptions()
    {
        Console.WriteLine("\nЧто ты хочешь сделать?");
        Console.WriteLine("1. Открыть дверь");
        Console.WriteLine("2. Посмотреть под кровать");
        Console.WriteLine("3. Открыть ящик");
        Console.WriteLine("4. Открыть вентиляцию");
        Console.WriteLine("5. Взглянуть на тумбочку");
        Console.WriteLine("6. Посмотреть на статую");
        Console.Write("Выберите действие (1-6): ");
    }

    static void TryOpenDoor()
    {
        if (!hasPicklock)
        {
            Console.WriteLine("Дверь закрыта, тебе нужен ключ");
            return;
        }

        Console.WriteLine("Ты использовал ключ и открыл дверь...");
        Console.WriteLine($"Поздравляем, {playerName}!Ты выбрался из комнаты.!");
    }

    static void LookUnderBed()
    {
        if (!hasArtifact1)
        {
            hasArtifact1 = true;
            Console.WriteLine($"{playerName}, Ты нашел первый артефакт под кроватью.");
        }
        else
        {
            Console.WriteLine("Ничего под кроватью нет.");
        }
    }

    static void OpenBox()
    {
        if (!hasKey)
        {
            Console.WriteLine("ящик закрыт, найдите ключ");
            return;
        }

        if (!boxOpened)
        {
            boxOpened = true;
            hasPicklock = true;
            Console.WriteLine($"{playerName},Вы открыли ящик, взяли ключ и открыли дверь");
        }
        else
        {
            Console.WriteLine("Ящик уже открыт ничего внутри нет");
        }
    }

    static void OpenVentilation()
    {
        if (!hasArtifact2)
        {
            ventilationAttempts++;
            if (ventilationAttempts < 3)
            {
                Console.WriteLine("Вентиляция еще закрыта, попробуйте открыть еще раз .");
            }
            else
            {
                hasArtifact2 = true;
                Console.WriteLine($"{playerName},Вы открыли вентиляцию и нашли второй артефакт");
            }
        }
        else
        {
            Console.WriteLine("Вентиляция открыта, но внутри ничего нет.");
        }
    }

    static void LookAtNightstand()
    {
        if (!hasArtifact3)
        {
            hasArtifact3 = true;
            Console.WriteLine($"{playerName}, Вы нашли третий артефакт на тубочке.");
        }
        else
        {
            Console.WriteLine("Ничего нового на тумбочке не появилось.");
        }
    }

    static void LookAtStatue()
    {
        if (statueActivated)
        {
            Console.WriteLine("Статуя дала вам ключ от ящика.");
            return;
        }

        if (hasArtifact1 && hasArtifact2 && hasArtifact3)
        {
            statueActivated = true;
            hasKey = true;
            Console.WriteLine($"{playerName},Активировав статую тремя артефактами, вы получили ключ от ящика.");
        }
        else
        {
            Console.WriteLine("Статуя выглядит загадочно. Похоже, для её активации требуется три артефакта..");
        }
    }

    static bool HasEscaped()
    {
        return hasPicklock && Console.ReadLine().Trim() == "1" && hasPicklock;
    }
}