using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestfulServices
{
    /// <summary>
    ///     (Rest) Representational State Transfer
    ///     Resources expose easily understood directory structure URIs.
    ///     Returns representations that transfer JSON or XML to represent data objects and attributes.
    ///     Messages use HTTP methods explicitly (GET, POST, PUT, and DELETE).
    ///     Stateless interactions store no client context on the server between requests. State dependencies limit and restrict scalability. The client holds session state.
    ///     1XX - informational
    ///     2XX - success
    ///     3XX - redirection
    ///     4XX - client error
    ///     5XX - server error
    /// </summary>
    [Route("api/[controller]")] // this allows for the controller name to be inferred dynamically as long as the UseMVC is specified in the startup class
    // Controller names should be a verb
    // Use nouns to represent resources
    // Use lowercase letters in URIs
    // Use hyphens not underscores
    // Do not use trailing slashes, slashes should represent a hierarchy 
    // Do not add file extensions to routes
    public class ExampleController : Controller // Extending controller allows for us to inherit a bunch of useful api methods
    {
        /// <summary>
        ///    Gets should be idempotent given a request the same parameters should yield the same results
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(string), 200)] // Includes a response body of type string
        [ProducesResponseType(204)] // No content
        [ProducesResponseType(307)] // Temporary Redirect  
        [ProducesResponseType(308)] // Permanent Redirect
        [ProducesResponseType(401)] // Unauthorized  
        [ProducesResponseType(403)] // Forbidden
        // IActionResult allows a wider range of return types then ActionResult, including any custom code that implements the IActionResult interface
        public async Task<IActionResult> ExampleGet() // Asynchronous method call
        {
            // return Ok(Something); Returns a 200 should include a response body
            // return NoContent(); Returns a 204
            // return RedirectPermanent("https://SomeSampleURI.com/things"); Sample 301 
            // return RedirectPreserveMethod(""); Sample 307
            // return RedirectToPagePermanentPreserveMethod() Sample 308
            // return NotFound() User does not have permission for action Sample 403
            return Unauthorized(); // Returns a 401
        }
        
        /// <summary>
        ///     Changes state on the server can be used for creates or updates
        ///     Post is not idempotent which means you can send a subset of the resources parameters
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(201)] // 201 stands for created, return the location (id) of the new resource
        public IActionResult ExamplePost<T>([FromBody] T ExampleBody)
        {
            return Created("","");
        }
        
        /// <summary>
        ///    Changes state on the server can be used for creates or updates.
        ///    The difference between a put and a post is that a put is idempotent
        ///    meaning that making the same api call will return the same result given the same inputs.
        ///    What is important about puts is that you must send all possible values including id's to avoid side effects
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ProducesResponseType(200)]
        public IActionResult ExamplePut()
        {
            return Ok();
        }
        
        /// <summary>
        ///     Delete is also idempotent
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        [ProducesResponseType(200)]
        public IActionResult ExampleDelete()
        {
            return Ok();
        }        
        
        /// <summary>
        ///     Not idempotent
        ///     Patches can be used for partially updating resources
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        [Route("")]
        [ProducesResponseType(200)]
        public IActionResult ExamplePatch()
        {
            return Ok();
        }
        
        /// <summary>
        ///     Options is idempotent
        ///     Options represent a request for information about the communication options available on the request/response chain identified by the Request-URI.
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [Route("")]
        [ProducesResponseType(200)]
        public IActionResult ExampleOptions()
        {
            return Ok();
        }
        /*
        1×× Informational

        100 Continue
        101 Switching Protocols
        102 Processing

        2×× Success

        200 OK
        201 Created
        202 Accepted
        203 Non-authoritative Information
        204 No Content
        205 Reset Content
        206 Partial Content
        207 Multi-Status
        208 Already Reported
        226 IM Used

        3×× Redirection

        300 Multiple Choices
        301 Moved Permanently
        302 Found
        303 See Other
        304 Not Modified
        305 Use Proxy
        307 Temporary Redirect
        308 Permanent Redirect

        4×× Client Error

        400 Bad Request
        401 Unauthorized
        402 Payment Required
        403 Forbidden
        404 Not Found
        405 Method Not Allowed
        406 Not Acceptable
        407 Proxy Authentication Required
        408 Request Timeout
        409 Conflict
        410 Gone
        411 Length Required
        412 Precondition Failed
        413 Payload Too Large
        414 Request-URI Too Long
        415 Unsupported Media Type
        416 Requested Range Not Satisfiable
        417 Expectation Failed
        418 I’m a teapot
        421 Misdirected Request
        422 Unprocessable Entity
        423 Locked
        424 Failed Dependency
        426 Upgrade Required
        428 Precondition Required
        429 Too Many Requests
        431 Request Header Fields Too Large
        444 Connection Closed Without Response
        451 Unavailable For Legal Reasons
        499 Client Closed Request

        5×× Server Error

        500 Internal Server Error
        501 Not Implemented
        502 Bad Gateway
        503 Service Unavailable
        504 Gateway Timeout
        505 HTTP Version Not Supported
        506 Variant Also Negotiates
        507 Insufficient Storage
        508 Loop Detected
        510 Not Extended
        511 Network Authentication Required
        599 Network Connect Timeout Error
        */
    }
}