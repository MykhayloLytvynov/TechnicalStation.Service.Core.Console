using System;
using System.Collections.Generic;
using System.Text;
using TechnicalStation.UI.VewModel.Extensions;

namespace TechnicalStation.Core.Dto.Transform.Base
{
    public class TransformerBase<B, I>
    {
        public I Transform(B domainObject)
        {
            I infoObject = (I)Activator.CreateInstance(typeof(I), null);
            domainObject.CopyProperties(infoObject);

            return infoObject;
        }

        public B Transform(I infoObject)
        {
            B domainObject = (B)Activator.CreateInstance(typeof(B), null);
            infoObject.CopyProperties(domainObject);

            return domainObject;
        }

        public List<I> Transform(List<B> domainObjectCollection)
        {
            List<I> result = new List<I>();
            foreach (var domainObject in domainObjectCollection)
            {
                result.Add(this.Transform(domainObject));
            }

            return result;
        }

        public List<B> Transform(List<I> infoObjectCollection)
        {
            List<B> result = new List<B>();
            foreach (var infoObject in infoObjectCollection)
            {
                result.Add(this.Transform(infoObject));
            }

            return result;
        }


    }
}
