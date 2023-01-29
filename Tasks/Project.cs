
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    internal class Project
    {
        public Dictionary<long, dynamic> _tasksArrays = new Dictionary<long, dynamic>();

        public void Add(long taskIdentifier, string taskDescription, bool taskDone)
        {
            dynamic d1 = new System.Dynamic.ExpandoObject();
            d1.description = taskDescription;
            d1.done = taskDone;

            _tasksArrays.Add(taskIdentifier, d1);
        }

        public void PrintInfo(IConsole console)
        {
            foreach (var task in _tasksArrays)
            {
                var taskKey = task.Key;
                var taskValue = task.Value;
                var taskDescription = taskValue.description;
                var taskDone = taskValue.done;
                
                console.WriteLine($"    [{(taskDone ? 'x' : ' ')}] {taskKey}: {taskDescription}");
            }
        }

        public void SetDoneIfExists(string identifier, bool done, IConsole console)
        {
            long parseIdentifier = long.Parse(identifier);
            if (_tasksArrays.ContainsKey(parseIdentifier))
            {
                _tasksArrays[parseIdentifier].done = done;
            }
        }
    }
}
