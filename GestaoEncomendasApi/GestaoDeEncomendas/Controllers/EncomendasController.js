const mongoose = require("mongoose");

const Cliente = require("../Models/Encomenda");
const Servico = require("../Service/EncomendaService.js");


module.exports.getAllEncomendas = (req, res, next) => {
  Servico.getAllEncomendas(req, res, next);
};

module.exports.getQuantidadeEncomendas = (req, res, next) => {
  Servico.getQuantidadeEncomendas(req, res, next);
};

module.exports.getEncomendaByID = (req, res, next) => {
  Servico.getEncomendaByID(req, res, next);
};

module.exports.postEncomenda = (req, res, next) => {
  Servico.postEncomenda(req, res, next);
};

module.exports.cancelarEncomenda = (req, res, next) => {
  Servico.cancelarEncomenda(req, res, next);
};

module.exports.alterarEncomenda = (req, res, next) => {
  Servico.alterarEncomenda(req, res);
};

module.exports.getAllEncomendasUser = (req, res, next) => {
  Servico.getAllEncomendasUser(req, res);
};

module.exports.solicitarCancelamentoEncomenda = (req, res, next) => {
  Servico.solicitarCancelamentoEncomenda(req, res);
};

module.exports.solicitarAlteracoesEncomenda = (req, res, next) => {
  Servico.solicitarAlteracoesEncomenda(req, res);
};