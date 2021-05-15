using System;
using FluentScheduler;

namespace BusinessLogic
{
    public class ParserDataTask : Registry
    {
        public ParserDataTask()
        {
            this.Schedule(() =>
                    new ParserJob())
                .ToRunOnceAt(DateTime.Now.AddSeconds(5))
                .AndEvery(15)
                .Minutes();
        }
    }

}
