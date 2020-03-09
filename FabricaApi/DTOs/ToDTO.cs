using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.DTOs;
using FabricaApi.Models;
using InterfaceGenerica.Models;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FabricaApi.Repo;

namespace FabricaApi.DTOs {

    public static class ToDTO {
        

        public static TipoMaquinaDTO TipoMaquinaToDTO (TipoMaquina tm) {

            TipoMaquinaDTO dto;

            dto = new TipoMaquinaDTO { descricao = tm.descricao.descricao };

            return dto;

        }

        public static IEnumerable<TipoMaquinaDTO> ListaTipoMaquinaToDTO (IEnumerable<TipoMaquina> lista) {
            List<TipoMaquinaDTO> listaFinal = new List<TipoMaquinaDTO> ();

            foreach (TipoMaquina p in lista) {
                listaFinal.Add (ToDTO.TipoMaquinaToDTO (p));
            }

            IEnumerable<TipoMaquinaDTO> l = listaFinal;
            return l;
        }

        public static OperacaoDTO OperacaoToOperacaoDTO (Operacao operacao, TipoOperacao tipo) {

            OperacaoDTO dto;

            dto = new OperacaoDTO { nomeTipoOp = tipo.nome.nome, nomeOperacao = operacao.nome.nome, duracao = new Duracao (operacao.duracao.minutos, operacao.duracao.segundos) };

            return dto;
        }

        public static ListaMaquinasOperacaoDTO MaquinaOperacaoToDTO (ListaMaquinasOperacao lmo) {

            ListaMaquinasOperacaoDTO dto;

            dto = new ListaMaquinasOperacaoDTO { idTipoMaquina = lmo.idTipoMaquina, idOperacao = lmo.idOperacao };

            return dto;
        }

        public static LinhaProducaoMaquinaDTO LinhaProducaoMaquinaToDTO (LinhaProducaoMaquina lmo) {

            LinhaProducaoMaquinaDTO dto;

            dto = new LinhaProducaoMaquinaDTO{ idLinhaProducao = lmo.idLinhaProducao, idMaquina = lmo.idMaquina };

            return dto;
        }

        public static IEnumerable<ListaMaquinasOperacaoDTO> ListaMaquinasOperacaoToDTO (IEnumerable<ListaMaquinasOperacao> lista) {
            List<ListaMaquinasOperacaoDTO> listaFinal = new List<ListaMaquinasOperacaoDTO> ();

            foreach (ListaMaquinasOperacao p in lista) {
                listaFinal.Add (ToDTO.MaquinaOperacaoToDTO (p));
            }

            IEnumerable<ListaMaquinasOperacaoDTO> l = listaFinal;
            return l;
        }

        public static IEnumerable<LinhaProducaoMaquinaDTO> ListaLinhaProducaoMaquinaToDTO (IEnumerable<LinhaProducaoMaquina> lista) {

            List<LinhaProducaoMaquinaDTO> listaFinal = new List<LinhaProducaoMaquinaDTO> ();

            foreach (LinhaProducaoMaquina p in lista) {
                listaFinal.Add (ToDTO.LinhaProducaoMaquinaToDTO (p));
            }

            IEnumerable<LinhaProducaoMaquinaDTO> l = listaFinal;

            return l;
        }

    }

}