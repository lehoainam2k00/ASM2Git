using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2Final
{
    public class Student : Individual
    {
        public string Batch { get; set; }
        public Student() : base()
        {}                                                                                                                              
        public Student(string ID, string Name, DateTime DateOfBirth, string Email, string Address,string StdBatch) : base(ID, Name, DateOfBirth, Email, Address)
        {
            this.Batch = StdBatch;
        }

        public void AddStudent(List<Individual> student)
        {
            base.AddNew();

            Console.WriteLine("Enter Student class (Default = BHAF): ");
            this.Batch = "BHAF";

            if (!student.Exists(s => s.ID == this.ID))
            {
                student.Add(new Student(this.ID, this.Name,this.DateOfBirth,this.Email, this.Address , this.Batch));
            }
        }


        public void ViewAllStudents(List<Individual> student)
        {
            base.ViewAll();
            if (student != null)
            {
                Console.WriteLine("ID   |   Name    |   Address |   Date of birth   |       Email     |   Class ");
                foreach (Individual I in student)
                {
                    Student s = I as Student;
                    Console.WriteLine(s.ID + "| " + s.Name + "| " + s.DateOfBirth + "| " + s.Email + "| " + s.Address + "| " + s.Batch);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("database is null");
                return;
            }
        }



        public void SearchStudent(string key, List<Individual> student)
        {
            int searchResult = 0;
            foreach (Individual I in student)
            {
                if (I.ID == key)
                {
                    Student s = I as Student;
                    searchResult = student.IndexOf(I);
                    if (searchResult > -1)
                    {
                        Console.WriteLine(student[searchResult].ID + " " + student[searchResult].Name + " " + student[searchResult].DateOfBirth + " " 
                            + student[searchResult].Email + " " + student[searchResult].Address);
                    }
                    else
                    {
                        Console.WriteLine("There is no student with that information!");
                        return;
                    }
                }
            }
        }



        public void DeleteStudent(string key,List <Individual> student)
        {
            foreach(Individual I in student)
            {
                if (I.ID == key)
                {
                    Student s = I as Student;
                    student.RemoveAt(student.IndexOf(I));
                    if (student.IndexOf(I) < 0)
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


        public void UpdateStudent(string key, List<Individual> student)
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
            foreach(Individual I in student)
            {
                if (I.ID == key)
                {
                    Student s = I as Student;
                    for (int i = 0; i < editDetail.Length; i++)
                    {
                        if((editDetail[i] != null)&&(editDetail[i] != ""))
                        {
                            s.Name = editDetail[1];
                            s.DateOfBirth = DateTime.ParseExact(editDetail[2], "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                            s.Email = editDetail[3];
                            s.Address = editDetail[4];
                            Console.WriteLine("Successful!!!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invailid ID!");
                    return;
                }
                SearchStudent(I.ID, student);
            }
        }
    }
}
