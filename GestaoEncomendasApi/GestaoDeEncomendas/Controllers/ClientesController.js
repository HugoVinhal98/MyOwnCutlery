const mongoose = require("mongoose");

const Cliente = require("../Models/Cliente");
const Servico = require("../Service/ClienteService.js");


module.exports.getAllClientes = (req, res, next) => {
  console.log("---");
  Servico.obterClientes(res);
};

module.exports.postClienteByEmail = (req, res, next) => {
  Servico.obterClienteMail(req, res);
};
module.exports.login = (req, res, next) => {
  Servico.autenticate(req, res);
};

module.exports.postCliente = (req, res, next) => {
  Servico.criarCliente(req, res);
};

module.exports.putCliente = (req, res, next) => {
  Servico.alterarCliente(req, res);
};

module.exports.putClienteAdmin = (req, res, next) => {
  Servico.alterarClienteAdmin(req, res);
};

module.exports.putClienteByEmail = (req, res, next) => {
  Servico.deleteClienteByEmail(req, res);
};

module.exports.alterarConfiguracao = (req, res, next) => {
  Servico.alterarPermissao(req, res);
};

module.exports.getConfiguracao = (req, res, next) => {
  Servico.getPermissao(req, res);
};

module.exports.alterarConfiguracaoCliente = (req, res, next) => {
  Servico.alterarPermissaoCliente(req, res);
};

module.exports.getConfiguracaoCliente = (req, res, next) => {
  Servico.getPermissaoCliente(req, res);
};