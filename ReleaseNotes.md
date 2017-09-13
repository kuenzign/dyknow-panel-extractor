## [Version 0.3.5.0](https://github.com/kuenzign/dyknow-panel-extractor/releases/download/DPX-Tools_0_3_5_0/DPX-Tools.0.3.5.0.msi) ##
**Released 3/20/2011**
  * Improved version of [DPX Answers](DPXAnswers.md) that has an improved interface for displaying and manipulating the answers that are automatically extracted and recognized from the Answer Boxes.  The visual improvements include displaying the ink content from each Answer Box for the entire panel and each individual Answer Box.
  * Provided an extensible framework for [DPX Answers](DPXAnswers.md) for automated clustering of individual answers based on a provided interface.  The IClusterAlgorithm is automatically detected and used when available in a user provided DLL file.  This download does not include any clustering algorithm, only identical answers will be automatically clustered.

## [Version 0.3.4.0](https://github.com/kuenzign/dyknow-panel-extractor/releases/download/DPX-Tools_0_3_4_0/DPX-Tools.0.3.4.0.msi) ##
**Released 10/23/2010**
  * The initial release of [DPX Answers](DPXAnswers.md) is able to analyze and grade the contents of AnswerBoxes.  When a file is opened, the contents of answer boxes are automatically anslyzed using handwriting recognition.  The individual answer boxes can then be graded and the results can be saved as a CSV file.
  * The [DPX Grader](DPXGrader.md) window can now be maximized and some minor improvements were made to the GUI to accomidate this change.
  * [DPX Parser Validator](DPXParserValidator.md) was made its own application.  Improvements to this application include using a thread for each CPU core and some other minor changes to the GUI.
  * [DPX Preview](DPXPreview.md) now matches the formatting and style of other application in the DPX-Tools suite.
  * [DPX Sorter](DPXSorter.md) uses a custom parser to perform the sorting of panels, and this code was moved out of the DPXReader library and directly into the application.  This application should use the [DPX Reader](DPXReader.md) library to perform the sorting ([issue 18](https://github.com/kuenzign/dyknow-panel-extractor/issues/18)).
  * The About window for the applications now matches the color scheme of the DPX-Tools suite.

## [Version 0.3.3.0](https://github.com/kuenzign/dyknow-panel-extractor/releases/download/DPX-Tools_0_3_3_0/DPX-Tools.0.3.3.0.msi) ##
**Released 8/13/2010**
  * [DPX Grader](DPXGrader.md) processes panels using multi-threaded workers to speed up the process.  A worker is created for each CPU core so computers with multiple cores will process files faster.
  * This release is compiled for x86 compatibility.  Some of the previous releases may not have been compiled using these setting.
  * Some minor tweaks to the [DPX Reader](DPXReader.md) library.

## [Version 0.3.2.0](https://github.com/kuenzign/dyknow-panel-extractor/releases/download/DPX-Tools_0_3_2_0/DPX-Tools.0.3.2.0.msi) ##
**Released 7/4/2010**
  * More improvements to the [DPX Reader](DPXReader.md) library that corrected problems with reading several types of files.  These corrections were made by using the Parser Validator and analyzing files.
  * ABOX (answer boxes) are now rendered on the panel as grey rectangles.

## [Version 0.3.1.0](https://github.com/kuenzign/dyknow-panel-extractor/releases/download/DPX-Tools_0_3_1_0/DPX-Tools.0.3.1.0.msi) ##
**Released 6/25/2010**
  * A minor release that fixed a threading issue that crashed the application when the option for writing out the results of the Parser Validator was selected.
  * Added another known files issue to the list of known problems (missing TXTMODEMODXAML and TXTMODEPARTXAML tags).
  * Fixed a variety of DPX parser bugs that were identified by analyzing another set of (older) files.

## [Version 0.3.0.0](https://github.com/kuenzign/dyknow-panel-extractor/releases/download/DPX-Tools_0_3_0_0/DPX-Tools.0.3.0.0.msi) ##
**Released 6/24/2010**
  * Newly added [DPX Grader](DPXGrader.md) application is able to recognize hand written text located in the corner of a page and convert it to text.  The results can then be saved as a CSV file which includes the participant's username and full name if it was collected in a DyKnow session..
  * A completely new serialization technique is now being used by [DPX Preview](DPXPreview.md) as well as [DPX Grader](DPXGrader.md).  This properly deserializes all known elements in a DyKnow file.  Additionally, images on DyKnow files are now more accurately rendered on the InkCanvas.  The other applications are still using manual XML parsing.
  * Included with [DPX Preview](DPXPreview.md) is a tool that tests the accuracy of the new serialization technique.  This new "Parser Validator" is able to perform a test on a set of DyKnow files to identify any errors that occur during the serialization and deserialization process.

## [Version 0.2.0.0](https://github.com/kuenzign/dyknow-panel-extractor/releases/download/DPX-Tools_0_2_0_0/DPX-Tools.0.2.0.0.msi) ##
**Released 5/12/2010**

  * Updated the structure of the project so that the names of each executable match the actual applications name.
  * Added a "Save Report" button to the report tab that saves the contents of the report window to a text file


## [Version 0.1.0.0](https://github.com/kuenzign/dyknow-panel-extractor/releases/download/DPX-Tools_0_1_0_0/DPX-Tools.0.1.0.0.msi) ##
**Released 4/28/2010**

  * This first release of DPX includes three software tools: [DPX Manager](DPXManager.md), [DPX Preview](DPXPreview.md), and [DPX Sorter](DPXSorter.md).  [DPX Manager](DPXManager.md) is the main software tool capable of importing DyKnow panels into a database and generating reports based off of the dates that each panel was submitted.  This first release is still considered a beta quality product.
