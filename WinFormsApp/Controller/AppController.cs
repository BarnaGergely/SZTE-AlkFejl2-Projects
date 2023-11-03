using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.DAO;

namespace WinFormsApp.Controller
{
    public class AppController
    {
        AppDAO dao;
        public AppController(AppDAO dao) 
        { 
            this.dao = dao;
        }

        public bool AddCategory(string categoryName) 
        {
            return dao.AddCategory(categoryName);
        }
        public string[] GetCategories()
        {
            return new string[0];
        }


    }
}
