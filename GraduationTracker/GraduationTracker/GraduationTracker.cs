using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;

            foreach (int reqId in diploma.Requirements)
            {
                Requirement req = Repository.GetRequirement(reqId);

                foreach (int courseID in req.Courses)
                {
                    Course course = Array.Find(student.Courses, val => val.Id == courseID);
                    average += course.Mark;
                    if (course.Mark > req.MinimumMark)
                        credits += req.Credits;
                }
            }
            average /= student.Courses.Length;

            if (average < 50)
                return new Tuple<bool, STANDING>(false, STANDING.Remedial);
            else if (average < 80)
                return new Tuple<bool, STANDING>(true, STANDING.Average);
            else if (average < 95)
                return new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
            else
                return new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);

        }
    }
}
