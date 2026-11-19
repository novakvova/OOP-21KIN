using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM.Models;

//Цея модель буде вміти реагувати на зміни 
//Підтримується можливість зміни влативостей - Property
public class UserVM : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string _name;
    private string _image;
    private string _phone;
    public string Name
    {
        get { return _name; }
        set
        {
            if(_name!=value)
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name)); //Повідомляє, що відбулися зміни
            }
        }
    }

    public string Image
    {
        get { return _image; }
        set
        {
            if (_image != value)
            {
                _image = value;
                NotifyPropertyChanged(nameof(Image)); //Повідомляє, що відбулися зміни
            }
        }
    }

    public string Phone
    {
        get { return _phone; }
        set
        {
            if (_phone != value)
            {
                _phone = value;
                NotifyPropertyChanged(nameof(Phone)); //Повідомляє, що відбулися зміни
            }
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    public void NotifyPropertyChanged(string propName)
    {
        //Якщо хто підписався на подію, то ми будемо його повідоляти про зміни
        PropertyChanged?
            .Invoke(this, new PropertyChangedEventArgs(propName));
    }

}
