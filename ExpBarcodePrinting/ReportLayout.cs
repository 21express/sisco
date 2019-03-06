using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.XtraRichEdit.API.Word;

namespace ExpBarcodePrinting
{
    class ReportLayout
    {
        public ReportLayout(string filename)
        {
            var folderPath = System.Windows.Forms.Application.StartupPath + "\\ReportLayout\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            _fileName = folderPath + filename;
        }

        private readonly string _fileName;

        public string LayoutPath
        {
            get
            {
                return _fileName;
            }
        }

        public bool HasLayout
        {
            get
            {
                return File.Exists(_fileName);
            }
        }
        public string LoadLayout()
        {
            return HasLayout ? "" : _fileName;
        }
    }
}
