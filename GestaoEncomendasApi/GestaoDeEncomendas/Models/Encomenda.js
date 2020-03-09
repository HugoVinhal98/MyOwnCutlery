var Estado = require("../ValueObjects/Estado");
//var Cliente = require("../Models/Cliente");
var Produto = require("../ValueObjects/Produto");
var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var EncomendaSchema = new Schema({
    nrEncomenda: Number,
    dataEnvio: Date,
    dataEntrega: Date,
    estado: Estado,
    clienteEmail: String,
    quantidade: Number,
    produto: Produto,
    cancelamentoCliente: String,
    solicitacaoCliente: String
});

module.exports = mongoose.model('Encomenda', EncomendaSchema);



//criar encomenda -> produto, quantidade, (user n escolhe estado nem datas), datas a null, estado = por enviar
//Possivelmente 2 tipos de alterar
//alterarADM -> datas (validações: dataEnvio < DataEntrega)
//alterarUser -> produto e/ou quantidades(n faz mto sentido, cancelar e criar nova)
//cancelar -> ver encomendas que user tem, escolher e passar estado = cancelada e retira da lista do user   