using System.Data;
using AdoNet;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


//var builder = new ConfigurationBuilder();
//builder.SetBasePath(Directory.GetCurrentDirectory());
//builder.AddJsonFile("appsettings.json");
//var config = builder.Build();
//var connectionString = config.GetConnectionString("DefaultConnection");


using (ApplicationContext db = new ApplicationContext()) // Добавление
{
    bool isAvailable = db.Database.CanConnect(); // Проверяет доступна ли БД
    Book HPS = new Book { AuthorId = 3, Title = "Гарри потер и Принц Персии", Price = 1850, Pages = 800 };
    Book HPB = new Book { AuthorId = 3, Title = "Гарри потер и Тараканы в общаге", Price = 100, Pages = 100 };

    //db.Books.Add(HPS);// по отдельности
    //db.Books.Add(HPB);
    db.Books.AddRange(HPS, HPB); // Всё вместе
    db.SaveChanges();
    Console.WriteLine("объекты успешно сохранены");
}
using (ApplicationContext db = new ApplicationContext())  // Получение \ чтение
{

    var books = db.Books.ToList();
    Console.WriteLine("Список Объектов: ");
    foreach (Book b in books)
    {
        Console.WriteLine($"{b.Id}. {b.Title} - {b.Price} руб.");
    }

    Console.WriteLine();
    var authors = db.Authors.ToList();
    Console.WriteLine("Список Объектов авторов: ");
    foreach (Author a in authors)
    {
        Console.WriteLine($"{a.Id}. {a.FirstName} {a.LastName}.");
    }
}
//using (ApplicationContext db = new ApplicationContext()) // Редактирование
//{
//    Book? book = db.Books.FirstOrDefault();
//    if (book != null)
//    {
//        book.AuthorId = 1; //обновили объект
//        db.Books.Update(book);
//        db.SaveChanges();
//    }
//    Console.WriteLine("\n Данные после редактирования: ");
//    var books = db.Books.ToList();
//    foreach (Book b in books)
//        Console.WriteLine($"{b.Id}. {b.Title} - {b.Price} руб.");
//}
//using (ApplicationContext db = new ApplicationContext()) // Удаление
//{
//    Book? book = db.Books.Find(104);
//    if (book != null)
//    {
//        db.Books.Remove(book);
//        db.SaveChanges();
//    }
//    Console.WriteLine("\n Данные после редактирования: ");
//    var books = db.Books.ToList();
//    foreach (Book b in books)
//        Console.WriteLine($"{b.Id}. {b.Title} - {b.Price} руб.");
//}



