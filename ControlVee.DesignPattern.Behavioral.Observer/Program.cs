namespace ControlVee.DesignPattern.Behavioral.Observer
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /* 
        Summary:  Define a one-to-many dependency between objects so that 
        when one object changes state, all its dependents are notified and updated automatically.

        Participants -
        The classes and objects participating in this pattern are:

            Subject  (Stock)
                - knows its observers. Any number of Observer objects may observe a subject
                - provides an interface for attaching and detaching Observer objects

            ConcreteSubject  (IBM)
                - stores state of interest to ConcreteObserver
                - sends a notification to its observers when its state changes

            Observer (IInvestor)
                - defines an updating interface for objects that should be notified of changes in a subject

            ConcreteObserver  (Investor)
                - maintains a reference to a ConcreteSubject object
                and defines the process by which it's assembled
                - stores state that should stay consistent with the subject's state
                - implements the Observer updating interface to keep its state consistent with the subject's state
    */
    /// </summary>
    class Program
    {
    }

    abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in _observers)
            {
                // How does this do anything?
                observer.Update();
            }
        }
    }

    abstract class ConcreteSubject  : Subject
    {
        private string _subjectState;

        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }

        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine($"Observer {_name}'s new state is {_observerState}");
        }
    }
}