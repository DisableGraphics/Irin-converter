using System;
using System.Diagnostics;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void Exit(object sender, EventArgs e)
    {
        Application.Quit();
    }

    protected void Open(object sender, EventArgs e)
    { 
        FileChooserDialog chooser = new FileChooserDialog(
        "Please select a text file to add to the queue ...",
        this,
        FileChooserAction.Open,
        "Cancel", ResponseType.Cancel,
        "Open", ResponseType.Accept);

        if (chooser.Run() == (int)ResponseType.Accept)
        {
            textview2.Buffer.Text += chooser.Filename;
            textview2.Buffer.Text += "\n";
        }
        chooser.Destroy();
    }

    protected void OpenFolder(object sender, EventArgs e)
    {
        FileChooserDialog chooser = new FileChooserDialog(
        "Please select a text file to add to the queue ...",
        this,
        FileChooserAction.Open,
        "Cancel", ResponseType.Cancel,
        "Open", ResponseType.Accept);

        if (chooser.Run() == (int)ResponseType.Accept)
        {
            textview2.Buffer.Text += chooser.CurrentFolder;
            textview2.Buffer.Text += "/*";
            textview2.Buffer.Text += "\n";
        }
        chooser.Destroy();
    }

    protected void Help(object sender, EventArgs e)
    {
        textview2.Buffer.Text = "----Irin Converter help----\n To convert a file to PDF select it with \"Open file\", then click on the PDF option";
    }

    protected void Clear(object sender, EventArgs e)
    {
        textview2.Buffer.Text = "";
    }

    protected void ToPDF(object sender, EventArgs e)
    {
        Process.Start("convert",textview2.Buffer.Text + " output/output.pdf");
    }

    protected void ToPNG(object sender, EventArgs e)
    {
        Process.Start("convert", textview2.Buffer.Text + " output/output.png");

    }
}

