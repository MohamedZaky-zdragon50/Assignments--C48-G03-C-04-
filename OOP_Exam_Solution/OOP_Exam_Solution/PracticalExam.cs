namespace OOP_Exam_Solution;

public class PracticalExam : Exam
{
    public PracticalExam(int time, int numberOfQuestions)
        : base(time, numberOfQuestions)
    {
    }

    public override void ShowExam()
    {
        Console.WriteLine("========== Practical Exam ==========");
        Console.WriteLine($"Time: {Time} minutes");
        Console.WriteLine($"Number Of Questions: {NumberOfQuestions}");
        Console.WriteLine();

        for (int i = 0; i < Questions.Length; i++)
        {
            Console.WriteLine($"Question {i + 1}");

            Console.WriteLine(Questions[i].Header);
            Console.WriteLine(Questions[i].Body);

            for (int j = 0; j < Questions[i].Answers.Length; j++)
            {
                Console.WriteLine(Questions[i].Answers[j]);
            }

            Console.WriteLine();
        }

        Console.WriteLine("---------- Right Answers ----------");

        for (int i = 0; i < Questions.Length; i++)
        {
            Console.WriteLine($"Question {i + 1}: {Questions[i].RightAnswer.AnswerText}");
        }
    }
}
