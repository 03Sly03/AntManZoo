﻿using AntManZooClassLibrary.DTOs;

namespace AntManZooBlazor.Services
{
    public interface IStaffService
    {
        //Task<Staff?> Get(int id);
        //Task<List<Staff>> GetAll();
        Task<bool> PostLogin(LoginRequestDTO staffDTO);
        //Task<bool> Put(Staff staff);
        //Task<bool> Delete(int id);
    }
}