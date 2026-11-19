// Probe.Run();

Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артём", 120);
Hero alexander = new Hero("   Александр   ", 150);
Hero sergey = new Hero("Сергей", 110);

alexander.TakeDamage(10);
alexander.Heal(10);

Guild guild = new Guild("Гильдия героев");
guild.AddHero(yaroslav);
guild.AddHero(anastasia);
guild.AddHero(artem);
guild.AddHero(alexander);
guild.AddHero(sergey);

Console.WriteLine($">>> {guild.Name}: участников {guild.MemberCount} <<<");
Console.WriteLine();

QuestBoard board = new QuestBoard(guild);

Quest floatQuest = new Quest(101, "Вернуть поплавок", 100, 30);
Console.WriteLine($"Поручение добавлено: {board.AddQuest(floatQuest)}");
Console.WriteLine($">>> №{floatQuest.Id}: {floatQuest.Title} <<<");

Console.WriteLine($"Назначение Сергея: {board.TryAssign(101, " сЕрГеЙ ")}");
Hero? assigned = floatQuest.AssignedHero;
if (assigned != null) {
    Console.WriteLine($"Исполнитель: {assigned.Name}");
}
Console.WriteLine($"Опыт после назначения: {sergey.Experience}");

Console.WriteLine($"Завершение: {board.TryComplete(101)}");
Console.WriteLine($"Опыт после завершения: {sergey.Experience}");
Console.WriteLine($"Повторное завершение: {board.TryComplete(101)}");
Console.WriteLine($"Опыт после повтора: {sergey.Experience}");

Console.WriteLine();
Console.WriteLine(floatQuest.GetInfo());
Console.WriteLine(sergey.GetInfo());

Console.WriteLine("\n Личный проект: Заказ товара ");
Warehouse warehouse = new Warehouse("Основной склад");
warehouse.AddProduct(new Product("Ноутбук", 5, 65000));

Product? laptop = warehouse.FindProductByTitle("ноутбук");
if (laptop != null) {
    Order failOrder = new Order(1, 10);
    Console.WriteLine($"Заказ на 10 шт. (отказ): {failOrder.TryStart(laptop)}");

    Order order = new Order(2, 2);
    Console.WriteLine($"Старт заказа №2 на 2 шт.: {order.TryStart(laptop)}");
    Console.WriteLine($"Завершение заказа №2: {order.TryFinish()}");
    Console.WriteLine($"Повторное завершение №2: {order.TryFinish()}");

    Product? updated = warehouse.FindProductByTitle("Ноутбук");
    if (updated != null) {
        Console.WriteLine($"Остаток товара «{updated.Title}» на складе: {updated.Quantity}");
    }
}
