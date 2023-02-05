Task("Clean")
    .Does(() =>
{
    CleanDirectory($"./Maui.FinancialManager/bin");
    CleanDirectory($"./Maui.FinancialManager/obj");
    CleanDirectory($"./Maui.FinancialManager.Core/bin");
    CleanDirectory($"./Maui.FinancialManager.Core/obj");
});

RunTarget("clean");