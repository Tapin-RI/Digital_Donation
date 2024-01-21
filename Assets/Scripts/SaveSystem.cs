/*
 C# Save System
 Author: Landon Montecalvo
 
 C# script designed to save and extract text from a ".txt" within a given directory of a Unity project.
 
 All Functionality:
    - Save string array.
    - Load ".txt" file.
    - Find number of save files.
*/

using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static readonly string Path = Application.dataPath + "/Saves/save"; // Defines root of save directory without identifier.

    public void Save(string[] saveContents) // Writes given string array to a ".txt" file.
    {
        // Prepares string array for writing.
        var saveString = string.Join(",", saveContents);
        var saveDirectory = Path + GetSaveCount() + ".txt";
        
        // Writes string to file.
        File.WriteAllText(saveDirectory, saveString);
    }

    public string[] Load(int saveCount) // Reads a ".txt" with the given identifier and returns string array.
    {
        var saveDirectory = Path + saveCount + ".txt"; // Generates required directory.
        
        // Reads the string, then formats it for return.
        var loadString = File.ReadAllText(saveDirectory);
        var loadContents = loadString.Split(",");

        return loadContents; // Returns the contents of the loaded ".txt" file in string array form.
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public static int GetSaveCount() // Gets the number of save files in the save directory.
    {
        var fileCount = 0;
        while (File.Exists(Path + fileCount)) fileCount++; // Looks for save file with "x" number until it doesn't find one.

        return fileCount; // Returns number of save files in integer form.
    }
}
