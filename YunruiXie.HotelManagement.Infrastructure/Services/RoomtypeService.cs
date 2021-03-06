﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YunruiXie.HotelManagement.Core.Entities;
using YunruiXie.HotelManagement.Core.Models.Request;
using YunruiXie.HotelManagement.Core.Models.Response;
using YunruiXie.HotelManagement.Core.RepositoryInterfaces;
using YunruiXie.HotelManagement.Core.ServiceInterfaces;
using YunruiXie.HotelManagement.Infrastructure.Repositories;

namespace YunruiXie.HotelManagement.Infrastructure.Services
{
    public class RoomtypeService : IRoomtypeService
    {
        private readonly IRoomtypeRepository _roomtypeRepository;
        private readonly IRoomRepository _roomRepository;

        public RoomtypeService(IRoomRepository roomRepository, IRoomtypeRepository roomtypeRepository)
        {
            _roomRepository = roomRepository;
            _roomtypeRepository = roomtypeRepository;
        }
        public async Task<RoomtypeResponseModel> CreateRoomtype(RoomtypeRequest roomtypeCreateRequest)
        {
            //If there is already a roomtype exists with same Id, throw exception
            var dbRoomtype = await _roomtypeRepository.GetRoomtypeById(roomtypeCreateRequest.Id);
            if (dbRoomtype != null && dbRoomtype.Id == roomtypeCreateRequest.Id)
                throw new Exception("Roomtype Already Exists");

            var roomtype = new ROOMTYPE
            {
                Id = roomtypeCreateRequest.Id,
                RTDESC = roomtypeCreateRequest.RTDESC,
                Rent = roomtypeCreateRequest.Rent,
            };
            var createRoomtype = await _roomtypeRepository.AddAsync(roomtype);
            var response = new RoomtypeResponseModel
            {
                Id = createRoomtype.Id,
                RTDESC = createRoomtype.RTDESC,
                Rent = createRoomtype.Rent,
            };
            return response;
        }

        public async Task DeleteRoomtype(int roomtypeId)
        {
            //If roomtype not exists, throw exception
            var roomtype = await _roomtypeRepository.GetRoomtypeById(roomtypeId);
            if (roomtype == null) throw new Exception("Room Type " + roomtypeId + " Not Exists");


            //If there is already a room exists of this roomtype, throw exception
            var dbRoom = await _roomRepository.GetRoomByRTCode(roomtypeId);
            if (dbRoom != null && dbRoom.RTCODE == roomtypeId)
                throw new Exception("Roomtype Exists, Cannot Delete Room");

            await _roomtypeRepository.DeleteAsync(roomtype);
        }

        public async Task<IEnumerable<RoomtypeResponseModel>> ListAllRoomtypes()
        {
            var allRoomtype = await _roomtypeRepository.ListAllAsync();
            var responses = new List<RoomtypeResponseModel>();
            foreach (var roomtype in allRoomtype)
            {
                var response = new RoomtypeResponseModel
                {
                    Id = roomtype.Id,
                    RTDESC = roomtype.RTDESC,
                    Rent = roomtype.Rent,
                };
                responses.Add(response);
            }
            return responses;
        }
        public async Task<RoomtypeResponseModel> GetRoomtypeDetails(int id)
        {
            var roomtype = await _roomtypeRepository.GetRoomtypeById(id);
            if (roomtype == null) throw new Exception("Roomtype " + id + " Not Exists");

            var response = new RoomtypeResponseModel
            {
                Id = roomtype.Id,
                RTDESC = roomtype.RTDESC,
                Rent = roomtype.Rent,
            };
            return response;
        }
        public async Task<RoomtypeResponseModel> UpdateRoomtype(RoomtypeRequest roomtypeUpdateRequest)
        {
            //If there there is not a roomtype exists with this Id, throw exception
            var dbRoomtype = await _roomtypeRepository.GetRoomtypeById(roomtypeUpdateRequest.Id);
            if (dbRoomtype == null) throw new Exception("Service " + roomtypeUpdateRequest.Id + " Not Exists");

            dbRoomtype.RTDESC = roomtypeUpdateRequest.RTDESC;
            dbRoomtype.Rent = roomtypeUpdateRequest.Rent;

            var updatedRoomtype = await _roomtypeRepository.UpdateAsync(dbRoomtype);
            var response = new RoomtypeResponseModel
            {
                Id = updatedRoomtype.Id,
                RTDESC = updatedRoomtype.RTDESC,
                Rent = updatedRoomtype.Rent,
            };
            return response;
        }
    }
}
