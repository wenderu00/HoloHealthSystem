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
        private IList<Phone> _phones;
        private IList<Room> _rooms;
        private IList<Manager> _managers;
        public Clinic(string name)
        {
            Name = name;
            _phones = new List<Phone>();
            _rooms = new List<Room>();
            _managers = new List<Manager>();

        }
        public string Name { get; private set; }
        public Address? Address { get; private set; }
        public IReadOnlyCollection<Phone> Phones { get { return _phones.ToArray(); } }
        public IReadOnlyCollection<Room> Rooms { get { return _rooms.ToArray(); } }
        public IReadOnlyCollection<Manager> Managers { get { return _managers.ToArray(); } }

        public void AddAddress(Address address)
        {
            if(address.Id == Id)
            {
                Address = address;
            }
        }
        
        public void AddPhone(Phone phone)
        {
            if (phone.IsValid && !_phones.Contains(phone))
            {
                _phones.Add(phone);
            };
        }
        public void RemovePhone(Phone phone)
        {
            _phones.Remove(phone);
        }
        
        public void AddRoom(Room room)
        {
            if (!_rooms.Contains(room))
            {
                _rooms.Add(room);
            }
        }
        public bool HasRoomNumber(string number)
        {
            foreach (var room in _rooms)
            {
                if (room.Number == number) return true;
            }
            return false;
        }
        public void AddManager(Manager manager)
        {
            _managers.Add(manager);
        }
        public void RemoveManager(Manager manager)
        {
            _managers.Remove(manager);
        }
    }
}
