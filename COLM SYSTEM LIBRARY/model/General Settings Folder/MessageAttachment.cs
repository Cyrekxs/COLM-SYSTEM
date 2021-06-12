using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.General_Settings_Folder
{
    public class MessageAttachment
    {
        public int AttachmentID { get; set; }

        public int TemplateID { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }

        public byte[] Attachement { get; set; }
    }
}
