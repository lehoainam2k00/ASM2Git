using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2Final
{
    public class Individual
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        List<Individual> individual = new List<Individual>();
        public Individual()
        {

        }
        public Individual(string ID, string Name, DateTime DoB, string Email, string Address)
        {
            this.ID = ID;
            this.Name = Name;
            this.DateOfBirth = DoB;
            this.Email = Email;
            this.Address = Address;
        }


        //ADD
        public virtual void AddNew()
        {
            Check check = new Check();
            while(true)
            {
                Console.WriteLine("Enter the Student ID('GTxxxx' or 'GXxxxx' x: is a digit): ");
                string importID = Console.ReadLine();
                if (check.CheckID(importID)>-1)
                {
                    this.ID = importID;
                    break;
                }
                else
                {
                    Console.WriteLine("The Student ID must start with 'GTxxxxx' or 'GXxxxxx'(x: is a digit)!!! ");
                }
            }
            Console.WriteLine("Enter the Student Name: ");
            this.Name = Console.ReadLine();
            Console.WriteLine("Enter Date of birth: ");
            this.DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/mm/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
            while (true)
            {
                Console.WriteLine("Enter the Student Email: ");
                string importEmail = Console.ReadLine();
                if (check.CheckGmail(importEmail) > -1)
                {
                    this.Email = importEmail;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong!!!!!!!!");
                }
            }
            Console.WriteLine("Enter Address: ");
            this.Address = Console.ReadLine();
        }


        //VIEW
        public virtual void ViewAll()
        {
            if(individual != null)
            {
                foreach(Individual I in individual)
                {
                    Console.WriteLine(I.ID + "   |   " + I.Name + "   |   " + I.DateOfBirth + "   |   " + I.Email + "   |   " + I.Address + "   |   ");
                }
            }
            else
            {
                Console.WriteLine("NULL!!!");
                return;
            }
        }



        //SEARCH
        public int Search(string type,string action,List<Individual>individual)
        {
            Console.WriteLine("Enter ID of " + type + " you want to " + action + ": ");
            string keyword = Console.ReadLine();
            int Outcome = 0;
            foreach(Individual I in individual)
            {
                if(I.ID == keyword)
                {
                    Outcome = individual.IndexOf(I);
                }
            }
            return Outcome;
        }
        public void PrintSearch(string type, List<Individual>individual)
        {
            int result = Search(type, "Search", individual);
            if (result != 0)
            {
                Console.WriteLine(individual[result].ID + individual[result].Name + individual[result].DateOfBirth + individual[result].Email + individual[result].Address);
            }
        }


        //DELETE
        public void Delete(string type, List<Individual> individual)
        {
            int result = Search(type, "Delete", individual);
            string temp = individual[result].ID;
            Console.WriteLine("Press 'y' if you would like to delete" + temp);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if(keyInfo.Key.ToString()=="y")
            {
                individual.RemoveAt(result);
                Console.WriteLine("Delete sucessfully!!!");
            }
            else
            {
                Console.WriteLine("Cancel!!!");
            }
        }



        //UPDATE
        public void Update(string type, List<Individual> individual)
        {
            int result = Search(type, "Delete", individual);
            string temp = individual[result].ID;
            string str0 = individual[result].Name + "" + individual[result].DateOfBirth + "" + individual[result].Email + "" + individual[result].Address;
            string str1 = "";
            string[] input = new string[5];
            if (result > -1)
            {
                Console.WriteLine("Enter Changed Name: ");
                input[1] = Console.ReadLine();
                Console.WriteLine("Enter Changed DoB: ");
                input[2] = Console.ReadLine();
                Console.WriteLine("Enter Changed E-Mail: ");
                input[3] = Console.ReadLine();
                Console.WriteLine("Enter Changed Address: ");
                input[4] = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Not Exist!!!");
            }
            for (int i = 0; i < 4; i++)
            {
                if ((input[i] != null) && (input[i] != ""))
                {
                    individual[result].Name = input[1];
                    individual[result].DateOfBirth = DateTime.ParseExact(input[2], "dd/mm/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                    individual[result].Email = input[3];
                    str1 = individual[result].Name + "" + individual[result].DateOfBirth + "" + individual[result].Email + "" + individual[result].Address;
                }
            }
        }



    }
}
