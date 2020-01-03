using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2Final
{
    public class Menu
    {
        Check check = new Check();
        Student student = new Student();
        Lecture lecture = new Lecture();
        List<Individual> I = new List<Individual>();


        public void MainMenu()
        {
            Console.WriteLine("***************Student,Lecture Management System*****************");
            Console.WriteLine("* 1. Manage Student");
            Console.WriteLine("* 2. Manage Lecturer");
            Console.WriteLine("* 3. Exit Program!!!");
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("                      -->  Enter Choice:  <--                    ");
        }


        public void MainMenuFuntion()
        {
            int input = 0;
            while (true)
            {
                MainMenu();
                input = int.Parse(Console.ReadLine());
                if(check.CheckInputValidation(input.ToString())==true)
                {
                    switch(input)
                    {
                        case 1:
                            StudentFuntion();
                            break;
                        case 2:
                            LectureFuntion();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
        void PrintSubmenu(string menu)
        {
            Console.WriteLine("Manage " + menu + " Funtion");
            Console.WriteLine("***********************************");
            Console.WriteLine("1. Add New " + menu + "");
            Console.WriteLine("2. View All " + menu + "");
            Console.WriteLine("3. Search " + menu + "");
            Console.WriteLine("4. Delete " + menu + "");
            Console.WriteLine("5. Update " + menu + "");
            Console.WriteLine("6. Back to main menu");
            Console.WriteLine("***********************************");
            Console.WriteLine("      -->  Enter Choice:  <--      ");
            Console.Write("Your option is: ");
        }


        void StudentFuntion()
        {
            int input = 0;
            bool f = true;
            while (f)
            {
                
                PrintSubmenu("Student");
                input = int.Parse(Console.ReadLine());
                if (check.CheckInputValidation(input.ToString()) == true)
                {
                    switch(input)
                    {
                        case 1:
                            
                            student.AddStudent(I);
                            break;
                        case 2:
                            
                            student.ViewAllStudents(I);
                            break;
                        case 3:
                            
                            string searchID = Console.ReadLine();
                            student.SearchStudent(searchID, I);
                            break;
                        case 4:
                            
                            string delID = Console.ReadLine();
                            student.DeleteStudent(delID, I);
                            break;
                        case 5:
                            
                            string updateID = Console.ReadLine();
                            student.UpdateStudent(updateID, I);
                            break;
                        case 6:
                            f = false;
                            break;
                    }
                }
            }
        }


        void LectureFuntion()
        {
            int input = 0;
            bool f = true;
            while (f)
            {
                
                PrintSubmenu("Lecture");
                input = int.Parse(Console.ReadLine());
                if (check.CheckInputValidation(input.ToString()) == true)
                {
                    switch (input)
                    {
                        case 1:
                            
                            lecture.AddLecture(I);
                            break;
                        case 2:
                            
                            lecture.ViewAll(I);
                            break;
                        case 3:
                            
                            string searchID = Console.ReadLine();
                            lecture.SearchLecture(searchID, I);
                            break;
                        case 4:
                            
                            string delID = Console.ReadLine();
                            lecture.DeleteLecture(delID, I);
                            break;
                        case 5:
                            
                            string updateID = Console.ReadLine();
                            lecture.UpdateLecture(updateID, I);
                            break;
                        case 6:
                            f = false;
                            break;
                    }
                }
            }
        }
    }
}
