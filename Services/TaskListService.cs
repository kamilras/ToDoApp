using AplikacjaInternetowa.Models;
using AplikacjaInternetowa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AplikacjaInternetowa.Services
{
    public class TaskListService
    {
        private ProjectContext context;

        public TaskListService(ProjectContext projectContext)
        {
            context = projectContext;
        }

        public TaskListViewModel GetAllOpen()
        {
            var tasks = context.Tasks.Where(x => x.Done == false).Select(y => new TaskListItemViewModel()
            {
                Id = y.Id,
                Desc = y.Desc,
                Title = y.Title
            });

            return new TaskListViewModel() { Tasks = tasks };
        }

        public void Add(string title, string desc)
        {
            var task = new Task()
            { 
                Title = title,
                Desc = desc,
                Done = false
            };

            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public void FinishTask(int id)
        {
            Task task = context.Tasks.Where(x => x.Id == id).FirstOrDefault();
            if (task != null)
            {
                task.Done = true;
            }

            context.Tasks.Update(task);
            
            context.SaveChanges();
        }
    }
}
