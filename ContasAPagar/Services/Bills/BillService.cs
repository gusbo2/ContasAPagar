using AutoMapper;
using ContasAPagar.Data;
using ContasAPagar.Data.Entities;
using ContasAPagar.Dtos.Bills;
using ContasAPagar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContasAPagar.Services.Bills
{
    public class BillService : IBillService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BillService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResponseModel<GetBillDto>> AddBill(AddBillDto newBill)
        {
            var responseModel = new ResponseModel<GetBillDto>();
            try
            {
                var bill = _mapper.Map<Bill>(newBill);
                _context.Add(bill);
                await _context.SaveChangesAsync();
                responseModel.Data = BillToBillDto(bill);
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = ex.Message;
            }
            return responseModel;
        }

        public async Task<ResponseModel<GetBillDto>> DeleteBill(int id)
        {
            var responseModel = new ResponseModel<GetBillDto>();
            try
            {
                var bill = await _context.Bills.FirstOrDefaultAsync(b => b.Id == id);
                if (bill == null)
                    throw new Exception("Conta não encontrada");

                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = ex.Message;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<GetBillDto>>> GetAllBill()
        {
            var bills = await _context.Bills.ToListAsync();
            List<GetBillDto> billDto = new List<GetBillDto>();
            foreach (var bill in bills)
            {
                billDto.Add(BillToBillDto(bill));
            }
            return new ResponseModel<List<GetBillDto>>
            {
                Data = billDto
            };
        }

        public async Task<ResponseModel<GetBillDto>> GetBill(int id)
        {
            var responseModel = new ResponseModel<GetBillDto>();
            try
            {
                var bill = await _context.Bills.FirstOrDefaultAsync(b => b.Id == id);
                if (bill != null)
                    responseModel.Data = BillToBillDto(bill);
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = ex.Message;
            }
            return responseModel;
        }

        public async Task<ResponseModel<GetBillDto>> UpdateBill(UpdatedBillDto billDto)
        {
            var responseModel = new ResponseModel<GetBillDto>();
            try
            {
                var bill = await _context.Bills.FirstOrDefaultAsync(b => b.Id == billDto.Id);
                if (bill == null)
                    throw new Exception("Conta não encontrada");

                bill.Name = billDto.Name;
                bill.Value = billDto.Value;
                bill.ExpirationDate = billDto.ExpirationDate;
                bill.PayDate = billDto.PayDate;

                await _context.SaveChangesAsync();
                responseModel.Data = BillToBillDto(bill);
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = ex.Message;
            }
            return responseModel;
        }

        private GetBillDto BillToBillDto(Bill bill)
        {
            var billDto = _mapper.Map<GetBillDto>(bill);
            billDto.DaysInArrears = bill.GetDaysInArrears();
            billDto.CorrectedValue = bill.CalculateTaxes();
            return billDto;
        }
    }
}