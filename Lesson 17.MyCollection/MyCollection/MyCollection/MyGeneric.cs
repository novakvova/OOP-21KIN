namespace MyCollection;

public class MyGeneric
{
    private object[] _items;

    public MyGeneric()
    {
        //на початку список пустий
        _items = new object[0];
    }
    public void Add(object item) // Додати новий елемент у масив
    {
        int count = _items.Length;
        object[] temp = new object[count + 1];
        //копіюю із одного масиву в інший
        for(int i=0; i<count; i++)
            temp[i] = _items[i];
        temp[count] = item; //зберігаю у кінцець масиву
        _items = temp; //оновляю новим даними старий масив
    }

    public object? Find(object item) //пошук елемента
    {
        foreach(var i in _items)
        {
            if(i is int)
            {
                try
                {
                    int myInt = (int)i;
                    if (myInt == (int)item)
                        return i;
                }
                catch { }
            }
            if(i is Dog)
            {
                try
                {
                    Dog myDog = (Dog)i;
                    Dog searchDog = (Dog)item;
                    if (myDog == searchDog)
                        return i;
                }
                catch { }
            }
            if(i == item) return i;
        }
        return null; 
    }

    public void ViewItems() //відображення колекції
    {
        foreach(object item in _items)
            Console.WriteLine(item);
    }
}
