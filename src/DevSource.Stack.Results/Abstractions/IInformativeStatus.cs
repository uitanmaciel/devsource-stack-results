using DevSource.Stack.Results.StatusCodeTypes;
using System.Collections.Generic;

namespace DevSource.Stack.Results.Abstractions;

public interface IInformativeStatus
{
    InformativeType InformativeType { get; }
    // Note: HttpInformative has a single 'Message' string, not IList<string>.
    // The interface should reflect what the HttpInformative class provides.
    // However, the Result classes expect IList<string>.
    // For consistency with IErrorStatus and ISuccessStatus, and with Result constructor,
    // let's stick to IList<string> here. The concrete HttpInformative class
    // will wrap its single message in a list when implementing this interface's Messages property.
    IList<string> Messages { get; }

    // Alternative for IInformativeStatus & IRedirectStatus if they truly only have one message:
    // string Message { get; }
    // And then the Result classes would need to handle constructing the list.
    // The current plan implies HttpInformative.Messages will be made to return IList<string>.
    // Let's proceed with IList<string> for the interface for now.
}
