using System;
using System.Collections.Generic;
using TaskManagerRepository;
using TaskManagerRepository.Repositories;
using TaskManagerRepository.Tables;

namespace TaskManagerConsole.Menus
{
    public class MainMenu
    {
        public EFTaskRepository _taskRepository;

        public MainMenu(string connectionString)
        {
            Data(connectionString);

            MainMenuLoop();
        }

        public void Data(string connectionString)
        {
            _taskRepository = new EFTaskRepository(new TaskManagerContext(connectionString));
        }

        public void MainMenuLoop()
        {
            while(true)
            {
                Console.Write(">");
                string command = Console.ReadLine();

                string[] commandSplit = command.Split(" ");

                if (command == "show all") 
                {
                    ShowTasks(_taskRepository.GetAll());
                }

                if(commandSplit.Length == 12)
                {
                    if (commandSplit[0] == "add" && commandSplit[1] == "task" && commandSplit[2] == "desc" && commandSplit[4] == "start" && commandSplit[7] == "end" && commandSplit[10] == "imp")
                    {
                        bool check = false;

                        if (DateTime.TryParse($"{commandSplit[5]} {commandSplit[6]}", out DateTime resultStart) == true && DateTime.TryParse($"{commandSplit[8]} {commandSplit[9]}", out DateTime resultEnd) == true && bool.TryParse(commandSplit[11], out bool resultImportant) == true)
                        {
                            if ($"{commandSplit[0]} {commandSplit[1]} {commandSplit[2]} {commandSplit[3]} {commandSplit[4]} {commandSplit[5]} {commandSplit[6]} {commandSplit[7]} {commandSplit[8]} {commandSplit[9]} {commandSplit[10]} {commandSplit[11]}" == command)
                            {
                                Task task = new Task()
                                {
                                    Description = commandSplit[3],
                                    Start = DateTime.Parse($"{commandSplit[5]} {commandSplit[6]}"),
                                    End = DateTime.Parse($"{commandSplit[8]} {commandSplit[9]}"),
                                    AllDay = false,
                                    Important = bool.Parse(commandSplit[11])
                                };

                                check = _taskRepository.Add(task);
                            }
                        }

                        ShowMessage(check);
                    }
                }
                
                if(commandSplit.Length == 9)
                {
                    if (commandSplit[0] == "add" && commandSplit[1] == "task" && commandSplit[2] == "desc" && commandSplit[4] == "start" && commandSplit[7] == "imp")
                    {
                        bool check = false;

                        if (DateTime.TryParse($"{commandSplit[5]} {commandSplit[6]}", out DateTime resultStart) == true && bool.TryParse(commandSplit[8], out bool resultImportant) == true)
                        {
                            if ($"{commandSplit[0]} {commandSplit[1]} {commandSplit[2]} {commandSplit[3]} {commandSplit[4]} {commandSplit[5]} {commandSplit[6]} {commandSplit[7]} {commandSplit[8]}" == command)
                            {
                                Task task = new Task()
                                {
                                    Description = commandSplit[3],
                                    Start = DateTime.Parse($"{commandSplit[5]} {commandSplit[6]}"),
                                    End = null,
                                    AllDay = true,
                                    Important = bool.Parse(commandSplit[8])
                                };

                                check = _taskRepository.Add(task);
                            }
                        }

                        ShowMessage(check);
                    }
                }

                if (commandSplit.Length == 14)
                {
                    if (commandSplit[0] == "edit" && commandSplit[1] == "task" && commandSplit[2] == "id" && commandSplit[4] == "desc" && commandSplit[6] == "start" && commandSplit[9] == "end" && commandSplit[12] == "imp")
                    {
                        bool check = false;

                        if (int.TryParse(commandSplit[3], out int resultId) == true && DateTime.TryParse($"{commandSplit[7]} {commandSplit[8]}", out DateTime resultStart) == true && DateTime.TryParse($"{commandSplit[10]} {commandSplit[11]}", out DateTime resultEnd) == true && bool.TryParse(commandSplit[13], out bool resultImportant) == true)
                        {
                            if ($"{commandSplit[0]} {commandSplit[1]} {commandSplit[2]} {commandSplit[3]} {commandSplit[4]} {commandSplit[5]} {commandSplit[6]} {commandSplit[7]} {commandSplit[8]} {commandSplit[9]} {commandSplit[10]} {commandSplit[11]} {commandSplit[12]} {commandSplit[13]}" == command)
                            {
                                Task task = new Task()
                                {
                                    Id = int.Parse(commandSplit[3]),
                                    Description = commandSplit[5],
                                    Start = DateTime.Parse($"{commandSplit[7]} {commandSplit[8]}"),
                                    End = DateTime.Parse($"{commandSplit[10]} {commandSplit[11]}"),
                                    AllDay = false,
                                    Important = bool.Parse(commandSplit[13])
                                };

                                check = _taskRepository.Update(task);
                            }
                        }

                        ShowMessage(check);
                    }
                }

                // edit task id [] desc [] start [] [] end [] [] imp []
                // 0    1    2  3  4    5  6     7  8  9   10 11 12  13

                // edit task id [] desc [] start [] [] imp []
                // 0    1    2  3  4    5  6     7  8  9   10

                if (commandSplit.Length == 11)
                {
                    if (commandSplit[0] == "edit" && commandSplit[1] == "task" && commandSplit[2] == "id" && commandSplit[4] == "desc" && commandSplit[6] == "start" && commandSplit[9] == "imp")
                    {
                        bool check = false;

                        if (int.TryParse(commandSplit[3], out int resultId) == true && DateTime.TryParse($"{commandSplit[7]} {commandSplit[8]}", out DateTime resultStart) == true && bool.TryParse(commandSplit[10], out bool resultImportant) == true)
                        {
                            if ($"{commandSplit[0]} {commandSplit[1]} {commandSplit[2]} {commandSplit[3]} {commandSplit[4]} {commandSplit[5]} {commandSplit[6]} {commandSplit[7]} {commandSplit[8]} {commandSplit[9]} {commandSplit[10]}" == command)
                            {
                                Task task = new Task()
                                {
                                    Id = int.Parse(commandSplit[3]),
                                    Description = commandSplit[5],
                                    Start = DateTime.Parse($"{commandSplit[7]} {commandSplit[8]}"),
                                    End = null,
                                    AllDay = true,
                                    Important = bool.Parse(commandSplit[10])
                                };

                                check = _taskRepository.Update(task);
                            }
                        }

                        ShowMessage(check);
                    }
                }

                if (commandSplit.Length == 2)
                {
                    if (commandSplit[0] == "remove")
                    {
                        bool check = false;

                        if (int.TryParse(commandSplit[1], out int resultId) == true &&
                            $"{commandSplit[0]} {commandSplit[1]}" == command)
                        {
                            check = _taskRepository.RemoveById(int.Parse(commandSplit[1]));
                        }

                        ShowMessage(check);
                    }
                }

                if (command == "exit")
                {
                    Console.WriteLine("Are you sure to log out? (y/n)[n]:");

                    Console.Write(">");

                    if (Console.ReadLine().ToLower() == "y")
                    {
                        break;
                    }
                }
            }
        }

