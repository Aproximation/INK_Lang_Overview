import Tkinter as Tk, tkFileDialog
 
########################################################################
class MyApp(object):
    """"""
 
    #----------------------------------------------------------------------
    def __init__(self, parent):
        """Constructor"""
        self.root = parent
        self.file_opt = options = {}
        self.root.title("Main frame")
        self.frame = Tk.Frame(parent)
        self.frame.pack()
        btn = Tk.Button(self.frame, text="Open Frame", command=self.openFrame)
        btn.pack()
        btn2 = Tk.Button(self.frame, text='Browse', command=self.askopenfile)
        btn2.pack()
        text = Tk.Text(self.root)
        text.insert(Tk.INSERT, "Hello world")
        text.pack()
        
 
    #----------------------------------------------------------------------
    def hide(self):
        """"""
        self.root.withdraw()
 
    #----------------------------------------------------------------------
    def openFrame(self):
        """"""
        self.hide()
        otherFrame = Tk.Toplevel()
        otherFrame.geometry("400x300")
        otherFrame.title("otherFrame")
        handler = lambda: self.onCloseOtherFrame(otherFrame)
        btn = Tk.Button(otherFrame, text="Close", command=handler)
        btn.pack()
 
    #----------------------------------------------------------------------
    def onCloseOtherFrame(self, otherFrame):
        """"""
        otherFrame.destroy()
        self.show()
 
    #----------------------------------------------------------------------
    def show(self):
        """"""
        self.root.update()
        self.root.deiconify()

    def askopenfile(self):
        file = tkFileDialog.askopenfile(mode='rb', **self.file_opt)
 
#----------------------------------------------------------------------
def main():
    root = Tk.Tk()
    root.geometry("800x600")
    app = MyApp(root)
    root.mainloop()

if __name__ == "__main__":
    main()
