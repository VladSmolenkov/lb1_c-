global using System.Text.RegularExpressions;
namespace Student
{ 
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(new String('-', 30));
            Student studentA = new Student("Kanov. D. A.", 60, 70, 90, 100, 59, 60, 76, 66, 56, 96);
            studentA.PIB = "RandomGuy A. V.";
            studentA.NBook = "312в3123";
            studentA.Curs = 3;
            Console.WriteLine(studentA.ToString());
            Console.WriteLine(new String('-', 30));
            Student studentB = new Student("Merisenko. B. A.", 60, 30, 100, 100, 100, 40, 50, 90, 20, 0);
            studentB.NBook = "455434";
            studentB.Curs = 3;
            studentB.SetMarkForSubject(Subjets.SoftSkills, 78);
            Console.WriteLine(studentB.ToString());
            Console.WriteLine($"Math = {studentB.GetMarkFromSubjet(Subjets.Math)}");
            var substructionMarks = Student.CompareStudents(studentA, studentB);
            Console.WriteLine("Substructed marks");
            foreach (var mark in substructionMarks)
            {
                Console.Write($"{mark} ");
            }
        }
    }
}