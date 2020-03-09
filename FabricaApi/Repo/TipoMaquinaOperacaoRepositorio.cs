using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FabricaApi.Models;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace FabricaApi.Repo
{
    public class TipoMaquinaOperacaoRepositorio : IRepositorio<ListaMaquinasOperacao>
    {
    
    private FabricaContext _context;

    public TipoMaquinaOperacaoRepositorio(FabricaContext context) {
            _context = context;
    }

    public IEnumerable<ListaMaquinasOperacao> SelectAll(){

        IEnumerable<ListaMaquinasOperacao> lista = _context.TipoMaquinas_Operacao;
        
        return lista;
        
    }

    public List<Operacao> SelectOperacoesByIdTM(long id){

        List<ListaMaquinasOperacao> operacaoL = _context.TipoMaquinas_Operacao.ToList();
        
        List<Operacao> opList = new List<Operacao>();


            foreach (ListaMaquinasOperacao op in operacaoL)
            {
                if (op.idTipoMaquina == id)
                {
                    opList.Add(_context.Operacoes.Find(op.idOperacao));
                }
            }

            return opList;
        }

    public ListaMaquinasOperacao Insert(ListaMaquinasOperacao tpo){

        _context.TipoMaquinas_Operacao.Add(tpo);
        _context.SaveChanges();

        return tpo;
    }

    public ListaMaquinasOperacao Delete(long id){

        var op = _context.TipoMaquinas_Operacao.Find(id);
            
            _context.TipoMaquinas_Operacao.Remove(op);
            _context.SaveChanges();
        
        return op;
    }

    public void UpdateOperacoesDeTM(long id, List<Operacao> l){
            //Lista com todas os tipos maquina operacao
            List<ListaMaquinasOperacao> maquinaOperacaoLista = _context.TipoMaquinas_Operacao.ToList();
            //Lista que ira conter todos os ids de operacoes recebidos por parametro
            List<long> listaIdsOperacao = new List<long>();
            
            

            //Adiciona a lista vazia todos os ids de operacao recebidos por parametro
            foreach(Operacao operation in l){
                //não inserir duplicados
                if(!(listaIdsOperacao.Contains(operation.Id))){
                    listaIdsOperacao.Add(operation.Id);
                }
            }

            List<long> listaOpTipoMaq = new List<long>();
            foreach (ListaMaquinasOperacao lm in maquinaOperacaoLista) {
                if (lm.idTipoMaquina == id) {
                    listaOpTipoMaq.Add(lm.idOperacao);
                }
            }

            foreach (long idOpInput in listaIdsOperacao) {
                if (!listaOpTipoMaq.Contains(idOpInput)) {
                    // REMOVE FROM DB WITH idOpInput
                    ListaMaquinasOperacao objectLMO = new ListaMaquinasOperacao();
                    objectLMO.idTipoMaquina = id;
                    objectLMO.idOperacao = idOpInput;
                    _context.TipoMaquinas_Operacao.Add(objectLMO);
                }
            }

            foreach (long idOpDb in listaOpTipoMaq) {
                if (!listaIdsOperacao.Contains(idOpDb)) {
                    // ADD TO DB WITH idOpDb
                    ListaMaquinasOperacao toRemove = null;
                    foreach (ListaMaquinasOperacao lm in maquinaOperacaoLista) {
                        if (lm.idTipoMaquina == id && lm.idOperacao == idOpDb) {
                            toRemove = lm;
                        }
                    }
                    // if (toRemove == null) {
                    //     return NotFound();
                    // }
                    _context.TipoMaquinas_Operacao.Remove(toRemove);
                    // await this.Delete(idOpDb);
                }
            }

            // foreach (long lala in toAdd) {
            //     Console.Write(lala + "\n\n");
            // }
            // Console.Write("allaalalalalalalalal\n\n");
            // foreach (long lala in toRemove) {
            //     Console.Write(lala + "\n\n");
            // }


            // foreach(ListaMaquinasOperacao lmo in maquinaOperacaoLista){
            //     //se for idTipoMaquina de lmo igual ao id recebido por parametro 
            //     if(lmo.idTipoMaquina == id){
            //         Console.Write("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB\n\n\n\n");
            //         Console.Write(listaIdsOperacao.Contains(lmo.idOperacao)); 
            //         //se o id existir na lista
            //         if(listaIdsOperacao.Contains(lmo.idOperacao)){
            //         // var itemToRemove = listaIdsOperacao.Single(lmo.idOperacao); && OTIMIZARRRRRR!!!!!!!!!!!!!!
            //             int aux = 0;
            //             foreach(long lon in listaIdsOperacao)
            //             {
            //                 if(lon == lmo.idOperacao){
            //                 listaIdsOperacao.RemoveAt(aux);
            //                 }
            //                 aux++;
            //             }
            //             //remove lmo da bd
            //         }else{
            //             _context.TipoMaquinas_Operacao.Remove(lmo);
            //         }
            //     }
            // }
            // //ids que foram enviados por parametro que ainda não existiam na lista
            // foreach(long opFinal in listaIdsOperacao ){
            //     //Objeto do tipo ListaMaquinasOperacao
            //     ListaMaquinasOperacao objectLMO = new ListaMaquinasOperacao();
            //     objectLMO.idTipoMaquina = id;
            //     objectLMO.idOperacao = opFinal;

            //     _context.TipoMaquinas_Operacao.Add(objectLMO);
            // }
    
            _context.SaveChanges();
        }

        public void Update(ListaMaquinasOperacao obj){
            ////////
        }
 
        public ListaMaquinasOperacao SelectById(long id){
            ////////////
            ListaMaquinasOperacao lmo = new ListaMaquinasOperacao();

            return lmo;
        }

   

    }
}