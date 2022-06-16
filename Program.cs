using System;
namespace consoleApp
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.Write("\nEnter the search path: ");
            string path = Console.ReadLine();

            Console.Write("\nEnter the search word: ");
            string fileName = Console.ReadLine();

            Console.Write("\nEnter the search file type: ");
            string? fileType = Console.ReadLine();

            SearchFile(path, fileName, fileType);
        }

        public static void SearchFile(string mainPath, string fileName, string? fileType)
        {
            try
            {               
                List<string> lstDirectories = new List<string>();
                List<string> lstFiles = new List<string>();
                
                lstDirectories.Add(mainPath);

                DirectoryInfo MainDir;
                string path = "", block = "■", back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
          
                for (int i = 0; i < lstDirectories.Count; i++)
                {
                    path = lstDirectories[i];

                    MainDir = new DirectoryInfo(path);
            
                    foreach(DirectoryInfo dir in MainDir.GetDirectories())
                    {
                        lstDirectories.Add(dir.FullName);
                    }
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;

                for (int i = 0; i < lstDirectories.Count; i++)
                {
                    path = lstDirectories[i];

                    MainDir = new DirectoryInfo(path);
            
                    foreach(FileInfo file in MainDir.GetFiles())
                    {
                        if(file.Name.Contains(fileName))
                            lstFiles.Add("==> " + file.FullName);
                    }

                    System.Threading.Thread.Sleep(20);
                    double per = ((double) i / (double)lstDirectories.Count() * (double)100);
                    string progres = "";
                    for (int j = 0; j <= per/2; j++)
                    {
                        progres += block;
                    }
                    Console.Write(back + "progress: " + progres + $" [%{per.ToString("00.00")}]");
                }

                Console.WriteLine("\n");
                
                if(!string.IsNullOrEmpty(fileType))
                    lstFiles = lstFiles.Where(x => x.EndsWith(fileType)).ToList();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Join("\n", lstFiles));
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"\n ==> Total: {lstFiles.Count} \n ==> Search about: {fileName} \n ==> File type: {fileType} \n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (System.Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
