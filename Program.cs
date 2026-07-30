using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ETS2_DevMode_Activator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ETS2 Developer & Console Mode Activator";
            PrintHeader();

            try
            {
                // 1. Locate Documents Folder
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string ets2Path = Path.Combine(documentsPath, "Euro Truck Simulator 2");
                string configFilePath = Path.Combine(ets2Path, "config.cfg");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[Info] Searching for config.cfg in default location...");
                Console.ResetColor();
                Console.WriteLine($"Target Path: {configFilePath}\n");

                if (!File.Exists(configFilePath))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[Warning] Could not find config.cfg at the default location.");
                    Console.WriteLine("Please enter the custom path to your config.cfg file manually:");
                    Console.ResetColor();
                    Console.Write("> ");
                    string? customPath = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(customPath))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[Error] Path cannot be empty. Exiting.");
                        Console.ResetColor();
                        PressAnyKeyToExit();
                        return;
                    }

                    configFilePath = customPath.Replace("\"", "").Trim(); // Clean quotes if drag-dropped

                    if (!File.Exists(configFilePath))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[Error] The file at '{configFilePath}' does not exist. Exiting.");
                        Console.ResetColor();
                        PressAnyKeyToExit();
                        return;
                    }
                }

                // 2. Perform backup
                string backupPath = configFilePath + ".bak";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[Info] Creating backup of current configuration...");
                Console.ResetColor();
                File.Copy(configFilePath, backupPath, true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[Success] Backup created: {backupPath}\n");
                Console.ResetColor();

                // 3. Process file
                string[] lines = File.ReadAllLines(configFilePath);
                bool devUpdated = false;
                bool consoleUpdated = false;

                // Match pattern: uset g_developer "value" (accounting for varying whitespace)
                Regex devRegex = new Regex(@"^\s*uset\s+g_developer\s+""[^""]*""");
                Regex consoleRegex = new Regex(@"^\s*uset\s+g_console\s+""[^""]*""");

                for (int i = 0; i < lines.Length; i++)
                {
                    if (devRegex.IsMatch(lines[i]))
                    {
                        lines[i] = "uset g_developer \"1\"";
                        devUpdated = true;
                    }
                    else if (consoleRegex.IsMatch(lines[i]))
                    {
                        lines[i] = "uset g_console \"1\"";
                        consoleUpdated = true;
                    }
                }

                // If not found in file, we append them
                var finalLines = new System.Collections.Generic.List<string>(lines);
                if (!devUpdated)
                {
                    finalLines.Add("uset g_developer \"1\"");
                    devUpdated = true;
                    Console.WriteLine("[Info] 'g_developer' not found, appending to file.");
                }
                if (!consoleUpdated)
                {
                    finalLines.Add("uset g_console \"1\"");
                    consoleUpdated = true;
                    Console.WriteLine("[Info] 'g_console' not found, appending to file.");
                }

                // 4. Save changes
                File.WriteAllLines(configFilePath, finalLines);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("====================================================");
                Console.WriteLine("[Success] ETS2 Developer & Console modes successfully enabled!");
                Console.WriteLine("====================================================\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("How to use in-game:");
                Console.ResetColor();
                Console.WriteLine("1. Start Euro Truck Simulator 2.");
                Console.WriteLine("2. Press the ` (tilde) key to open the console console overlay.");
                Console.WriteLine("3. Press '0' on your main keyboard (not Numpad) to toggle Free Camera mode.");
                Console.WriteLine("4. Use Numpad 8, 5, 4, 6 to move the camera, and mouse scroll to adjust speed.");
                Console.WriteLine("5. Press Ctrl+F9 to teleport your truck to the free camera position.");
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }

            PressAnyKeyToExit();
        }

        static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("====================================================");
            Console.WriteLine("    ETS2 Developer & Console Mode Config Activator  ");
            Console.WriteLine("    Developed by Playhaux (https://playhaux.com)    ");
            Console.WriteLine("====================================================");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void PressAnyKeyToExit()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
