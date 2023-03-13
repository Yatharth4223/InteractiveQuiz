using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Quiz_By_YatharthJain
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(): base(){ 
            _choices = new List<string> { 
            "True",
            "False"
            };
        }
    }
}
