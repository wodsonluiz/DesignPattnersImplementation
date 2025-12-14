using System;
using System.Collections.Generic;
using System.Linq;

namespace Memento
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Manager: Employee
    {
        public List<Employee> Employees = new();
        public Manager(int id, string name): base(id, name)
        {
            
        }
    }

    /// <summary>
    /// Receiver
    /// </summary>
    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee empployee);
        void RemoveEmployee(int managerId, Employee empployee);
        bool HasEmployee(int managerId, int empployeeId);
        void WriteDataStore();
    }

    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = 
            new List<Manager>() { new Manager(1, "Wodson"), new Manager(2, "Joao") };

        public void AddEmployee(int managerId, Employee empployee)
        {
            _managers.First(m => m.Id == managerId).Employees.Add(empployee);
        }

        public bool HasEmployee(int managerId, int empployeeId)
        {
            return _managers.First(m => m.Id == managerId).Employees.Any(e => e.Id == empployeeId);
        }

        public void RemoveEmployee(int managerId, Employee empployee)
        {
            _managers.First(m => m.Id == managerId).Employees.Remove(empployee);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id}, {manager.Name}");
                if(manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id} {employee.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"\t No employees. ");
                }
            }
        }
    }

    /// <summary>
    /// Command
    /// </summary>
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
        AddEmployeeToManagerListMemento CreateMemento();
    }

    public class AddEmployeeToManagerListMemento
    {
        public int ManagerId { get; private set; }
        public Employee Employee { get; private set; }

        public AddEmployeeToManagerListMemento(
            int managerId,
            Employee employee)
        {
            ManagerId = managerId;
            Employee = employee;
        }
    }

    /// <summary>
    /// ConcreteCommand and Originator
    /// </summary>
    public class AddEmployeeToManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository _employeeManagerRepository;
        private int _managerId;
        private Employee _employee;

        public AddEmployeeToManagerList(
            IEmployeeManagerRepository employeeManagerRepository,
            int managerId,
            Employee employee)
        {
            _employeeManagerRepository = employeeManagerRepository;
            _managerId = managerId;
            _employee = employee;
        }

        public bool CanExecute()
        {
            if(_employee == null)
                return false;

            if(_employeeManagerRepository.HasEmployee(_managerId, _employee.Id))
                return false;

            return true;
        }

        public void Undo()
        {
            if(_employee == null)
            {
                return;
            }

            _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
        }

        public void Execute()
        {
            _employeeManagerRepository.AddEmployee(_managerId, _employee);
        }

        public AddEmployeeToManagerListMemento CreateMemento()
        {
            return new AddEmployeeToManagerListMemento(_managerId, _employee);
        }

        public void RestoreMemento(AddEmployeeToManagerListMemento memento)
        {
            _managerId = memento.ManagerId;
            _employee = memento.Employee;
        }
        
    }

    /// <summary>
    /// Invoker and Caretaker
    /// </summary>
    public class CommandManager
    {
        private readonly Stack<AddEmployeeToManagerListMemento> _mementos = new Stack<AddEmployeeToManagerListMemento>();
        private AddEmployeeToManagerList _commands;

        public void Invoke(ICommand command)
        {
            if(_commands == null)
            {
                _commands = (AddEmployeeToManagerList)command;
            }

            if(command.CanExecute())
            {
                command.Execute();
                _mementos.Push(command.CreateMemento());
            }
        }

        public void Undo()
        {
            if(_mementos.Any())
            {
                _commands.RestoreMemento(_mementos.Pop());
                _commands.Undo();
            }
        }

        public void UndAll()
        {
            while(_mementos.Any())
            {
                _commands.RestoreMemento(_mementos.Pop());
                _commands.Undo();
            }
        }
    }
}