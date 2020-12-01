using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void TestMethodGetStudent()
        {
            Student student = Repository.GetStudent(1);
            Assert.IsTrue(student.Id == 1);
        }

        [TestMethod]
        public void TestMethodGetDiploma()
        {
            Diploma diploma = Repository.GetDiploma(1);
            Assert.IsTrue(diploma.Id == 1);
        }

        [TestMethod]
        public void TestMethodGetRequirements()
        {
            Requirement[] requirements = Repository.GetRequirements();
            Assert.IsTrue(requirements[0].Id == 100);
        }

        [TestMethod]
        public void TestMethodGetRequirement()
        {
            Requirement[] requirements = Repository.GetRequirements();
            Requirement requirement = Repository.GetRequirement(100);
            Assert.IsTrue(requirement.Id == 100);
        }

    }
}
