using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TextOperationService
{
    public class TextOperationService : ITextOperationService
    {
        public string DoWork(string text)
        {
            var textCharArr = text.ToCharArray();

            for (int i = 0; i < textCharArr.Length/2; i++)
            {
                // ReSharper disable once SwapViaDeconstruction
                var tmp = textCharArr[i];
                textCharArr[i] = textCharArr[textCharArr.Length - i - 1];
                textCharArr[textCharArr.Length - i - 1] = tmp;
            }

            //textCharArr = textCharArr.Reverse().ToArray();
            return new string(textCharArr);
        }
    }
}
