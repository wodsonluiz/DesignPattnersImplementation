using System;

namespace Proxy;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Constructing document");
        var myDocument = new Document("MyDocument.pdf");
        Console.WriteLine("Document constructed");
        myDocument.DisplayDocument();

        Console.WriteLine("");

        Console.WriteLine("Constructing document proxy");
        var myDocumentProxy = new DocumentProxy("MyDocument.pdf");
        Console.WriteLine("Document constructed");
        myDocumentProxy.DisplayDocument();

        Console.WriteLine("");

        Console.WriteLine("Constructing protected document proxy");
        var myProtectedDocumentProxy = new ProtectedDocumentProxy("MyDocument.pdf", "Viewer");
        Console.WriteLine("Document constructed");
        myProtectedDocumentProxy.DisplayDocument();

        Console.WriteLine("");

        Console.WriteLine("Constructing protected document proxy");
        var myProtectedDocumentProxy2 = new ProtectedDocumentProxy("MyDocument.pdf", "ViewerError");
        Console.WriteLine("Document constructed");
        myProtectedDocumentProxy2.DisplayDocument();
    }
}
