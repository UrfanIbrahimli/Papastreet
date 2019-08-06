﻿using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using PapaStreet.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.ServiceFacades
{
    public class PhoneNumberServiceFacade : BaseServiceFacade, IBaseServiceFacade<PhoneNumberDto>
    {
        private readonly PhoneNumberService _phoneNumberService;

        public PhoneNumberServiceFacade(PhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }
        public IQueryable<PhoneNumberDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _phoneNumberService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<PhoneNumberDto>().AsQueryable();
        }

        public PhoneNumberDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _phoneNumberService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new PhoneNumberDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _phoneNumberService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(PhoneNumberDto obj)
        {
            var response = new SiteResponse();
            var command = _phoneNumberService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}