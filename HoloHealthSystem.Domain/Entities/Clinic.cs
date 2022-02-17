using HoloHealthSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Clinic : Entity
    {
        public Clinic(string name)
        {
            Name = name;
            Phones = new List<Phone>();
            Rooms = new List<Room>();
            Managers = new List<Manager>();

        }
        public string Name { get; private set; }
        public Address? address { get; private set; }
        public IList<Phone> Phones { get; private set; }
        public IList<Room> Rooms { get; private set;}
        public IList<Manager> Managers { get; private set; } 
        public void AddPhone(Phone phone)
        {
            if (phone.IsValid)
            {
                Phones.Add(phone);
            };
        }
        public void RemovePhone(Phone phone)
        {
            Phones.Remove(phone);
        }
        public void AddRoom(Room room)
        {
            if (!Rooms.Contains(room))
            {
                Rooms.Add(room);
            }
        }
        public void AddManager(Manager manager)
        {
            Managers.Add(manager);
        }
    }
}
