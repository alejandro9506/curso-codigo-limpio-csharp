List<string> TaskList = new List<string>();

int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

/// <summary>
/// Show the options for task, 1. Add, 2. Remove, 3. List, 4. Exit
/// </summary>
/// <returns>Returns option selected by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string optionMenu = Console.ReadLine();
    return Convert.ToInt32(optionMenu);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowTaskList();

        string optionTaskRemove = Console.ReadLine();
        // Remove one position because the array starts in 0
        int indexToRemove = Convert.ToInt32(optionTaskRemove) - 1;
        if (indexToRemove > (TaskList.Count - 1) || TaskList.Count < 0)
        {
            Console.WriteLine("Opción no válida");
        }
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                string taskRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea  {taskRemove} eliminada");
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Opción no válida");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskAdd = Console.ReadLine();
        if (!string.IsNullOrEmpty(taskAdd))
        {
            TaskList.Add(taskAdd);
            Console.WriteLine("Tarea registrada");
        }
        else
        {
            Console.WriteLine("No se puede agregar una tarea vacía");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Opción no válida");
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        ShowTaskList();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

void ShowTaskList()
{
    var indexTask = 1;
    Console.WriteLine("----------------------------------------");
    TaskList.ForEach(task =>
    {
        Console.WriteLine($"{indexTask++} .  {task}");
    });
    Console.WriteLine("----------------------------------------");
}

public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}