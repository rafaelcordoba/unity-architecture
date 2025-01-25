using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor;

namespace GitTools
{
    public static class Solution
    {
        public static void Sync()
        {
            var projectGeneration = new ProjectGeneration();
            AssetDatabase.Refresh();
            projectGeneration.GenerateAndWriteSolutionAndProjects();
        }
    }
}