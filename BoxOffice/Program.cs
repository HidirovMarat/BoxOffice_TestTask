
class Program
{
    const int onePoundEqualShilling = 20;
    const int oneShillingEqualPence = 12;

    public static int GetPoundToPence(int pound)
    {
        return pound * onePoundEqualShilling * oneShillingEqualPence;
    }

    public static int GetShillingToPence(int shilling)
    {
        return shilling * oneShillingEqualPence;
    }

    public static int GetAllPence(int pounds, int shillings, int pence)
    {
        return GetPoundToPence(pounds) + GetShillingToPence(shillings) + pence; 
    }

    public static bool IsCorrect(int number)
    {
        return number >= 0;
    }

    public static void Update(ref int pounds, ref int shillings, ref int pence)
    {
        string[] input = Console.ReadLine().Split(' ');
        while (true)
        {
            bool isCorrect = true;
            try
            {
                pounds = int.Parse(input[0]);
                shillings = int.Parse(input[1]);
                pence = int.Parse(input[2]);

                if (!(IsCorrect(pounds) && IsCorrect(pence) && IsCorrect(shillings)))
                {
                    Console.WriteLine("Стоимость не могут быть отрицательными!Повторите");
                    isCorrect = false;
                }
            }
            catch
            {
                Console.WriteLine("Ввод не корректный, повторите");
                isCorrect = false;
            }
            
            if (isCorrect)
                break;
            input = Console.ReadLine().Split(' ');
        }
    }
    static void Main(string[] args)
    {
        // Ввод данных от пользователя
        Console.Write("Введите стоимость товара (фунты шиллинги пенсы): ");     
        int costPounds = -1;
        int costShillings = -1;
        int costPence = -1;
        Update(ref costPounds, ref costShillings, ref costPence);

        Console.Write("Введите сумму, которую дает покупатель (фунты шиллинги пенсы): ");
        int paymentPounds = -1;
        int paymentShillings = -1;
        int paymentPence = -1;
        Update(ref paymentPounds, ref paymentShillings, ref paymentPence);


        if (GetAllPence(costPounds, costShillings, costPence) > GetAllPence(paymentPounds, paymentShillings, paymentPence))
        {
            Console.WriteLine("Ошибка");
            return;
        }
        if (GetAllPence(costPounds, costShillings, costPence) == GetAllPence(paymentPounds, paymentShillings, paymentPence))
        {
            Console.WriteLine("Нет сдачи");
            return;
        }
        int change = GetAllPence(paymentPounds, paymentShillings, paymentPence) - GetAllPence(costPounds, costShillings, costPence);
        // Подсчет сдачи
        int changePounds = change / GetPoundToPence(1);
        change -= GetPoundToPence(changePounds);
        int changeShillings = change / GetShillingToPence(1);
        change -= GetShillingToPence(changeShillings);
        int changePence = change;
        // Проверка
        if (GetAllPence(paymentPounds, paymentShillings, paymentPence) - GetAllPence(costPounds, costShillings, costPence) == GetAllPence(changePounds, changeShillings, changePence))
            Console.WriteLine($"Фунты - {changePounds}, Шиллинги - {changeShillings}, Пенсы - {changePence}");
    }
}
