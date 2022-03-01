using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SchoolPortal.Models
{
    internal class Message
    {
        public string Text { get; set; }
        public string Time { get; set; }

        public SolidColorBrush Color
        {
            get
            {
                return new SolidColorBrush(Colors.LightGray);
            }
        }
        public HorizontalAlignment Aligment
        {
            get
            {
               return HorizontalAlignment.Left;
            }

        }
    }
}
