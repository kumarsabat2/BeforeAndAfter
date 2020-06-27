using System;
using System.Collections.Generic;
using System.Linq;
using System.Activities;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace String_Operation
{
    public class Before_After : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> Main_String { get; set; }
        [Category("Input")]
        
        public InArgument<string> Before { get; set; }
        [Category("Input")]
        [DefaultValue(null)]

        public InArgument<string> After { get; set; }
        [Category("OutPut")]
        [RequiredArgument]
        public OutArgument<string> Final_text { get; set; }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        protected override void Execute(CodeActivityContext context)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            var STR = Main_String.Get(context);
            var vBefore = Before.Get(context);
            var vAfter = After.Get(context);
            int Pos1 = STR.IndexOf(vBefore) + vBefore.Length;
            int Pos2 = STR.IndexOf(vAfter);

            string FinalString;
            if (vAfter=="")  FinalString = STR.Substring(Pos1);            
            else  FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            FinalString = FinalString.Trim();
            Final_text.Set(context, FinalString);
        }


    }
}
