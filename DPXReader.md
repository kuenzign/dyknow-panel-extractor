# Introduction #
This library provides a means to read in DyKnow files.  DyKnowReader is capable of parsing the XML that is contained in a DyKnow file and reading the individual panels that are contained within the file.

## Legacy Reader ##
This method employs direct XML parsing and is used by DPXManager.  This approach is not the ideal method for reading in files and will eventually be replaced.  There is limited support for rendering the contents of a panel onto an InkCanvas, but it will no longer be improved and is restricted to ink and images only.

## DyKnow Reder ##
This second generation approach to reading in a DyKnow file uses Microsoft's built in serialization methods to directly load the contents of the file into memory by creating instances of the objects in memory.  This approach benefits from the fact that it attempts to accurately represent the DyKnow file and allows for the writing of files.

The current applications that use this library are DPXGrader and DPXPreview.  The rendering support for this method is slightly more advanced than the legacy approach and will continue to improve.

### Known Panel Rendering Problems ###
  * Elements that are not shown
    * Polls (See [issue 13](https://github.com/kuenzign/dyknow-panel-extractor/issues/13))
    * Web pages
    * Page text (See [issue 14](https://github.com/kuenzign/dyknow-panel-extractor/issues/14))
    * Text boxes (See [issue 15](https://github.com/kuenzign/dyknow-panel-extractor/issues/15))
  * Resized or moved ink does not render the transformation properly (See [issue 12](https://github.com/kuenzign/dyknow-panel-extractor/issues/12))

### Workaround for [issue 12](https://github.com/kuenzign/dyknow-panel-extractor/issues/12) ###
The solution to properly rendering resized or moved elements on the DyKnow panel is to remove the panel history using DyKnow before opening the file using DPX.

## Important Notes ##
DyKnow's ability to store the history of modifications to a file prevents the contents of the InkCanvas from being modified.
