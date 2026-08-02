using System;
using System.Collections.Generic;

public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problem;

    public MathAssignment(string studentName, string topic, string textbookSection, string problem) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problem = problem;
    }


    public string TextbookSection
    {
        get { return _textbookSection; }
        set { _textbookSection = value; }
    }
    public string Problem
    {
        get { return _problem; }
        set { _problem = value; }
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problem}";
    }
}

