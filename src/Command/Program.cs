using System;

namespace Command;

class Program
{
    static void Main(string[] args)
    {
        CommandManager commandManager = new();
        IEmployeeManagerRepository repository = new EmployeeManagerRepository();

        commandManager.Invoke(
            new AddEmployeeToManagerList(repository, 1, new Employee(111, "Maria"))
        );
        repository.WriteDataStore();

        commandManager.Invoke(
            new AddEmployeeToManagerList(repository, 1, new Employee(222, "Nubia"))
        );
        repository.WriteDataStore();

        commandManager.Undo();
        repository.WriteDataStore();

        commandManager.Invoke(
            new AddEmployeeToManagerList(repository, 2, new Employee(333, "Silvana"))
        );
        repository.WriteDataStore();

        commandManager.Invoke(
            new AddEmployeeToManagerList(repository, 2, new Employee(333, "Silvana"))
        );
        repository.WriteDataStore();

        commandManager.UndAll();
        repository.WriteDataStore();
    }
}
