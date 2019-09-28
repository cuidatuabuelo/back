using System;

namespace CuidaTuAbuelo.Logic
{
    public class CommandResult<T>
    {
        public bool result { get; set; }
        public string message { get; set; }
        public T data { get; set; }

        public CommandResult(bool result, string message, T data)
        {
            this.result = result;
            this.message = message;
            this.data = data;
        }


    }

}
