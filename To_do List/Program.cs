using System;
using System.Collections.Generic;
using System.Threading;

//things are starting to get a bit messy, maybe im gonna allocate these bunch of functions to some classes

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
            Console.Write("Please enter your name [ENTER for default]: ");
            person.Name = Console.ReadLine();

            if (string.IsNullOrEmpty(person.Name))
            {
                person.Name = "Guest-User";
            }

            Console.WriteLine("\nUser logged: {0}", person.Name);

            while (onCheck)
            {
                Console.WriteLine("1. See your current task list");
                Console.WriteLine("2. Add a new task to the current task list");
                Console.WriteLine("3. Remove a task from the current task list");
                Console.WriteLine("4. See all the completed tasks");
                Console.WriteLine("E. Close the program");
                Console.WriteLine(" \n");

                Console.Write("What you´re gonna do?: ");
                string userChoose = Console.ReadLine().ToUpper();

                if (userChoose == "1")
                {
                    CurrentTaskList();
                }
                else if (userChoose == "2")
                {
                    AddingToCurrentTaskList();
                }
                else if (userChoose == "3")
                {
                    RemovingFromCurrentList();
                }
                else if (userChoose == "4")
                {
                    CompletedTasksFromCurrentList();
                }
                else if (userChoose.Equals("E"))
                {
                    CloseProgram();
                    onCheck = false;
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
            bool onWork = true;

            if (ToDoList.Count.Equals(0))
            {
                Console.WriteLine("Your current task list is empty. . . Time to add some tasks!!\n");
            }

            else
            {
                Console.WriteLine($"Your current list has ({ToDoList.Count}) tasks on it:\n");//check if its null or empty

                for (int i = 0; i < ToDoList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ToDoList[i]}");
                }

                Console.WriteLine("\nWants to mark any task as completed? [Y/N]: ");
                string userChoose = Console.ReadLine().ToUpper();

                while (onWork)
                {
                    if (userChoose.Equals("Y"))
                    {
                        Console.Write("Which one?: ");
                        int value = Convert.ToInt32(Console.ReadLine());

                        string removeValueByIndex = ToDoList[value - 1];

                        ToDoList.RemoveAt(value - 1);
                        CompletedList.Add(removeValueByIndex);

                        Console.WriteLine($"Task ({removeValueByIndex}) marked as completed!!\n");

                        onWork = false;
                    }
                    else if (userChoose.Equals("N"))
                    {
                        Console.WriteLine("Press enter to continue. . .");//achar um meio de nn ficar repetindo isso
                        Console.ReadKey();
                        Console.Clear();
                        onWork = false;
                    }
                    else
                    {
                        Console.WriteLine("Wrong parameter, please try again. . .");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
            }
        }

        static void AddingToCurrentTaskList()
        {
            Console.Write("Please enter the task: ");
            string taskAdded = Console.ReadLine();//checar se tem uma task já igual e ver se é valida
            ToDoList.Add(taskAdded);

            Console.WriteLine("Task added succesfully!");

            Console.WriteLine("Press enter to continue. . .");//achar um meio de nn ficar repetindo isso
            Console.ReadKey();

            Console.Clear();
        }

        //sla se é uma boa ideia isso, ou poderia embutir o currenttasklist a esse, porem esse apenas remove e ñ printa nada
        static void RemovingFromCurrentList()
        {
            if (ToDoList.Count == 0)
            {
                Console.WriteLine("The current list is empty! Add some tasks. . .");
            }
            else
            {
                Console.WriteLine("This is the current tasks listed: ");

                for (int i = 0; i < ToDoList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ToDoList[i]}");
                }

                try//lindo
                {
                    Console.Write("\nWhich task you want to remove?: ");
                    int removingTask = Convert.ToInt32(Console.ReadLine());

                    ToDoList.RemoveAt(removingTask - 1);

                    Console.WriteLine("Task removed.");
                }
                catch
                {
                    Console.WriteLine("This value has not been found!! Please try again!");
                }
            }

            Console.WriteLine("Press enter to continue. . .");
            Console.ReadKey();
            Console.Clear();
        }

        static void CompletedTasksFromCurrentList()
        {
            if (CompletedList.Count == 0)
            {
                Console.WriteLine("You dint mark any task as completed yet. . .");
            }
            else
            {
                Console.WriteLine($"you´ve got {CompletedList.Count} tasks done by now");

                for (int i = 0; i < CompletedList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {CompletedList[i]}");
                }
            }

            //c pa posso tranformar isso em uma função, e só chamar ela na hora das escolhas qnd encerrar nessa ou em outras
            //funções
            Console.WriteLine("Press enter to continue. . .");
            Console.ReadKey();
            Console.Clear();
        }

        static void CloseProgram()
        {
            Console.WriteLine("Thanks for using, press any key to close the program. . .");
            Console.ReadKey();
        }

    }
}

