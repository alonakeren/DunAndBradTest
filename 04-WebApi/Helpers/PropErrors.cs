using System.Collections.Generic;

namespace DunBrad
{
    public class PropErrors
    {
        public string property { get; set; }
        public List<string> errors { get; set; } = new List<string>();
    }
}