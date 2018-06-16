using System;

namespace EpamLibrary.Contracts.Exception
{
    public class UserExistsException : System.Exception
    {
        public object Sender { get; }
        public UserExistsEventArgs Args { get; }

        public UserExistsException()
        :this(null, new UserExistsEventArgs())
        {
            
        }

        public UserExistsException(object sender, UserExistsEventArgs args)
        {
            Sender = sender;
            Args = args;
        }
    }

    public class UserExistsEventArgs : EventArgs
    {

    }
}