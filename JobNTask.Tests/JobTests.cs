using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobNTask.Lib.Model;
using JobNTask.Lib.Examples.Action;
using JobNTask.Lib.Examples.Target;

namespace JobNTask.Tests;

[TestClass]
public class JobTests
{
    [TestMethod]
    public void Job_CanAddTask()
    {
        var job = new Job("1", "Blacksmith");
        var task = new Task("1", "Design the Homepage", new CutAction(), 1, new Tree());
    }
}