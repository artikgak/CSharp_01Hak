using System;

namespace _01Hak.Models
{
    internal class User

    {
        private int _age;
        private DateTime _date;
        private String _westernZodiak;
        private String _chineseZodiak;

        #region Properties
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        public String WesternZodiak
        {
            get
            {
                return _westernZodiak;
            }
            set
            {
                _westernZodiak = value;
            }
        }
        public String ChineseZodiak
        {
            get
            {
                return _chineseZodiak;
            }
            set
            {
                _chineseZodiak = value;
            }
        }
        #endregion
    }
}
