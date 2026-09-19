using OOP_Exam_Solution;

Subject subject = new Subject(1, "Object Oriented Programming");

// Answers
Answer trueAnswer = new Answer(1, "True");
Answer falseAnswer = new Answer(2, "False");

Answer[] trueFalseAnswers =
{
    trueAnswer,
    falseAnswer
};

Answer answer1 = new Answer(1, "Class");
Answer answer2 = new Answer(2, "Object");
Answer answer3 = new Answer(3, "Method");

Answer[] mcqAnswers =
{
    answer1,
    answer2,
    answer3
};

// Questions
TrueFalseQuestion q1 = new TrueFalseQuestion(
    "Question 1",
    "C# supports inheritance.",
    5,
    trueFalseAnswers,
    trueAnswer);

MCQQuestion q2 = new MCQQuestion(
    "Question 2",
    "Which one is used to create an object from a class?",
    5,
    mcqAnswers,
    answer2);

MCQQuestion q3 = new MCQQuestion(
    "Question 3",
    "Which one contains data and behavior?",
    5,
    mcqAnswers,
    answer1);

// Create a Final Exam
FinalExam finalExam = new FinalExam(60, 2);
finalExam.Questions[0] = q1;
finalExam.Questions[1] = q2;

subject.CreateExam(finalExam);

Console.WriteLine($"Subject: {subject}");
Console.WriteLine();

subject.Exam.ShowExam();

Console.WriteLine();
Console.WriteLine("Clone and Compare Test");
Console.WriteLine("==================================");

// ICloneable
Question clonedQuestion = (Question)q1.Clone();

Console.WriteLine("Original Question:");
Console.WriteLine(q1);

Console.WriteLine("Cloned Question:");
Console.WriteLine(clonedQuestion);

// IComparable
Console.WriteLine();
Console.WriteLine($"Compare q1 and q2 by Mark: {q1.CompareTo(q2)}");

Console.WriteLine();
Console.WriteLine("Press Enter to continue to Practical Exam...");
Console.ReadLine();

// Create a Practical Exam
PracticalExam practicalExam = new PracticalExam(30, 1);
practicalExam.Questions[0] = q3;

subject.CreateExam(practicalExam);

Console.Clear();
Console.WriteLine($"Subject: {subject}");
Console.WriteLine();

subject.Exam.ShowExam();
