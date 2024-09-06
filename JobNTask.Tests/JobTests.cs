using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobNTask.Lib.Model;

namespace JobNTask.Tests;

[TestClass]
public class JobTests
{
    [TestMethod]
    public void Job_CanAddTask()
    {
        var job = new Job("1", "Blacksmith");
        var task = new Task("1", "Forge a sword");
    }
}