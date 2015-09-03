using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotVVM.Samples.BasicSamples.ViewModels
{
    public class Sample1ViewModel : DotvvmViewModelBase
    {
        public string NewTaskTitle { get; set; }

        public List<TaskViewModel> Tasks { get; set; }

        public Sample1ViewModel()
        {
            Tasks = new List<TaskViewModel>();
        }

        public override Task Init()
        {
            if (!Context.IsPostBack)
            {
                Tasks.Add(new TaskViewModel() { IsCompleted = false, TaskId = Guid.NewGuid(), Title = "Do the laundry" });
                Tasks.Add(new TaskViewModel() { IsCompleted = true, TaskId = Guid.NewGuid(), Title = "Wash the car" });
                Tasks.Add(new TaskViewModel() { IsCompleted = true, TaskId = Guid.NewGuid(), Title = "Go shopping" });
                StupidTask = new TaskViewModel() { Title = "stupid" };
            }
            return base.Init();
        }

        public void AddTask()
        {
            Tasks.Add(new TaskViewModel()
            {
                Title = NewTaskTitle,
                TaskId = Guid.NewGuid()
            });
            NewTaskTitle = string.Empty;
        }

        public void CompleteTask(Guid id)
        {
            Tasks.Single(t => t.TaskId == id).IsCompleted = true;
        }
    }

    public class TaskViewModel
    {

        public Guid TaskId { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}