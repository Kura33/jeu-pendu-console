using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LePendu
{
    public class Word
    {
        public string Text { get; set; }

        public int Lenght { get; }

        public Word(string text)
        {
            Text = text.ToUpper();
            Lenght = text.Length;
        }

        public int GetIndexOf(char letter)
        {
            return Text.IndexOf(letter);
        }
    }
}
