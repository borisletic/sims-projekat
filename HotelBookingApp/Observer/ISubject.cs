using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingApp.Observer
{
    public interface ISubject
    {
        void NotifyObservers();

        void Unsubscribe(IObserver observer);

        void Subscribe(IObserver observer);
        
        
    }
}
