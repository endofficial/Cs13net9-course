using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using static System.Console;

Debug.WriteLine("Hello, World! I'm Debug");
Trace.WriteLine("Hello, World! I'm Trace"); // Debug è per lo sviluppo, Trace è per il runtime

// Configurare un altro listener che scriverà un file di testo 

//.Combine unisce più percorsi in uno solo
string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "log.txt");

WriteLine($"Writing to: {logPath}");

// classe che fa parte del namespace System.Diagnostic; funge da ascoltatore. Cattura l'output di Trace e Debug e lo indirizza in un'uscita
TextWriterTraceListener logFile = new(File.CreateText(logPath));

// aggiunge il listener alla lista di ascoltatori di Trace
Trace.Listeners.Add(logFile);

#if DEBUG
Trace.AutoFlush = true;
#endif

string settingsFile = "appsetting.json";

string settingsPath = Path.Combine(Directory.GetCurrentDirectory(), settingsFile);

WriteLine("Processing: {0}", settingsPath);
WriteLine(File.ReadAllText(settingsPath));
WriteLine("----");

// Non legge direttamente i file, ma agisce come un "costruttore" che ti permette di definire
// quali sorgenti di configurazione vuoi usare (come file JSON, variabili d'ambiente, segreti dell'utente, ecc.) e in quale ordine.
ConfigurationBuilder builder = new();

// SetBasePath() dice al costruttore dove iniziare a cercare i file che gli indicherai in seguito.
builder.SetBasePath(Directory.GetCurrentDirectory());

// optional: false vuol dire che il file è obbligatorio; se non lo trova, l'applicazione non partirà.
//reloadOnChange: true significa che se il file cambia, la configurazione si aggiornerà automaticamente.
builder.AddJsonFile(settingsFile, optional: false, reloadOnChange: true);

// Cerca le variabili d'ambiente e le aggiunge alla configurazione
IConfigurationRoot configuration = builder.Build();

TraceSwitch ts = new(displayName: "PacktSwitch", description: "This switch is set via a JSON config.");

// Cercaa un blocco di configurazione chiamato "PacktSwitch" e lo associa al TraceSwitch con bind(ts)
configuration.GetSection("PacktSwitch").Bind(ts); //CHIEDERE PERCHé NON FUNZIONA IL DEBUG

// Aggiunge il valore del trace switch dalla configurazione
WriteLine($"Trace switch value: {ts.Value}");
WriteLine($"Trace switch level: {ts.Level}");

Trace.WriteLineIf(ts.TraceError, "Trace error");
Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
Trace.WriteLineIf(ts.TraceInfo, "Trace info");
Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");



// chiude il listener di Debug e Trace
Debug.Close();
Trace.Close();

WriteLine("Press enter to exit.");
Console.ReadLine();

// vediamo l'uso del trace switch
/* 0 = Off
 * 1 = Error
 * 2 = Warning
 * 3 = Info
 * 4 = Verbose produce tutti i livelli
 */

