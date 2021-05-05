using System;
using FluentScheduler;

namespace LogicApp
{
    public class ParserDataTask : Registry
    {
        public ParserDataTask() => 
            this.Schedule(()=>
                new ParserJob())
                .ToRunOnceAt(DateTime.Now.AddSeconds(30))
                .AndEvery(1)
                .Minutes();
    }
}
