namespace OOP_Exam_Solution;

public class Answer
{
    public int AnswerId { get; set; }
    public string AnswerText { get; set; }

    public Answer(int answerId, string answerText)
    {
        AnswerId = answerId;
        AnswerText = answerText;
    }

    public override string ToString()
    {
        return $"{AnswerId}. {AnswerText}";
    }
}
