using System;
using System.Collections.Generic;
using System.IO;


public class ToDOList
{

    static List<string> tasks = new List<string>(); // قائمة لتخزين المهام

    public static void Main(string[] args)
    {

        Console.WriteLine("Welcome to the To-Do-List App!");

        while (true)
        {
            Console.WriteLine("\n1. Add a new task");
            Console.WriteLine("2. View all tasks");
            Console.WriteLine("3. Delete a task");
            Console.WriteLine("4. Exit");
            Console.WriteLine("5. Save tasks to file");
            Console.Write("Please choose an option (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    DeleteTask();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the To-Do-List App! Goodbye! 👋");
                    return;
                case "5":
                    SaveTasksToFile();
                    break;
                default:
                    Console.WriteLine("❌ Invalid choice. Please try again.");
                    break;
            }
        }




    }

    private static void AddTask()
    {
        Console.WriteLine("\nAdd a new task");
        Console.Write("Enter the task description: ");
        string taskDescription = Console.ReadLine() ?? "No description";
        tasks.Add(taskDescription);
        Console.WriteLine("Task added successfully! ✅");
    }
    private static void ViewTasks()
    {
        Console.WriteLine("\n📋 List of all tasks");

        if (tasks.Count == 0)
        {
            Console.WriteLine("❗ No tasks available.");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    private static void DeleteTask()
    {
        Console.WriteLine("\nDelete a task");
        Console.Write("Enter the task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task deleted successfully! 🗑️");
        }
        else
        {
            Console.WriteLine("❌ Invalid task number. Please try again.");
        }
    }

    private static void SaveTasksToFile()
    {
        Console.Write("Enter the filename to save tasks: ");
        string filename = Console.ReadLine() ?? "tasks.txt";

        try
        {
            File.WriteAllLines(filename, tasks);
            Console.WriteLine($"Tasks saved to {filename} successfully! 📂");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error saving tasks: {ex.Message}");
        }
    }
    
}

