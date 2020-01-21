﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MdDox
{
    public class CommandLineOptions
    {
        public string AssemblyName { get; set; }
        public string TypeName { get; set; }  
        public string OutputFile { get; set; } 
        public string Format { get; set; }
        public bool IgnoreMethods { get; set; }
        public List<string> IgnoreAttributes { get; set; } = new List<string>();
        public bool Recursive { get; set; }
        public List<string> RecursiveAssemblies { get; set; } = new List<string>();
        
        /// <summary>
        /// True if links to the framework documentation should be added for the system namespace types
        /// </summary>
        public bool MsdnLinks { get; set; }
        /// <summary>
        /// Optional view parameter for msdn documentation urls. If not specified then view parameter is not generated for urls 
        /// defaulting to the latest version.
        /// </summary>
        public string MsdnView { get; set; }
    }
}
