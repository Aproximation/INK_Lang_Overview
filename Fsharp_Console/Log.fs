module Log

open System

type LogType = Info = 1| Warning = 2| Error = 3


let LogMsg(msg:string, logType:LogType) =
        match logType with
        | LogType.Info ->
            printf "%A" msg
        | LogType.Warning ->
            Console.ForegroundColor<-ConsoleColor.Yellow
            printf "%A" msg
            Console.ForegroundColor<-ConsoleColor.White
        | LogType.Error ->
            Console.ForegroundColor<-ConsoleColor.Red
            printf "%A" msg
            Console.ForegroundColor<-ConsoleColor.White

