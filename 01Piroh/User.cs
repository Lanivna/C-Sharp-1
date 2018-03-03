using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace _01Piroh
{

    class User
    {
        private DateTime _dateOfBirth;
        private int _age;
        private string _western;
        private string _chinese;


        public User(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            _age = AgeCount();
            _western = WesternZodiac();
            _chinese = ChineseZodiac();
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            private set { _dateOfBirth = value; }

        }

        public int  AgeCount ()
        {
            DateTime today = DateTime.Today;
            int _age = today.Year - _dateOfBirth.Year;
            
            if ((_dateOfBirth.Month > DateTime.Today.Month) ||
                     (_dateOfBirth.Month == DateTime.Today.Month && _dateOfBirth.Day > DateTime.Today.Day))
            { _age--; }
            if ((_age<0) || (_age > 135))
            {
                string message = "You didn't enter your birthday right.";
                string caption = "Something doesn't seem right!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxResult result;

                result = MessageBox.Show(message, caption, button);
               
            }


        
             return _age;
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Western
        {
            get { return _western; }
            set { _western = value;  }
        }

        public string Chinese
        {
            get { return _chinese; }
            set { _chinese = value; }
        }

        private string WesternZodiac()
        {
            if (((_dateOfBirth.Month == 3) && (_dateOfBirth.Day >= 21 || _dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 4) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 20)))
            {
                return "Aires";
            }
            if (((_dateOfBirth.Month == 4) && (_dateOfBirth.Day >= 21 || _dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 5) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 21)))
            {
                return "Taurus";
            }

            if (((_dateOfBirth.Month == 5) && (_dateOfBirth.Day >= 21 || _dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 6) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 21)))
            {
                return "Gemini";
            }
            if (((_dateOfBirth.Month == 6) && (_dateOfBirth.Day >= 22 || _dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 7) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 22)))
            {
                return "Cancer";
            }
            if (((_dateOfBirth.Month == 7) && (_dateOfBirth.Day >= 23 || _dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 8) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 22)))
            {
                return "leo";
            }
            if (((_dateOfBirth.Month == 8) && (_dateOfBirth.Day >= 23 || _dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 9) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 21)))
            {
                return "Virgo";
            }
            if (((_dateOfBirth.Month == 9) && (_dateOfBirth.Day >= 22 || _dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 10) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 22)))
            {
                return "Libra";
            }
            if (((_dateOfBirth.Month == 10) && (_dateOfBirth.Day >= 23 || _dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 11) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 21)))
            {
                return "Scorpio";
            }
            if (((_dateOfBirth.Month == 11) && (_dateOfBirth.Day >= 22 || _dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 12) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 21)))
            {
                return "Sagittarius";
            }
            if (((_dateOfBirth.Month == 12) && (_dateOfBirth.Day >= 22 || _dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 1) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 20)))
            {
                return "Capricorn";
            }
            if (((_dateOfBirth.Month == 1) && (_dateOfBirth.Day >= 21 || _dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 2) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 19)))
            {
                return "Aquarius";
            }
            if (((_dateOfBirth.Month == 2) && (_dateOfBirth.Day >= 20 || _dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 3) && (_dateOfBirth.Day >= 01 || _dateOfBirth.Day <= 20)))
            {
                return "Pisces";
            }
            else
            {
                return "";
            }
        }

        private string ChineseZodiac()
        {
            switch ((_dateOfBirth.Year - 4) % 12)
            {
                case 0:
                    return "Rat";
                    break;
                case 1:
                    return "Ox";
                    break;
                case 2:
                    return "Tiger";
                    break;
                case 3:
                    return "Rabbit";
                    break;
                case 4:
                    return "Dragon";
                    break;
                case 5:
                    return "Snake";
                    break;
                case 6:
                    return "Horse";
                    break;
                case 7:
                    return "Goat";
                    break;
                case 8:
                    return "Monkey";
                    break;
                case 9:
                    return "Rooster";
                    break;
                case 10:
                    return "Do";
                    break;
                case 11:
                    return "Pig";
                    break;

                default:
                    return " ";
                    break;
            }
        }


}
}
