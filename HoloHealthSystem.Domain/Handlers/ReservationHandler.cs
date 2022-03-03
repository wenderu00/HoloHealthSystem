using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.ReservationCommands;
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
    public class ReservationHandler :
        IHandler<CreateReservationCommand>,
        IHandler<RemoveReservationCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IReservationRepository _reservationRepository;

        public ReservationHandler(IRoomRepository roomRepository, IDoctorRepository doctorRepository,IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _doctorRepository = doctorRepository;
            _reservationRepository = reservationRepository;
        }
        public ICommandResult Handle(CreateReservationCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Comando inválido", command.Notifications);
            var room = _roomRepository.GetById(command.Room);
            var doctor = _doctorRepository.GetById(command.Doctor);
            var reservation = new Reservation(room,doctor,command.Begin,command.End);
            if(room.HasConflictReservation(reservation) && doctor.HasConflictReservation(reservation))
                return new GenericCommandResult(false, "Reserva tem conflito tanto com as reservas do médico quanto para as reservas da sala", reservation);
            else if(room.HasConflictReservation(reservation))
                return new GenericCommandResult(false, "Reserva possui conflito com as reservas da sala", reservation);
            else if(doctor.HasConflictReservation(reservation))
                return new GenericCommandResult(false, "Reserva possui conflito com as reservas do medico", reservation);
            room.AddReservation(reservation);
            doctor.AddReservation(reservation);
            _roomRepository.Update(room);
            _doctorRepository.Update(doctor);
            _reservationRepository.Create(reservation);
            return new GenericCommandResult(true, "Comando inválido", reservation);
        }

        public ICommandResult Handle(RemoveReservationCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Comando inválido", command.Notifications);
            var resevation = _reservationRepository.GetByID(command.Reservation);
            if(resevation == null)
                return new GenericCommandResult(false,"reserva não encontrada",command.Reservation);
            var room = _roomRepository.GetById(resevation.Room.Id);
            var doctor = _doctorRepository.GetById(resevation.Doctor.CRM);
            room.RemoveReservation(resevation);
            doctor.RemoveReservation(resevation);
            _roomRepository.Update(room);
            _doctorRepository.Update(doctor);
            _reservationRepository.Delete(resevation);
            return new GenericCommandResult(true, "reserva deletada com sucesso", resevation);
        }
    }
}
