using System;

namespace eConcierge.Foundation.Applications.EventArguments
{
    public class GenericEventArgs<T> : EventArgs
    {
        public T Data { get; set; }

        public GenericEventArgs(T data)
        {
            Data = data;
        }
        public GenericEventArgs()
        {
        }
    }
}
