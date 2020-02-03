using System;
using System.Collections;
using System.Collections.Generic;

namespace Capstone_Task_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> menu = new List<string> { "List tasks", "Add task", "Delete task", "Mark task complete", "Quit" };

            List<MyTask> listOfTasks = new List<MyTask>
            {
                new MyTask("Sean", "Finish Capstone 2", DateTime.Parse("2/4/2020")),
                new MyTask("James", "Finish SC2 Terran Campaign", DateTime.Parse("3/1/2020")),
                new MyTask("Blake", "Finish working shift at Pizza Parlor", DateTime.Parse("2/3/2020")),
                new MyTask("Ryan", "Sing a song", DateTime.Parse("2/14/2020")),
                new MyTask("Cameron", "Play Smash Brothers", DateTime.Parse("2/4/2020")),
                new MyTask("Carson", "Take his wife on a date", DateTime.Parse("2/14/2020")),
             };

            Console.WriteLine("Select a number in the menu to perform different actions\n");

            bool continueLoop = true;
            while (continueLoop == true)
            {
                PrintList(menu);
                int input = InputIsInt(menu, Console.ReadLine());
                if (input == 0) { ListTasks(listOfTasks); }
                else if (input == 1) { AddTask(listOfTasks); }
                else if (input == 2) { DeleteTask(listOfTasks); }
                else if (input == 3) { MarkTaskComplete(listOfTasks); }
                else if (input == 4) { Quit(); }

                continueLoop = Option1or2("\nWould you like to select another option? (y/n) : ", "y", "n");
            }


        }

        public static int InputIsInt(List<MyTask> list, string pick)
        {
            try
            {
                int intPick = int.Parse(pick) - 1;
                string tryExceptionT = list[intPick].TeamMemberName;
                return intPick;
            }
            catch
            {
                return InputIsInt(list, GetUserInput($"Invalid selection, enter a number between 1 - {list.Count}: "));
            }
        }
        public static int InputIsInt(List<string> list, string pick)
        {
            try
            {
                int intPick = int.Parse(pick) - 1;
                string tryExceptionT = list[intPick];
                return intPick;
            }
            catch
            {
                return InputIsInt(list, GetUserInput($"Invalid selection, enter a number between 1 - {list.Count}: "));
            }
        }
        public static bool Option1or2(string message, string option1, string option2)
        {
            string userContinue = "";
            while (userContinue != option1 && userContinue != option2)
            {
                Console.Write(message);
                userContinue = Console.ReadLine().ToLower();

                if (userContinue == "n")
                {
                    Console.WriteLine("Okay!!");
                    return false;
                }
            }
            Console.WriteLine();
            return true;
        }
        public static string GetUserInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return input;
        }
        public static void PrintList(List<string> listToPrint)
        {
            for (int i = 0; i < listToPrint.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {listToPrint[i]}");
            }
        }
        public static void ListTasks(List<MyTask> listToPrint)
        {
            for (int i = 0; i < listToPrint.Count; i++)
            {
                Console.WriteLine($"Task {i + 1}: {listToPrint[i].TeamMemberName} \tDue Date: {listToPrint[i].DueDate}  \tCompleted: {listToPrint[i].Completed} \tDescription: {listToPrint[i].Description}");
            }
            Console.WriteLine();
        }
        public static void AddTask(List<MyTask> listToAddTo)
        {
            string name = GetUserInput("Enter name: ");
            string description = GetUserInput("Enter description: ");

            DateTime dueDate = DateTime.Parse("1/1/11");
            bool validDate = false;
            while (validDate == false)
            {
                try
                {
                    dueDate = DateTime.Parse(GetUserInput("Enter due date (mm/dd/yy): "));
                    validDate = true;
                }
                catch
                {
                    Console.WriteLine("Invalid date");
                    validDate = false;
                }
            }
            listToAddTo.Add(new MyTask(name, description, dueDate));
        }
        public static void DeleteTask(List<MyTask> listToDeleteFrom)
        {
            ListTasks(listToDeleteFrom);
            int num = InputIsInt(listToDeleteFrom, GetUserInput("Select a task to delete: "));
            listToDeleteFrom.RemoveAt(num);
        }
        public static void MarkTaskComplete(List<MyTask> listToMarkUp)
        {

        }
        public static void Quit()
        {

        }


    }
}
