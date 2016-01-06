// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
open FileControler
open Log

[<EntryPoint>]
let main argv = 
    if not (argv.Length = 1) 
    then Log.LogMsg("Należy podać argument wywołania programu wskazujący na plik do odczytu",Log.LogType.Error); System.Environment.Exit 1
    
    let path = (string)(argv.GetValue(0))
    let fc = FileControler.FileControler(path)
    let whiteC = fc.CountWhiteChars()
    let longestW = fc.FindLongestWord()
    printf "Liczba wierszy %A\n" fc.rowsNumber
    printf "Liczba znaków %A\n" fc.charsNumber
    printf "W tym białych %A\n" whiteC
    printf "Nadłuższy znak %A\n" longestW
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
    