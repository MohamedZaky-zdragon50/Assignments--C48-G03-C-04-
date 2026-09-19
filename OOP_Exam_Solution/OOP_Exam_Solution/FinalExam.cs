namespace OOP_Exam_Solution;

public class FinalExam : Exam
{
    public FinalExam(int time, int numberOfQuestions)
        : base(time, numberOfQuestions)
    {
    }

    public override void ShowExam()
    {
        Console.WriteLine("========== Final Exam ==========");
        Console.WriteLine($"Time: {Time} minutes");
        Console.WriteLine($"Number Of Questions: {NumberOfQuestions}");
        Console.WriteLine();

        int totalGrade = 0;

        for (int i = 0; i < Questions.Length; i++)
        {
            Console.WriteLine($"Question {i + 1}");

            Questions[i].ShowQuestion();

            totalGrade += Questions[i].Mark;
            Console.WriteLine();
        }

        Console.WriteLine($"Total Grade: {totalGrade}");
    }
}
