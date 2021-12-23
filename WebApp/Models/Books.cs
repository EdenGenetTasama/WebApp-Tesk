using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Books
    {

        public string Name;
        public string writter;
        public int yearOfOut;
        public int numberOfPage;
        public int id;

        public Books(string _name, string _writter, int _yearOfOut, int _numberPages, int _id)
        {
            this.id = _id;
            this.Name = _name;
            this.writter = _writter;
            this.yearOfOut = _yearOfOut;
            this.numberOfPage = _numberPages;
        }
        public Books()
        {

        }
    }
}