using System.Collections.Generic;
using System.Collections;

namespace StringTheory
{
    public class Sequence : IEnumerable<Event>
    {
        private List<Event> events = new List<Event>();
        private Queue<Event> eventsQueue = new Queue<Event>();
        public void StartSequence()
        {
            /*
            for (int i = 0; i < events.Count; i++)
            {
                events[i].Run();
            }*/

            do
            {
                eventsQueue.Dequeue().Run();
            } while (eventsQueue.Count != 0);

        }

        public void AddEvent(Event ds)
        {
            //events.Add(ds);
            eventsQueue.Enqueue(ds);
        }

        public void AddEvent(Event[] events)
        {
            foreach (Event ev in events)
            {
                //this.events.Add(ev);
                this.eventsQueue.Enqueue(ev);
            }
        }

        public void InsertEvent(Event ev)
        {
            Queue<Event> newQueue = new Queue<Event>();
            newQueue.Enqueue(ev);
            foreach(Event existingEvent in eventsQueue)
            {
                newQueue.Enqueue(existingEvent);
            }
            eventsQueue = newQueue;
        }

        public void InsertEvent(Event[] events)
        {
            foreach(Event newEvent in events)
            {
                InsertEvent(newEvent);
            }
        }

        public void AddSequence(Sequence seq)
        {
            foreach (Event ev in seq)
            {
                //events.Add(ev);
                eventsQueue.Enqueue(ev);
            }
        }

        public void InsertSequence(Sequence seq)
        {
            Queue<Event> newQueue = new Queue<Event>();
            foreach (Event ev in seq)
            {
                newQueue.Enqueue(ev);
            }

            foreach (Event existingEvent in eventsQueue)
            {
                newQueue.Enqueue(existingEvent);
            }
            eventsQueue = newQueue;
        }


        // Basic Enumerator implementation.
        public IEnumerator<Event> GetEnumerator()
        {
            foreach (Event ev in eventsQueue)
            {
                yield return ev;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
