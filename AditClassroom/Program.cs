using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/// <summary>
/// Adit's Program for practicing XML
/// Date: 3/26/2017
/// 
/// if you are logged in as a teacher:
/// add assignments 
/// 
/// if you are a student:
/// print the assignments
/// </summary>
namespace AditClassroom
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc1 = XDocument.Load("Teacheraccounts.xml");
            XDocument doc2 = XDocument.Load("Studentaccounts.xml");
            XDocument doc3 = XDocument.Load("Assignments.xml");
            int login;
            string useruser;
            string userpass;
            string teacher1user = "teacher1";
            string teacher1pass = "teacher1pass";
            string student1user = "student1";
            string student1pass = "student1pass";
            List<Accounts> teacheraccounts = new List<Accounts>();
            List<Accounts> studentaccounts = new List<Accounts>();
            List<Assignment> teacherassignments = new List<Assignment>();

            foreach (XElement account in doc1.Root.Elements("Account"))
            {
                string username = account.Element("Username").Value;
                string password = account.Element("Password").Value;
                teacheraccounts.Add(new Accounts(username, password));
            }

            //login
            Console.WriteLine("If you are a teacher press 1, If you are a student press 2, if you want to create an account press 3");
            login = int.Parse(Console.ReadLine());
            if (login == 1)
            {
                Console.WriteLine("Type in your username");
                useruser = Console.ReadLine();
                Console.WriteLine("Enter your password");
                userpass = Console.ReadLine();
                if (useruser == teacher1user && userpass == teacher1pass)
                {
                    Console.WriteLine("Login Success");
                    int menue1;
                    Console.WriteLine("Type in 1 if you want to add a assignment and type 2 if you want to edit the schedule");
                    menue1 = int.Parse(Console.ReadLine());
                    if (menue1 == 1)
                    {
                        Console.WriteLine("Add an assignment name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Add an assignment description");
                        string desc = Console.ReadLine();
                        Console.WriteLine("(Enter the day this assignment is due)");
                        int dueday = int.Parse(Console.ReadLine());
                        Console.WriteLine("(Enter the month this assignment is due)");
                        int duemonth = int.Parse(Console.ReadLine());
                        Console.WriteLine("(Enter the year the assignment is due)");
                        int dueyear = int.Parse(Console.ReadLine());

                        Assignment assignment1 = new Assignment(name, desc, dueday, duemonth, dueyear);
                        teacherassignments.Add(new Assignment(name, desc, dueday, duemonth, dueyear));
                        XElement nameElement = new XElement("assignmentname");
                        nameElement.Value = name;
                        XElement descElement = new XElement("assignmentdescription");
                        descElement.Value = desc;
                        XElement dayElement = new XElement("day");
                        XElement monthElement = new XElement("month");
                        XElement yearElement = new XElement("year");
                        XElement dueDateElement = new XElement("duedate", monthElement, dayElement, yearElement);

                        XElement assignmentElement = new XElement("Assignment", nameElement, descElement, dueDateElement);
                        doc3.Root.Add(assignmentElement);

                        Console.WriteLine("Your Assignment has been saved\nPress 1 to preview it");
                        int menue2 = int.Parse(Console.ReadLine());
                        if (menue2 == 1)
                        {
                            Console.WriteLine("Name:{0}\nDescription:{1}\nDue Date:{2}/{3}/{4}", assignment1.assignmentname, assignment1.assignmentdesc, assignment1.duemonth, assignment1.dueday, assignment1.dueyear);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Username or Password is Incorrect");
                    }
                    if (menue1 == 2)
                    {
                        string x = doc3.Root.Element("assignment").Element("assignmentdue").Value;

                        //sort assignments by due date
                        DateTime now = DateTime.Now;
                        for (int i = 0; i < 1000; i++)
                        {


                        }
                    }

                }
                else
                {
                    Console.WriteLine("Username or Password is incorrect");
                }

            }
            if (login == 2)
            {
                Console.WriteLine("Type in your username");
                useruser = Console.ReadLine();
                Console.WriteLine("Enter your password");
                userpass = Console.ReadLine();
                if (useruser == student1user && userpass == student1pass)
                {
                    Console.WriteLine("Login Success");

                }
                else
                {
                    Console.WriteLine("Username or Password is incorrect");
                }

            }

            if (login == 3)
            {
                Console.WriteLine("Press 1 to make a teacher account and press 2 to make a student account");
                int accountselect = int.Parse(Console.ReadLine());
                if (accountselect == 1) //TEACHERACCOUNT
                {
                    Console.WriteLine("Create a Username and Enter in Below:");
                    string newName = Console.ReadLine();
                    for (int i = 0; i < teacheraccounts.Count; i++)
                    {
                        if (newName == teacheraccounts[i].username)
                        {
                            Console.WriteLine("Username is taken please try again.");
                            newName = Console.ReadLine();
                        }
                    }
                    Console.WriteLine("Enter a password");
                    string newPass = Console.ReadLine();
                    teacheraccounts.Add(new Accounts(newName, newPass));
                    XElement userElement = new XElement("Username");
                    userElement.Value = newName;
                    XElement passElement = new XElement("Password");
                    passElement.Value = newPass;
                    XElement accountElement = new XElement("Account", userElement, passElement);
                    doc1.Root.Add(accountElement);
                    Console.WriteLine("Account Created");
                }

                if (accountselect == 2) //STUDENTACCOUNT
                {
                    Console.WriteLine("Create a Username and Enter in Below:");
                    string newName = Console.ReadLine();
                    for (int i = 0; i < studentaccounts.Count; i++)
                    {
                        if (newName == studentaccounts[i].username)
                        {
                            Console.WriteLine("Username is taken please try again.");
                            newName = Console.ReadLine();
                        }
                    }
                    Console.WriteLine("Enter a password");
                    string newPass = Console.ReadLine();
                    studentaccounts.Add(new Accounts(newName, newPass));
                    XElement userElement = new XElement("Username");
                    userElement.Value = newName;
                    XElement passElement = new XElement("Password");
                    passElement.Value = newPass;
                    XElement accountElement = new XElement("Account", userElement, passElement);
                    doc2.Root.Add(accountElement);
                    Console.WriteLine("Account Created");

                }

            }

            doc1.Save("Teacheraccounts.xml");
            doc2.Save("Studentaccounts.xml");
            doc3.Save("Assignments.xml");
            Console.ReadKey();
        }


    }
}

