namespace HotelBookingApp.Observer
{
    public interface ISubject
    {
        void NotifyObservers();

        void Unsubscribe(IObserver observer);

        void Subscribe(IObserver observer);  
        
    }
}
