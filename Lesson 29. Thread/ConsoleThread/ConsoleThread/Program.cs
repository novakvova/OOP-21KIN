// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Привіт! Козаки і козячки працюємо із потоками");

int threadId = Thread.CurrentThread.ManagedThreadId;

Console.WriteLine("Ідентифікатор осоного потоку: " + threadId);

Directory.CreateDirectory("cats");

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

Thread[] threads = new Thread[10];

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(MyThreadYellow);
    threads[i].Start();

}
//Створили новий потік
//Thread myThread = new Thread(MyThreadYellow);
//myThread.Start(); //Запустили новий потік

string imageUrl = "https://i.pravatar.cc/1200";

for (int i = 0; i < 10; i++)
{
    //Console.WriteLine($"i = {i+1}");
    HttpClient client = new HttpClient();
    var bytes = client.GetByteArrayAsync(imageUrl).Result;
    string file = Path.Combine("cats", Guid.NewGuid().ToString() + ".jpg");
    File.WriteAllBytes(file, bytes);
    Console.WriteLine($"Завантажено фото {i+1}");

    //Thread.Sleep(1000); //Затримка на 1 секунду
}

Console.WriteLine("Програма завершила роботу");

stopWatch.Stop();
// Get the elapsed time as a TimeSpan value.
TimeSpan ts = stopWatch.Elapsed;

// Format and display the TimeSpan value.
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);
Console.WriteLine("RunTime " + elapsedTime);

void MyThreadYellow()
{
    string imageUrl = "https://i.pravatar.cc/1200";
    for (int i = 0; i < 10; i++)
    {
        //Console.WriteLine($"i = {i + 1}");
        HttpClient client = new HttpClient();
        var bytes = client.GetByteArrayAsync(imageUrl).Result;
        string file = Path.Combine("cats", "2-"+Guid.NewGuid().ToString() + ".jpg");
        File.WriteAllBytes(file, bytes);
        Console.WriteLine($"2. -- Завантажено фото {i + 1}");
    }
}
