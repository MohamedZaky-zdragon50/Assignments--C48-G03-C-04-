namespace OOP_Exam_Solution;

public abstract class Question : ICloneable, IComparable<Question>
{
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }

    public Answer[] Answers { get; set; }
    public Answer RightAnswer { get; set; }

    protected Question(string header, string body, int mark)
    {
        Header = header;
        Body = body;
        Mark = mark;
        Answers = Array.Empty<Answer>();
        RightAnswer = new Answer(0, "");
    }

    protected Question(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
        : this(header, body, mark)
    {
        Answers = answers;
        RightAnswer = rightAnswer;
    }

    public int CompareTo(Question? other)
    {
        if (other == null)
            return 1;

        return Mark.CompareTo(other.Mark);
    }

    public virtual object Clone()
    {
        Question copy = (Question)this.MemberwiseClone();

        if (Answers != null)
        {
            copy.Answers = new Answer[Answers.Length];

            for (int i = 0; i < Answers.Length; i++)
            {
                copy.Answers[i] = new Answer(Answers[i].AnswerId, Answers[i].AnswerText);
            }
        }

        if (RightAnswer != null)
        {
            copy.RightAnswer = new Answer(RightAnswer.AnswerId, RightAnswer.AnswerText);
        }

        return copy;
    }

    public override string ToString()
    {
        return $"{Header}: {Body} - Mark = {Mark}";
    }

    public abstract void ShowQuestion();
}
