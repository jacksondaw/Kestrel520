using System;
using Microsoft.AspNet.Http;

namespace Kestrel520.Models
{
    public class FileDescription
    {
        public string ContentType { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public string Description { get; set; }
        
        public string FileName { get; set; }
        
        public IFormFile File { get; set; }
    }
}