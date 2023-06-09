﻿namespace Lib.Exceptions
{
    /// <summary>
    /// 
    /// </summary>

    [Serializable]
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message) { }

        public DataNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}