        public void ShowMessage(bool check)
        {
            if (check == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("OK");

                Console.ResetColor();
            }

            if (check == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("ERROR");

                Console.ResetColor();
            }
        }

        public void ShowTasks(List<Task> tasks)
        {
            int count = 0;

            foreach (var item in tasks)
            {
                count++;

                ShowTask(item);

                Console.WriteLine();

                if(count % 5 == 0 && tasks.Count != count) 
                {
                    Console.WriteLine("---- More ( Press 'Q' to break ) ----");

                    var result = Console.ReadKey();

                    if (result.Key == ConsoleKey.Spacebar) { Console.WriteLine(); }

                    if (result.Key == ConsoleKey.Q) { Console.WriteLine(); break; }
                }
            }
        }

        public void ShowTask(Task task)
        {
            if (task.Important == true) { Console.ForegroundColor = ConsoleColor.Cyan; }

            Console.WriteLine($"Id: {task.Id}");

            Console.WriteLine($"Description: {task.Description}");

            if (task.AllDay == true) 
            {
                Console.WriteLine($"Start: {task.Start.ToString("dd/MM/yyyy")}");
            }

            if (task.AllDay == false) 
            {
                Console.WriteLine($"Start: {task.Start}");
                Console.WriteLine($"End: {task.End}");
            }

            if (task.Important == true) { Console.ResetColor(); }
        }
    }
}