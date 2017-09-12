﻿// <copyright file="Database.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>Manager for the database.</summary>
namespace DPXDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using DPXReader;

    /// <summary>
    /// Manager for the database.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// The connection to the database.
        /// </summary>
        private OleDbConnection connection;

        /// <summary>
        /// Initializes a new instance of the Database class.
        /// </summary>
        /// <param name="filename">The path to the database file.</param>
        public Database(string filename)
        {
            this.connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Persist Security Info=False");
            this.Open();
            this.Close();
        }

        /// <summary>
        /// Gets the connection to the database.
        /// </summary>
        /// <value>The connection.</value>
        public OleDbConnection Connection
        {
            get { return this.connection; }
        }

        // QUERIES ON THE SECTION TABLE

        /// <summary>
        /// Gets a specific sections name.
        /// </summary>
        /// <param name="id">The database identifier.</param>
        /// <returns>The sections name.</returns>
        public string GetSectionName(int id)
        {
            string mySelectQuery = "SELECT S.[sectionName] FROM Sections S WHERE S.[ID] = @parm1";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            myCommand.Parameters.AddWithValue("@parm1", id);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            string section = string.Empty;
            try
            {
                if (myReader.Read())
                {
                    section = myReader.GetString(0);
                }
                else
                {
                    throw new Exception("Problem retrieving student from database");
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return section;
        }

        /// <summary>
        /// Adds a specific section to the database.
        /// </summary>
        /// <param name="name">The section to add.</param>
        /// <returns>True if operation was successful.</returns>
        public bool AddSection(string name)
        {
            this.Open();
            string query = "INSERT INTO Sections([sectionName]) VALUES(@parm1)";
            int status;
            OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
            cmdInsert.Parameters.Clear();
            try
            {
                cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                // Add parameters to the query
                cmdInsert.Parameters.AddWithValue("@parm1", name);

                status = cmdInsert.ExecuteNonQuery(); // 0 = failed, 1 = success
                if (!(status == 0))
                {
                    return false; // ItFailed
                }
                else
                {
                    return true; // It Worked!
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error"); // Display the error
            }
            finally
            {
                this.Close(); // All done
            }

            return true;
        }

        /// <summary>
        /// Gets a sections database identifier.
        /// </summary>
        /// <param name="name">The name of the section.</param>
        /// <returns>The database identifier.</returns>
        public int GetSectionId(string name)
        {
            // IMPLEMENT ME
            string mySelectQuery = "SELECT S.[ID], S.[sectionName] FROM Sections S WHERE S.[sectionName] = @parm1";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            myCommand.Parameters.AddWithValue("@parm1", name);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            int id = -1;
            try
            {
                if (myReader.Read())
                {
                    id = myReader.GetInt32(0);
                }
                else
                {
                    throw new Exception("Problem retrieving student from database");
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return id;
        }

        /// <summary>
        /// Gets all of the sections.
        /// </summary>
        /// <returns>A list of all of the sections.</returns>
        public List<Section> GetSections()
        {
            string mySelectQuery = "SELECT S.[ID], S.[sectionName] FROM Sections S ORDER BY [sectionName] ASC";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            List<Section> sections = new List<Section>();
            sections.Add(new Section(-1, "No Section"));
            try
            {
                while (myReader.Read())
                {
                    sections.Add(new Section(myReader.GetInt32(0), myReader.GetString(1)));
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return sections;
        }

        // QUERIES ON THE STUDENT TABLE

        /// <summary>
        /// Gets a list of the students.
        /// </summary>
        /// <returns>A list of all of the students.</returns>
        public List<Student> GetAllStudents()
        {
            string mySelectQuery = "SELECT S.[ID], S.[username], S.[fullName], S.[firstName], S.[lastName], S.[Section], S.[isEnrolled] FROM Students S ORDER BY S.[fullName]";
            this.Open();
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            OleDbDataReader myReader = myCommand.ExecuteReader();
            List<Student> students = new List<Student>();
            try
            {
                while (myReader.Read())
                {
                    if (myReader.IsDBNull(5))
                    {
                        students.Add(new Student(
                            myReader.GetInt32(0),
                            myReader.GetString(1),
                            myReader.GetString(2),
                            myReader.GetString(3),
                            myReader.GetString(4),
                            -1,
                            myReader.GetBoolean(6)));
                    }
                    else
                    {
                        students.Add(new Student(
                            myReader.GetInt32(0),
                            myReader.GetString(1),
                            myReader.GetString(2),
                            myReader.GetString(3),
                            myReader.GetString(4),
                            myReader.GetInt32(5),
                            myReader.GetBoolean(6)));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return students;
        }

        /// <summary>
        /// Gets a specific student.
        /// </summary>
        /// <param name="id">The student database identifier.</param>
        /// <returns>The student.</returns>
        public Student GetStudent(int id)
        {
            string mySelectQuery = "SELECT S.[ID], S.[username], S.[fullName], S.[firstName], S.[lastName], ";
            mySelectQuery += "S.[Section], S.[isEnrolled] FROM Students S WHERE S.[ID] = @parm1";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            myCommand.Parameters.AddWithValue("@parm1", id);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            Student student = new Student();
            try
            {
                if (myReader.Read())
                {
                    if (myReader.IsDBNull(5))
                    {
                        student = new Student(
                            myReader.GetInt32(0),
                            myReader.GetString(1),
                            myReader.GetString(2),
                            myReader.GetString(3),
                            myReader.GetString(4),
                            -1,
                            myReader.GetBoolean(6));
                    }
                    else
                    {
                        student = new Student(
                            myReader.GetInt32(0),
                            myReader.GetString(1),
                            myReader.GetString(2),
                            myReader.GetString(3),
                            myReader.GetString(4),
                            myReader.GetInt32(5),
                            myReader.GetBoolean(6));
                    }
                }
                else
                {
                    throw new Exception("Problem retrieving student from database");
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return student;
        }

        /// <summary>
        /// Add a student to the database.
        /// </summary>
        /// <param name="s">The student to add.</param>
        /// <returns>True on a successful add.</returns>
        public bool AddStudent(Student s)
        {
            // The section is going to be null
            if (s.Section < 0)
            {
                this.Open();
                string query = "INSERT INTO Students([username], [fullName], [firstName], [lastName], [isEnrolled]) VALUES(@parm1, @parm2, @parm3, @parm4, @parm5)";
                int status;
                OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
                cmdInsert.Parameters.Clear();
                try
                {
                    cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                    // Add parameters to the query
                    cmdInsert.Parameters.AddWithValue("@parm1", s.Username);
                    cmdInsert.Parameters.AddWithValue("@parm2", s.FullName);
                    cmdInsert.Parameters.AddWithValue("@parm3", s.FirstName);
                    cmdInsert.Parameters.AddWithValue("@parm4", s.LastName);
                    cmdInsert.Parameters.AddWithValue("@parm5", s.IsEnrolled);

                    status = cmdInsert.ExecuteNonQuery(); // 0 = failed, 1 = success
                    if (!(status == 0))
                    {
                        return false; // It Failed
                    }
                    else
                    {
                        return true; // It Worked!
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, "Error"); // Display the error
                }
                finally
                {
                    this.Close(); // All done
                }

                return true;
            }
            else
            {
                // We know what section
                this.Open();
                string query = "INSERT INTO Students([username], [fullName], [firstName], [lastName], [Section], [isEnrolled]) VALUES(@parm1, @parm2, @parm3, @parm4, @parm5, @parm6)";
                int status;
                OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
                cmdInsert.Parameters.Clear();
                try
                {
                    cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                    // Add parameters to the query
                    cmdInsert.Parameters.AddWithValue("@parm1", s.Username);
                    cmdInsert.Parameters.AddWithValue("@parm2", s.FullName);
                    cmdInsert.Parameters.AddWithValue("@parm3", s.FirstName);
                    cmdInsert.Parameters.AddWithValue("@parm4", s.LastName);
                    cmdInsert.Parameters.AddWithValue("@parm5", s.Section);
                    cmdInsert.Parameters.AddWithValue("@parm6", s.IsEnrolled);

                    status = cmdInsert.ExecuteNonQuery(); // 0 = failed, 1 = success
                    if (!(status == 0))
                    {
                        return false; // It Failed
                    }
                    else
                    {
                        return true; // It Worked!
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, "Error"); // Display the error
                }
                finally
                {
                    this.Close(); // All done
                }

                return true;
            }
        }

        /// <summary>
        /// Test to see if a username is already in the database.
        /// </summary>
        /// <param name="username">The username to test.</param>
        /// <returns>True if the username exists in the database.</returns>
        public bool IsStudentUsername(string username)
        {
            string mySelectQuery = "SELECT S.[ID], S.[username], S.[fullName], S.[firstName], S.[lastName], ";
            mySelectQuery += "S.[Section], S.[isEnrolled] FROM Students S WHERE S.[username] = @parm1";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            myCommand.Parameters.AddWithValue("@parm1", username);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            bool studentTest = false;
            try
            {
                if (myReader.Read())
                {
                    studentTest = true;
                }
                else
                {
                    throw new Exception("Problem retrieving student from database");
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return studentTest;
        }

        /// <summary>
        /// Changes the section that a student is enrolled in.
        /// </summary>
        /// <param name="section">The section database identifier.</param>
        /// <param name="studentId">The student database identifier.</param>
        /// <returns>True if the change was successful.</returns>
        public bool UpdateStudentSection(int section, int studentId)
        {
            if (section == -1)
            {
                this.Open();
                string query = "UPDATE Students AS S SET S.Section = Null WHERE S.ID = @parm2;";
                int status;
                OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
                cmdInsert.Parameters.Clear();
                try
                {
                    cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                    // Add parameters to the query
                    cmdInsert.Parameters.AddWithValue("@parm2", studentId);
                    status = cmdInsert.ExecuteNonQuery(); // 0 = failed, 1 = success
                    if (!(status == 0))
                    {
                        return false; // It Failed
                    }
                    else
                    {
                        return true; // It Worked!
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, "Error"); // Display the error
                }
                finally
                {
                    this.Close(); // All done
                }
            }
            else
            {
                this.Open();
                string query = "UPDATE Students AS S SET S.Section = @parm1 WHERE S.ID = @parm2;";
                int status;
                OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
                cmdInsert.Parameters.Clear();
                try
                {
                    cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                    // Add parameters to the query
                    cmdInsert.Parameters.AddWithValue("@parm1", section);
                    cmdInsert.Parameters.AddWithValue("@parm2", studentId);

                    status = cmdInsert.ExecuteNonQuery(); // 0 = failed, 1 = success
                    if (!(status == 0))
                    {
                        return false; // It Failed
                    }
                    else
                    {
                        return true; // It Worked!
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, "Error"); // Display the error
                }
                finally
                {
                    this.Close(); // All done
                }
            }

            return true;
        }

        /// <summary>
        /// Changes the enrollment status for a student.
        /// </summary>
        /// <param name="val">The enrollment status.</param>
        /// <param name="studentId">The student database identifier.</param>
        /// <returns>True if the change was successful.</returns>
        public bool UpdateStudentSetEnrolled(bool val, int studentId)
        {
            this.Open();
            string query = "UPDATE Students AS S SET S.isEnrolled = @parm1 WHERE S.ID = @parm2;";
            int status;
            OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
            cmdInsert.Parameters.Clear();
            try
            {
                cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                // Add parameters to the query
                if (val == true)
                {
                    cmdInsert.Parameters.AddWithValue("@parm1", true);
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@parm1", false);
                }

                cmdInsert.Parameters.AddWithValue("@parm2", studentId);

                status = cmdInsert.ExecuteNonQuery(); // 0 = failed, 1 = success
                if (!(status == 0))
                {
                    return false; // It Failed
                }
                else
                {
                    return true; // It Worked!
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error"); // Display the error
            }
            finally
            {
                this.Close(); // All done
            }

            return true;
        }

        // QUERIES ON THE FILE TABLE

        /// <summary>
        /// Adds a file to the database.
        /// </summary>
        /// <param name="f">The file to add to the database.</param>
        /// <returns>The database identifier for the new file object.</returns>
        public int AddFile(File f)
        {
            this.Open();
            string query = "INSERT INTO Files ( [Classdate], [fileName], [meanStrokes], [stdDevStrokes], ";
            query += "[minStrokes], [maxStrokes], [meanDataLength], [stdDevDataLength], [minDataLength], [maxDataLength] ) ";
            query += " VALUES(@parm1, @parm2, @parm3, @parm4, @parm5, @parm6, @parm7, @parm8, @parm9, @parm10)";

            int insertId = -1;
            OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
            cmdInsert.Parameters.Clear();
            try
            {
                cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                // Add parameters to the query
                cmdInsert.Parameters.AddWithValue("@parm1", f.Classdate);
                cmdInsert.Parameters.AddWithValue("@parm2", f.FileName);
                cmdInsert.Parameters.AddWithValue("@parm3", f.MeanStrokes);
                cmdInsert.Parameters.AddWithValue("@parm4", f.StdDevStrokes);
                cmdInsert.Parameters.AddWithValue("@parm5", f.MinStrokes);
                cmdInsert.Parameters.AddWithValue("@parm6", f.MaxStrokes);
                cmdInsert.Parameters.AddWithValue("@parm7", f.MeanDataLength);
                cmdInsert.Parameters.AddWithValue("@parm8", f.StdDevDataLength);
                cmdInsert.Parameters.AddWithValue("@parm9", f.MinDataLength);
                cmdInsert.Parameters.AddWithValue("@parm10", f.MaxDataLength);

                cmdInsert.ExecuteNonQuery();
                cmdInsert.CommandText = "Select @@Identity";
                insertId = (int)cmdInsert.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error"); // Display the error
            }
            finally
            {
                this.Close(); // All done
            }

            return insertId;
        }

        /// <summary>
        /// Add a DyKnow file to the database.
        /// </summary>
        /// <param name="dr">The DyKnow file to add.</param>
        /// <param name="d">The date of the file.</param>
        /// <returns>The database identifier for the new file.</returns>
        public int AddFile(DyKnowReader dr, DateTime d)
        {
            int classdateId = -1;
            if (!this.IsClassdate(d))
            {
                // Date is not in the database
                this.AddClassdate(d);
            }

            classdateId = this.GetClassdateId(d);

            File f = new File(
                classdateId,
                dr.FileName,
                dr.MaxStrokeCount,
                dr.MeanStrokes,
                dr.MaxStrokeCount,
                dr.MeanStrokeDistance,
                dr.MeanStrokeDistance,
                dr.StdDevStrokeDistance,
                dr.MinStrokeDistance,
                dr.MaxStrokeDistance);
            return this.AddFile(f);
        }

        // QUERIES ON THE CLASSDATE TABLE

        /// <summary>
        /// Add a classdate to the database..
        /// </summary>
        /// <param name="d">The class date to add.</param>
        /// <returns>True if the change was successful.</returns>
        public bool AddClassdate(DateTime d)
        {
            this.Open();
            string query = "INSERT INTO Classdates ( classDate ) VALUES (@parm1)";
            int status;
            OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
            cmdInsert.Parameters.Clear();
            try
            {
                cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                // Add parameters to the query
                cmdInsert.Parameters.AddWithValue("@parm1", d.Date);

                status = cmdInsert.ExecuteNonQuery(); // 0 = failed, 1 = success
                if (!(status == 0))
                {
                    return false; // It Failed
                }
                else
                {
                    return true; // It Worked!
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error"); // Display the error
            }
            finally
            {
                this.Close(); // All done
            }

            return true;
        }

        /// <summary>
        /// Determines if a class date is already in the database.
        /// </summary>
        /// <param name="d">The date to check.</param>
        /// <returns>True if the date is already in the database.</returns>
        public bool IsClassdate(DateTime d)
        {
            string mySelectQuery = "SELECT C.[ID], C.[classDate] FROM Classdates C WHERE C.[classDate] = @parm1";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            myCommand.Parameters.AddWithValue("@parm1", d.Date);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();

            bool panelFound = false;
            try
            {
                // If a row was returned the date is in the database
                if (myReader.Read())
                {
                    panelFound = true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return panelFound;
        }

        /// <summary>
        /// Gets the database identifier for a specified date.
        /// </summary>
        /// <param name="d">The date to look up an identifier for.</param>
        /// <returns>The database identifier.</returns>
        public int GetClassdateId(DateTime d)
        {
            string mySelectQuery = "SELECT C.[ID], C.[classDate] FROM Classdates C WHERE C.[classDate] = @parm1";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            myCommand.Parameters.AddWithValue("@parm1", d.Date);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            int id = -1;
            try
            {
                if (myReader.Read())
                {
                    id = myReader.GetInt32(0);
                }
                else
                {
                    throw new Exception("Problem retrieving student from database");
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return id;
        }

        /// <summary>
        /// Get a list of class dates.
        /// </summary>
        /// <returns>The list of class dates.</returns>
        public List<Classdate> GetClassdates()
        {
            string mySelectQuery = "SELECT C.[ID], C.[classDate] FROM Classdates C ORDER BY [classDate] DESC";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            List<Classdate> dates = new List<Classdate>();
            try
            {
                while (myReader.Read())
                {
                    dates.Add(new Classdate(myReader.GetInt32(0), myReader.GetDateTime(1)));
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return dates;
        }

        // QUERIES ON THE PANELS TABLE

        /// <summary>
        /// Adds a panel to the database.
        /// </summary>
        /// <param name="fileid">The file that the panel is part of.</param>
        /// <param name="d">The panel to add to the database.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool AddPanel(int fileid, DyKnowPage d)
        {
            this.Open();
            string query = "INSERT INTO Panels ( [File], [slideNumber], [username], [totalStrokeCount], ";
            query += "[netStrokeCount], [deletedStrokeCount], [totalDateLength], [netDataLength], [deletedDataLength], ";
            query += "[isBlank], [analysis] ) VALUES(@parm1, @parm2, @parm3, @parm4, @parm5, @parm6, @parm7, @parm8, ";
            query += "@parm9, @parm10, @parm11)";
            int status;
            OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
            cmdInsert.Parameters.Clear();
            try
            {
                cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                // Add parameters to the query
                cmdInsert.Parameters.AddWithValue("@parm1", fileid);
                cmdInsert.Parameters.AddWithValue("@parm2", d.PageNumber);
                cmdInsert.Parameters.AddWithValue("@parm3", d.UserName);
                cmdInsert.Parameters.AddWithValue("@parm4", d.TotalStrokeCount);
                cmdInsert.Parameters.AddWithValue("@parm5", d.NetStrokeCount);
                cmdInsert.Parameters.AddWithValue("@parm6", d.DeletedStrokeCount);
                cmdInsert.Parameters.AddWithValue("@parm7", d.TotalStrokeDistance);
                cmdInsert.Parameters.AddWithValue("@parm8", d.NetStrokeDistance);
                cmdInsert.Parameters.AddWithValue("@parm9", d.DeletedStrokeDistance);
                cmdInsert.Parameters.AddWithValue("@parm10", d.IsBlank);
                cmdInsert.Parameters.AddWithValue("@parm11", d.Finished);

                status = cmdInsert.ExecuteNonQuery(); // 0 = failed, 1 = success
                if (!(status == 0))
                {
                    return false; // It Failed
                }
                else
                {
                    return true; // It Worked!
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error"); // Display the error
            }
            finally
            {
                this.Close(); // All done
            }

            return true;
        }

        /// <summary>
        /// Gets all of the panels for the specified student.
        /// </summary>
        /// <param name="studentid">The students database identifier.</param>
        /// <returns>The list of panels.</returns>
        public List<DisplayPanelInfo> GetPanelsForStudent(int studentid)
        {
            string mySelectQuery = "SELECT Classdates.classDate, Files.fileName, Panels.slideNumber, Panels.totalStrokeCount, Panels.netStrokeCount, Panels.isBlank, Panels.analysis FROM (Classdates INNER JOIN Files ON Classdates.ID = Files.Classdate) INNER JOIN (Students INNER JOIN Panels ON Students.username = Panels.username) ON Files.ID = Panels.File WHERE (((Students.ID)= @parm1)) ORDER BY Classdates.classDate DESC;";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            myCommand.Parameters.AddWithValue("@parm1", studentid);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            List<DisplayPanelInfo> panelinfo = new List<DisplayPanelInfo>();
            try
            {
                while (myReader.Read())
                {
                    panelinfo.Add(new DisplayPanelInfo(
                        myReader.GetDateTime(0),
                        myReader.GetString(1),
                        myReader.GetInt32(2),
                        myReader.GetInt32(3),
                        myReader.GetInt32(4),
                        myReader.GetBoolean(5),
                        myReader.GetString(6)));
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return panelinfo;
        }

        // QUERIES ON THE EXCEPTIONS TABLE

        /// <summary>
        /// Add an exception to the database.
        /// </summary>
        /// <param name="e">Exception to be added.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool AddException(Exceptions e)
        {
            this.Open();
            string query = "INSERT INTO Exceptions ( [Classdate], [Student], [Reason], [notes] ) ";
            query += "VALUES (@parm1, @parm2, @parm3, @parm4)";
            int status;
            OleDbCommand cmdInsert = new OleDbCommand(query, this.connection);
            cmdInsert.Parameters.Clear();
            try
            {
                cmdInsert.CommandType = System.Data.CommandType.Text; // Type of query
                // Add parameters to the query
                cmdInsert.Parameters.AddWithValue("@parm1", e.Classdate);
                cmdInsert.Parameters.AddWithValue("@parm2", e.Student);
                cmdInsert.Parameters.AddWithValue("@parm3", e.Reason);
                cmdInsert.Parameters.AddWithValue("@parm4", e.Notes);

                status = cmdInsert.ExecuteNonQuery(); // 0 = failed, 1 = success
                if (!(status == 0))
                {
                    return false; // It Failed
                }
                else
                {
                    return true; // It Worked!
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error"); // Display the error
            }
            finally
            {
                this.Close(); // All done
            }

            return true;
        }

        /// <summary>
        /// Gets all of the exceptions for the specified student.
        /// </summary>
        /// <param name="studentid">The students database identifier.</param>
        /// <returns>List of exceptions for the student.</returns>
        public List<DisplayExceptionInfo> GetExceptionsForStudent(int studentid)
        {
            string mySelectQuery = "SELECT Classdates.classDate, Reasons.Credit, Reasons.description, Exceptions.notes FROM Classdates INNER JOIN (Reasons INNER JOIN (Students INNER JOIN Exceptions ON Students.ID = Exceptions.Student) ON Reasons.ID = Exceptions.Reason) ON Classdates.ID = Exceptions.Classdate WHERE Students.ID = @parm1 ORDER BY Classdates.classDate DESC;";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            myCommand.Parameters.AddWithValue("@parm1", studentid);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            List<DisplayExceptionInfo> exceptionlist = new List<DisplayExceptionInfo>();
            try
            {
                while (myReader.Read())
                {
                    exceptionlist.Add(new DisplayExceptionInfo(
                        myReader.GetDateTime(0),
                        myReader.GetBoolean(1),
                        myReader.GetString(2),
                        myReader.GetString(3)));
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return exceptionlist;
        }

        // QUERIES ON THE REASON TABLE

        /// <summary>
        /// Get the list of reasons.
        /// </summary>
        /// <returns>The list of reasons.</returns>
        public List<Reason> GetReasons()
        {
            string mySelectQuery = "SELECT R.[ID], R.[Credit], R.[description] FROM Reasons R ORDER BY [ID] ASC";
            OleDbCommand myCommand = new OleDbCommand(mySelectQuery, this.connection);
            this.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            List<Reason> reasons = new List<Reason>();
            try
            {
                while (myReader.Read())
                {
                    reasons.Add(new Reason(
                        myReader.GetInt32(0),
                        myReader.GetBoolean(1),
                        myReader.GetString(2)));
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                myReader.Close();
                this.Close();
            }

            return reasons;
        }

        // REPORT GENERATION

        /// <summary>
        /// Generate a report for the specified dates.
        /// </summary>
        /// <param name="dates">The list of dates.</param>
        /// <returns>The report.</returns>
        public string GenerateReport(List<Classdate> dates)
        {
            List<string> report = new List<string>();
            ReportGeneration rg = new ReportGeneration(this, dates);
            return rg.GetReport();
        }

        // DATABASE MANAGEMENT

        /// <summary>
        /// Open the database.
        /// </summary>
        private void Open()
        {
            this.connection.Open();
        }

        /// <summary>
        /// Close the database.
        /// </summary>
        private void Close()
        {
            this.connection.Close();
        }
    }
}