namespace OOP_Exam_Solution;

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
        : base(header, body, mark, answers, rightAnswer)
    {
    }

    public override void ShowQuestion()
    {
        Console.WriteLine(Header);
        Console.WriteLine(Body);

        for (int i = 0; i < Answers.Length; i++)
        {
            Console.WriteLine(Answers[i]);
        }

        Console.WriteLine($"Right Answer: {RightAnswer.AnswerText}");
        Console.WriteLine($"Mark: {Mark}");
    }
}
