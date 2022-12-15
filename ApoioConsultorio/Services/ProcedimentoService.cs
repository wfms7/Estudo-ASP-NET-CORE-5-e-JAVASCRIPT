using ApoioConsultorio.Data;
using ApoioConsultorio.Data.Dto.Procedimento;

using ApoioConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApoioConsultorio.Services
{
    public class ProcedimentoService
    {

        private AppDbContext _dbContex;

        public ProcedimentoService(AppDbContext dbContex)
        {
            _dbContex = dbContex;
        }

        public  ReadProcedimentoDto CreateAtividade(CreatedProcedimentoDto dto)
        {
            Procedimento obj = new Procedimento();
            obj.Nome = dto.Nome;
            obj.Tipo = dto.Tipo;
            obj.ValorParcelado = dto.ValorParcelado;
            obj.ValorAvista = dto.ValorAvista;
            obj.Material_1 = dto.Material_1;
            obj.Material_2 = dto.Material_2;
            obj.Material_3 = dto.Material_3;
            obj.Material_4 = dto.Material_4;
            obj.MaterialCustos_1 = dto.MaterialCustos_1;
            obj.MaterialCustos_2 = dto.MaterialCustos_2;
            obj.MaterialCustos_3 = dto.MaterialCustos_3;
            obj.MaterialCustos_4 = dto.MaterialCustos_4;
            obj.EquipeCustos1 = dto.EquipeCustos1;
            obj.EquipeCustos2 = dto.EquipeCustos2;
            obj.EquipeCustos3 = dto.EquipeCustos3;
            obj.EquipeCustos4 = dto.EquipeCustos4;
            obj.especial = dto.especial;


            _dbContex.Procedimentos.Add(obj);
            _dbContex.SaveChanges();

            ReadProcedimentoDto result = new ReadProcedimentoDto();
            result.Id = obj.Id;
            result.Nome = obj.Nome;
            result.Tipo = obj.Tipo;
            result.ValorParcelado = obj.ValorParcelado;
            result.ValorAvista= obj.ValorAvista;
            return result;
        }

        internal (List<ReadProcedimentoDto> read, int total) loadAtividadeComEspecial(int skip, int take, string nameProcedimento, bool especial)
        {

            decimal zero = 00.00m;
            List<Procedimento> result;
            int total;

        
            
            if (nameProcedimento == "" || nameProcedimento == null || nameProcedimento == "null")
            {
                result = _dbContex.Procedimentos.Where(x=> x.especial == especial).Skip(skip).Take(take).ToList();

                total = _dbContex.Procedimentos.Where(x => x.especial == especial).Count();
            }
            else
            {
                result = _dbContex.Procedimentos.Where(x => x.Nome.Contains(nameProcedimento) && x.especial== especial).Skip(skip).Take(take).ToList();
                total = _dbContex.Procedimentos.Where(x => x.Nome.Contains(nameProcedimento) && x.especial == especial).Count();
            }

            
           

            List<ReadProcedimentoDto> reads = new List<ReadProcedimentoDto>();


            foreach (var item in result)
            {
                LucroImpostosTaxa lucro_Avista = lucroAvista(item);
                LucroImpostosTaxa lucro_Parcelado = parceladoLucro(item);
                reads.Add(new ReadProcedimentoDto
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Tipo = item.Tipo,
                    ValorAvista = item.ValorAvista + zero,
                    ValorParcelado = item.ValorParcelado + zero,
                    Material_1 = item.Material_1,
                    Material_2 = item.Material_2,
                    Material_3 = item.Material_3,
                    Material_4 = item.Material_4,
                    MaterialCustos_1 = item.MaterialCustos_1 + zero,
                    MaterialCustos_2 = item.MaterialCustos_2 + zero,
                    MaterialCustos_3 = item.MaterialCustos_3 + zero,
                    MaterialCustos_4 = item.MaterialCustos_4 + zero,
                    EquipeCustos1 = item.EquipeCustos1 + zero,
                    EquipeCustos2 = item.EquipeCustos2 + zero,
                    EquipeCustos3 = item.EquipeCustos3 + zero,
                    EquipeCustos4 = item.EquipeCustos4 + zero,
                    lucroAvista = lucro_Avista.Lucro + zero,
                    lucroParcelado = lucro_Parcelado.Lucro + zero,
                    especial = item.especial


                });
            }


            return (reads, total);


        }

        public ReadProcedimentoDto buscarProcedimentoPorID(int? id)
        {

            Procedimento procedimento = _dbContex.Procedimentos.FirstOrDefault(x => x.Id == id);
            LucroImpostosTaxa lucro_Avista = lucroAvista(procedimento);
            LucroImpostosTaxa lucro_pacelado = parceladoLucro(procedimento);
            ReadProcedimentoDto read = new ReadProcedimentoDto();
            decimal zero = 00.00m;
            


            read.Id = procedimento.Id;
            read.Nome = procedimento.Nome;
            read.Tipo = procedimento.Tipo;
            read.ValorAvista = procedimento.ValorAvista + zero;
            read.ValorParcelado = procedimento.ValorParcelado + zero;
            read.Material_1 = procedimento.Material_1;
            read.Material_2 = procedimento.Material_2;
            read.Material_3 = procedimento.Material_3;
            read.Material_4 = procedimento.Material_4;
            read.MaterialCustos_1 = procedimento.MaterialCustos_1 + zero;
            read.MaterialCustos_2 = procedimento.MaterialCustos_2 + zero;
            read.MaterialCustos_3 = procedimento.MaterialCustos_3 + zero;
            read.MaterialCustos_4 = procedimento.MaterialCustos_4 + zero;
            read.EquipeCustos1 = procedimento.EquipeCustos1 + zero;
            read.EquipeCustos2 = procedimento.EquipeCustos2 + zero;
            read.EquipeCustos3 = procedimento.EquipeCustos3 + zero;
            read.EquipeCustos4 = procedimento.EquipeCustos4 + zero;
            read.lucroAvista = lucro_Avista.Lucro + zero;
            read.lucroParcelado = lucro_pacelado.Lucro + zero;
            read.ImpostoNFAvista = lucro_Avista.ImpostoNF + zero;
            read.TaxaAvista = lucro_Avista.TaxaCartao + zero;
            read.ImpostoNFParcelado = lucro_pacelado.ImpostoNF + zero;
            read.TaxaParcelado = lucro_pacelado.TaxaCartao + zero;
            read.especial = procedimento.especial;

            return read;

        }

        public ReadProcedimentoDto Calcular(UpdateProcedimentoDto dto)
        {
            Procedimento obj = new Procedimento();
            obj.Nome = dto.Nome;
            obj.Tipo = dto.Tipo;
            obj.ValorParcelado = dto.ValorParcelado;
            obj.ValorAvista = dto.ValorAvista;
            obj.Material_1 = dto.Material_1;
            obj.Material_2 = dto.Material_2;
            obj.Material_3 = dto.Material_3;
            obj.Material_4 = dto.Material_4;
            obj.MaterialCustos_1 = dto.MaterialCustos_1;
            obj.MaterialCustos_2 = dto.MaterialCustos_2;
            obj.MaterialCustos_3 = dto.MaterialCustos_3;
            obj.MaterialCustos_4 = dto.MaterialCustos_4;
            obj.EquipeCustos1 = dto.EquipeCustos1;
            obj.EquipeCustos2 = dto.EquipeCustos2;
            obj.EquipeCustos3 = dto.EquipeCustos3;
            obj.EquipeCustos4 = dto.EquipeCustos4;

            LucroImpostosTaxa avista = lucroAvista(obj);
            LucroImpostosTaxa parcelado = parceladoLucro(obj);

            ReadProcedimentoDto readProcedimentoDto = new ReadProcedimentoDto();
            readProcedimentoDto.Nome = dto.Nome;
            readProcedimentoDto.Tipo = dto.Tipo;
            readProcedimentoDto.ValorParcelado = dto.ValorParcelado;
            readProcedimentoDto.ValorAvista = dto.ValorAvista;
            readProcedimentoDto.Material_1 = dto.Material_1;
            readProcedimentoDto.Material_2 = dto.Material_2;
            readProcedimentoDto.Material_3 = dto.Material_3;
            readProcedimentoDto.Material_4 = dto.Material_4;
            readProcedimentoDto.MaterialCustos_1 = dto.MaterialCustos_1;
            readProcedimentoDto.MaterialCustos_2 = dto.MaterialCustos_2;
            readProcedimentoDto.MaterialCustos_3 = dto.MaterialCustos_3;
            readProcedimentoDto.MaterialCustos_4 = dto.MaterialCustos_4;
            readProcedimentoDto.EquipeCustos1 = dto.EquipeCustos1;
            readProcedimentoDto.EquipeCustos2 = dto.EquipeCustos2;
            readProcedimentoDto.EquipeCustos3 = dto.EquipeCustos3;
            readProcedimentoDto.EquipeCustos4 = dto.EquipeCustos4;
            readProcedimentoDto.lucroAvista = avista.Lucro;
            readProcedimentoDto.ImpostoNFAvista = avista.ImpostoNF;
            readProcedimentoDto.TaxaAvista = avista.TaxaCartao;
            readProcedimentoDto.lucroParcelado = parcelado.Lucro;
            readProcedimentoDto.ImpostoNFParcelado = parcelado.ImpostoNF;
            readProcedimentoDto.TaxaParcelado = parcelado.TaxaCartao;

            return readProcedimentoDto;


        }

        public  (List<ReadProcedimentoDto>,int) loadAtividade(int skip, int take,string nameProcedimento)
        {
            decimal zero = 00.00m;
            List<Procedimento> result;
            int total;
            

            
            if (nameProcedimento == "" || nameProcedimento == null || nameProcedimento =="null") { 
                 result  = _dbContex.Procedimentos.Skip(skip).Take(take).ToList();

             total = _dbContex.Procedimentos.Count();
            }
            else
            {
                result = _dbContex.Procedimentos.Where(x=> x.Nome.Contains(nameProcedimento)).Skip(skip).Take(take).ToList();
                total = _dbContex.Procedimentos.Where(x => x.Nome.Contains(nameProcedimento)).Count();
            }
            

            List<ReadProcedimentoDto> reads = new List<ReadProcedimentoDto>();


            foreach (var item in result)
            {
                LucroImpostosTaxa lucro_Avista = lucroAvista(item);
                LucroImpostosTaxa lucro_Parcelado = parceladoLucro(item);
                reads.Add(new ReadProcedimentoDto
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Tipo = item.Tipo,
                    ValorAvista = item.ValorAvista + zero,
                    ValorParcelado = item.ValorParcelado + zero,
                    Material_1 = item.Material_1,
                    Material_2 = item.Material_2,
                    Material_3 = item.Material_3,
                    Material_4 = item.Material_4,
                    MaterialCustos_1 = item.MaterialCustos_1 + zero,
                    MaterialCustos_2 = item.MaterialCustos_2 + zero,
                    MaterialCustos_3 = item.MaterialCustos_3 + zero,
                    MaterialCustos_4 = item.MaterialCustos_4 + zero,
                    EquipeCustos1 = item.EquipeCustos1 + zero,
                    EquipeCustos2 = item.EquipeCustos2 + zero,
                    EquipeCustos3 = item.EquipeCustos3 + zero,
                    EquipeCustos4 = item.EquipeCustos4 + zero,
                    lucroAvista = lucro_Avista.Lucro + zero,
                    lucroParcelado = lucro_Parcelado.Lucro + zero,
                    especial = item.especial


                }) ;
            }


            return (reads, total);

        }

        public bool DeletarProcedimento(int? id)
        {
            Procedimento procedimento = _dbContex.Procedimentos.FirstOrDefault(x => x.Id == id);
            if (procedimento == null)
            {
                return false;
            }

            _dbContex.Procedimentos.Remove(procedimento);
            _dbContex.SaveChanges();
            return true;

        }

        public bool updatadeProcedimento(UpdateProcedimentoDto dto)
        {
            Procedimento procedimento = _dbContex.Procedimentos.FirstOrDefault(x => x.Id == dto.Id);
            if (procedimento== null)
            {
                return false;
            }

            procedimento.Nome = dto.Nome;
            procedimento.Tipo = dto.Tipo;
            procedimento.ValorAvista = dto.ValorAvista;
            procedimento.ValorParcelado = dto.ValorParcelado;
            procedimento.MaterialCustos_1 = dto.MaterialCustos_1;
            procedimento.MaterialCustos_2 = dto.MaterialCustos_2;
            procedimento.MaterialCustos_3 = dto.MaterialCustos_3;
            procedimento.MaterialCustos_4 = dto.MaterialCustos_4;
            procedimento.Material_1 = dto.Material_1;
            procedimento.Material_2 = dto.Material_2;
            procedimento.Material_3 = dto.Material_3;
            procedimento.Material_4 = dto.Material_4;
            procedimento.EquipeCustos1 = dto.EquipeCustos1;
            procedimento.EquipeCustos2 = dto.EquipeCustos2;
            procedimento.EquipeCustos3 = dto.EquipeCustos3;
            procedimento.EquipeCustos4 = dto.EquipeCustos4;
            procedimento.especial = dto.especial;

            _dbContex.SaveChanges();

            return true;

        }

        private LucroImpostosTaxa lucroAvista(Procedimento procedimento)
        {
            decimal ImpostoAvista = 0;
            decimal TaxaAvista = 0;
            decimal lucroAvista = 0;
            LucroImpostosTaxa lucroImpostosTaxa = new LucroImpostosTaxa();

            ImpostoTaxa impostoTaxa = _dbContex.ImpostoTaxas.FirstOrDefault(x => x.ativo == 99);

            if (procedimento.Tipo == "CIRURGIA")
            {
                TaxaAvista = procedimento.ValorAvista * impostoTaxa.taxa_avista;
                lucroAvista = procedimento.ValorAvista - (procedimento.EquipeCustos1 + procedimento.EquipeCustos2 + procedimento.EquipeCustos3 + procedimento.EquipeCustos4 + procedimento.MaterialCustos_1 + procedimento.MaterialCustos_2 + procedimento.MaterialCustos_3 + procedimento.MaterialCustos_4);

                ImpostoAvista = lucroAvista * impostoTaxa.imposto_nf;

                decimal lucro_Avista = lucroAvista -  (ImpostoAvista+TaxaAvista);
                lucroImpostosTaxa.Lucro = lucro_Avista;
                lucroImpostosTaxa.ImpostoNF = TaxaAvista;
                lucroImpostosTaxa.TaxaCartao = ImpostoAvista;

                return lucroImpostosTaxa;
            }
            ImpostoAvista = procedimento.ValorAvista * impostoTaxa.imposto_nf;
            TaxaAvista = procedimento.ValorAvista * impostoTaxa.taxa_avista;

            lucroAvista = procedimento.ValorAvista - (procedimento.EquipeCustos1 + procedimento.EquipeCustos2 + procedimento.EquipeCustos3 + procedimento.EquipeCustos4 + procedimento.MaterialCustos_1 + procedimento.MaterialCustos_2 + procedimento.MaterialCustos_3 + procedimento.MaterialCustos_4 + ImpostoAvista + TaxaAvista);

            lucroImpostosTaxa.Lucro = lucroAvista;
            lucroImpostosTaxa.ImpostoNF = TaxaAvista;
            lucroImpostosTaxa.TaxaCartao = ImpostoAvista;

            return lucroImpostosTaxa;




        }



        private LucroImpostosTaxa parceladoLucro(Procedimento procedimento)
        {
            decimal ImpostoParcelado = 0;
            decimal TaxaParcelado = 0;
            decimal lucroParcelado = 0;
            LucroImpostosTaxa lucroImpostosTaxa = new LucroImpostosTaxa();

            ImpostoTaxa impostoTaxa = _dbContex.ImpostoTaxas.FirstOrDefault(x => x.ativo == 99);

            if (procedimento.Tipo == "CIRURGIA")
            {
                TaxaParcelado = procedimento.ValorParcelado * impostoTaxa.taxa_Parcelado;
                lucroParcelado = procedimento.ValorParcelado - (procedimento.EquipeCustos1 + procedimento.EquipeCustos2 + procedimento.EquipeCustos3 + procedimento.EquipeCustos4 + procedimento.MaterialCustos_1 + procedimento.MaterialCustos_2 + procedimento.MaterialCustos_3 + procedimento.MaterialCustos_4 );

                ImpostoParcelado = lucroParcelado * impostoTaxa.imposto_nf;

               decimal lucro_Parcelado = lucroParcelado - (ImpostoParcelado+ TaxaParcelado);

                lucroImpostosTaxa.Lucro = lucro_Parcelado;
                lucroImpostosTaxa.ImpostoNF = ImpostoParcelado;
                lucroImpostosTaxa.TaxaCartao = TaxaParcelado;
                return lucroImpostosTaxa;
            }
            ImpostoParcelado = procedimento.ValorParcelado * impostoTaxa.imposto_nf;
            TaxaParcelado = procedimento.ValorParcelado * impostoTaxa.taxa_Parcelado;

            lucroParcelado = procedimento.ValorParcelado - (procedimento.EquipeCustos1 + procedimento.EquipeCustos2 + procedimento.EquipeCustos3 + procedimento.EquipeCustos4 + procedimento.MaterialCustos_1 + procedimento.MaterialCustos_2 + procedimento.MaterialCustos_3 + procedimento.MaterialCustos_4 + ImpostoParcelado + TaxaParcelado);



            lucroImpostosTaxa.Lucro = lucroParcelado;
            lucroImpostosTaxa.ImpostoNF = ImpostoParcelado;
            lucroImpostosTaxa.TaxaCartao = TaxaParcelado;

            return lucroImpostosTaxa;

        }
    }
}
