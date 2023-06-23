//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace EventsTabExample
{
    // This component adds a TypeEventsTab to the Properties Window.
    [PropertyTabAttribute(typeof(TypeEventsTab), PropertyTabScope.Document)]
    public class TypeEventsTabComponent : Component
    {
        public TypeEventsTabComponent()
        {
        }
    }

    // This example events tab lists events by their delegate type.
    public class TypeEventsTab : System.Windows.Forms.Design.EventsTab
    {
        [BrowsableAttribute(true)]
        private IServiceProvider sp;

        public TypeEventsTab(IServiceProvider sp) : base(sp)
        {
            this.sp = sp;
        }

        // Returns the properties of the specified component extended with a 
        // CategoryAttribute reflecting the name of the type of the property.
        public override System.ComponentModel.PropertyDescriptorCollection
            GetProperties(ITypeDescriptorContext context, object component,
            System.Attribute[] attributes)
        {
            // Obtain an instance of the IEventBindingService.
            IEventBindingService eventPropertySvc = (IEventBindingService)
                sp.GetService(typeof(IEventBindingService));

            // Return if an IEventBindingService could not be obtained.
            if (eventPropertySvc == null)
                return new PropertyDescriptorCollection(null);

            // Obtain the events on the component.
            EventDescriptorCollection events =
                TypeDescriptor.GetEvents(component, attributes);

            // Create an array of the events, where each event is assigned 
            // a category matching its type.
            EventDescriptor[] newEvents = new EventDescriptor[events.Count];
            for (int i = 0; i < events.Count; i++)
                newEvents[i] = TypeDescriptor.CreateEvent(events[i].ComponentType, events[i],
                    new CategoryAttribute(events[i].EventType.FullName));
            events = new EventDescriptorCollection(newEvents);

            // Return event properties for the event descriptors.
            return eventPropertySvc.GetEventProperties(events);
        }

        // Provides the name for the event property tab.
        public override string TabName
        {
            get
            {
                return "Events by Type";
            }
        }
    }
}
//</Snippet1>
