<pre>Övning 12: Garage 2.0 - Återkomsten
Garaget kommer till webben i ASP.NET MVC! Då detta är den första MVC-baserade
garageversionen så kommer vi att fokusera på gränssnitt och funktionalitet.
Uppgiftsbeskrivningen är skriven i prioriteringsordning. De första punkterna är
grundläggande för applikationen, de senare är mer av bonuskaraktär.
Singelmodell
I denna version vill vi bara använda en ensam modell - precis som i tidigare
MVC-övningar. Alltså inte en modell för varje fordonstyp, utan endast en klass
Fordon / Vehicle med fält som motsvarar: typ , registreringsnummer , färg , märke ,
modell , antal hjul .
Grundfunktionalitet
● Fordon skall kunna parkeras och hämtas ut.
● Vid parkering skall användaren kunna fylla i fordonets data.
● Det skall finnas en översiktsvy där alla parkerade fordon visas med viss grunddata
t.ex. Typ, RegNr, färg & parkeringstid*.
● En detaljvy för varje fordon där övrig infomation visas, t.ex. antal hjul , märke &
modell .
Utseende
Applikationen skall ha ett enhetligt utseende, tydligt och lättnavigerat. Språk och
instruktioner skall vara anpassade för användningen, exempelvis: vi skapar inte en bil - vi
parkerar/checkar in bilen, vi skall inte heller radera en bil - vi “hämtar/checkar ut den”
osv.
Input-kontroll
Vissa input vill vi inte att användaren skall kunna skriva hur de vill i fritext. Viss
inputkontroll ges av scaffoldingen (endast nummer i sifferfält osv), andra vill vi hantera
manuellt.
Tidstämpel
En tidsstämpel för när fordonet parkerades (lagras i databasen tillsammans med övrig
fordinsinformation) bör inte matas in manuellt utan skall genereras och sparas
automatiskt när användaren checkar in ett fordon. Om man endast scaffoldar
(auto-genererar) vyerna så kommer detta input dock att dyka upp som ett fritext fält -
hantera detta.
Fordonstyper
Fordonstyp skall gärna inte heller skrivas in manuellt, utan skall finnas som en
dropdownlista som bara innehåller giltiga fordonstyper. I MVC-projekt av versionen
högre än 5.1 görs detta enkelt med enum , utan behov av ytterligare modeller:
www.codeproject.com/Articles/776908/Dealing-with-Enum-in-MVC
* parkeringstid är en bonusuppgift/senare prioriterad
Filtrering och sortering
I takt med antalet parkerade fordon så växer behovet av en sökfunktion. Implementera
en sökning för registreringsnummer. Om tid finns så utöka sökningen till de andra
fälten. Om Ytterligare tid finns så implementera även sorteringsknappar ovanför
kolumnerna i översiktsvyn så att användaren kan välja en kolumn att sortera fallande.
Kvitto
I samband med utcheckning så har vissa kunder ett behov av ett kvitto för att redovisa
hur länge de parkerat. Implementera en ny vy som visar fordonsinformationen,
in/ut-checkningstid, total parkeringsperiod och pris automatiskt efter att en bil checkats
ut. Om tid finns, gör denna utskriftsvänlig. Ni sätter ert eget pris, men 60kr/timme ger er
fina avrundningar till att börja med.
Lycka till!
</pre>
