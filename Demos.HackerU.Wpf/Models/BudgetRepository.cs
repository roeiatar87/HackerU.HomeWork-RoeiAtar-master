using Demos.HackerU.HomeWork.HW_18.Ef;
using Demos.HackerU.HomeWork.Inhheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.Wpf.Models
{
    public class BudgetRepository
    {
        private static BudgetRepository Instance = null;
        private BudgetRepository()
        {

        }

        public static BudgetRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BudgetRepository();
            }
            return Instance;
        }

        public int AddNewBudget(Budget budget)
        {

            using (BudgetContext Db = new BudgetContext())
            {
                Db.budgets.Add(budget);
                return Db.SaveChanges();
            }

        }

        public List<Budget> GetAllBudgets()
        {
            var list = new List<Budget>();
            using (BudgetContext Db = new BudgetContext())
            {
                list = Db.budgets.ToList();
                return list;
            }
        }

        public int DeletetBudget(Budget budget)
        {

            using (BudgetContext Db = new BudgetContext())
            {
                Db.budgets.Remove(budget);
                return Db.SaveChanges();
            }

        }


    }
}
