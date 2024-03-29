﻿namespace Interactive_Quiz_By_YatharthJain;

public partial class MainPage : ContentPage
{
    private Quiz _quiz;
    Question _chosenQuestion;
    
    public MainPage()
	{
        try
        {
            _quiz = new Quiz();

            InitializeComponent();
            RunQuiz();
        }
        catch(Exception ex)
        {
            DisplayAlert("error", $"No more questions left\nYour score is: {_quiz.Score}", "OK");
        }
    }

    private void QuitButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("message", $"Your score is: {_quiz.Score}", "OK");
    }

    private void NextQuestionButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (_quiz.CurrentQuestionIndex >= _quiz._totalQuestions)
            {
                throw new Exception();
            }
            _chosenQuestion = _quiz.GetNextQuestion();

        }
        catch
        {
            DisplayAlert("message", $"Your score is: {_quiz.Score}", "OK");
        }

    }

    private void Option1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        changeColor(Option1Button);
        Option1Button.IsChecked = false;
        RunQuiz();
    }

    private void Option2_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        changeColor(Option2Button);
        Option2Button.IsChecked = false;
        RunQuiz();
    }

    private void Option3_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        changeColor(Option3Button);
        Option3Button.IsChecked = false;
        RunQuiz();
    }

    private void Option4_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        changeColor(Option4Button);
        Option4Button.IsChecked = false;
        RunQuiz();
    }

    private void changeColor(RadioButton button)
    {
        bool isCorrect = _quiz.CheckUserAnswer(button.Content.ToString(), _chosenQuestion);
        if (isCorrect)
        {
            //this changes color to green
            button.BackgroundColor = Color.FromRgb(0, 255, 0);
        }

        //This changes backgrounf to red
        button.BackgroundColor = Color.FromRgb(255, 0, 0);
    }

    private void RunQuiz()
    {
        _chosenQuestion = _quiz.GetNextQuestion();

        DisplayTitle.Text = $"{_quiz.Title}";
        DisplayQuestion.Text = $"{_chosenQuestion.QuestionText}";

        if (_chosenQuestion is TrueFalseQuestion)
        {
            Option1Button.Content = _chosenQuestion._choices[0].ToString();
            Option2Button.Content = _chosenQuestion._choices[1].ToString();
            Option3Button.IsVisible = false;
            Option4Button.IsVisible = false;
        }

        Option1Button.Content = _chosenQuestion._choices[0];
        Option2Button.Content = _chosenQuestion._choices[1];
        Option3Button.Content = _chosenQuestion._choices[2];
        Option4Button.Content = _chosenQuestion._choices[3];

    }
}

