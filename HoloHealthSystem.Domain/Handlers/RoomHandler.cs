using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.RoomCommands;
using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Handlers.Contracts;
using HoloHealthSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Handlers
{
    public class RoomHandler : 
        IHandler<CreateRoomCommand>,
        IHandler<UpdateRoomNumberCommand>
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IRoomRepository _roomRepository;
        public RoomHandler(IClinicRepository clinicRepository,IRoomRepository roomRepository)
        {
            _clinicRepository = clinicRepository;
            _roomRepository = roomRepository;
        }
        public ICommandResult Handle(CreateRoomCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "O comando é inválido", command.Notifications);
            var clinic = _clinicRepository.GetById(command.Clinic);
            if (clinic == null)
                return new GenericCommandResult(false, "A clinica é inválida", command.Clinic);
            if(clinic.HasRoomNumber(command.Number))
                return new GenericCommandResult(false,"Já existe uma sala com esse número",command.Number);
            var room = new Room(command.Number, clinic);
            clinic.AddRoom(room);
            _roomRepository.Create(room);
            _clinicRepository.Update(clinic);
            return new GenericCommandResult(true, "Sala criada com sucesso", room);
        }

        public ICommandResult Handle(UpdateRoomNumberCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "O comando é inválido", command.Notifications);
            var room = _roomRepository.GetById(command.Room);
            if (room == null)
                return new GenericCommandResult(false, "A sala é inválida", command.Room);
            if(room.Clinic.HasRoomNumber(command.Number))
                return new GenericCommandResult(false, "Já existe uma sala com esse número", command.Number);
            room.UpdateNumber(command.Number);
            _roomRepository.Update(room);
            return new GenericCommandResult(true, "Número alterado com sucesso", room);
        }
    }
}
