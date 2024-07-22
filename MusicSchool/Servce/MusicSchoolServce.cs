using MusicSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MusicSchool.configutaion.MusicSchoolConfiguration;

namespace MusicSchool.Servce
{
    internal static class MusicSchoolServce
    {
        // פונקציה להוספת סטודנטים לכיתה מסוימת
        public static void AddManyStudents(string classRoomName, params studentModel[] students)
        {
            // טעינת המסמך ה-XML
            XDocument document = XDocument.Load(MusicSchoolPath);

            // מציאת אלמנט ה-class-room המתאים לפי שם הכיתה
            XElement? classRoom =
                document.Descendants("class-room").FirstOrDefault(cr => cr.Attribute("name")?.Value == classRoomName);

            if (classRoom != null)
            {
                // יצירת רשימה של אלמנטים לסטודנטים לפי הפרמטר שהתקבל
                List<XElement> studentsXElements = students.Select(st =>
                    new XElement(
                        "student",
                        new XAttribute("name", st.name),
                        new XElement("instrument", st.insturment.name)
                    )).ToList();

                // הוספת הסטודנטים ל-class-room המתאים
                classRoom.Add(studentsXElements);

                // שמירת השינויים במסמך
                document.Save(MusicSchoolPath);
            }
        }

        // פונקציה להוספת סטודנט יחיד לכיתה מסוימת
        public static void InsertStudent(string classRoomName, string studentName, string instrumentName)
        {
            // טעינת המסמך ה-XML
            XDocument document = XDocument.Load(MusicSchoolPath);

            // מציאת אלמנט ה-class-room המתאים לפי שם הכיתה
            XElement? classRoom = document.Descendants("class-room").FirstOrDefault(x => x.Attribute("name")?.Value == classRoomName);

            // אם לא נמצא class-room, ישוב מייד
            if (classRoom == null)
            {
                return;
            }

            // יצירת אלמנט חדש לסטודנט
            XElement student = new(
                "student",
                new XAttribute("name", studentName),
                new XElement("instrument", instrumentName)
            );

            // הוספת הסטודנט ל-class-room המתאים
            classRoom.Add(student);

            // שמירת השינויים במסמך
            document.Save(MusicSchoolPath);
        }

        // פונקציה להוספת שם מורה לכיתה מסוימת
        public static void InsertTeacherName(string classRoom, string teacherName)
        {
            // טעינת המסמך ה-XML
            XDocument document = XDocument.Load(MusicSchoolPath);

            // מציאת אלמנט ה-class-room המתאים לפי שם הכיתה
            XElement musicSchool = document.Descendants("class-room").FirstOrDefault(x => x.Attribute("name").Value == classRoom);

            // אם לא נמצא class-room, ישוב מייד
            if (musicSchool == null)
            {
                return;
            }

            // יצירת אלמנט חדש למורה
            XElement teacher = new(
                "teacher",
                new XAttribute("name", teacherName)
            );

            // הוספת המורה ל-class-room המתאים
            musicSchool.Add(teacher);

            // שמירת השינויים במסמך
            document.Save(MusicSchoolPath);
        }

        // פונקציה ליצירת כיתה חדשה
        public static void InsertClassRoom(string classRoomName)
        {
            // טעינת המסמך ה-XML
            XDocument document = XDocument.Load(MusicSchoolPath);

            // מציאת אלמנט ה-music-School הראשי
            XElement musicSchool = document.Descendants("music-School").FirstOrDefault();

            // אם לא נמצא music-School, ישוב מייד
            if (musicSchool == null)
            {
                return;
            }

            // יצירת אלמנט חדש ל-class-room
            XElement classRoom = new(
                "class-room",
                new XAttribute("name", classRoomName)
            );

            // הוספת ה-class-room החדש ל-music-School
            musicSchool.Add(classRoom);

            // שמירת השינויים במסמך
            document.Save(MusicSchoolPath);
        }

        // פונקציה ליצירת מסמך XML אם אינו קיים
        public static void CreateXMLIfExists()
        {
            // בדיקה אם אין קובץ במיקום שנקרא MusicSchoolPath
            if (!File.Exists(MusicSchoolPath))
            {
                // אם אין, יוצרים מסמך XML חדש באמצעות XDocument
                XDocument document = new();

                // יוצרים אלמנט ראשי בשם music-School 
                XElement musicSchool = new("music-School");

                // מוסיפים את האלמנט למסמך 
                document.Add(musicSchool);

                // שמירת השינוים שביצענו
                document.Save(MusicSchoolPath);
            }
        }
    }
}
