using ApoioConsultorio.Data;
using ApoioConsultorio.Data.Dto.ImpostoTaxa;
using ApoioConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApoioConsultorio.Services
{
    public class ImpostoTaxaService
    {


        private AppDbContext _dbContex;

        public ImpostoTaxaService(AppDbContext dbContex)
        {
            _dbContex = dbContex;
        }
        public ReadImpostoTaxaDto buscar(int status)
        {

            ImpostoTaxa impostoTaxa = _dbContex.ImpostoTaxas.FirstOrDefault(x => x.ativo == status);

            ReadImpostoTaxaDto read = new ReadImpostoTaxaDto();

           

            read.Id = impostoTaxa.Id;
            read.imposto_nf =   impostoTaxa.imposto_nf * 100;
            read.taxa_avista = impostoTaxa.taxa_avista * 100;
            read.taxa_Parcelado = impostoTaxa.taxa_Parcelado * 100;
            read.ativo = impostoTaxa.ativo;

            return read;

        }

        internal List<ReadImpostoTaxaDto> BuscarTodasTaxas(int v)
        {
            List<ImpostoTaxa> impostoTaxa = _dbContex.ImpostoTaxas.ToList();

            List<ReadImpostoTaxaDto> read = new List<ReadImpostoTaxaDto>();


            foreach (var item in impostoTaxa)
            {
                read.Add(new ReadImpostoTaxaDto { 
                Id =item.Id,
                imposto_nf = item.imposto_nf * 100,
                taxa_avista = item.taxa_avista * 100,
                taxa_Parcelado = item.taxa_Parcelado * 100,
                ativo = item.ativo
            });
        }
           

            return read;
        }

        internal bool Atualizar(UpdateImpostotaxaDto dto)
        {
            ImpostoTaxa impostoTaxa = _dbContex.ImpostoTaxas.FirstOrDefault(x => x.ativo == dto.ativo);

            impostoTaxa.imposto_nf = dto.imposto_nf / 100;
            impostoTaxa.taxa_avista = dto.taxa_avista / 100;
            impostoTaxa.taxa_Parcelado = dto.taxa_Parcelado / 100;
            _dbContex.SaveChanges();
            return true;


        }
    }
}
