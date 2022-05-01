using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner.Common
{
    /// <summary>
    /// This is the template class for the HTTP Post that will be sent to the "shorten" function.
    /// </summary>
    public class UrlRequest
    {
        public string Url { get; set; } 
    }
}
