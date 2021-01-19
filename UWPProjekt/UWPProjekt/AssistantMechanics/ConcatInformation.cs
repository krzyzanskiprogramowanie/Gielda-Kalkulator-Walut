using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPProjekt.AssistantMechanics
{
    class ConcatInformation
    {
     
            public static string toSave(string[] aarayWords)
            {
                string wordToSend = "";

                foreach (string word in aarayWords)
                {
                    wordToSend += $" {word}";
                }
                return wordToSend;
            }
        
    }
}
