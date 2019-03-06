using System;
using System.ComponentModel;

namespace SISCO.Presentation.Common
{
    public class ExtendedBindingList<T> : BindingList<T>
    {
        protected override void RemoveItem(int index)
        {
            if (BeforeRemove != null)
                BeforeRemove(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
            base.RemoveItem(index);
        }

        public event EventHandler<ListChangedEventArgs> BeforeRemove;
    }
}
