namespace MyBogusRandom;

class Laptop
{
    //процесор
    public string CPU { get; set; } = null!;
    //оперативна пам'ять
    public int RAM { get; set; } //в гігабайтах
    //розмір ssd диску
    public int SSD { get; set; } //в гігабайтах
    //діагональ екрану
    public double ScreenSize { get; set; } //в дюймах
    //Бренд ноутбука
    public string Brand { get; set; } = null!;
    //Модель ноутбука
    public string Model { get; set; } = null!;
    //Ціна ноутбука
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"Brand: {Brand}\nModel: {Model}\nCPU: {CPU}\nRAM: {RAM} GB\nSSD: {SSD} GB\nScreen Size: {ScreenSize}\"\nPrice: {Price:C}";
    }
}
