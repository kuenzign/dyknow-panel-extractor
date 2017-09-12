![http://lh5.ggpht.com/_l4Rv5VGKzLQ/S_AIbmqqHBI/AAAAAAAAAbY/CmbksmrExmE/s400/DPXManager.png](http://lh5.ggpht.com/_l4Rv5VGKzLQ/S_AIbmqqHBI/AAAAAAAAAbY/CmbksmrExmE/s400/DPXManager.png)

# Introduction #
This document describes the features of the DyKnow Panel eXtractor.

# Interfaces #
  * Import student roster into the database (CSV file including Student name, username, and section)
  * Add / Update student in the database  (Includes toggling a student's enrollment status)
  * Change a student from one section to another. (Also lists students currently not in a section)
  * Manage the list of sections (Add / Update sections)
  * Import DyKnow file into the database (Includes adding new students into the database)  Dyknow file is previewed before it is imported.
  * Add Student Exception to the database
  * Display a summary for a single student (easily searchable)
  * Generate a grade report for specific days

### Tabs ###
  * Import DyKnow File
  * Manage Students
  * Generate Report

# Compatibility #
## 64 Bit ##
There is only a 32 bit version of DPX, but it does run on 64 bit computers.  This is because of the Microsoft.ACE.OLEDB.12.0 library only supports 32 bit applications, even under a 64 bit version of Windows.  _Builds of DPX should be built in x86 mode, but it is possible that some releases are cross compiled to x64 and will not work on 64 bit systems._

## Access OLEDB Driver ##
If you do not have Office 2007 installed you can install the OLEDB driver for Access by downloading and installing the appropriate file from here: http://www.microsoft.com/downloads/details.aspx?FamilyID=7554F536-8C28-4598-9B72-EF94E038C891&displaylang=en