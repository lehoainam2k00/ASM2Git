using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2Final
{
    public class Lecture : Individual
    {
        public string Dept { get; set; }

        public Lecture() : base()
        { }

        public Lecture(string ID, string Name, DateTime DateOfBirth, string Email, string Address, string LecDept) : base(ID, Name, DateOfBirth, Email, Address)
        {
            this.Dept = LecDept;
        }

        public void AddLecture(List<Individual> lecture)
        {
            base.AddNew();
            Console.WriteLine("Enter Lecture Dept: ");
            if (!lecture.Exists(l => l.ID == this.ID))
            {
                lecture.Add(new Lecture(this.ID, this.Name, this.DateOfBirth, this.Email, this.Address , this.Dept));
            }
        }

        public void ViewAll(List<Individual> lecture)
        {
            if (lecture != null)
            {
                Console.WriteLine("ID   |   Name    |   Address |   Date of birth   |       Email     |   Class ");
                foreach (Individual I in lecture)
                {
                    //Initiate object Student as a Person but still a student
                    Lecture l = I as Lecture;

                    //Print out data
                    Console.WriteLine(l.ID + "| " + l.Name + "| " + l.DateOfBirth + "| " + l.Email + "| " + l.Address + "| " + l.Dept);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("NULL!!!");
                return;
            }
        }


        public void SearchLecture(string key, List<Individual> lecture)
        {
            int searchResult = 0;
            foreach (Individual I in lecture)
            {
                if (I.ID == key)
                {
                    Lecture l = I as Lecture;
                    searchResult = lecture.IndexOf(I);
                    if (searchResult > -1)
                    {
                        Console.WriteLine(lecture[searchResult].ID + " " + lecture[searchResult].Name + " " + lecture[searchResult].DateOfBirth + " " + 
                            lecture[searchResult].Email + " " + lecture[searchResult].Address);
                    }
                    else
                    {
                        Console.WriteLine("There is no lecture with that information!");
                        return;
                    }
                }
            }
        }


        public void DeleteLecture(string key, List<Individual> lecture)
        {
            foreach (Individual I in lecture)
            {
                if (I.ID == key)
                {
                    Lecture l = I as Lecture;
                    lecture.RemoveAt(lecture.IndexOf(I));
                    if (lecture.IndexOf(I) < 0)
                    {
                        Console.WriteLine("Deleted Successfully!!!");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Something Wrongggg!!!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invailid ID!!!");
                    return;
                }
            }
        }


        public void UpdateLecture(string key, List<Individual> lecture)
        {
            string[] editDetail = new string[5];
            Console.WriteLine("Enter Changed Name: ");
            editDetail[1] = Console.ReadLine();
            Console.WriteLine("Enter Changed DoB: ");
            editDetail[2] = Console.ReadLine();
            Console.WriteLine("Enter Changed E-Mail: ");
            editDetail[3] = Console.ReadLine();
            Console.WriteLine("Enter Changed Address: ");
            editDetail[4] = Console.ReadLine();
            foreach (Individual I in lecture)
            {
                if (I.ID == key)
                {
                    Lecture l = I as Lecture;
                    for (int i = 0; i < editDetail.Length; i++)
                    {
                        if ((editDetail[i] != null) && (editDetail[i] != ""))
                        {
                            l.Name = editDetail[1];
                            l.DateOfBirth = DateTime.ParseExact(editDetail[2], "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                            l.Email = editDetail[3];
                            l.Address = editDetail[4];
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invailid ID!");
                    return;
                }
                SearchLecture(I.ID, lecture);
            }
        }


    }
}
