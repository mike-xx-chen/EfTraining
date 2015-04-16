using MyCompany.EfTraining.BusinessComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.EfTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var logic = new TodoItemLogic();
            logic.InitializeDb();
            var list = logic.GetAll();
            var first = logic.GetFirst();
            var last = logic.GetLast();
            var def = logic.GetDefault();
            var item = logic.Search("1 2 3");
        }
    }
}
