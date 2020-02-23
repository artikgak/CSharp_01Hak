using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KMACSharp01Hak.Tools;
using KMACSharp01Hak.Tools.Managers;
using KMACSharp01Hak.Tools.MVVM;

namespace KMACSharp01Hak.ViewModels.DatePicker
{
    internal class DateViewModel : BaseViewModel
    {
        #region Fields

        private DateTime _userPickedDate = DateTime.Today;
        private string _age;
        private string _westernZodiac;
        private string _chineseZodiac;

        #region Commands
        private RelayCommand<object> _selectDateCommand;
        #endregion

        #endregion

        #region Properties

        public DateTime UserPickedDate
        {
            get { return _userPickedDate; }
            set
            {
                _userPickedDate = value;
                OnProperyChanged();
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnProperyChanged();
            }
        }
        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set
            {
                _westernZodiac = value;
                OnProperyChanged();
            }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                _chineseZodiac = value;
                OnProperyChanged();
            }
        }

        #region Commands

        public RelayCommand<object> SelectDateCommand
        {
            get
            {
                return _selectDateCommand ?? (_selectDateCommand = new RelayCommand<object>(
                           SelectDateImplementation));
            }
        }

        #endregion

        #endregion

        private async void SelectDateImplementation(object o)
        {
            //loader
            Age = "";
            WesternZodiac = "";
            ChineseZodiac = "";
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    try
                    {
                        ComputeAge();
                        ComputeWesternZodiak();
                        ComputeChineseZodiak();
                        CheckBirthDay();
                    }
                    catch (InvalidDataException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            );
            LoaderManager.Instance.HideLoader();
        }

        private void CheckBirthDay()
        {
            if (UserPickedDate.Month == DateTime.Today.Month && UserPickedDate.Day == DateTime.Today.Day)
            {
                MessageBox.Show("Happy Birthday! Have a nice day");
            }
        }

        private void ComputeAge()
        {
            DateTime today = DateTime.Today;
            int res = today.Year - UserPickedDate.Year;
            if (UserPickedDate.Month > today.Month ||
                (UserPickedDate.Month == today.Month && UserPickedDate.Day > today.Day))
                --res;
            if (res >= 0 && res <= 135)
                Age = $"Age: {res}";
            else
                throw new InvalidDataException("Invalid date picked");
        }

        private void ComputeWesternZodiak()
        {
            if ((UserPickedDate.Month == 1 && UserPickedDate.Day >= 21) ||
                (UserPickedDate.Month == 2 && UserPickedDate.Day <= 20))
            {
                WesternZodiac = "Western sign: Aquarius";
                return;
            }
            if ((UserPickedDate.Month == 2 && UserPickedDate.Day >= 21) ||
                (UserPickedDate.Month == 3 && UserPickedDate.Day <= 20))
            {
                WesternZodiac = "Western sign: Pisces";
                return;
            }
            if ((UserPickedDate.Month == 3 && UserPickedDate.Day >= 21) ||
                (UserPickedDate.Month == 4 && UserPickedDate.Day <= 20))
            { 
                WesternZodiac = "Western sign: Aries";
                return;
            }

            if ((UserPickedDate.Month == 4 && UserPickedDate.Day >= 21) ||
                (UserPickedDate.Month == 5 && UserPickedDate.Day <= 20))
            {
                WesternZodiac = "Western sign: Taurus";
                return;
            }
            if ((UserPickedDate.Month == 5 && UserPickedDate.Day >= 21) ||
                (UserPickedDate.Month == 6 && UserPickedDate.Day <= 21))
            {
                WesternZodiac = "Western sign: Gemini";
                return;
            }
            if ((UserPickedDate.Month == 6 && UserPickedDate.Day >= 22) ||
                (UserPickedDate.Month == 7 && UserPickedDate.Day <= 22))
            {
                WesternZodiac = "Western sign: Cancer";
                return;
            }
            if ((UserPickedDate.Month == 7 && UserPickedDate.Day >= 23) ||
                (UserPickedDate.Month == 8 && UserPickedDate.Day <= 23))
            {
                WesternZodiac = "Western sign: Leo";
                return;
            }
            if ((UserPickedDate.Month == 8 && UserPickedDate.Day >= 24) ||
                (UserPickedDate.Month == 9 && UserPickedDate.Day <= 23))
            {
                WesternZodiac = "Western sign: Virgo";
                return;
            }
            if ((UserPickedDate.Month == 9 && UserPickedDate.Day >= 24) ||
                (UserPickedDate.Month == 10 && UserPickedDate.Day <= 22))
            {
                WesternZodiac = "Western sign: Libra";
                return;
            }
            if ((UserPickedDate.Month == 10 && UserPickedDate.Day >= 23) ||
                (UserPickedDate.Month == 11 && UserPickedDate.Day <= 22))
            {
                WesternZodiac = "Western sign: Scorpio";
                return;
            }
            if ((UserPickedDate.Month == 11 && UserPickedDate.Day >= 23) ||
                (UserPickedDate.Month == 12 && UserPickedDate.Day <= 21))
            {
                WesternZodiac = "Western sign: Sagittarius";
                return;
            }
            if ((UserPickedDate.Month == 12 && UserPickedDate.Day >= 22) ||
                (UserPickedDate.Month == 1 && UserPickedDate.Day <= 20))
            {
                WesternZodiac = "Western sign: Capricorn";
            }
        }

        //[Jan21 to Feb20] there's 31 days, so the middle is 16th day. It's 5 Feb. So assume each year starts at 5 Feb.
        private void ComputeChineseZodiak()
        {
            int year = UserPickedDate.Year;
            if (UserPickedDate.Month <= 2 && UserPickedDate.Day < 5)
                --year;
            ChineseZodiac = $"Chinese zodiak: {ChineseElemental(year)} {ChineseAnimal(year)}";
        }

        private string ChineseElemental(int year)
        {
            switch (year%10)
            {
                case 0:
                case 1:
                    return "Metal";
                case 2:
                case 3:
                    return "Water";
                case 4:
                case 5:
                    return "Wood";
                case 6:
                case 7:
                    return "Fire";
                case 8:
                    return "Earth";
                default:
                    return "Earth";
            }
        }

        private string ChineseAnimal(int year)
        {
            switch (year%12)
            {
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "Monkey";
            }
        }

    }
}
