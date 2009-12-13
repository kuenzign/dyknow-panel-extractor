﻿// <copyright file="ReportGeneration.cs" company="DPX">
// GNU General Public License v3
// </copyright>
namespace DPXDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class ReportGeneration
    {
        private Database db;

        private List<Student> students;

        private List<Section> sections;

        private List<Classdate> dates;

        private List<StudentReport> studentReport;

        public ReportGeneration(Database db, List<Classdate> dates)
        {
            this.db = db;
            this.dates = dates;
            this.students = db.GetAllStudents();
            this.sections = db.GetSections();
            
            // Generate the report... this will take a while
            this.studentReport = new List<StudentReport>();
            for (int i = 0; i < this.students.Count; i++)
            {
                this.studentReport.Add(new StudentReport(db, this.students[i], dates));
            }
        }

        public string GetReport()
        {
            string report = "Report for - ";
            for (int i = 0; i < this.dates.Count; i++)
            {
                report += this.dates[i] + " - ";
            }

            report += "\n";

            // Not the most elegant solution to break student's out by section, but it works.
            List<Section> sections = this.db.GetSections();
            for (int n = 0; n < sections.Count; n++)
            {
                report += "\n----------------------------------------------------\n";
                report += sections[n].SectionName + ":\n";
                for (int i = 0; i < this.studentReport.Count; i++)
                {
                    if (sections[n].Id == this.studentReport[i].Student.Section)
                    {
                        StudentReport sr = this.studentReport[i];
                        report += sr.ToString() + "\n";
                    }
                }
            }

            return report;
        }
    }
}