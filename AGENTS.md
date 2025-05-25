# Contributor Guide

## Hints of develop environment

- The `Website` folder will be rebuilt using SolidJS in the future.
  Keep editing to a minimum.
- The following folders are imported external assets and shouldn't be edited.
  - `Assets`
  - `Packages/com.vrchat.*`
- The `*.cs` file may be UdonSharp. Please keep in mind the limitations of
  UdonSharp 1.0 when editing.
  - The test code in UdonSharp does not support Unity's Edit Mode; it only
    supports Play Mode. Consider this when implementing the test code.
