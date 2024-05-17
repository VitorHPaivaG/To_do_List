using System;
using System.Collections.Generic;
using System.Threading;

//faça uma coisa de cada vez, se fizer 900 coisas ao mesmo tempo, sai tudo errado na hora de manejar


//to_do: 
/* username and check if its empty or not (if it is, just put default or ask if it wants default, whatever) (done)
 * make the current task list and the completed task list (and maybe a removed tasks list? idk) (done)
 * function to ask the user to add a new task to the current one (done)
 * function to ask if the user wants to see the current task list (done)
 * func. to ask if the user wants to remove a task (done)
 * func. to ask what the user wants to do (the first thing this should be) (done)
 * ask if the user wants to mark as completed any task on the current task list, remove it of current list to add to completed one
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
            Console.Write("Please enter your name [ENTER for default]: ");
            person.Name = Console.ReadLine();

            if (string.IsNullOrEmpty(person.Name))
            {
                person.Name = "Default-user";//nn pensei em nada melhor
            }

            Console.WriteLine("User logged: {0}", person.Name);

            while (onCheck)
            {
                Console.WriteLine("1. See your current task list");
                Console.WriteLine("2. Add a new task to the current task list");
                Console.WriteLine("3. Remove a task from the current task list");
                Console.WriteLine("4. See all the completed tasks");
                Console.WriteLine("E. Close the program");
                Console.WriteLine(" \n");

                Console.Write("What you gonna do?: ");
                string userChoose = Console.ReadLine();

                if (userChoose == "1")//acho q tem um jeito mais inteligente para nn ficar repetindo isso
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
                else if (userChoose == "E" || userChoose == "e")//fazer o comparativo (tolower etc), em vez de um ou outro
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
            if (ToDoList.Count == 0 || ToDoList == null)//tem jeitos melhores de abordar isso
            {
                Console.WriteLine("You dont have any tasks on the current list yet. . .\n");
            }
            else
            {
                Console.WriteLine($"Your current list has {ToDoList.Count} tasks on it:\n");//check if its null or empty

                for (int i = 0; i < ToDoList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ToDoList[i]}");
                }

                Console.WriteLine("\nWants to mark any task as completed? [Y/N]: ");
                string userChoose = Console.ReadLine();

                if (userChoose == "Y" || userChoose == "y")
                {
                    Console.Write("Which one?: ");
                    int value = Convert.ToInt32(Console.ReadLine());

                    string s = ToDoList[value - 1];

                    ToDoList.RemoveAt(value - 1);
                    CompletedList.Add(s);

                    Console.WriteLine($"Task ({s}) marked as completed!!\n");
                }
                else if (userChoose == "N" || userChoose == "n")
                {
                    Console.WriteLine("Press enter to continue. . .");//achar um meio de nn ficar repetindo isso
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Wrong parameter, please try again. . .");//fazer depois o while
                    Console.ReadKey();
                    Console.Clear();
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
            if (ToDoList.Count == 0)//seria index 0 ou valor 0?
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

                Console.Write("\nWhich task you want to remove?: ");
                int removingTask = Convert.ToInt32(Console.ReadLine());//se tiver fora do scopo, trow exe, ou alguma condição

                ToDoList.RemoveAt(removingTask - 1);//if its out of range, trow exep ?? idk may try it later

                Console.WriteLine("Task removed.");
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

