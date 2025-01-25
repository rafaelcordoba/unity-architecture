using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor;
using UnityEngine;

namespace GitTools
{
    public static class Solution
    {
        public static void Sync()
        {
            Debug.Log("generating solution files");
            var projectGeneration = new ProjectGeneration();
            AssetDatabase.Refresh();
            projectGeneration.GenerateAndWriteSolutionAndProjects();
        }
    }
}