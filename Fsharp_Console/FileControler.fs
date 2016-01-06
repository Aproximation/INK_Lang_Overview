module FileControler
open Log
open System.IO

    type FileControler(path:string)=
        let Path = path
        do if not (File.Exists(Path)) then (Log.LogMsg("Podana ścieżka nie prowadzi do pliku", Log.LogType.Error); System.Environment.Exit 1)
        let seqLines = seq {
                use sr = new StreamReader (Path)
                while not sr.EndOfStream do
                    yield sr.ReadLine ()
        }
        let lines = List.ofSeq(seqLines)
        member this.rowsNumber = Seq.length(lines)
        member this.charsNumber = lines |> List.sumBy(fun line -> line.Length)
        //member this.whiteCharsNumber = 0
        //member this.longestWord = "";
        member this.CountWhiteChars()=begin 
            let mutable counter = 0
            [for line in lines -> [for char in line -> if System.Char.IsWhiteSpace(char) then counter<-counter+1]] |> ignore
            counter
        end
        member this.FindLongestWord()=begin 
        let mutable longestWord = ""
        [for line in lines do
            for word in line.Split [|' '|] do
                if word.Length > longestWord.Length then 
                    longestWord <- word] |> ignore;
        longestWord
        end
