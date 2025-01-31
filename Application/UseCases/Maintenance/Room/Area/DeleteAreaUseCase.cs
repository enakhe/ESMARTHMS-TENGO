﻿using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Area
{
    public class DeleteAreaUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteAreaUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(string id)
        {
            _roomRepository.DeleteArea(id);
        }
    }
}
