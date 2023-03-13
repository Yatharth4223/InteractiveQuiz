using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Quiz_By_YatharthJain
{
    internal class Question
    {
        public string QuestionText { get; set; }

        public int Points { get; set; }

        public string CorrectAnswer { get; set; }

        protected List<string> _choices;


    }
}
