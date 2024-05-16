using System;
using System.Collections.Generic;
using System.Threading;

//faça uma coisa de cada vez, se fizer 900 coisas ao mesmo tempo, sai tudo errado na hora de manejar


//todo: 
/* username and check if its empty or not (if it is, just put default or ask if it wants default, whatever)
 * make the current task list and the completed task list (and maybe a removed tasks list? idk)
 * function to ask the user to add a new task to the current one
 * function to ask if the user wants to see the current task list
 * func. to ask if the user wants to remove a task
 * func. to ask what the user wants to do (the first thing this should be)
 */
namespace To_do_List
{
    class Program
    {
        static List<string> ToDoList = new List<string>();
        static List<string> CompletedList = new List<string>();

        class Person
        {
            public string Name { get; set; }//just name for now

            public Person() { }
            public Person(string name) { Name = name; }
        }

        static void Main()
        {
            Person person = new Person();
            bool onCheck = true;
            int clearingConsole = 500;

            Console.Title = "Console to-do list";

            Console.WriteLine("Welcome to the To-do tasks list!");
            Console.Write("Please enter your name: ");
            person.Name = Console.ReadLine();

            Console.WriteLine("User logged: {0}", person.Name);

            while (onCheck)
            {
                Console.WriteLine("1. See your current task list");
                Console.WriteLine("2. Add a new task to the current task list");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" \n");



                Console.Write("What you gonna do?: ");
                string userChoose = Console.ReadLine();

                if (userChoose == "1")//acho q tem um jeito mais inteligente para nn ficar repetindo isso
                {
                    CurrentTaskList();
                }
                else if (userChoose == "2")
                {
                    AddingToTaskList();
                }
                else
                {
                    Console.WriteLine("\nWrong parameter, press enter to try again. . .");
                    Console.ReadKey();
                    Thread.Sleep(clearingConsole);
                    Console.Clear();
                }
            }
        }

        static void CurrentTaskList()
        {

            Console.WriteLine($"Your current list has {ToDoList.Count} tasks on it:\n");

            for (int i = 0; i < ToDoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ToDoList[i]}");
            }

            Console.WriteLine("Press enter to continue. . .");//achar um meio de nn ficar repetindo isso
            Console.ReadKey();
        }

        static void AddingToTaskList()
        {
            Console.Write("Please enter the task: ");
            string taskAdded = Console.ReadLine();//checar se tem uma task já igual e ver se é valida
            ToDoList.Add(taskAdded);

            Console.WriteLine("Task added succesfully!");

            Console.WriteLine("Press enter to continue. . .");//achar um meio de nn ficar repetindo isso
            Console.ReadKey();
        }

    }
}

