using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM
{
    public class Utilties
    {
        public static User user { get; set; }

        public static int GetActiveSchoolYear()
        {
            if (user != null)
                return user.SchoolYearID;
            else
                return 0;
        }

        public static int GetActiveSemester()
        {
            if (user != null)
                return user.SemesterID;
            else
                return 0;
        }

        public static string GetActiveSchoolYearInfo()
        {
            return SchoolYear.GetSchoolYear(user.SchoolYearID).Name;
        }

        public static string GetActiveSchoolSemesterInfo()
        {
            return SchoolSemester.GetSchoolSemester(user.SemesterID).Semester;
        }

        public static string GetAssessor()
        {
            return user.AccountName;
        }

        public static bool IsNumber(double val)
        {
            string input = val.ToString();
            bool result = double.TryParse(input, out val);
            return result;
        }

        public static byte[] ConvertImageToByte(Image image)
        {
            byte[] result;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                result = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(result, 0, result.Length);
            }
            return result;
        }

        public static Image ConvertByteToImage(byte[] image)
        {
            Image result;
            using (MemoryStream ms = new MemoryStream(image))
            {
                result = Image.FromStream(ms);
            }
            return result;
        }
    }
}
