![https://lh5.googleusercontent.com/_l4Rv5VGKzLQ/TYaR0wTjxjI/AAAAAAAAAgU/0e2H-fWkEBQ/s400/DPXAnswers.png](https://lh5.googleusercontent.com/_l4Rv5VGKzLQ/TYaR0wTjxjI/AAAAAAAAAgU/0e2H-fWkEBQ/s400/DPXAnswers.png)

# Introduction #

This application provides a semi-automated way to process student responses and grade panels for accuracy.  The DyKnow file is read in and the ink contents of AnswerBoxes are automatically converted to strings using handwriting recognition.  The individual boxes are then marked as correct or incorrect and the results can be saved as a CSV file.

An extensible framework is included as part of this application that allows for the automated clustering of student responses.  The IClusterAlgorithm interface is used to automatically detect a class that is contained within a DLL file that is place within the application directory.  This algorithm is able to use the the data provided by the ClusterLibraryCore.dll file to manipulate the groups of answers that are automatically recognized by DPX Answers.