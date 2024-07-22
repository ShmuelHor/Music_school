using MusicSchool.Model;
using MusicSchool.Servce;
using System.Diagnostics.Metrics;
using System.Linq;
using static MusicSchool.Servce.MusicSchoolServce;
using static MusicSchool.Servce.PracticeServce;
namespace MusicSchool
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            //CreatXMLIfExists();
            //insertClassRoom("guitar jazz");
            //insertTeacherName("guitar jazz","avi");
            //InsertStudent("guitar jazz", "enosh", "guitar");
            studentModel shmuel = new studentModel("shmuel", new insturmentModel("Piano"));
            studentModel yossi = new studentModel("yossi", new insturmentModel("Violin"));
            studentModel[] students = [shmuel,yossi];


            AddManyStudents("guitar jazz", students);



        }
    }
}
