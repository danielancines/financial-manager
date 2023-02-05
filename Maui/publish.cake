Task("Clean")
    .Does(() =>
{
    CleanDirectory($"./Maui.FinancialManager/bin");
    CleanDirectory($"./Maui.FinancialManager/obj");
    CleanDirectory($"./Maui.FinancialManager.Core/bin");
    CleanDirectory($"./Maui.FinancialManager.Core/obj");
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetRestore("./Maui.FinancialManager/Financial Buddy.csproj");
    DotNetRestore("./Maui.FinancialManager.Core/Maui.FinancialManager.Core.csproj");
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetPublish("./Maui.FinancialManager/Financial Buddy.csproj",
        new DotNetPublishSettings()
        {
            Configuration = "Release",
            Framework = "net7.0-ios",
            MSBuildSettings = new DotNetMSBuildSettings().WithProperty("ArchiveOnBuild", "true")
        });
});

RunTarget("Build");