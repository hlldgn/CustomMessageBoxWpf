using Lib.Enums;

namespace Lib.Abstract
{
    public interface ICustomMessageBoxView
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public MessageBoxResultLib Result { get; set; }
        public bool ButtonOKVisible { get; set; }
        public bool ButtonYesVisible { get; set; }
        public bool ButtonNoVisible { get; set; }
        public bool ButtonCancelVisible { get; set; }
        void DisplayButtons(MessageBoxButtonLib button);
        void DisplayImage<TEnum>(TEnum packIcon) where TEnum :struct,Enum;
    }
}
