var Produto = require("../ValueObjects/Produto");
var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var ProdutoEncomendadoSchema = new Schema({
    quantidade: Number,
    nrEncomendas: Number,
    produto: Produto
});

module.exports = mongoose.model('ProdutoEncomendado', ProdutoEncomendadoSchema);