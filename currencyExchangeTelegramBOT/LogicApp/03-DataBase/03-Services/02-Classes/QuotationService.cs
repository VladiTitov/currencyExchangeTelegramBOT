﻿using System.Collections.Generic;
using AutoMapper;
using Banks;
using DataAccess.Repo;

namespace LogicApp
{
    class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepository;
        private readonly IMapper _mapper;

        public QuotationService(IQuotationRepository quotationRepository, IMapper mapper)
        {
            _quotationRepository = quotationRepository;
            _mapper = mapper;
        }

        public List<QuotationDTO> GetData() =>
            _mapper.Map<List<QuotationDTO>>(_quotationRepository.GetAll());

        public void Add(QuotationDTO quotation) =>
            _quotationRepository.Add(_mapper.Map<Quotation>(quotation));

        public void Update(QuotationDTO quotation) =>
            _quotationRepository.Update(_mapper.Map<Quotation>(quotation));

        public void Delete(string id) =>
            _quotationRepository.Delete(id);
    }
}
