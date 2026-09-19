namespace OOP_Exam_Solution;

public abstract class Exam
{
    public int Time { get; set; }
    public int NumberOfQuestions { get; set; }
    public Question[] Questions { get; set; }

    protected Exam(int time, int numberOfQuestions)
    {
        Time = time;
        NumberOfQuestions = numberOfQuestions;
        Questions = new Question[numberOfQuestions];
    }

    public abstract void ShowExam();
}
