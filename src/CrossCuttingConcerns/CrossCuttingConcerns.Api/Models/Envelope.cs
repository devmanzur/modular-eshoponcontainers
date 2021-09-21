using System;

namespace CrossCuttingConcerns.Api.Models
{
    
    public class Envelope<T>
    {
        public Envelope()
        {
            
        }
        
        // ReSharper disable once MemberCanBeProtected.Global
        protected internal Envelope(T body, string errorMessage)
        {
            Body = body;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
            IsSuccess = errorMessage == null;
        }

        /// <summary>
        /// These fields were made public for e2e tests only
        /// </summary>
        public T Body { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeGenerated { get; set; }
        public bool IsSuccess { get; set; }
    }

    public class Envelope : Envelope<string>
    {
        private Envelope(string errorMessage)
            : base(errorMessage ==null ? null : "", errorMessage)
        {
        }

        public Envelope()
        {
            
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Ok()
        {
            return new Envelope(null);
        }

        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }

        public static Envelope<T> Error<T>(T error, string errorMessage)
        {
            return new Envelope<T>(error, errorMessage);
        }
    }
}