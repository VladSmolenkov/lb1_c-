using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Student
    {
        private const int MAXMARKALLOWED = 100;
        private string _pib;
        private string _nBook;
        private int _curs;
        private Dictionary<Subjets, int> _marks;

        public string PIB
        {
            get { return _pib; }
            set
            {                 
                _pib = CheckPIB(value);
            }
        }
        public string NBook
        {
            get { return _nBook; }
            set
            {
                var regex = new Regex(@"^[0-9]{0,}$");
                bool isMatch = regex.IsMatch(value);
                if (!isMatch)
                {
                    throw new ArgumentException("NBook can contain only numbers without space");
                }
                _nBook = value;
            }
        }
        public int Curs
        {
            get { return _curs; }
            set
            {
                _curs = value;
            }
        }
        public decimal AvgMark
        {
            get
            {
                decimal avgMark = 0;
                int totalSum = 0;
                for (Subjets i = 0; (int)i < _marks.Count; i++)
                {
                    totalSum += _marks[i];
                }
                avgMark = (decimal)(totalSum) / _marks.Count;
                return avgMark;
            }
        }
        public Dictionary<Subjets, int> Marks
        {
            get { return _marks; }
        }
        public Student(string PIB, int mathMark = 0, int programmingMark = 0, //initializeable constructor
            int computerLogicsMark = 0, int ukrainianCulture = 0,
            int philosophyMark = 0, int dataBaseLearningMark = 0,
            int chemistryMark = 0, int physicalEducation = 0,
            int logicsMark = 0, int softSkillsMark = 0
        )
        {
            _pib = CheckPIB(PIB);
            _marks = new Dictionary<Subjets, int>(10);
            int[] subjectMarks = { mathMark, programmingMark,
                computerLogicsMark, ukrainianCulture,
                philosophyMark, dataBaseLearningMark,
                chemistryMark, physicalEducation,
                logicsMark, softSkillsMark };
            
            for (int i = 0; i <= 9; i++)
            {
                if(subjectMarks[i] > MAXMARKALLOWED || subjectMarks[i] < 0)
                {
                    throw new ArgumentException($"mark of subjects cant be more than {MAXMARKALLOWED} or less than 0\n" +
                        $"wrong mark for {(Subjets)i}");
                }
                _marks.Add((Subjets)i, subjectMarks[i]);
            }
        }
        private string CheckPIB(string PIB)
        {
            var regex = new Regex(@"^[^0-9]+$");
            bool isMatch = regex.IsMatch(PIB);
            if (!isMatch || string.IsNullOrEmpty(PIB))
            {
                throw new ArgumentException("PIB cant contain numbers or be empty");
            }
            return PIB;
        }
        public void SetMarkForSubject(Subjets subject, int mark)
        {
            if (mark > MAXMARKALLOWED || mark < 0)
            {
                throw new ArgumentException($"mark of subjects cant be more than {MAXMARKALLOWED} or less than 0");
            }
            _marks[subject] = mark;
        }
        public int GetMarkFromSubjet(Subjets subject)
        {
            return _marks[subject];
        }
        public override string ToString()
        {
            string result = $"PIB = {PIB}\n" +
                $"NBook = {NBook}\n" +
                $"Curs = {Curs}\n" +
                $"Average mark = {AvgMark}\n **** Marks ****\n";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _marks.Count; i++)
            {
                stringBuilder.AppendLine($"Subjet : {(Subjets)i} - Mark: {_marks[(Subjets)i]}");
            }
            result += stringBuilder.ToString();
            return result;
        }
        public static int[] CompareStudents(Student a, Student b)
        {
            if(a == null || b == null)
            {
                throw new NullReferenceException("One of the students was null");
            }
            int[] result = new int[10];
            Dictionary<Subjets, int> marksStudentA = a.Marks;
            Dictionary<Subjets, int> marksStudentB = b.Marks;
            for (int i = 0; i < a.Marks.Count; i++)
            {
               result[i] = marksStudentA[(Subjets)i] - marksStudentB[(Subjets)i];
            }
            return result;
        }
    }
}
