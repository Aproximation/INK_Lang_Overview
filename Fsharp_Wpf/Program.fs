// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
 #light 


open System
open System.Windows
open System.Windows.Input

(* From Chap 1 - TypeYourTitle.cs *)
open System
open System.ComponentModel
open System.IO
open System.Windows
open System.Windows.Controls
open System.Windows.Input
open System.Windows.Media

(* From Chap 4 - EditSomeText.cs *)
type EditSomeText = class
   inherit Window
   
   val mutable strFileName : String
   val txtbox : TextBox
   
   new () as this = {
      strFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"\\test.txt");
      txtbox = new TextBox()} then

      this.Title <- "Edit Some Text"
      this.txtbox.AcceptsReturn <- true
      this.txtbox.TextWrapping <- TextWrapping.Wrap
      this.txtbox.VerticalScrollBarVisibility <- ScrollBarVisibility.Auto
      this.txtbox.KeyDown.Add
         ( fun args -> 
             match args.Key with
             | Key.F5 ->
                 this.txtbox.SelectedText <- DateTime.Now.ToString()
                 this.txtbox.CaretIndex <- this.txtbox.SelectionStart + 
                                           this.txtbox.SelectionLength
             | _ -> ())
      this.Content <- this.txtbox
      
      try
         this.txtbox.Text <- File.ReadAllText(this.strFileName)
      with
         exn -> MessageBox.Show("dupa!") |>ignore
      
      this.txtbox.CaretIndex <- this.txtbox.Text.Length
      this.txtbox.Focus() |> ignore
   
   override this.OnClosing (args:CancelEventArgs) =
      try
         Directory.CreateDirectory(Path.GetDirectoryName(this.strFileName))|>ignore
      with
         exc ->
            let result = MessageBox.Show("File could not be saved: " + exc.Message +
                                         "\nClose program anyway?", this.Title,
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Exclamation) 
            if (result = MessageBoxResult.No) then 
               args.Cancel <- false 
                                         
end

#if COMPILED
[<STAThread()>]
do 
    let app =  new Application() in
    app.Run(new EditSomeText()) |> ignore
#endif