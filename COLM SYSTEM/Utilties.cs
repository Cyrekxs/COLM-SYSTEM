using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace COLM_SYSTEM
{
    public class Utilties
    {
        private static ISchoolYearSemesterRepository _SchoolYearRepository = new SchoolYearSemesterRepository();
        public static int GetUserSchoolYearID()
        {
            if (Program.user != null)
                return Program.user.SchoolYearID;
            else
                return 0;
        }

        public static int GetUserSemesterID()
        {
            if (Program.user != null)
                return Program.user.SemesterID;
            else
                return 0;
        }

        public static async Task<IEnumerable<SchoolYear>> GetSchoolYears()
        {
            return await _SchoolYearRepository.GetSchoolYears();
        }

        public static async Task<SchoolYear> GetActiveSchoolYear()
        {
            return await _SchoolYearRepository.GetActiveSchoolYear();
        }

        public static async Task<IEnumerable<SchoolSemester>> GetSchoolSemesters()
        {
            return await _SchoolYearRepository.GetSemesters();
        }

        public static async Task<SchoolSemester> GetActiveSemester()
        {
            return await _SchoolYearRepository.GetActiveSemester();
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
            try
            {
                Image result;
                using (MemoryStream ms = new MemoryStream(image))
                {
                    result = Image.FromStream(ms);
                }
                return result;
            }
            catch (System.Exception)
            {
                return null;
            }



        }

        public static string FormatText(string value)
        {
            if (value != null)
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                value = value.ToLower();
                return ti.ToTitleCase(value);
            }
            else
            {
                return "";
            }

        }
    }
}
