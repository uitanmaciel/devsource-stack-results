<div align="center">
    <img src="https://github.com/uitanmaciel/devsource-stack-notifications/blob/main/src/DevSource.Stack.Notifications/devsource-icon.jpeg" 
         width="130"
    />  
</div>

# DevSource.Stack.Results

DevSource.Stack.Results is a lightweight and robust C# library designed to simplify error handling and improve the readability of your code. It provides a standardized way to return and handle results from functions and methods, clearly distinguishing between successful and failed results.

## Features

- Easy-to-use **Result** and **Result<T>** types for encapsulating operation outcomes.
- Supports conveying error details, including custom messages and error codes.
- Enhances code readability and maintainability.
- Standardized return of responses.
- Supports statuses for:

    1. Informational Responses (100 - 199);
    2. Successful Responses (200 - 299);
    3. Redirect Messages (300 - 399);
    4. Client Error Responses (400 - 499);
    5. Server Error Responses (500 - 599);

## Installation and usage

To integrate this library into your project:

**1- Setup:** Include the library files in your project directory by installing directly from the NuGet repository.

```bash

dotnet add package DevSource.Stack.Results
```

**2- Initialization:** Instantiate the Smooth.Result and integrate it with your project's flow. Ex.:

```bash
  using DevSource.Stack.Results;
```

**3- Usage:** You can use it in several ways. Here is an example of very common usage:

```bash
public class User
{
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public Result<User> Auth(string email, string password)
    {
        var user = //...Some method to fetch user information.

        if (email != user.Email || password != user.Password)
            return Result<User>.Failure(Error.Unauthorized);

        return Result<User>.Ok(data: user);
    }
}
```
**Failure output**
```bash
{
   "IsSuccess":false,
   "StatusCode":401,
   "ErrorMessage":"Unauthorized: Authentication is required and has failed or has not been provided.",
   "Data":null
}
```

**OK output**
```bash
{
   "IsSuccess":true,
   "StatusCode":null,
   "ErrorMessage":"",
   "Data":{
      "Email":"<User email>",
      "Password":"<User password>"
   }
}
```

If the method does not need to return any object, you can use it like this:

```bash
public class User
{
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public Result Auth(string email, string password)
    {
        var user = //...Some method to fetch user information.

        if (email != user.Email || password != user.Password)
            return Result.Failure(Error.Unauthorized);

        return Result.Ok();
    }
}
```
**Failure output**
```bash
{
   "IsSuccess":false,
   "StatusCode":401,
   "ErrorMessage":"Unauthorized: Authentication is required and has failed or has not been provided."
}
```

**OK output**
```bash
{
   "IsSuccess":true,
   "StatusCode":null,
   "ErrorMessage":""
}
```

## Error Types and messages errors

- **400 - BadRequest** - 
    _**[Error Message]:** "Your request could not be understood due to malformed syntax."_
- **401 - Unauthorized** - 
    _**[Error Message]:** "Authentication is required and has failed or has not been provided."_
- **402 - PaymentRequired** - 
    _**[Error Message]:** "Payment is required to access this resource."_
- **403 - Forbidden** - 
    _**[Error Message]:** "You do not have the necessary permissions to access this resource."_
- **404 - NotFound** - 
    _**[Error Message]:** "The requested resource could not be found."_
- **405 - MethodNotAllowed** - 
    _**[Error Message]:** "The method specified in the request is not allowed for the resource identified."_
- **406 - NotAcceptable** - 
    _**[Error Message]:** "The resource is capable of generating only content not acceptable according to the Accept headers sent in the request."_
- **407 - ProxyAuthenticationRequired** - 
    _**[Error Message]:** "You must authenticate with a proxy server before this request can be served."_
- **408 - RequestTimeout** - 
    _**[Error Message]:** "The server timed out waiting for the request."_
- **409 - Conflict** - 
    _**Error Message:** "The request could not be completed due to a conflict with the current state of the resource."_
- **410 - Gone** - 
    _**[Error Message]:** "The requested resource is no longer available at the server and no forwarding address is known."_
- **411 - LengthRequired** - 
    _**[Error Message]:** "The request did not specify the length of its content, which is required by the requested resource."_
