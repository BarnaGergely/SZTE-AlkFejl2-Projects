using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.Model;

namespace WinFormsApp.DAO
{
    internal class AppDAO
    {
        private List<string> categories = new List<string>();
        private List<Pet> pets = new List<Pet>();

        public bool AddCategory(string category) {
            if (categories.Contains(category)) {
                return true;
            }
            categories.Add(category);
            return false;
        }

        public string[] GetCategories()
        {
            return categories.ToArray();
        }
    }
}
