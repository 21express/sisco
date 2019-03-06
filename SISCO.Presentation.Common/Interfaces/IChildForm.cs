using System;
using Devenlab.Common;

namespace SISCO.Presentation.Common.Interfaces
{
    public interface IChildForm
    {
        EnumStateChange StateChange { get; set; }
        void ActiveForm(object sender, EventArgs e);
        void InactiveForm(object sender, EventArgs e);
        void CloseForm();
        void New();
        void Save();
        void Delete();
        void Top();
        void Previous();
        void Next();
        void Bottom();
        void OpenData(string codeText);
        void Find();
        void Refresh();
        void SetNoPod(string code);
    }
}
