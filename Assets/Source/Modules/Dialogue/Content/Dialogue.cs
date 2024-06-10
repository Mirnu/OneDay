using Poll;
using System.Collections.Generic;


namespace Dialogue
{
    public class Dialogue
    {
        public string Author;
        public string Text;
        public List<Choise> Childrens;
        public bool isChoise = false;

        public static DiagueBuilder Build()
        {
            return new DiagueBuilder();
        }

        public class DiagueBuilder
        {
            private Dialogue _dialogue = new Dialogue();

            public DiagueBuilder Author(string author)
            {
                _dialogue.Author = author;
                return this;
            }

            public DiagueBuilder Text(string text)
            {
                _dialogue.Text = text;
                return this;
            }

            public DiagueBuilder Childrens(List<Choise> childrens)
            {
                _dialogue.Childrens = childrens;
                if (childrens.Count > 0)
                {
                    _dialogue.isChoise = true;
                }
                return this;
            }

            public Dialogue Build() => _dialogue;
        }
    }
}

