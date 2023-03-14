using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Quiz_By_YatharthJain
{
    internal class Quiz
    {
        private List<Question> _questionList;
        private List<Question> _completedQuestionList = new List<Question>();


        private int _currentQuestionIndex = -1;

        public int CurrentQuestionIndex { get { return _currentQuestionIndex; } }

        private int _score = 0;
        public string Title { get; set; }

        public int _totalQuestions;

        public int Score 
        { 
            get
            {
                return _score;
            }
        }

        public Quiz()
        {
            Title = "Brain Teasers!";
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            _questionList = new List<Question>
            {
                new MultipleChoiceQuestion()
                {
                    QuestionText = "What is the national animal of Canada?",
                    Points = 10,
                    CorrectAnswer = "Beaver",
                    _choices = new List<string>{"Lion","Elephant","Beaver","Bear" }   
                },

                new MultipleChoiceQuestion()
                {
                    QuestionText = "Which planet in our solar system is known as the Red Planet?",
                    Points = 10,
                    CorrectAnswer = "Mars",
                    _choices = new List<string>{"Venus","Jupitor","Earth","Mars" }

                },

                new MultipleChoiceQuestion()
                {
                    QuestionText = "What is the capital city of Australia?",
                    Points = 10,
                    CorrectAnswer = "Canberra",
                    _choices = new List<string>{"Melbourne","Brisbane","Sydney","Canberra" }

                },

                new MultipleChoiceQuestion()
                {
                    QuestionText = "Which of the following is not a primary color?",
                    Points = 10,
                    CorrectAnswer = "Yellow",
                    _choices = new List<string>{"Yellow","Red","Green","Blue" }

                },

                new MultipleChoiceQuestion()
                {
                    QuestionText = "Which of the following is not a type of renewable energy?",
                    Points = 10,
                    CorrectAnswer = "NaturalGas",
                    _choices = new List<string>{"Solar","Wind","NaturalGas","Hydropower" }

                },

                new TrueFalseQuestion()
                {
                    QuestionText = "Does Greenland belong to Canada?",
                    Points = 20,
                    CorrectAnswer = "false",
                    _choices = new List<string>{"true","false"}
                }
            };
            _totalQuestions = _questionList.Count;
        }

        private Question GetQuestionWithoutAnswer()
        {
            Random random = new Random();
            int randomIndex = random.Next(_questionList.Count);

            Question chosenQuestion = _questionList[randomIndex];

            foreach(Question k in _completedQuestionList)
            {
                if(chosenQuestion == k)
                {
                    randomIndex = random.Next(_questionList.Count);
                    chosenQuestion = _questionList[randomIndex];
                }

            }
            //removing chosen question from the list so it doesn't appear again 
            _completedQuestionList.Add(chosenQuestion);

            chosenQuestion.CorrectAnswer = null;
            return chosenQuestion;
        }

        public Question GetNextQuestion()
        {
            _currentQuestionIndex += 1;

            if (_currentQuestionIndex >= _totalQuestions)
            {
                throw new Exception("No more questions");
            }
            
            return GetQuestionWithoutAnswer();

        }

        public bool CheckUserAnswer(string userAnswer, Question chosenQuestion)
        {
            string correctAnswer = "";
            foreach (Question k in _questionList)
            {
                if (k == chosenQuestion)
                {
                    correctAnswer = k.CorrectAnswer;
                }
            }
            if (userAnswer == correctAnswer)
            {
                _score += chosenQuestion.Points;
                return true;
            }
            return false;
        
        }

    }


}