- **412 - PreconditionFailed** - 
    _**[Error Message]:** "One or more preconditions given in the request header fields evaluated to false when tested on the server."_
- **413 - PayloadTooLarge** - 
    _**[Error Message]:** "The server is refusing to process a request because the request payload is larger than the server is willing or able to process."_
- **414 - UriToLong** - 
    _**[Error Message]:** "The URI provided was too long for the server to process."_
- **415 - UnsupportedMediaType** - 
    _**[Error Message]:** "The server is refusing to service the request because the entity of the request is in a format not supported by the requested resource for the requested method."_
- **416 - RangeNotSatisfiable** - 
    _**[Error Message]**: "The server cannot serve the requested ranges."_
- **417 - ExpectationFailed** - 
    _**[Error Message]**: "The server cannot meet the requirements of the Expect request-header field."_
- **421 - MisdirectedRequest** - 
    _**[Error Message]**: "The request was directed at a server that is not able to produce a response."_
- **422 - UnprocessableContent** - 
    _**[Error Message]**: "The server understands the content type of the request entity, but was unable to process the contained instructions."_
- **423 - Locked** - 
    _**[Error Message]**: "The resource that is being accessed is locked."_
- **424 - FailedDependency** - 
    _**[Error Message]**: "The request failed due to the failure of a previous request."_
- **425 - TooEarly** - 
    _**[Error Message]**: "The server is unwilling to risk processing a request that might be replayed."_
- **426 - UpgradeRequired** - 
    _**[Error Message]**: "The client should switch to a different protocol."_
- **428 - PreconditionRequired** - 
    _**[Error Message]**: "The server requires the request to be conditional."_
- **429 - TooManyRequests** - 
    _**[Error Message]**: "You have sent too many requests in a given amount of time."_
- **431 - RequestHeaderFieldsTooLarge** - 
    _**[Error Message]**: "The server is unwilling to process the request because its header fields are too large."_
- **451 - UnavailableForLegalReasons** - 
    _**[Error Message]**: "The requested resource is unavailable due to legal reasons."_
- **500 - InternalServerError** - 
    _**[Error Message]**: "The server encountered an unexpected condition that prevented it from fulfilling the request."_
- **501 - NotImplemented** - 
    _**[Error Message]**: "The server does not support the functionality required to fulfill the request."_
- **502 - BadGateway** - 
    _**[Error Message]**: "The server received an invalid response from the upstream server."_
- **503 - ServiceUnavailable** - 
    _**[Error Message]**: "The server is currently unable to handle the request due to a temporary overloading or maintenance of the server."_
- **504 - GatewayTimeout** - 
    _**[Error Message]**: "The upstream server failed to send a request in the time allowed by the server."_
- **505 - HttpVersionNotSupported** - 
    _**[Error Message]**: "The server does not support the HTTP protocol version that was used in the request."_
- **506 - VariantAlsoNegotiates** - 
    _**[Error Message]**: "The server has an internal configuration error: the chosen variant resource is configured to engage in transparent content negotiation and is therefore not a suitable endpoint in the negotiation process."_
- **507 - InsufficientStorage** - 
    _**[Error Message]**: "The server is unable to store the representation needed to complete the request."_
- **508 - LoopDetected** - 
    _**[Error Message]**: "The server detected an infinite loop while processing the request."_
- **510 - NotExtended** - 
    _**[Error Message]**: "Further extensions to the request are required for the server to fulfill it."_
- **511 - NetworkAuthenticationRequired** - 
    _**[Error Message]**: "The client needs to authenticate to gain network access."_

## Running the tests

To run the tests, run the following command

```bash
  dotnet test
```

## Contributing

Contributions are what make the open source community such an amazing place to learn, be inspired, and create. Any contributions you make will be greatly appreciated.

**Fork the Project**

- Create your Feature Branch (git checkout -b feat/contributing)
- Commit your changes (git commit -m 'Add some contribute')
- Push to the Branch (git push origin feat/contributing)
- Open a Pull Request

## Support and Contact

If you encounter any issues or have questions, please feel free to reach out through our [GitHub Issues](https://github.com/uitanmaciel/devsource-stack-results/issues) page.