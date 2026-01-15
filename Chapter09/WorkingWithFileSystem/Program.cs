using Spectre.Console;

#region Handling cross-platform enviroments and filesystem

SectionTitle("Handling cross-platform enviroments and filesystem");

//Creo una tabella spectre console
Table table = new();

//Aggiungo le colonne
table.AddColumn("[blue]MEMBER[/]");
table.AddColumn("[blue]VALUE[/]"); //Uso il markup di spectre console per colorare il testo

//Aggiungo le righe
table.AddRow("Path.PathSeparator", PathSeparator.ToString());
table.AddRow("Path.DirectorySeparatorChar", DirectorySeparatorChar.ToString());
table.AddRow("Directory.GetCurrentDirectory()", GetCurrentDirectory());
table.AddRow("Enviroment.CurrentDirectory", CurrentDirectory);
table.AddRow("Enviroment.SystemDirectory", SystemDirectory);
table.AddRow("Path.GetTempPath()", GetTempPath());
table.AddRow("");
table.AddRow("GetFolderPath(SpecialFolder", "");
table.AddRow("  .System)", GetFolderPath(SpecialFolder.System));
table.AddRow("  .ApplicationData)", GetFolderPath(SpecialFolder.MyDocuments));
table.AddRow("  .Personal)", GetFolderPath(SpecialFolder.Personal));

AnsiConsole.Write(table);

#endregion

#region Managing drives

SectionTitle("Managing drives");

Table drives = new();

//Aggiungo le colonne
drives.AddColumn("[blue]NAME[/]");
drives.AddColumn("[blue]TYPE[/]");
drives.AddColumn("[blue]FORMAT[/]");
drives.AddColumn(new TableColumn("[blue]SIZE (BYTES)[/]").RightAligned()); //utilizzo di nuovo new perché voglio allineare a destra la colonna
drives.AddColumn(new TableColumn("[blue]FREE SPACE[/]").RightAligned());

//Ottengo le informazioni sui drive
foreach (DriveInfo drive in DriveInfo.GetDrives())
{
    if (drive.IsReady)
    {
        drives.AddRow(drive.Name, drive.DriveType.ToString(), drive.DriveFormat, drive.TotalSize.ToString("N0"), drive.AvailableFreeSpace.ToString("N0")); //N0 formatta il numero con le virgole. Ovvero 1000000 diventa 1,000,000
    }
    else
    {
        drives.AddRow(drive.Name, drive.DriveType.ToString(), string.Empty, string.Empty, string.Empty);
    }
}

AnsiConsole.Write(drives);

#endregion

#region Managing directories

SectionTitle("Managing directories");

string newFolder = Combine(GetFolderPath(SpecialFolder.MyDocuments), "NewFolder");

WriteLine($"Working with: {newFolder}");

//Dobbiamo specificare esplicitamente quale metodo Exists utilizzare
//perché abbiamo importato staticamente sia Path che Directory.
WriteLine($"Does it exist? {Directory.Exists(newFolder)}"); //Controlla se esiste

WriteLine("Creating it...");
CreateDirectory(newFolder); //Crea la cartella

WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
Write("Confirm the directory exists, and then press any key.");
ReadKey(intercept: true);

WriteLine("Deleting it...");
Delete(newFolder, recursive: true); //Elimina la cartella. Recursive true elimina anche il contenuto
WriteLine($"Does it exist? {Path.Exists(newFolder)}");


#endregion

#region Managing files

SectionTitle("Managing files");

string dir = Combine(GetFolderPath(SpecialFolder.MyDocuments), "OutputFiles");

CreateDirectory(dir);

//Definire il percorso del file
string textFile = Combine(dir, "Dummy.txt");
string backupFile = Combine(dir, "Dummy.bak");
WriteLine($"Working with: {textFile}"); //Mostra il percorso del file
WriteLine($"Does it exist? {File.Exists(textFile)}"); //Controlla se esiste

//Creo un nuovo file di testo e ci scrivo dentro
StreamWriter textWriter = File.CreateText(textFile); //Crea il file; streamwriter per scrivere dentro
textWriter.WriteLine("Hello C#!");
textWriter.Close(); 
WriteLine($"Does it exist? {File.Exists(textFile)}"); //Controlla se esiste

File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);

WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
WriteLine("Confirm the files exist, and then press any key.");
ReadKey(intercept: true);

//Cancello il file 
File.Delete(textFile);
WriteLine($"Does it exist? {File.Exists(textFile)}");

//Leggo il contenuto del file di backup
WriteLine($"Reading contents of {backupFile}:");
StreamReader textReader = File.OpenText(backupFile);
WriteLine(textReader.ReadToEnd());
textReader.Close();

#endregion

#region Managing paths

SectionTitle("Managing paths");

WriteLine($"Folder name: {GetDirectoryName(textFile)}");
WriteLine($"File name: {GetFileName(textFile)}");
WriteLine($"File name without extension: {GetFileNameWithoutExtension(textFile)}");
WriteLine($"File extension: {GetExtension(textFile)}");
WriteLine($"Random file name: {GetRandomFileName()}");
WriteLine($"Temporary file name: {GetTempFileName()}");

#endregion

#region Getting file information

SectionTitle("Getting file information");

FileInfo info = new(backupFile); //Creo un oggetto FileInfo per ottenere informazioni sul file
WriteLine($"{backupFile}");
WriteLine($"Contains {info.Length} bytes");
WriteLine($"Last accessed: {info.LastAccessTime}");
WriteLine($"Has readonly set to {info.IsReadOnly}");

#endregion

#region hoy you work with files

//FileStream file = File.Open(pathToFile, FileMode.Open, FileAccess.Read, FileShare.Read);

FileInfo infof = new(backupFile);
WriteLine("Is the backup file compressed? {0}", info.Attributes.HasFlag(FileAttributes.Compressed));

#endregion