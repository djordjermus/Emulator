using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorGui {
    public static class Assert {
        public static bool IfFalse(bool condition) {
            if (!condition)
                System.Media.SystemSounds.Hand.Play();
            return !condition;
        }
        public static bool IfFalse(bool condition, string caption, string text) {
            if (IfFalse(condition)) {
                MessageBox.Show(text, caption);
                return true;
            }
            return false;
        }
        public static bool IfFalse(bool condition, Reason reason) =>
            IfFalse(condition, reason.Caption, reason.Text);
        

        public class Reason { 
            public Reason(string caption, string text) {
                Caption = caption;
                Text = text;
            }
            public string Text { get; set; }
            public string Caption { get; set; }
        }
    }
}
