using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Quiz_By_YatharthJain
{
    internal class MultipleChoiceQuestion: Question
    {

        public MultipleChoiceQuestion() : base()
        {
            _choices = new List<string> 
            { 
                "Lion",
                "Elephant",
                "Bear",
                "Beaver"
            };
        }
    }
}
