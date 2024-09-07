using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobNTask.Lib.Model;
using JobNTask.Lib.Repository;
using JobNTask.Lib.Manager;
using JobNTask.Lib.Examples.Action;
using JobNTask.Lib.Examples.Target;
using System.Threading;
using System;




namespace JobNTask.Tests;

[TestClass]
public class TaskManagerTests
{
    [TestMethod]
    public void ProcessActionUpdatesAllRelevantTasks()
    {
        var task1 = new Task("1", "Cut down the tree", new CutAction(), 5, new Tree());
        var task2 = new Task("2", "Cut down the tree", new CutAction(), 3, new Tree());

        var taskRepository = new InMemoryTaskRepository();
        taskRepository.AddTask(task1);
        taskRepository.AddTask(task2);

        var taskManager = new TaskManager(taskRepository);

        taskManager.ProcessAction(new CutAction(), new Tree(), 3);

        Assert.IsFalse(task1.IsCompleted());
        Assert.IsTrue(task2.IsCompleted());
    }
}