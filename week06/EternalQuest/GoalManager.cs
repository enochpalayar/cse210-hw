using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid choice. Try again and please choose a valid number.");
                continue;
            }

            if (choice == 1)
            {
                CreateGoal();
            }
            else if (choice == 2)
            {
                ListGoalDetails();
            }
            else if (choice == 3)
            {
                SaveGoals();
            }
            else if (choice == 4)
            {
                LoadGoals();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
            else if (choice == 6)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again and please choose a valid number.");
            }
        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }
    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string inputType = Console.ReadLine();
        int type;
        if (!int.TryParse(inputType, out type))
        {
            Console.WriteLine("Invalid choice. Please choose between 1, 2, or 3 only.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string inputPoints = Console.ReadLine();
        int points;
        if (!int.TryParse(inputPoints, out points))
        {
            Console.WriteLine("Invalid input. Points must be a number.");
            return;
        }

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            string inputTarget = Console.ReadLine();
            int target;
            if (!int.TryParse(inputTarget, out target))
            {
                Console.WriteLine("Invalid input. Target must be a number.");
                return;
            }

            Console.Write("What is the bonus for accomplishing it that many times? ");
            string inputBonus = Console.ReadLine();
            int bonus;
            if (!int.TryParse(inputBonus, out bonus))
            {
                Console.WriteLine("Invalid input. Bonus must be a number.");
                return;
            }

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        else
        {
            Console.WriteLine("Invalid choice. Please choose between 1, 2, or 3 only.");
        }
    }
    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        string inputChoice = Console.ReadLine();
        int choice;
        if (!int.TryParse(inputChoice, out choice) || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid goal number.");
            return;
        }
        Goal goal = _goals[choice - 1];
        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;
        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points.");
        CheckLevel();
    }
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File is not found. Please check the filename.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            return;
        }
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split('|');
            string type = parts[0].Trim();

            if (type == "SimpleGoal")
            {
                SimpleGoal simpleg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                if (bool.Parse(parts[4])) simpleg.MarkComplete();
                _goals.Add(simpleg);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal checklg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4]));
                checklg.SetAmountCompleted(int.Parse(parts[6]));
                _goals.Add(checklg);
            }
        }
    }
    //This is the method that determines the rank of the user based on their score or current score.
    public void CheckLevel()
    {
        string title;
        int level;

        if (_score >= 10000) { level = 5; title = "Eternity Seeker"; }
        else if (_score >= 5000) { level = 4; title = "Master"; }
        else if (_score >= 2000) { level = 3; title = "Champion"; }
        else if (_score >= 500) { level = 2; title = "Explorer"; }
        else { level = 1; title = "Beginner"; }

        Console.WriteLine($"You are now Level {level}: {title}!");
    }

}