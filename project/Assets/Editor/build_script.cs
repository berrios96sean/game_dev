using UnityEditor;

public class BuildScript
{
    public static void Build()
    {
        string[] scenes = { "Assets/Scenes/Wyatt's Scene.unity" }; // Add your scene paths here

        string buildPath = "Builds/"; // Specify the build output path

        BuildPipeline.BuildPlayer(scenes, buildPath, BuildTarget.StandaloneLinux64, BuildOptions.None);
    }
}
