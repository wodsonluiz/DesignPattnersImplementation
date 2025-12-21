using System;
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsability;

class Program
{
    static void Main(string[] args)
    {
        var validDocument = new Document("How to avoid Java Development", DateTimeOffset.UtcNow, true, true);
        var invalidDocument = new Document("How to avoid Java Development", DateTimeOffset.UtcNow, false, true);

        var documentHandlerChain = new DocumentTitleHandler();
        documentHandlerChain.SetSuccessor(new DocumentLastModifiedHandler())
                            .SetSuccessor(new DocumentApprovedByLitigationHandler())
                            .SetSuccessor(new DocumentApprovedByManagementHandler());
        
        try
        {
            Console.WriteLine("Valid document is valid. ");
            documentHandlerChain.Handle(validDocument);

            Console.WriteLine("Invalid document is valid. ");
            documentHandlerChain.Handle(invalidDocument);
            
        }
        catch (ValidationException validationException)
        {
            Console.WriteLine(validationException.Message);
        }

    }
}
