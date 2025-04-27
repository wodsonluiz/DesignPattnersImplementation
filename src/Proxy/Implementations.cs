using System;
using System.Threading;

namespace Proxy
{

    /// <summary>
    /// Subject
    /// </summary>
    public interface IDocument
    {
        void DisplayDocument();
    }

    /// <summary>
    /// RealSubject
    /// </summary>
    public class Document: IDocument
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public int AuthorId { get; private set; }
        public DateTimeOffset LastAccessed { get; private set; }
        private readonly string _fileName; 

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Executing expansive action: Loading a file form disk");

            //fake loading...
            Thread.Sleep(1000);

            Title = "An Expensive documento";
            Content = "Lots and lots of content";
            AuthorId = 1;
            LastAccessed = DateTimeOffset.UtcNow;
        }
    }

    /// <summary>
    /// Proxy
    /// </summary>
    public class DocumentProxy : IDocument
    {
        private readonly string _fileName;
        private readonly Lazy<Document> _document;

        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }

        public void DisplayDocument()
        {
            _document.Value.DisplayDocument();
        }
    }

    public class ProtectedDocumentProxy : IDocument
    {
        private readonly string _fileName;
        private readonly string _userRole;
        private DocumentProxy _documentProxy;

        public ProtectedDocumentProxy(string fileName, string userRole)
        {
            _fileName = fileName;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(_fileName);
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Entering DisplayDocument {nameof(ProtectedDocumentProxy)}");

            if(_userRole != "Viewer")
            {
                throw new UnauthorizedAccessException();
            }

            _documentProxy.DisplayDocument();

            System.Console.WriteLine($"Exiting DisplayDocument {nameof(ProtectedDocumentProxy)}");
        }
    }
}