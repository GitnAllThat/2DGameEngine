using System;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace CommonWinFormsFunctions
{
    public static class Validation
    {


        //Stops stupid input from the user (ie two decimal points or a "-" in the middle of a load of numbers
        public static bool ValidateText(Type type, string text, KeyPressEventArgs e, int insertIndex, string selectedText)
        {
            bool isValid = true;

            char ch = e.KeyChar;





            if (type == typeof(float) || type == typeof(Vector2) || type == typeof(Vector3))
            {
                //  This will stop the keypress if the keypress is:
                // A period which has already been used. (Unless the text to be replaced contains a period)
                // The whole text is being replaced
                if (ch == 46  && (!selectedText.Contains(".") && text.Contains(".")))
                {
                    e.Handled = true;
                    isValid = false;
                }


                //This will stop the keypress if the keypress is a "-" which:
                // isnt at the beginning.
                // or if the selection being replaced isnt at the beginning
                if (ch == 45 &&
                    ((insertIndex != 0)|| (!selectedText.Contains("-")) && (text.Contains("-"))))
                {
                    e.Handled = true;
                    isValid = false;
                }




                //This will stop the keypress if the keypress is:(Not a didgit) and (Not a backspace) 
                if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 45) 
                {
                    e.Handled = true;
                    isValid = false;
                }
            }
            if (type == typeof(int))
            {
                //This will stop the keypress if the keypress is:
                //(Not a didgit) and (Not backspace)
                if (!Char.IsDigit(ch) && ch != 8)
                {
                    e.Handled = true;
                    isValid = false;
                }
            }




            return isValid;
        }

        public static bool ValidateTextBoxInput(string text)
        {
            if (text == "" || text == "-" || text == "." || text == "-.") return false;
            return true;
        }


    }
}
