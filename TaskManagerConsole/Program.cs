using System;
using TaskManagerConsole.Menus;

namespace TaskManagerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            new MainMenu("Data Source=.\\SQLEXPRESS;Initial Catalog=TaskManager;Integrated Security=SSPI");
        }
    }
}
