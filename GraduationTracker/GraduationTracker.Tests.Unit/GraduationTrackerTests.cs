using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        Diploma diploma;
        Student[] students;
        GraduationTracker tracker;
        List<Tuple<bool, STANDING>> graduated;

        [TestInitialize]
        public void TestInitialize()
        {
            tracker = new GraduationTracker();

            diploma = Repository.GetDiploma(1);

            students = new[]
            {
              Repository.GetStudent(1),
              Repository.GetStudent(2),
              Repository.GetStudent(3),
              Repository.GetStudent(4),

            //tracker.HasGraduated()
            };

            graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }
        }

        [TestMethod]
        public void TestPassedStudentCanNotHaveRemedialStanding()
        {

            Assert.IsFalse(
                graduated.Any(
                    val =>  val.Item1 == true &&
                    val.Item2 == STANDING.Remedial
                )
            );

        }

        [TestMethod]
        public void TestStudentWhoFailedCanNotHaveGoodStanding()
        {

            Assert.IsFalse(
                graduated.Any(
                    val => val.Item1 == false && (
                        val.Item2 == STANDING.Average || 
                        val.Item2 == STANDING.MagnaCumLaude || 
                        val.Item2 == STANDING.SumaCumLaude
                        )
                )
            );

        }

        [TestMethod]
        public void TestStudentFailed()
        {
            Assert.IsTrue(
                graduated[3].Item1 == false && 
                graduated[3].Item2 == STANDING.Remedial
            );
        }

        [TestMethod]
        public void TestStudentWithAverageStanding()
        {
            Assert.IsTrue(
                graduated[2].Item1 == true &&
                graduated[2].Item2 == STANDING.Average
            );
        }

        [TestMethod]
        public void TestStudentWithMagnaCumLaudeStanding()
        {
            Assert.IsTrue(
                graduated[1].Item1 == true &&
                graduated[1].Item2 == STANDING.MagnaCumLaude
            );
        }

        [TestMethod]
        public void TestStudentWithSumaCumLaudeStanding()
        {
            Assert.IsTrue(
                graduated[0].Item1 == true &&
                graduated[0].Item2 == STANDING.SumaCumLaude
            );
        }

        [TestMethod]
        public void TestStudentWithNoneStanding()
        {
            Assert.IsFalse(
                graduated.Any(val => val.Item1 == false &&
                val.Item2 == STANDING.None
                )
            );
        }

    }
}
